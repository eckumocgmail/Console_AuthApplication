using ApplicationCore.Domain.Odbc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCommon.DataSource
{
    public static class AuthoruzationDataModelExtensions
    {
        public static DatabaseManager GetDatabaseManager(this AuthorizationDataModel model)
        {
            model.Database.EnsureCreated();
            string con = "Driver={SQL Server};" + AuthorizationDataModel.DEFAULT_CONNECTION_STRING.Replace(@"\\", @"\");
            return new DatabaseManager(con);
        }
    }
}
