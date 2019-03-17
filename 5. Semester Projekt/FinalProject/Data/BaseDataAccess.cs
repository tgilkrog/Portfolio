using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class BaseDataAccess
    {
        protected string connectionString;

        public BaseDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
