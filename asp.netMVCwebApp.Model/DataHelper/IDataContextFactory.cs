using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.netMVCwebApp.Model
{
    public interface IDataContextFactory
    {
        System.Data.Linq.DataContext Context { get; }
        void SaveAll();
    }//end interface
}//end namespace