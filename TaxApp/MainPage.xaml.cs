using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TaxApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Tax tax;
        string constantText = "0.05";
        string taxAmountInputValue = string.Empty;

        public MainPage()
        {
            this.InitializeComponent();

            tax = new Tax();
        }
        //Radio Button 
        private void GSTRadioButton_Click(object sender, RoutedEventArgs e)
        {

            if (((RadioButton)sender).IsChecked == true)
            {          

                RadioButton radioButtunTapped = (RadioButton)sender;
                this.constantText = radioButtunTapped.Tag.ToString();
                Debug.WriteLine("I'm Inside my Radio Button Tapped");

                doTaxCalculation(tax.sentValue, constantText);

            }
        }
        //Got Focus Event Handler
        private void purchaseAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            purchaseAmount.Text = string.Empty;
            Debug.WriteLine("I'm Inside my purchaseAmount Got Focus");
        }
        //LostFocus Event Handler
        private void purchaseAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            //purchaseAmount.Text = constantText.purchasePrice;
        }
        //Text Changed
        private void purchaseAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            string taxInputValue = purchaseAmount.Text;
            doTaxCalculation(taxInputValue, constantText);
        }

        private void doTaxCalculation(string inputvalue, string percentage)
        {

            tax.Calculate(inputvalue, percentage);
            taxAmount.Text = tax.taxAmount;
            totalAmount.Text = tax.totalAmount;
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Adesh Shah... Researcher and Food lover!!");
            await dialog.ShowAsync();
        }
    }
}
