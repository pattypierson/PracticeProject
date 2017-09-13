using PracticeProject.Data;
using PracticeProject.Data.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Services
{
    public abstract class BaseService
    {
        public IDataProvider DataProvider { get; set; }

        public BaseService(IDataProvider dataProvider)
        {
            this.DataProvider = dataProvider;
        }

        public BaseService()
        {
            this.DataProvider = new SqlDataProvider("Data Source=localhost;Initial Catalog=PracticeProject;Integrated Security=True");
        }
    }
}
