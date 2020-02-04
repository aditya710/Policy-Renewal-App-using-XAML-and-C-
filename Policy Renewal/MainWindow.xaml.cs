using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Policy_Renewal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {     
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_Month.Content = System.DateTime.Now.ToString("MMMMM");
        }

        private void AddRemoveSuppPlans(bool IsChecked)
        {
            int premium = 0;
            int sAssured = 0;

            if (int.TryParse(tbx_MonthlyPrem.Text, out premium)) { }
            if (int.TryParse(tbx_SumAssured.Text, out sAssured)) { }

            if (IsChecked == true)
            {
                premium = premium + 20;
                sAssured = sAssured + 240;
            }

            if (IsChecked == false)
            {
                premium = premium - 20;
                sAssured = sAssured - 240;
            }
            tbx_MonthlyPrem.Text = premium.ToString();
            tbx_SumAssured.Text = sAssured.ToString();
        }
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {

            string input = tbx_PolicyNo.Text.ToString();
            var list = from m in App._expPolicyInfo where m.policyNo.Equals(input) || m.firstName.Contains(input) || m.lastName.Contains(input) || m.fullName.Equals(input) select m;


            var details = list.ToArray();

            //DateTime? firstDate = DateTime.Now;
            //DateTime? secondDate = details[0].birthDate;
            //TimeSpan? duration = firstDate - secondDate;
            //var ageYear = Convert.ToInt32(duration.Value.TotalDays / 365);


            tbx_FirstName.Text = details[0].firstName;
            tbx_LastName.Text = details[0].lastName;
            tbx_DateOfBirth.Text = details[0].birthDate.Date.ToString("d");
            tbx_Age.Text = details[0].age.ToString();
            tbx_Address.Text = details[0].address;
            tbx_PolicyType.Text = details[0].policyType;
            tbx_PolicyStatus.Text = details[0].policyStatus;
            dp_StartDate.SelectedDate = details[0].startDate;
            dp_EndDate.SelectedDate = details[0].endDate;
            cb_AIB.IsChecked = details[0].suppAIB;
            cb_FIB.IsChecked = details[0].suppFIB;
            cb_ADB.IsChecked = details[0].suppADB;
            cb_TIR.IsChecked = details[0].suppTIR;
            tbx_SumAssured.Text = details[0].sumAssured.ToString();
            tbx_BenefitAmt.Text = details[0].benefitAmount.ToString();
            tbx_MonthlyPrem.Text = details[0].monthlyPremium.ToString();
        }

        private void RenewPolicyDate(object sender, SelectionChangedEventArgs e)
        {
            dp_EndDate.SelectedDate = dp_StartDate.SelectedDate.Value.AddMonths(12);

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cb_AIB_Checked(object sender, RoutedEventArgs e)
        {
            AddRemoveSuppPlans(true);
        }

        private void cb_AIB_Unchecked(object sender, RoutedEventArgs e)
        {
            AddRemoveSuppPlans(false);
        }

        private void cb_FIB_Checked(object sender, RoutedEventArgs e)
        {
            AddRemoveSuppPlans(true);
        }

        private void cb_FIB_Unchecked(object sender, RoutedEventArgs e)
        {
            AddRemoveSuppPlans(false);
        }

        private void cb_ADB_Checked(object sender, RoutedEventArgs e)
        {
            AddRemoveSuppPlans(true);
        }

        private void cb_ADB_Unchecked(object sender, RoutedEventArgs e)
        {
            AddRemoveSuppPlans(false);
        }

        private void cb_TIR_Checked(object sender, RoutedEventArgs e)
        {
            AddRemoveSuppPlans(true);
        }

        private void cb_TIR_Unchecked(object sender, RoutedEventArgs e)
        {
            AddRemoveSuppPlans(false);
        }

        private void tbx_SumAssured_TextChanged(object sender, TextChangedEventArgs e)
        {
            int premium = 0;
            int bAmount = 0;
            int sAssured = 0;

            if (int.TryParse(tbx_MonthlyPrem.Text, out premium)) { }
            if (int.TryParse(tbx_BenefitAmt.Text, out bAmount)) { }
            if (int.TryParse(tbx_SumAssured.Text, out sAssured)) { }

            premium = sAssured / 12;
            bAmount = sAssured * 4;


            //if(cb_AIB.IsChecked == true)
            //{
            //    premium += 20;
            //    sAssured += 20;
            //}
            tbx_MonthlyPrem.Text = premium.ToString();
            tbx_BenefitAmt.Text = bAmount.ToString();

        }

        private void btn_Renew_Click(object sender, RoutedEventArgs e)
        {
            

            var propList = new ObservableCollection < PolicyDetailsProperties >();

            propList.Add(new PolicyDetailsProperties
            {
                policyNo = tbx_PolicyNo.Text,
                firstName = tbx_FirstName.Text,
                lastName = tbx_LastName.Text,
                birthDate = Convert.ToDateTime(tbx_DateOfBirth.Text),
                age = Convert.ToInt32(tbx_Age.Text),
                address = tbx_Address.Text,
                policyType = tbx_PolicyType.Text,
                policyStatus = "Renewed",
                startDate = dp_StartDate.SelectedDate.Value,
                endDate = dp_StartDate.SelectedDate.Value,
                sumAssured = Convert.ToInt32(tbx_SumAssured.Text),
                monthlyPremium = Convert.ToInt32(tbx_MonthlyPrem.Text),
                benefitAmount = Convert.ToInt32(tbx_BenefitAmt.Text),
                suppAIB = cb_AIB.IsChecked.Value,
                suppFIB = cb_AIB.IsChecked.Value,
                suppADB = cb_AIB.IsChecked.Value,
                suppTIR = cb_AIB.IsChecked.Value,
                policyRenewedDate = DateTime.Now.Date
            });
            

            XMLOperations.WriteXml<ObservableCollection<PolicyDetailsProperties>>(propList, "RenewedPolicies.xml");

            MessageBox.Show("Renewed", "Success");
        }
    }
}

