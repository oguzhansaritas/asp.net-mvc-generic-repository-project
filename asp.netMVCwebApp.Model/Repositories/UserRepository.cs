
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using asp.netMVCwebApp.Model;

namespace asp.netMVCwebApp.Model
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(IDataContextFactory _IDataContextFactory)
            : base(_IDataContextFactory)
        {

        }//end user rep
    }//end class
}//end namespace