using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Policy_Renewal
{
    /// <summary>
    /// Interaction logic for RenewedPolicies.xaml
    /// </summary>
    public partial class RenewedPolicies : Window
    {
        public static ObservableCollection<PolicyDetailsProperties> _renPolicyInfo;
        public RenewedPolicies()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {           
            _renPolicyInfo = XMLOperations.ReadXML<ObservableCollection<PolicyDetailsProperties>>("RenewedPolicies.xml");

            if (_renPolicyInfo == null)
            {
                _renPolicyInfo = new ObservableCollection<PolicyDetailsProperties>();
            }
            RenewedPolicyGrid.ItemsSource = _renPolicyInfo;

        }

        private void tbx_filterRenPolicies_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = tbx_filterRenPolicies.Text;
            var list = from m in _renPolicyInfo where m.policyNo.Contains(input) || m.firstName.Contains(input) || m.lastName.Contains(input) select m;
            RenewedPolicyGrid.ItemsSource = list;
        }

    }
}
