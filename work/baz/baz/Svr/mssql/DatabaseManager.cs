using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;





namespace PlayV.Dal
{
    /// <summary>
    /// Summary description for DatabaseManager
    /// </summary>
    public class DatabaseManager
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["KBConn"].ConnectionString;

        public static bool ColumnEqual(object A, object B)
        {

            // Compares two values to see if they are equal. Also compares DBNULL.Value.
            // Note: If your DataTable contains object fields, then you must extend this
            // function to handle them in a meaningful way if you intend to group on them.

            if (A == DBNull.Value && B == DBNull.Value) //  both are DBNull.Value
                return true;
            if (A == DBNull.Value || B == DBNull.Value) //  only one is DBNull.Value
                return false;
            return (A.Equals(B));  // value type standard comparison
        }

        public static DataTable SelectDistinct(DataTable SourceTable, string FieldName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);

            object LastValue = null;
            foreach (DataRow dr in SourceTable.Select("", FieldName))
            {
                if (LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])))
                {
                    LastValue = dr[FieldName];
                    dt.Rows.Add(new object[] { LastValue });
                }
            }
            return dt;
        }

        public static SqlDataReader GetDataReader(string query)
        {
            SqlDataReader reader = null;
            SqlCommand command = null;
            SqlConnection connection = new SqlConnection(_connectionString);



          

            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
            catch
            {
                connection.Dispose();
                if (reader != null) reader.Dispose();
                return null;
            }
        }


        public static int ExecuteNonQuery(string sql)
        {
            SqlCommand command = null;
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                return command.ExecuteNonQuery();

            }
            catch
            {
                return 0;
            }

            finally
            {
                if (connection != null) connection.Dispose();
            }

        }




        public static object ExecuteScalar(string sql)
        {
            SqlCommand command = null;
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
            connection.Open();
            command = new SqlCommand(sql, connection);
            return command.ExecuteScalar();

            }
            catch
            {
                return 0;
            }

            finally
            {
                if (connection != null) connection.Dispose();
            }

        }





        public static int ExecuteNonQuery(string procedureName, SQLParameterList parameters)
        {
            SqlCommand command = null;
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                connection.Open();
                command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                return command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
              
            }
            finally
            {
                if (connection != null) connection.Dispose();
            }
        }


        public static object ExecuteScalar(string procedureName, SQLParameterList parameters)
        {
            SqlCommand command = null;
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
            connection.Open();
            command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command.ExecuteScalar();

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection != null) connection.Dispose();
            }
        }



        public static SqlDataReader GetDataReader(string procedureName, SQLParameterList parameters)
        {
            SqlDataReader reader = null;
            SqlCommand command = null;
            SqlConnection connection = new SqlConnection(_connectionString);


            try
            {
                connection.Open();
                command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;

            }
            catch(Exception ex)
            {
                connection.Dispose();
                if (reader != null) reader.Dispose();
                throw ex;
                return null;
            }
        }




        public static SqlDataReader GetDataReaderSP(string procedureName, SQLParameterList parameters)
        {
            
            
            if (_connectionString==null) throw new Exception("db con=");
            
            
            SqlDataReader reader = null;
            SqlCommand command = null;
            SqlConnection connection = new SqlConnection(_connectionString);


            try
            {
                connection.Open();
                command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;

            }
            catch (Exception ex)
            {
                connection.Dispose();
                if (reader != null) reader.Dispose();
                throw ex;
                return null;
            }
        }


        public static DataSet GetDataSet(string procedureName, SQLParameterList parameters)
        {
            DataSet         dataSet = new DataSet();
            SqlDataAdapter  dataAdapter = null;
			
            SqlCommand      command = null;
            SqlConnection   connection = new SqlConnection(_connectionString);

            try
            {
                connection.Open();
                command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                dataAdapter = new SqlDataAdapter(command);

                dataAdapter.Fill(dataSet);

                return dataSet;

            }
            catch(Exception ex)
            {
                return null;
                //Need to watch out for catching errors here (lets log it at some point)
                //for instance any errors in Pete's CLR's
            }
            finally
            {
                connection.Dispose();
            }
        }

        
        public static DataSet GetDataSet(string procedureName)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = null;

            SqlCommand command = null;
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                connection.Open();
                command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                

                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet);
                return dataSet;

            }
            catch (Exception ex)
            {
                return null;
                //Need to watch out for catching errors here (lets log it at some point)
                //for instance any errors in 
            }
            finally
            {
                connection.Dispose();
            }
        }




        //public static PagedDataSource GetPagedDatasource(string procedureName, SQLParameterList parameters, int pagesize)
        //{
        //    DataTable data = GetDataTable(procedureName, parameters);

        //    if (data != null)
        //    {
        //        PagedDataSource pagedData = new PagedDataSource();
        //        pagedData.DataSource = data.DefaultView;
        //        pagedData.AllowPaging = true;
        //        pagedData.PageSize = pagesize;
                
        //        return pagedData;
        //    }
        //    else
        //        return null;

        //}

        public static DataTable GetDataTable(string procedureName, SQLParameterList parameters)
        {
            DataTable table = new DataTable();
             
            SqlDataAdapter dataAdapter = null;

            SqlCommand command = null;
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                connection.Open();
                command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                dataAdapter = new SqlDataAdapter(command);

                dataAdapter.Fill(table);

                return table;

            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Dispose();
            }
        }

		public DataTable GetDataTable(string SqlStatement) {
			DataTable		DT = new DataTable();
			SqlDataAdapter	DA;
			SqlCommand		Command;
			SqlConnection	Connection = new SqlConnection(_connectionString);

			Connection.Open();
			Command = new SqlCommand(SqlStatement, Connection);
			DA = new SqlDataAdapter(Command);
			DA.Fill(DT);
			Connection.Close();

			return DT;
		}
	}

    public class SQLParameterList : System.Collections.CollectionBase
    {
      
        public SqlParameter this[int index]
        {
            get { return ((SqlParameter)(List[index])); }
            set { List[index] = value; }
        }

        public int AddParameter(string parameterName, object value)
        {
            return Add(new System.Data.SqlClient.SqlParameter(parameterName, value));
        }

        public int Add(SqlParameter parameter)
        {
            return List.Add(parameter);
        }

        public void Insert(int index, SqlParameter parameter)
        {
            List.Insert(index, parameter);
        }

        public void Remove(SqlParameter parameter)
        {
            List.Remove(parameter);
        }

        public bool Contains(SqlParameter parameter)
        {
            return List.Contains(parameter);
        }

    }
}