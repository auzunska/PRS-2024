using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ServiceReference1;

namespace PRS_Lab4_SOAP_UI
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

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new WebServiceSoapClient(WebServiceSoapClient.EndpointConfiguration.WebServiceSoap);
                int num1 = int.Parse(txtAddNumber1.Text);
                int num2 = int.Parse(txtAddNumber2.Text);
                int result = await client.AddAsync(num1, num2); 
                lblAddResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private async void btnCelsiusToFahrenheit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new WebServiceSoapClient(WebServiceSoapClient.EndpointConfiguration.WebServiceSoap);
                double celsius = double.Parse(txtCelsius.Text);
                double fahrenheit = await client.CelsiusToFahrenheitAsync(celsius); 
                lblCelsiusToFahrenheitResult.Text = fahrenheit.ToString(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private async void btnFahrenheitToCelsius_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new WebServiceSoapClient(WebServiceSoapClient.EndpointConfiguration.WebServiceSoap);
                double fahrenheit = double.Parse(txtFahrenheit.Text);
                double celsius = await client.FahrenheitToCelsiusAsync(fahrenheit); 
                lblFahrenheitToCelsiusResult.Text = celsius.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}