using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Policy_Renewal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<PolicyDetailsProperties> _expPolicyInfo;

        private void App_Startup(object sender, StartupEventArgs e)
        {
            //_expPolicyInfo = GenerateData(3);

            _expPolicyInfo = XMLOperations.ReadXML<ObservableCollection<PolicyDetailsProperties>>("ExpiredPolicies.xml");

            if (_expPolicyInfo == null)
            {
                _expPolicyInfo = new ObservableCollection<PolicyDetailsProperties>();
            }
        }

        private ObservableCollection<PolicyDetailsProperties> GenerateData(int cnt)
        {
            var polList = new ObservableCollection<PolicyDetailsProperties>();

            var date1 = new DateTime(1994, 7, 10);
            var bdate = date1.ToShortDateString();
            DateTime sDate = new DateTime(2019, 1, 31);
            DateTime eDate = new DateTime(2020, 1, 31);

            for (int i = 0; i < cnt; i++)
            {
                polList.Add(new PolicyDetailsProperties 
                {
                    policyNo = 34500.ToString(),
                    firstName = "Aditya",
                    lastName = "Shelar",
                    birthDate = date1,
                    age = 26,
                    address = "Am Steingarten 14, App No. 365, Mannheim",
                    policyType = "Life Insurance",
                    policyStatus = "Expired",
                    startDate = sDate,
                    endDate = eDate,
                    sumAssured = 2400,
                    monthlyPremium = 200,
                    benefitAmount = 9600,
                    suppAIB = false,
                    suppFIB = false,
                    suppADB = false,
                    suppTIR = false
                });
            }

            return polList;
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            XMLOperations.WriteXml<ObservableCollection<PolicyDetailsProperties>>(_expPolicyInfo, "ExpiredPolicies.xml");
        }
    }
}
