using DataVault.Exceptions;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DataVault.Storage
{
    /// <summary>
    /// Helper for performing storage access actions to a MS SQL DB
    /// </summary>
    public sealed class SQLHelper
    {
        #region Fields

        private string dbConnectionString = string.Empty;

        #endregion

        #region Class Constructor
        
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="DBConnectionString">Typical MSSQL connection string</param>
        public SQLHelper(string DBConnectionString)
        {
            dbConnectionString = DBConnectionString;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Executes a Stored Procedure returning one DataTable with 1+ results.
        /// It is the caller's responsability to check that the number of rows is greather than 0.
        /// </summary>
        /// <param name="StoredProcedureName">Name of the stored procedure to execute</param>
        /// <param name="Parameters">Optional SqlParameter array for the stored procedure parameters</param>
        /// <returns>DataTable</returns>
        /// <exception cref="StorageException">Errors executing the action</exception>
        public DataTable ExecuteDataset(string StoredProcedureName, List<IDBParameter> Parameters)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataAdapter dataAdapter = null;
            bool errorExecutingOperation = false;
            DataTable dataTable = new DataTable();

            try
            {
                connection = new SqlConnection(dbConnectionString);
                command = new SqlCommand(StoredProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (Parameters != null)
                {
                    foreach (IDBParameter parameter in Parameters)
                    {
                        command.Parameters.Add(parameter.GetSQLParameter());
                    }
                }

                dataAdapter = new SqlDataAdapter(command);
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (Exception)
            {
                errorExecutingOperation = true;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
                if (command != null)
                {
                    command.Dispose();
                }
            }

            if (errorExecutingOperation)
            {
                throw new StorageException("ExecuteDataset", StoredProcedureName);
            }
            else
            {
                return dataTable;
            }
        }

        /// <summary>
        /// Executes a Stored Procedure returning one DataRow
        /// </summary>
        /// <param name="StoredProcedureName">Name of the stored procedure to execute</param>
        /// <param name="Parameters">Optional SqlParameter array for the stored procedure parameters</param>
        /// <returns>DataRow or null</returns>
        /// <exception cref="StorageException">Errors executing the action</exception>
        public DataRow ExecuteDatasetSingleResult(string StoredProcedureName, List<IDBParameter> Parameters)
		{
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataAdapter dataAdapter = null;
            bool errorExecutingOperation = false;
            DataRow dataRow = null;

            try
            {
                connection = new SqlConnection(dbConnectionString);
                command = new SqlCommand(StoredProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (Parameters != null)
                {
                    foreach (IDBParameter parameter in Parameters)
                    {
                        command.Parameters.Add(parameter.GetSQLParameter());
                    }
                }

                dataAdapter = new SqlDataAdapter(command);
                connection.Open();
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count == 1)
                {
                    dataRow = dataTable.Rows[0];
                }

            }
            catch (Exception)
            {
                errorExecutingOperation = true;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
                if (command != null)
                {
                    command.Dispose();
                }
            }

            if (errorExecutingOperation)
            {
                throw new StorageException("ExecuteDatasetSingleResult", StoredProcedureName);
            }
            else
            {
                return dataRow;
            }
		}

        /// <summary>
        /// Executes a Stored Procedure returning the number of affected rows
        /// </summary>
        /// <param name="StoredProcedureName">Name of the stored procedure to execute</param>
        /// <param name="Parameters">Optional SqlParameter array for the stored procedure parameters</param>
        /// <returns># of affected rows</returns>
        /// <exception cref="StorageException">Errors executing the action</exception>
        public int ExecuteNonQuery(string StoredProcedureName, List<IDBParameter> Parameters)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            bool errorExecutingOperation = false;
            int affectedRows = 0;

            try
            {
                connection = new SqlConnection(dbConnectionString);
                command = new SqlCommand(StoredProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (Parameters != null)
                {
                    foreach (IDBParameter parameter in Parameters)
                    {
                        command.Parameters.Add(parameter.GetSQLParameter());
                    }
                }

                connection.Open();
                affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                errorExecutingOperation = true;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
                if (command != null)
                {
                    command.Dispose();
                }
            }

            if (errorExecutingOperation)
            {
                throw new StorageException("ExecuteNonQuery", StoredProcedureName);
            }
            else
            {
                return affectedRows;
            }
        }

        /// <summary>
        /// Executes a Stored Procedure returning first column of the first row as a numeric value
        /// </summary>
        /// <param name="StoredProcedureName">Name of the stored procedure to execute</param>
        /// <param name="Parameters">Optional SqlParameter array for the stored procedure parameters</param>
        /// <returns># of affected rows</returns>
        /// <exception cref="StorageException">Errors executing the action</exception>
        public long ExecuteScalar(string StoredProcedureName, List<IDBParameter> Parameters)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            bool errorExecutingOperation = false;
            long returnedValue = 0;

            try
            {
                connection = new SqlConnection(dbConnectionString);
                command = new SqlCommand(StoredProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (Parameters != null)
                {
                    foreach (IDBParameter parameter in Parameters)
                    {
                        command.Parameters.Add(parameter.GetSQLParameter());
                    }
                }

                connection.Open();
                returnedValue = Convert.ToInt64(command.ExecuteScalar());
            }
            catch (Exception)
            {
                errorExecutingOperation = true;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
                if (command != null)
                {
                    command.Dispose();
                }
            }

            if (errorExecutingOperation)
            {
                throw new StorageException("ExecuteScalar", StoredProcedureName);
            }
            else
            {
                return returnedValue;
            }
        }

        #endregion
    }
}
