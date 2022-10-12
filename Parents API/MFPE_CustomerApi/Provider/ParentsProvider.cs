using ParentsApi.Models;
using ParentsApi.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParentsApi.Provider
{
    public class ParentsProvider : IProvider<Parents>
    {
        IRepository<Parents> _repository;

       // static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CustomerProvider));
        public ParentsProvider(IRepository<Parents> repository)
        {
            _repository = repository;

        }
        /// <summary>
        /// This function returns true if account is getting created with the help of Customer Id.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Parents model)
        {
            try
            {
                var parentExist = _repository.Get(model.RegId);
                if (parentExist == null)
                {
                    if (_repository.Add(model))
                    {

                        return true;
                    }
                }
                else
                {
                    //_log4net.Warn("User already exist with Id :" + model.CustomerId);

                }
                return false;
           }
            catch(Exception e)
           {
                throw e;
           }
        }
        
        /// This function returns customer details for particular id.
        
        public Parents Get(int id)
        {
            try
            {
                return _repository.Get(id);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        
        /// This function returns full customer list.
        
        public IEnumerable<Parents> GetAll() 
        {
            try
            {
                
                var parent = _repository.GetAll().ToList();
                if (parent.Count == 0)
                {
                    //_log4net.Info("List is empty");
                    throw new System.ArgumentNullException("List is empty");
                }
                else
                {
                    return parent;
                }
                
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
