using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Transactions;
using ParentsApi.Models;
using ParentsApi.Provider;
using ParentsApi.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ParentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ParentsController : ControllerBase
    {
        //static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ParentsController));
        private readonly IProvider<Parents> _provider;

        public ParentsController(IProvider<Parents> provider)
        {
            _provider = provider;
        }
        
        /// This method returns full Customer list.
        
        [HttpGet("Get")]
        public IActionResult Get()
        {
            try
            {
                //_log4net.Info("Get Api Initiated");
                return Ok(_provider.GetAll());
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// This method is returning customer details according to Customer Id.
        
        [HttpGet]
        [Route("getParentDetails/{id}")]
        public IActionResult getParentDetails([FromRoute]int id)
        {
            if (id == 0)
            {
                //_log4net.Warn("User has sent some invalid CustomerId");
                return BadRequest();
            }
            Parents listParents = new Parents();
            try
            {
                listParents = _provider.Get(id);
                if (listParents == null)
                {
                    //_log4net.Error("No record found for the user Id :" + id);
                    return NotFound();
                }
                else
                {
                    //_log4net.Info("Customer's Details has been successfully returned");
                    return Ok(listParents);
                }
            }
            catch(Exception e)
            {
                //_log4net.Error("Error occurred while calling get method" + e.Message);
                return new StatusCodeResult(500);
            }
        }
        
        
        /// This function returns customer creation status after creating customer account.
        
        [HttpPost]
        [Route("createParents")]
        public IActionResult createParents([FromBody]Parents parent)
        {
            if(!ModelState.IsValid)
			{
                //_log4net.Info("No Customer has been returned");
                return BadRequest();
            }
            try
            {
                bool result = _provider.Add(parent);

                if (result)
                {
                    //_log4net.Info("Customer has been successfully created");
                    ParentsCreationStatus cts = new ParentsCreationStatus();
                    cts.Message = "Customer and its account has been successfully created.";
                    cts.RegId = parent.RegId;
                    return Ok(cts);
                }
                else
                {
                    return new StatusCodeResult(409);
                }
            }
            catch (Exception e)
            {
                //_log4net.Error("Error occurred while calling post method" + e.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}
