using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy_Renewal
{
    public class PolicyDetailsProperties
    {
        public string policyNo { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public DateTime birthDate { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string policyType { get; set; }
        public string policyStatus { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool suppAIB { get; set; }
        public bool suppFIB { get; set; }
        public bool suppADB { get; set; }
        public bool suppTIR { get; set; }
        public int sumAssured { get; set; }
        public int benefitAmount { get; set; }
        public int monthlyPremium { get; set; }
        public string policyExpiryMonth { get; set; }
        public DateTime policyRenewedDate { get; set; }

    }
}
