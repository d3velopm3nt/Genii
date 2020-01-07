using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALX.Core.Sql
{
   public class SqlDbConnection
    {
        private string _connectionString;
        public SqlDbConnection()
        {

            if (CoreHelper.ConnectionString == null || CoreHelper.ConnectionString == "")
                _connectionString = AppConfig.DefaultConnectionString;
            else
                _connectionString = CoreHelper.ConnectionString;
        }

        #region Async Methods

        public async Task<bool> ExecuteQueryAsync(string query)
        {
            var tries = 3;
            while (true)
            {
                try
                {
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        try
                        {
                            using (var sqlCommand = new SqlCommand(query, sqlConnection))
                            {
                                await sqlConnection.OpenAsync();
                                return (await sqlCommand.ExecuteNonQueryAsync()) > 0;
                            }
                        }
                        finally
                        {
                            sqlConnection?.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception at query: " + query);
                    if (tries-- <= 0)
                    {
                        throw;
                    }
                }
            }
        }

        public async Task<object> ExecuteScalarAsync(string query)
        {
            var tries = 3;
            while (true)
            {
                try
                {
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        try
                        {
                            using (var sqlCommand = new SqlCommand(query, sqlConnection))
                            {
                                await sqlConnection.OpenAsync();
                                return await sqlCommand.ExecuteScalarAsync();
                            }
                        }
                        finally
                        {
                            sqlConnection?.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception at query: " + query);
                    if (tries-- <= 0)
                    {
                        throw;
                    }
                }
            }
        }

        public async Task<T> ExecuteScalarTypeAsync<T>(string query)
        {
            while (true)
            {
                var tries = 3;
                try
                {
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        try
                        {
                            using (var sqlCommand = new SqlCommand(query, sqlConnection))
                            {
                                await sqlConnection.OpenAsync();
                                return (T)(await sqlCommand.ExecuteScalarAsync());
                            }
                        }
                        finally
                        {
                            sqlConnection?.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception at query: " + query);
                    if (tries-- <= 0)
                    {
                        throw;
                    }
                }
            }
        }

        public async Task<DataTable> GetDataTableAsync(string query)
        {
            var tries = 3;
            var source = new TaskCompletionSource<DataTable>();
            var table = new DataTable();
            while (true)
            {
                try
                {
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        try
                        {
                            await sqlConnection.OpenAsync();
                            using (var sqlCommand = new SqlCommand(query, sqlConnection))
                            {
                                //sqlConnection.Open();
                                using (var dataReader = await sqlCommand.ExecuteReaderAsync())
                                {
                                    try
                                    {
                                        table.Load(dataReader);
                                        source.SetResult(table);
                                    }
                                    finally
                                    {
                                        dataReader?.Close();
                                    }
                                }
                            }
                        }
                        finally
                        {
                            sqlConnection?.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception at query: " + query);
                    if (tries-- <= 0)
                    {
                        throw;
                    }
                }
                return table;
            }
        }

        public async Task<DataView> GetDataViewAsync(string query)
        {
            var tries = 3;
            var source = new TaskCompletionSource<DataTable>();
            var table = new DataTable();
            while (true)
            {
                try
                {
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        try
                        {
                            using (var sqlCommand = new SqlCommand(query, sqlConnection))
                            {
                                await sqlConnection.OpenAsync();
                                using (var dataReader = await sqlCommand.ExecuteReaderAsync())
                                {
                                    try
                                    {
                                        table.Load(dataReader);
                                        source.SetResult(table);
                                    }
                                    finally
                                    {
                                        dataReader?.Close();
                                    }
                                }
                            }
                        }
                        finally
                        {
                            sqlConnection?.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception at query: " + query);
                    if (tries-- <= 0)
                    {
                        throw;
                    }
                }
                return new DataView(table);
            }
        }

        #endregion

        #region Sync Methods
        public bool ExecuteQuery(string query)
        {
            var tries = 3;
            while (true)
            {
                try
                {
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        try
                        {
                            using (var sqlCommand = new SqlCommand(query, sqlConnection))
                            {
                                sqlConnection.Open();
                                return (sqlCommand.ExecuteNonQuery()) > 0;
                            }
                        }
                        finally
                        {
                            sqlConnection?.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception at query: " + query);
                    if (tries-- <= 0)
                    {
                        throw;
                    }
                }
            }
        }

        public object ExecuteScalar(string query)
        {
            var tries = 3;
            while (true)
            {
                try
                {
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        try
                        {
                            using (var sqlCommand = new SqlCommand(query, sqlConnection))
                            {
                                 sqlConnection.Open();
                                return  sqlCommand.ExecuteScalar();
                            }
                        }
                        finally
                        {
                            sqlConnection?.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception at query: " + query);
                    if (tries-- <= 0)
                    {
                        throw;
                    }
                }
            }
        }

        public T ExecuteScalarType<T>(string query)
        {
            while (true)
            {
                var tries = 3;
                try
                {
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        try
                        {
                            using (var sqlCommand = new SqlCommand(query, sqlConnection))
                            {
                                sqlConnection.Open();
                                return (T)( sqlCommand.ExecuteScalar());
                            }
                        }
                        finally
                        {
                            sqlConnection?.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception at query: " + query);
                    if (tries-- <= 0)
                    {
                        throw;
                    }
                }
            }
        }

        public  DataTable GetDataTable(string query)
        {
            var tries = 3;
            var source = new TaskCompletionSource<DataTable>();
            var table = new DataTable();
            while (true)
            {
                try
                {
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        try
                        {
                             sqlConnection.Open();
                            using (var sqlCommand = new SqlCommand(query, sqlConnection))
                            {
                                //sqlConnection.Open();
                                using (var dataReader = sqlCommand.ExecuteReader())
                                {
                                    try
                                    {
                                        table.Load(dataReader);
                                        source.SetResult(table);
                                    }
                                    finally
                                    {
                                        dataReader?.Close();
                                    }
                                }
                            }
                        }
                        finally
                        {
                            sqlConnection?.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception at query: " + query);
                    if (tries-- <= 0)
                    {
                        throw;
                    }
                }
                return table;
            }
        }

        public DataView GetDataView(string query)
        {
            var tries = 3;
            var source = new TaskCompletionSource<DataTable>();
            var table = new DataTable();
            while (true)
            {
                try
                {
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        try
                        {
                            using (var sqlCommand = new SqlCommand(query, sqlConnection))
                            {
                                 sqlConnection.Open();
                                using (var dataReader =  sqlCommand.ExecuteReader())
                                {
                                    try
                                    {
                                        table.Load(dataReader);
                                        source.SetResult(table);
                                    }
                                    finally
                                    {
                                        dataReader?.Close();
                                    }
                                }
                            }
                        }
                        finally
                        {
                            sqlConnection?.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception at query: " + query);
                    if (tries-- <= 0)
                    {
                        throw;
                    }
                }
                return new DataView(table);
            }
        }

        #endregion

    }
}
