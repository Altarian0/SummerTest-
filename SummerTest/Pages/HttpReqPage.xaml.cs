using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace SummerTest.Pages
{
    /// <summary>
    /// Interaction logic for HttpReqPage.xaml
    /// </summary>
    public partial class HttpReqPage : Page
    {
        public HttpReqPage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// send HTTP Request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PushButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MethodCombo.SelectedItem == null)
                {
                    MessageBox.Show("Неверный метод Http запроса.");
                    return;
                }

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(UrlText.Text);
                webRequest.Method = MethodCombo.Text;

                if (MethodCombo.Text == "POST")
                {
                    webRequest.ContentType = "application/json";
                    string data = "{\"foo1\":\"bar1\",\"foo2\":\"bar2\"}";
                    using (Stream stream = webRequest.GetRequestStream())
                    {
                        using (StreamWriter streamWriter = new StreamWriter(stream))
                        {
                            streamWriter.Write(data);
                        }
                    }
                }

                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                using (Stream stream = webResponse.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        ResponseText.Text = $"{streamReader.ReadToEnd()} \n\n {(int)webResponse.StatusCode} - {webResponse.StatusCode}";
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ProtocolViolationException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch
            {
                MessageBox.Show("Неверный формат URL запроса.");
            }


        }

    }
}
