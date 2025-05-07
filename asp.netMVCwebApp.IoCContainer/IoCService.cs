using asp.netMVCwebApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.netMVCwebApp.IoCContainer
{
    public class IoC
    {
        /// <summary>
        /// it keep interfaces and their implemented classes
        /// </summary>
        Dictionary<Type, object> _bindingList = new Dictionary<Type, object>();
        /// <summary>
        /// Add new implementing 
        /// </summary>
        /// <typeparam name="T">Interface</typeparam>
        /// <param name="toRegister">implemented object by interface</param>
        public void Register<T>(T toRegister)
        {
            if (!this.isInitialize)
            {
                this.InitializeComponents();
            }
            if (!_bindingList.Any(k => k.Key == toRegister.GetType()))
                _bindingList.Add(typeof(T), toRegister);
        }

        /// <summary>
        /// get implemented class
        /// </summary>
        /// <typeparam name="T">interface</typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            if (!isInitialize)
                InitializeComponents();
            return (T)_bindingList[typeof(T)];
        }

        private bool isInitialize;
        /// <summary>
        /// it initialize all respository objects
        /// </summary>
        private void InitializeComponents()
        {
            isInitialize = true;
            _bindingList = new Dictionary<Type, object>();
            this.Register<IDataContextFactory>(new LSDataContextFactory());
            this.Register<UserRepository>(new UserRepository(this.Resolve<IDataContextFactory>()));


            isInitialize = false;
        }
    }
}