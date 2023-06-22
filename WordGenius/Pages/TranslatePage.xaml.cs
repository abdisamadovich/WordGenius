using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Net.Http.Headers;

namespace WordGenius.Pages
{
    /// <summary>
    /// Interaction logic for TranslatePage.xaml
    /// </summary>
    public partial class TranslatePage : Page
    {
        public TranslatePage()
        {
            InitializeComponent();
        }

        private async void btReverse_Click(object sender, RoutedEventArgs e)
        {
            string s =await Translate("uz","en","salom");
            MessageBox.Show(s);

        }

        public static async Task<string> Translate(string from, string to, string text)
        {
            string body;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =  {
                             { "X-RapidAPI-Key", "0e819fdfcemshe3c0ac29f13aefdp102ad9jsn11b845f5385f" },
                             { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
                            },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                 {
                     { "q", "Hello" },
                     { "target", "uz" },
                     { "source", "en" },
                 }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }
            return body;
        }
    }
}
