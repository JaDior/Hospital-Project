using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Model
{
    public class Encounter : BaseEntity
    {
        public int PatientId { get; set; }
        public string Notes { get; set; }
        public string VisitCode { get; set; }
        public string Provider { get; set; }
        public string BillingCode { get; set; }
        public string ICD10 { get; set; }
        public double TotalCost     { get; set; }
        public double CoPay { get; set; }
        public string ChiefComplaint { get; set; }
        public int Pulse { get; set; }
        public int SystolicPressure { get; set; }
        public int DiastolicPressure { get; set; }
    }
}
