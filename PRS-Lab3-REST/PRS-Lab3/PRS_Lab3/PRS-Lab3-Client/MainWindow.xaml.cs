using StudentService;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
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
using System.Xml;

namespace PRS_Lab3_Client
{
    public partial class MainWindow : Window
    {
        private const string ServiceBaseUrl = "http://localhost:59229/Service1.svc/"; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetResource_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load($"{ServiceBaseUrl}getResource");
            resultTextBox.Text = xmlDoc.InnerXml;
        }

        private void AddResource_Click(object sender, RoutedEventArgs e)
        {
            string url = $"{ServiceBaseUrl}addResource?id={txtId.Text}&value={txtValue.Text}";
            resultTextBox.Text = SendPostRequest(url);
        }

        private void UpdateResource_Click(object sender, RoutedEventArgs e)
        {
            string url = $"{ServiceBaseUrl}updateResource?id={txtId.Text}&value={txtValue.Text}&isdel={chkDelete.IsChecked.ToString().ToLower()}";
            resultTextBox.Text = SendPostRequest(url);
        }

        private string SendPostRequest(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = 0;

            using WebResponse response = request.GetResponse();
            using StreamReader reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
        }
    }
}