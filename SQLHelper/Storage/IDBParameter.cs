using System;
using System.Data.SqlClient;

namespace SQL_Helper.Storage
{
    /// <summary>
    /// Interface to allow iterating a generic List of DBParameters
    /// </summary>
    public interface IDBParameter
    {
        /// <summary>
        /// Gets the SQL version of the parameter, auto-casting it.
        /// </summary>
        /// <returns>SqlParameter Parameter ready for using in SQL stored procedures</returns>
        SqlParameter GetSQLParameter();
    }
}
