using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Divar.Core.Entities;

namespace Divar.Core
{
    public interface IDataServiceRepository<T> :IDisposable where T : class
    {   
        bool Insert(FormCollection collection);
        Task<bool> InsertAsync(FormCollection collection);
        void EntInsert(T data);
        Task EntInsertAsync(T data);
        bool Update(FormCollection collection);
        Task<bool> UpdateAsync(FormCollection collection);
        void EntUpdate(T data);
        Task EntUpdateAsync(T data);
        bool Delete(T data);
        Task<bool> DeleteAsync(T data);
        T GetObj(Expression<Func<T, bool>> predicate);
        Task<T> GetObjAsync(Expression<Func<T, bool>> predicate);
        List<T> GetAllObj();
        Task<List<T>> GetAllObjAsync();
        IQueryable<T> Query(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetPagedBy<TKey>(Expression<Func<T, bool>> predicate, int pageSize, int pageNumber, Expression<Func<T, TKey>> orderBy, bool isDesc);
        IQueryable<T> GetPaged<TKey>(int pageSize, int pageNumber, Expression<Func<T, TKey>> orderBy, bool isDesc);
	    DivarEntities GetContext();
        bool Commit();
        Task<bool> CommitAsync();
        Task<T> FindObjectAsync(params object[] data);
        T FindObject(params object[] data);

		//void GetDataRowCount(GridViewCustomBindingGetDataRowCountArgs e);
		//void GetData(GridViewCustomBindingGetDataArgs e);



	    void Update(T obj);


    }
}
