
using System;

namespace SQL_Helper.Exceptions
{
    /// <summary>
    /// Exceptions thrown when performing storage operations
    /// </summary>
    class StorageException : ApplicationBaseException
    {
        #region Fields

        private string action;
        private string storedProcedureName;

        #endregion

        #region Properties

        /// <summary>
        /// SQL Helper action performed
        /// </summary>
        public string Action
        {
            get
            {
                return action;
            }
        }

        /// <summary>
        /// Stored Procedure tried to be executed
        /// </summary>
        public string StoredProcedureName
        {
            get
            {
                return storedProcedureName;
            }
        }

        #endregion

        #region Class Constructor

        /// <summary>
        /// Class Constructor.
        /// </summary>
        /// <param name="Action">SQL Helper action performed</param>
        /// <param name="StoredProcedureName">Stored Procedure tried to be executed</param>
        public StorageException(string Action, string StoredProcedureName)
            : base(string.Format("Action:{0} SPName:{1}", Action, StoredProcedureName))
        {
            action = Action;
            storedProcedureName = StoredProcedureName;
        }

        #endregion
    }
}
