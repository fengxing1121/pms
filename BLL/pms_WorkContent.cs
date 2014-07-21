using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// 业务逻辑类pms_WorkContent 的摘要说明。
	/// </summary>
	public class pms_WorkContent
	{
		private readonly TSM.DAL.pms_WorkContent dal=new TSM.DAL.pms_WorkContent();
		public pms_WorkContent()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int WorkContentID)
		{
			return dal.Exists(WorkContentID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TSM.Model.pms_WorkContent model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TSM.Model.pms_WorkContent model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int WorkContentID)
		{
			
			dal.Delete(WorkContentID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_WorkContent GetModel(int WorkContentID)
		{
			
			return dal.GetModel(WorkContentID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public TSM.Model.pms_WorkContent GetModelByCache(int WorkContentID)
		{
			
			string CacheKey = "pms_WorkContentModel-" + WorkContentID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(WorkContentID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.pms_WorkContent)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.pms_WorkContent> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.pms_WorkContent> DataTableToList(DataTable dt)
		{
			List<TSM.Model.pms_WorkContent> modelList = new List<TSM.Model.pms_WorkContent>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.pms_WorkContent model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.pms_WorkContent();
					if(dt.Rows[n]["WorkContentID"].ToString()!="")
					{
						model.WorkContentID=int.Parse(dt.Rows[n]["WorkContentID"].ToString());
					}
					model.WorkContent=dt.Rows[n]["WorkContent"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

