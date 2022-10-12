using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsApi.Models
{
    public class Parents
    {
        [Key]
        public int RegId { get; set; }

        [Required]
        public string ParentName { get; set; }
        
        [Required]
        public string StudentName { get; set; }

        [Required]
        public string StudentRegNum { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PrimaryContactPerson { get; set; }

        [Required]
        public long PrimaryContactNum { get; set; }

        [Required]
        public string SecondaryContactPerson { get; set; }

        [Required]
        public long SecondaryContactNumber { get; set; }

        [Required]
        public string Pwd { get; set; }




    }
}
