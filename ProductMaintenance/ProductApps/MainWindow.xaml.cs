using System;
using System.Collections.Generic;
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

namespace ProductApps
{
    public partial class MainWindow : Window
    {
        Product cProduct;
        private const decimal deliveryCharge = 25.00M;  // Delivery charge constant
        private const decimal wrapCharge = 5.00M;       // Wrap charge constant

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create a Product instance using user input
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));

                // Calculate total payment
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);

                // Display the total charge (total payment + delivery charge)
                decimal totalCharge = cProduct.TotalPayment + deliveryCharge;
                totalChargeTextBlock.Text = Convert.ToString(totalCharge);

                // Display the total charge after adding wrap charge
                decimal totalChargeWithWrap = totalCharge + wrapCharge;
                totalChargeWithWrapTextBox.Text = Convert.ToString(totalChargeWithWrap);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter valid data", "Data Entry Error");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
            totalChargeTextBlock.Text = "";  // Clear the total charge text
            totalChargeWithWrapTextBox.Text = "";  // Clear the total charge with wrap text
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
