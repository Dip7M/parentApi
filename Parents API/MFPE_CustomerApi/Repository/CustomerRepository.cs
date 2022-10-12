using ParentsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace ParentsApi.Repository
{
    public class ParentsRepository : IRepository<Parents>
    {
        //static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ParentsRepository));
        public static List<Parents> ListParents = new List<Parents>()
        {
            new Parents {RegId = 1, ParentName = "Alok Sen", StudentName="Aditi Sen", StudentRegNum="SPA001", Address = "Kolkata, WB", Country="India", State="West Bengal", City="Kolkata", ZipCode=700001, Email="Alok@gmail.com", PrimaryContactPerson="Alok Sen",
                PrimaryContactNum=9876543213, SecondaryContactPerson= "Anita Sen", SecondaryContactNumber=8976543216, Pwd="Alok@123"},
            new Parents {RegId = 1, ParentName = "Dip Mondal", StudentName="Loy Mondal", StudentRegNum="SPA002", Address = "Kolkata, WB", Country="India", State="West Bengal", City="Kolkata", ZipCode=700001, Email="Dip@gmail.com", PrimaryContactPerson="Dip Mondal",
                PrimaryContactNum=9686543213, SecondaryContactPerson= "Amalita Mondal", SecondaryContactNumber=7006543216, Pwd="Dip@123"},
        };
        
        /// This function returns added customer list and returning boolean value is customer id is getting created.
        
        public bool Add(Parents item)
        {
            try
            {
                ListParents.Add(item);
                //_log4net.Info("Customer details has been successfully entered.");
                return true;
            }
            catch(Exception e)
            {
                //_log4net.Error("Error" + e.Message);
            }
            return false;
        }
        
        /// This function returns all the customer details based on id.
        
        public Parents Get(int id)
        {
            try
            {
                //_log4net.Info("Customer details  has been successfully retrieved");
                return ListParents.Find(p => p.RegId == id);
            }
            catch(Exception e)
            {
                //_log4net.Error("Error " + e.Message);
                throw e;
            }
            
        }
        
        /// This function returns all the customer lists.
        
        public IEnumerable<Parents> GetAll()
        {
           
                //_log4net.Info("Customer details is finally recieved.");
                return ListParents.ToList();
            
        }

    }
}
