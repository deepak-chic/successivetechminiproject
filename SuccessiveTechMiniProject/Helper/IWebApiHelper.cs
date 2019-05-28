using System;
using System.Collections.Generic;

namespace SuccessiveTechMiniProject
{
    public interface IWebApiHelper<T> : IDisposable where T : class 
    {
        IList<T> GetAll(string apiControllerName);
        T Get(string apiControllerName);
        int Create(string apiControllerName, T entity);
        int Edit(string apiControllerName, T entity);
        int Delete(string apiControllerName);
    }
}