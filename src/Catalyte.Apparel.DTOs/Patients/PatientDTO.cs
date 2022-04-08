using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.DTOs.Patients
{
    public class PatientDTO
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }   
        public string SSN { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
        public int Weight { get; set; }
        public string Insurance { get; set; }
        public string Gender { get; set; }

        
    }
}
