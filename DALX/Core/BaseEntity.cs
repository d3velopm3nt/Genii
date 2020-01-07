using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALX.Core.Sql;
using DALX.Mapping;
using DALX.Core.Sql.Filters;
using System.Data;
using DALC4NET;
using DALX.Attributes;
using DALX.Core.Sql.Sorters;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DALX.Core
{
    public class BaseEntity<T> : IEntity<T> where T : class, new()
    {
        #region Properties
        [DataMapping(true)] public string Status { get; set; }
        [DataMapping(true)] public object ID { get; set; }
        //public DateTime CreatedDateTime { get; set; }
        //public DateTime ModifiedDateTime { get; set; }
        public DBHelper DbHelper { get; set; }
        public string LinkedServer { get; set; }
        public string EntityTableName { get; set; }
        #endregion

        #region Constructor

        public BaseEntity()
        {
            this.EntityTableName = this.GetType().Name;

            // this.DbHelper = new DBHelper();

        }

        public BaseEntity(DBHelper dBHelper = null)
        {
            if (dBHelper != null)
            {
                this.DbHelper = dBHelper;
                DBQueryManager.DBHelper = this.DbHelper;
                QueryBuilder.LinkedServer = this.DbHelper.LinkedServer;
            }
            this.EntityTableName = this.GetType().Name;

        }

        public BaseEntity(object id, DBHelper dBHelper = null)
        {
            this.ID = id;
            if (dBHelper != null)
            {
                this.DbHelper = dBHelper;
                DBQueryManager.DBHelper = this.DbHelper;
                QueryBuilder.LinkedServer = this.DbHelper.LinkedServer;
            }
            this.EntityTableName = this.GetType().Name;

            if (ID != null)
                GetEntity();
        }


        #endregion


        #region CRUD Methods

        /// <summary>
        /// This Method will save a new record in the datbase of line of text in the a text file.
        /// </summary>
        /// <returns></returns>
        public virtual bool Create()
        {
            try
            {
                //this.CreatedDateTime = DateTime.Now;
                //this.ModifiedDateTime = DateTime.Now;
                //this.Status = EntityState.Active.ToString();

                return DBQueryManager.Create(this, this.EntityTableName);
            }
            catch (Exception ex)
            {
               
                throw new Exception(ex.Message);

            }
        }

        #region Read

        public virtual List<T> Read(int SelectTop = 0)
        {
            try
            {

                return DBQueryManager.Read<T>(EntityTableName, null, null, SelectTop);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// This Method will return a list of entities based on the parameters.
        /// </summary>
        /// <param name="filterCollection"></param>
        /// <param name="sorters"></param>
        /// <param name="SelectTop"></param>
        /// <returns></returns>
        public virtual List<T> Read(List<QueryFilter> filters, SorterCollection sorters, int SelectTop = 0)
        {
            try
            {
                return DBQueryManager.Read<T>(EntityTableName, filters, sorters, SelectTop);
            }
            catch (Exception ex)
            {
              
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Multiple QueryFilters and Select Top Optional
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="SelectTop"></param>
        /// <returns></returns>
        public virtual List<T> Read(List<QueryFilter> filters, int SelectTop = 0)
        {
            try
            {
                return DBQueryManager.Read<T>(EntityTableName, filters, null, SelectTop);
            }
            catch (Exception ex)
            {
               
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Read Table with only one sorter and multiple filters
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="sorter"></param>
        /// <param name="SelectTop"></param>
        /// <returns></returns>
        public virtual List<T> Read(List<QueryFilter> filters, QuerySorter sorter, int SelectTop = 0)
        {
            try
            {
                var sorters = new SorterCollection();
                sorters.Add(sorter);

                return DBQueryManager.Read<T>(EntityTableName, filters, sorters, SelectTop);
            }
            catch (Exception ex)
            {
         
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Read Table with one filter and one sorter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="sorter"></param>
        /// <param name="SelectTop"></param>
        /// <returns></returns>
        public virtual List<T> Read(QueryFilter filter, QuerySorter sorter, int SelectTop = 0)
        {
            try
            {
                var sorters = new SorterCollection();
                sorters.Add(sorter);

                var filters = new List<QueryFilter>();
                filters.Add(filter);

                return DBQueryManager.Read<T>(EntityTableName, filters, sorters, SelectTop);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// One QuerySorter and optional Select Top
        /// </summary>
        /// <param name="sorter"></param>
        /// <param name="SelectTop"></param>
        /// <returns></returns>
        public virtual List<T> Read(QuerySorter sorter, int SelectTop = 0)
        {
            try
            {
                var sorters = new SorterCollection();
                sorters.Add(sorter);

                return DBQueryManager.Read<T>(EntityTableName, null, sorters, SelectTop);
            }
            catch (Exception ex)
            {
  
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// One QueryFilter and optional Select Top
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="SelectTop"></param>
        /// <returns></returns>
        public virtual List<T> Read(QueryFilter filter, int SelectTop = 0)
        {
            try
            {
                var filters = new List<QueryFilter>();
                filters.Add(filter);
                return DBQueryManager.Read<T>(EntityTableName, filters, null, SelectTop);
            }
            catch (Exception ex)
            {
             
                throw new Exception(ex.Message);
            }
        }
        #endregion

        public virtual void GetEntity()
        {
            if (!DBQueryManager.GetEntity(this, ID))
                this.ID = null;
        }
        /// <summary>
        /// This method will update the entity with the new changes
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public bool Update(DBParameterCollection parameters = null, QueryFilterCollection filters = null)
        {
            try
            {
                if (parameters == null)
                    parameters = ParameterMapper<T>.Map(this);
                if (filters == null)
                    filters = FilterHelper.AddIdEqualsFilter(this.ID);
                return DBQueryManager.Update<T>(this.EntityTableName, parameters, filters.FilterList);
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }

        public bool Update(string column, string value)
        {
            return DBQueryManager.Update(EntityTableName, column, value, (int)this.ID);
        }

        public bool Delete()
        {
            try
            {
                var collection = FilterHelper.AddIdAndStatusFilters(this.ID, this.Status);
                return DBQueryManager.Delete(this, this.EntityTableName, collection);
            }
            catch (Exception ex)
            {
             
                return false;
                //throw new Exception(ex.Message);
            }
        }

        public bool DeleteAll()
        {
            return DBQueryManager.Delete(this, this.EntityTableName, null);
        }

        public List<T> RawSelect(string query)
        {
            return DBQueryManager.SelectQuery<T>(query);
        }

        public int Count()
        {
            return DBQueryManager.Count(EntityTableName);
        }

        public List<T> Distinct(string identifier)
        {
            return DBQueryManager.Distinct<T>(EntityTableName, identifier);
        }

        public bool Exist(string column, string value)
        {
            bool check = false;
            var ID = DBQueryManager.CheckIfExist(column, value, EntityTableName);
            if (ID > 0)
            {
                this.ID = ID;
                check = true;
            }
            return check;

        }

        #endregion

        #region CRUD Methods ASYNC

        /// <summary>
        /// This Method will save a new record in the datbase of line of text in the a text file.
        /// </summary>
        /// <returns></returns>
        public virtual bool CreateAsync()
        {
            try
            {
                //this.CreatedDateTime = DateTime.Now;
                //this.ModifiedDateTime = DateTime.Now;
                //this.Status = EntityState.Active.ToString();

                return DBQueryManager.Create(this, this.EntityTableName);
            }
            catch (Exception ex)
            {
              
                throw new Exception(ex.Message);

            }
        }

        #region Read

        public async Task<List<T>> ReadAsync(int SelectTop = 0)
        {
            try
            {
                List<T> list = null;
                await Task.Run(() =>
                 {
                     list = DBQueryManager.Read<T>(EntityTableName, null, null, SelectTop);
                 });
                return list;
            }
            catch (Exception ex)
            {
                
                return null;
                //throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This Method will return a list of entities based on the parameters.
        /// </summary>
        /// <param name="filterCollection"></param>
        /// <param name="sorters"></param>
        /// <param name="SelectTop"></param>
        /// <returns></returns>
        public async Task<List<T>> ReadAsync(List<QueryFilter> filters, SorterCollection sorters, int SelectTop = 0)
        {
            try
            {
                List<T> list = null;
                await Task.Run(() =>
                {
                    list = DBQueryManager.Read<T>(EntityTableName, filters, sorters, SelectTop);
                });
                return list;
            }
            catch (Exception ex)
            {
             
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Multiple QueryFilters and Select Top Optional
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="SelectTop"></param>
        /// <returns></returns>
        public async Task<List<T>> ReadAsync(List<QueryFilter> filters, int SelectTop = 0)
        {
            try
            {
                List<T> list = null;
                await Task.Run(() =>
                {
                    list = DBQueryManager.Read<T>(EntityTableName, filters, null, SelectTop);
                });
                return list;
            }
            catch (Exception ex)
            {
            
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Read Table with only one sorter and multiple filters
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="sorter"></param>
        /// <param name="SelectTop"></param>
        /// <returns></returns>
        public async Task<List<T>> ReadAsync(List<QueryFilter> filters, QuerySorter sorter, int SelectTop = 0)
        {
            try
            {
                List<T> list = null;
                await Task.Run(() =>
                {
                    var sorters = new SorterCollection();
                    sorters.Add(sorter);

                    list = DBQueryManager.Read<T>(EntityTableName, filters, sorters, SelectTop);
                });
                return list;
            }
            catch (Exception ex)
            {
              
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Read Table with one filter and one sorter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="sorter"></param>
        /// <param name="SelectTop"></param>
        /// <returns></returns>
        public async Task<List<T>> ReadAsync(QueryFilter filter, QuerySorter sorter, int SelectTop = 0)
        {
            try
            {
                List<T> list = null;
                await Task.Run(() =>
                {
                    var sorters = new SorterCollection();
                    sorters.Add(sorter);

                    var filters = new List<QueryFilter>();
                    filters.Add(filter);

                    list = DBQueryManager.Read<T>(EntityTableName, filters, sorters, SelectTop);
                });
                return list;
            }
            catch (Exception ex)
            {
               
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// One QuerySorter and optional Select Top
        /// </summary>
        /// <param name="sorter"></param>
        /// <param name="SelectTop"></param>
        /// <returns></returns>
        public async Task<List<T>> ReadAsync(QuerySorter sorter, int SelectTop = 0)
        {
            try
            {
                List<T> list = null;
                await Task.Run(() =>
                {
                    var sorters = new SorterCollection();
                    sorters.Add(sorter);

                    list = DBQueryManager.Read<T>(EntityTableName, null, sorters, SelectTop);
                });
                return list;
            }
            catch (Exception ex)
            {
               
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// One QueryFilter and optional Select Top
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="SelectTop"></param>
        /// <returns></returns>
        public async Task<List<T>> ReadAsync(QueryFilter filter, int SelectTop = 0)
        {
            try
            {
                List<T> list = null;
                await Task.Run(() =>
                {
                    var filters = new List<QueryFilter>();
                    filters.Add(filter);
                    list = DBQueryManager.Read<T>(EntityTableName, filters, null, SelectTop);
                });
                return list;
            }
            catch (Exception ex)
            {
              
                throw new Exception(ex.Message);
            }
        }
        #endregion



        public async void GetEntityAsync()
        {
            await Task.Run(() =>
            {
                if (!DBQueryManager.GetEntity(this, ID))
                    this.ID = null;
            });
        }
        /// <summary>
        /// This method will update the entity with the new changes
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(DBParameterCollection parameters = null, QueryFilterCollection filters = null)
        {
            try
            {
                await Task.Run(() =>
                {
                    if (parameters == null)
                        parameters = ParameterMapper<T>.Map(this);
                    if (filters == null)
                        filters = FilterHelper.AddIdEqualsFilter(this.ID);
                    return DBQueryManager.Update<T>(this.EntityTableName, parameters, filters.FilterList);
                });
                return false; ;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    var collection = FilterHelper.AddIdAndStatusFilters(this.ID, this.Status);
                    return DBQueryManager.Delete(this, this.EntityTableName, collection);
                });
                return false;
            }
            catch (Exception ex)
            {
               
                return false;
                //throw new Exception(ex.Message);
            }
        }

        public async Task<List<T>> RawSelectAsync(string query)
        {
            await Task.Run(() =>
            {
                return DBQueryManager.SelectQuery<T>(query);
            });
            return null;
        }

        #endregion

        #region Private Methods


        #endregion
    }
}
