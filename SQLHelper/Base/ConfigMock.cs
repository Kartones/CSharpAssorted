using System;

namespace SQL_Helper.Base
{
    /// <summary>
    /// Config Mock, to abstract from whatever config system you want to use
    /// </summary>
    class ConfigMock
    {
        public static string DBConnectionString = "mock connection string";
    }
}
