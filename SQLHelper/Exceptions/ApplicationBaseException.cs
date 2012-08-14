using System;

namespace DataVault.Exceptions
{
    /// <summary>
    /// Base exception for all the system. Always inherit from it to create derived exceptions.
    /// </summary>
    class ApplicationBaseException : Exception
    {
        #region Class Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="Message">Exception message</param>
        public ApplicationBaseException(string Message)
            : base(Message)
        {
        }

        #endregion
    }
}
