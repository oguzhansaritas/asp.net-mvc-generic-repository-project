using System;
using asp.netMVCwebApp.IoCContainer;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace asp.netMVCwebApp.IoCContainer
{
    public class RepositoryFactory<T>
    {
        public static T GetRepositoryInstance()
        {
            IoC ioc = new IoC();

            T repository = ioc.Resolve<T>();

            return repository;

        }//End Method

    }//end class
}//end namespace