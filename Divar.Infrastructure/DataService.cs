using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using Divar.Core;
using Divar.Core.Entities;
using Divar.Infrastructure.Services;

namespace Divar.Infrastructure
{
    public class DataService<T> : IDataServiceRepository<T> where T : class, new()
    {
        #region variables
        private T _obj;
        private readonly DivarEntities _context;
        #endregion

        #region constructors
        public DataService(T data, DivarEntities context)
        {
            _obj = data;
            _context = context;
        }
        public DataService(DivarEntities context)
        {
            _obj = new T();
            _context = context;
        }

        public DataService()
        {
            _obj = new T();
            _context = new DivarEntities();
        }
        #endregion
        public bool Insert(FormCollection collection)
        {
            try
            {
                SetObjProperties(collection);
                _context.Set<T>().Add(_obj);
                return _context.SaveChanges() > 0;
            }
            catch (GeneralException e)
            {
                e.InsertException();
                return false;
            }
        }

        public async Task<bool> InsertAsync(FormCollection collection)
        {
            try
            {
                SetObjProperties(collection);
                _context.Set<T>().Add(_obj);
                return await _context.SaveChangesAsync() > 0;
            
            }
            catch (GeneralException e)
            {
                e.InsertException();
                return false;
            }
        }

        public void EntInsert(T data)
        {
            _context.Set<T>().Add(data);
        }

        public async Task EntInsertAsync(T data)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Add(data);
            });
        }
		/// <summary>
		/// Amin Update
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public void Update(T obj)
	    {
			try
			{
				if (obj == null)
				{
					throw new ArgumentNullException("obj");
				}
				this._context.SaveChanges();
			}
			catch (DbEntityValidationException dbEx)
			{
				string errorMessage = String.Empty;
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
					}
				}

				throw new Exception(errorMessage, dbEx);
			}
		}
		public bool Update(FormCollection collection)
        {
            try
            {
				ModifyObjectProperties(collection);
				_context.Entry(_obj).State = EntityState.Modified;
				return  _context.SaveChanges() > 0;
            }
            catch (GeneralException e)
            {
                e.InsertException();
                return false;
            }
        }
        public async Task<bool> UpdateAsync(FormCollection collection)
        {
            try
            {
                ModifyObjectProperties(collection);
                _context.Entry(_obj).State = EntityState.Modified;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (GeneralException e)
            {
                e.InsertException();
                return false;
            }
        }

        public void EntUpdate(T data)
        {
            _context.Entry(data).State = EntityState.Modified;
        }
        public async Task EntUpdateAsync(T data)
        {
            await Task.Run(() =>
            {
                _context.Entry(data).State = EntityState.Modified;
            });
        }
        public bool Delete(T data)
        {
            try
            {
                _context.Set<T>().Remove(data);
                return _context.SaveChanges() > 0;
            }
            catch (GeneralException e)
            {
                e.InsertException();
                return false;
            }
        }
        public async Task<bool> DeleteAsync(T data)
        {
            try
            {
                _context.Set<T>().Remove(data);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (GeneralException e)
            {
                e.InsertException();
                return false;
            }
        }

        public T GetObj(Expression<Func<T, bool>> predicate)
        {
            try
            {
               return _context.Set<T>().FirstOrDefault(predicate);
            }
            catch (GeneralException e)
            {
                e.InsertException();
                return null;
            }
        }

        public async Task<T> GetObjAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().FirstOrDefaultAsync(predicate);

            }
            catch (GeneralException e)
            {
                e.InsertException();
                return null;
            }
        }

        public List<T> GetAllObj()
        {
            try
            {
                return _context.Set<T>().Where(n => true)
                    .ToList();
            }
            catch (GeneralException e)
            {
                e.InsertException();
                return null;
            }
        }
        public async Task<List<T>> GetAllObjAsync()
        {
            try
            {
                return await _context.Set<T>().Where(n => true)
                    .ToListAsync();
            }
            catch (GeneralException e)
            {
                e.InsertException();
                return null;
            }
        }
        public T GetLocalObj()
        {
            return _obj;
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetPagedBy<TKey>(Expression<Func<T, bool>> predicate, int pageSize, int pageNumber, Expression<Func<T, TKey>> orderBy, bool isDesc)
        {

            if (isDesc)
                return
                    _context.Set<T>()
                        .Where(predicate)
                        .OrderByDescending(orderBy)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);
            else
                return
                    _context.Set<T>()
                        .Where(predicate)
                        .OrderBy(orderBy)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);
        }
        public IQueryable<T> GetPaged<TKey>(int pageSize, int pageNumber, Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return
                    _context.Set<T>()
                        .OrderByDescending(orderBy)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);
            else
                return
                _context.Set<T>()
                    .OrderBy(orderBy)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);
        }

        public DivarEntities GetContext()
        {
            return _context;
        }


        /// <summary>
        /// setting properties of the objects from FormCollection collection
        /// </summary>
        /// <param name="collection">the collection</param>
        private void SetObjProperties(FormCollection collection)
        {
            try
            {
                //here we fetch the properties of the class
                var objProperties = _obj.GetType().GetProperties();

                //iterating through properties to set them
                foreach (var i in objProperties)
                {
                    //checking for null or writable ability of the property
                    if (i != null && i.CanWrite)
                    {
                        //check if we have set this property in UI
                        if (collection[i.Name] != null)
                        {
                            //if the UI sent the property empty we put null
                            if (collection[i.Name] == "")
                            {
                                i.SetValue(_obj, null);
                            }
                            //in this if,we check for icollection members and fill them
                            else if (i.PropertyType.IsInterface && i.PropertyType.Name.Contains("Collection"))
                            {
                                //we get the ids of the related entities
                                var values = collection[i.Name].Split(',');

                                //this is the subtype of the icollection member
                                var subObjTotal = Activator.CreateInstance(i.PropertyType.GenericTypeArguments[0]);

                                //here we make a dynamic list of the related entity to insert them here
                                Type classContainerType = subObjTotal.GetType();
                                Type listType = typeof(List<>).MakeGenericType(new[] { classContainerType });
                                IList classContainer = (IList)Activator.CreateInstance(listType);

                                //we loop through all the members of the related entity
                                foreach (var j in values)
                                {
                                    //make a new instance of the related object
                                    var subObj = Activator.CreateInstance(i.PropertyType.GenericTypeArguments[0]);

                                    //this is the first member of the subTable(the id)
                                    var subObjFirstProperty = subObj.GetType().GetProperties().FirstOrDefault();

                                    //checking if the id type is GUID set it here
                                    if (subObjFirstProperty.PropertyType.Name == "Guid")
                                    {
                                        var convertedValue = new Guid(j);
                                        subObjFirstProperty.SetValue(subObj, convertedValue);
                                    }
                                    //other id types other than GUID
                                    else
                                    {
                                        var convertedValue = Convert.ChangeType(j, subObjFirstProperty.PropertyType);
                                        subObjFirstProperty.SetValue(subObj, convertedValue);
                                    }

                                    //attaching the object to Entity Framework Context
                                    _context.Set(subObj.GetType()).Attach(subObj);

                                    //adding the object to dynamically created list
                                    i.PropertyType.GetMethod("Add").Invoke(classContainer, new Object[] { subObj });

                                }
                                //we setting the list to the _obj
                                i.SetValue(_obj, classContainer);
                            }
                            //we should check for classes and make a new instance
                            //but we dont need that because we just set the foreign key property
                            else if (i.PropertyType.IsClass && i.PropertyType.Name.ToLower() != "string")
                            {
                                var convertedValue = Convert.ChangeType(collection[i.Name], i.PropertyType);
                                i.SetValue(_obj, convertedValue);
                            }
                            //check for GUID type as we cannot convert to that type dynamically
                            else if (i.PropertyType.Name == "Guid")
                            {
                                var convertedValue = new Guid(collection[i.Name]);
                                i.SetValue(_obj, convertedValue);
                            }
                            //none of the above our last try to map the property
                            else
                            {
                                var convertedValue = ChangeNullableType(collection[i.Name], i.PropertyType);
                                i.SetValue(_obj, convertedValue);
                            }
                        }


                    }
                }
            }
            catch (GeneralException e)
            {
                //logging the error into database
                e.InsertException();
            }
        }


        /// <summary>
        /// first we clear all the related collection objects,then we set the new properties to entity
        /// </summary>
        /// <param name="collection">the collection</param>
        private void ModifyObjectProperties(FormCollection collection)
        {
            try
            {
				PropertyInfo primaryKey;
				if (_obj.GetType().BaseType.Name.ToLower() != "object")
				{
					//we find the primary key property
					primaryKey =
						_obj.GetType().GetProperties().First(m => m.Name == _obj.GetType().BaseType.Name + "Id");
				}
				else
				{
					primaryKey = _obj.GetType().GetProperties().First(m => m.Name == _obj.GetType().Name + "Id");
				}

				//here we fetch the entity from database
				if (primaryKey.PropertyType.Name == "Guid")
				{
					var convertedValue = new Guid(collection[primaryKey.Name]);
					_obj = FindObject(convertedValue);
				}
				else
				{
					var convertedValue = Convert.ToInt64(collection[primaryKey.Name]);
					_obj = FindObject(convertedValue);
				}


				//here we fetch the properties of the class
				var objProperties = _obj.GetType().GetProperties();


                //iterating through properties to find collection items
                foreach (var i in objProperties)
                {

                    //we check for collection type
                    if (i.PropertyType.IsInterface && i.PropertyType.Name.Contains("Collection"))
                    {

                        //this is the subtype of the icollection member
                        var subObjTotal = Activator.CreateInstance(i.PropertyType.GenericTypeArguments[0]);

                        //making IList class container for collection
                        Type classContainerType = subObjTotal.GetType();
                        Type listType = typeof(List<>).MakeGenericType(new[] { classContainerType });
                        IList classContainer = (IList)Activator.CreateInstance(listType);

                        //we load the collection entities
                        _context.Entry(_obj).Collection(i.Name);

                        //we get the collection values from _obj
                        classContainer = (IList)_obj.GetType().GetProperty(i.Name).GetValue(_obj);
                        //clearing the collection
                        _obj.GetType()
                            .GetProperty(i.Name)
                            .PropertyType.GetMethod("Clear")
                            .Invoke(classContainer, new Object[] { });
                    }
                }
                //updating the entity to clear the entity relations
                _context.Entry(_obj).State = EntityState.Modified;
                //saving changes
                _context.SaveChanges();

                _context.Set<T>().Attach(_obj);
                //now we are assigning new values from FormCollection collection object
                foreach (var i in objProperties)
                {
                    //checking for null or writable ability of the property
                    if (i != null && i.CanWrite)
                    {
                        //check if we set this property in UI
                        if (collection[i.Name] != null)
                        {
                            //if the UI sent the property empty we put null
                            if (collection[i.Name] == "")
                            {
                                i.SetValue(_obj, null);
                            }
                            //in this if,we check for icollection members and fill them
                            else if (i.PropertyType.IsInterface && i.PropertyType.Name.Contains("Collection"))
                            {
                                //we get the ids of the related entities
                                var values = collection[i.Name].Split(',');

                                //this is the subtype of the icollection member
                                var subObjTotal = Activator.CreateInstance(i.PropertyType.GenericTypeArguments[0]);

                                //here we make a dynamic list of the related entity to insert them here
                                Type classContainerType = subObjTotal.GetType();
                                Type listType = typeof(List<>).MakeGenericType(new[] { classContainerType });
                                IList classContainer = (IList)Activator.CreateInstance(listType);

                                //we loop through all the members of the related entity
                                foreach (var j in values)
                                {
                                    //make a new instance of the related object
                                    var subObj = Activator.CreateInstance(i.PropertyType.GenericTypeArguments[0]);

                                    //this is the first member of the subTable(the id)
                                    var subObjFirstProperty = subObj.GetType().GetProperties().FirstOrDefault();

                                    //checking if the id type is GUID set it here
                                    if (subObjFirstProperty.PropertyType.Name == "Guid")
                                    {
                                        var convertedValue = new Guid(j);
                                        subObj =
                                            _context.Set(i.PropertyType.GenericTypeArguments[0]).Find(convertedValue);

                                    }
                                    //other id types other than GUID
                                    else
                                    {
                                        var convertedValue = Convert.ChangeType(j,
                                            subObjFirstProperty.PropertyType);

                                        subObj =
                                            _context.Set(i.PropertyType.GenericTypeArguments[0]).Find(convertedValue);
                                    }

                                    //attaching the object to Entity Framework Context
                                    _context.Set(subObj.GetType()).Attach(subObj);

                                    //adding the object to dynamically created list
                                    i.PropertyType.GetMethod("Add").Invoke(classContainer, new Object[] { subObj });

                                }
                                //we setting the list to the _obj
                                i.SetValue(_obj, classContainer);
                            }
                            //we should check for classes and make a new instance
                            //but we dont need that because we just set the foreign key property
                            else if (i.PropertyType.IsClass && i.PropertyType.Name.ToLower() != "string")
                            {
                                var convertedValue = Convert.ChangeType(collection[i.Name], i.PropertyType);
                                i.SetValue(_obj, convertedValue);
                            }
                            //check for GUID type as we cannot convert to that type dynamically
                            else if (i.PropertyType.Name == "Guid")
                            {
                                var convertedValue = new Guid(collection[i.Name]);
                                i.SetValue(_obj, convertedValue);
                            }
                            //none of the above our last try to map the property
                            else
                            {
                                try
                                {
                                    var convertedValue = Convert.ChangeType(collection[i.Name], i.PropertyType);
                                    i.SetValue(_obj, convertedValue);
                                }
                                catch
                                {
                                    var convertedValue = ChangeNullableType(collection[i.Name], i.PropertyType);
                                    i.SetValue(_obj, convertedValue);
                                }
                            }
                        }


                    }
                }
            }
            catch (GeneralException e)
            {
                e.InsertException();
            }
        }

        private object ChangeNullableType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void MapViewModelToModel<TSource, TDestination>(TSource viewModel, TDestination model, Dictionary<string, Dictionary<string, string>> propertyNames = null)
        {
            //should code much here
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<T> FindObjectAsync(params object[] data)
        {
            return await _context.Set<T>().FindAsync(data);
        }
        public T FindObject(params object[] data)
        {
            return _context.Set<T>().Find(data);
        }

        //public void GetDataRowCount(GridViewCustomBindingGetDataRowCountArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //public void GetData(GridViewCustomBindingGetDataArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
