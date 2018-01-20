using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Divar.Web.Areas.Admin.Models
{
	//DataContract for Serializing Data - required to serve in JSON format
	[DataContract]
	public class DataPoint
	{
		public DataPoint(double y, string label)
		{
			this.Y = y;
			this.Label = label;
			this.LegendText = label;
		}

		//Explicitly setting the name to be used while serializing to JSON. 
		[DataMember(Name = "label")]
		public string Label = null;

		[DataMember(Name = "legendText")]
		public string LegendText = null;

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public Nullable<double> Y = null;

	}
}