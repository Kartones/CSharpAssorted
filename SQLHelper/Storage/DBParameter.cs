using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DataVault.Storage
{
    /// <summary>
    /// Generic DB Parameter container. Provides an abstraction from outside the DB layer
    /// </summary>
    /// <typeparam name="T">.NET Type of the parameter (will be converted to the SQL equivalent)</typeparam>
    public class DBParameter<T> : IDBParameter
    {
        #region Fields

        private string paramName;
        private T paramValue;
        private int? paramMaxsize = null;

        // Mapping of base types to SQL types
        private static readonly Dictionary<Type, SqlDbType> typesDictionary = new Dictionary<Type, SqlDbType>
        {
            { typeof(string), SqlDbType.NVarChar },
            { typeof(DateTime), SqlDbType.DateTime },
            { typeof(long), SqlDbType.BigInt },
            { typeof(int), SqlDbType.SmallInt },
            { typeof(byte), SqlDbType.TinyInt },
            { typeof(bool), SqlDbType.Bit }
        };

        #endregion

        #region Class Constructor

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="Name">Name of the Parameter (including the "@")</param>
        /// <param name="Value">Value of the parameter</param>
        public DBParameter(string Name, T Value)
        {
            paramName = Name;
            paramValue = Value;
        }

        /// <summary>
        /// Class Constructor.
        /// </summary>
        /// <param name="Name">Name of the Parameter (including the "@")</param>
        /// <param name="Value">Value of the parameter</param>
        /// <param name="MaxSize">Maximum size for the parameter</param>
        public DBParameter(string Name, T Value, int MaxSize) : this(Name, Value)
        {
            paramMaxsize = MaxSize;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the SQL version of the parameter, auto-casting it.
        /// </summary>
        /// <returns>SqlParameter Parameter ready for using in SQL stored procedures</returns>
        public SqlParameter GetSQLParameter()
        {
            SqlParameter returnParam = (paramMaxsize != null) ?
                new SqlParameter(paramName, typesDictionary[typeof(T)], paramMaxsize.Value) :
                new SqlParameter(paramName, typesDictionary[typeof(T)]);

            // TODO: if (!typesDictionary.ContainsKey(typeof(T))) throw exception

            returnParam.Value = paramValue;

            return returnParam;
        }

        #endregion
    }
}
