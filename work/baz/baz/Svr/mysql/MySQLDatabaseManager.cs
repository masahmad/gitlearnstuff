using System;
using System.Data;
using System.Configuration;
using System.Web;
using MySql.Data.MySqlClient;



namespace PlayV.MYSqlDal
{
    /// <summary>
    /// Summary description for DatabaseManager
    /// </summary>
    public class MySQLDatabaseManager
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


        public static MySqlDataReader GetDataReader(string query)
        {
          
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            MySqlConnection connection = new MySqlConnection(_connectionString);

            try
            {
                connection.Open();
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                                
                return reader;
            }
            catch
            {
                connection.Dispose();
                if (reader != null) reader.Dispose();
                return null;
            }



            finally
            {
              //  if (connection != null) connection.Dispose();
            }


        }






        public static int ExecuteNonQuery(string sql)
        {
            MySqlCommand command = null;
            MySqlConnection connection = new MySqlConnection(_connectionString);

            try
            {
                connection.Open();
                command = new MySqlCommand(sql, connection);
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
            MySqlCommand command = null;
            MySqlConnection connection = new MySqlConnection(_connectionString);

            try
            {
            connection.Open();
            command = new MySqlCommand(sql, connection);
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





        public static int ExecuteNonQuery(string procedureName, MySQLParameterList parameters)
        {
            MySqlCommand command = null;
            MySqlConnection connection = new MySqlConnection(_connectionString);

            try
            {
                connection.Open();
                command = new MySqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                
                foreach (MySqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                return command.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
              
            }
            finally
            {
                if (connection != null) connection.Dispose();
            }
        }




        public static object ExecuteScalar(string procedureName, MySQLParameterList parameters)
        {
            MySqlCommand command = null;
            MySqlConnection connection = new MySqlConnection(_connectionString);

            try
            {
            connection.Open();
            command = new MySqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (MySqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command.ExecuteScalar();

            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection != null) connection.Dispose();
            }
        }



        public static MySqlDataReader GetDataReader(string procedureName, MySQLParameterList parameters)
        {
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            MySqlConnection connection = new MySqlConnection(_connectionString);


            try
            {
                connection.Open();
                command = new MySqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (MySqlParameter parameter in parameters)
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
        

        public static MySqlDataReader GetDataReaderSP(string procedureName, MySQLParameterList parameters)
        {
            
            
            if (_connectionString==null) throw new Exception("db con=");
            
            
            MySqlDataReader reader = null;
            MySqlCommand command = null;
            MySqlConnection connection = new MySqlConnection(_connectionString);


            try
            {
                connection.Open();
                command = new MySqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (MySqlParameter parameter in parameters)
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


        public static DataSet GetDataSet(string procedureName, MySQLParameterList parameters)
        {
            DataSet         dataSet = new DataSet();
            MySqlDataAdapter  dataAdapter = null;
			
            MySqlCommand      command = null;
            MySqlConnection   connection = new MySqlConnection(_connectionString);

            try
            {
                connection.Open();
                command = new MySqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                
                foreach (MySqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                dataAdapter = new MySqlDataAdapter(command);

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
            MySqlDataAdapter dataAdapter = null;

            MySqlCommand command = null;
            MySqlConnection connection = new MySqlConnection(_connectionString);

            try
            {
                connection.Open();
                command = new MySqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                

                dataAdapter = new MySqlDataAdapter(command);
                dataAdapter.Fill(dataSet);
                return dataSet;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

        public static DataTable GetDataTable(string procedureName, MySQLParameterList parameters)
        {
            DataTable table = new DataTable();
             
            MySqlDataAdapter dataAdapter = null;

            MySqlCommand command = null;
            MySqlConnection connection = new MySqlConnection(_connectionString);

            try
            {
                connection.Open();
                command = new MySqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (MySqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                dataAdapter = new MySqlDataAdapter(command);

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
			MySqlDataAdapter	DA;
			MySqlCommand		Command;
			MySqlConnection	Connection = new MySqlConnection(_connectionString);

			Connection.Open();
			Command = new MySqlCommand(SqlStatement, Connection);
			DA = new MySqlDataAdapter(Command);
			DA.Fill(DT);
			Connection.Close();

			return DT;
		}
	}

    public class MySQLParameterList : System.Collections.CollectionBase
    {
        public MySqlParameter this[int index]
        {
            get { return ((MySqlParameter)(List[index])); }
            set { List[index] = value; }
        }

        public int AddParameter(string parameterName, object value)
        {
            return Add(new MySqlParameter(parameterName, value));
        }

        public int Add(MySqlParameter parameter)
        {
            return List.Add(parameter);
        }

        public void Insert(int index, MySqlParameter parameter)
        {
            List.Insert(index, parameter);
        }

        public void Remove(MySqlParameter parameter)
        {
            List.Remove(parameter);
        }

        public bool Contains(MySqlParameter parameter)
        {
            return List.Contains(parameter);
        }

    }
}