using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using asp.netMVCwebApp.Model;

namespace asp.netMVCwebApp.Model
{
    public class LSDataContextFactory : IDataContextFactory
    {

        private System.Data.Linq.DataContext _dataContext;
        public LSDataContextFactory()
        {
            if (_dataContext == null)
            {
                string connStr = System.Configuration.ConfigurationSettings.AppSettings["connStr"].ToString();
                _dataContext = new LSasp_netMVCwebAppDataContext(connStr/* "Data Source=.;Initial Catalog=NAME;Persist Security Info=True;User ID=sa;Password="*/);
            }

        }

        public System.Data.Linq.DataContext Context
        {
            get
            {
                return _dataContext;
            }
        }

        public void SaveAll()
        {
            Context.SubmitChanges();
        }
    }
}//end namespace