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
using WordGenius.Entities.Translator;
using Newtonsoft.Json;
using System.Net.Http.Json;

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

        private void BtReverse_Click(object sender, RoutedEventArgs e)
        {
            string temp = FromLb.Content.ToString()!;
            FromLb.Content = toLb.Content;
            toLb.Content = temp;
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
                     { "q", $"{text}" },
                     { "target", $"{to}" },
                     { "source", $"{from}" },
                 }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }
            return body;
        }

        private async void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            //string text = new TextRange(rchTb.Document.ContentStart, rchTb.Document.ContentEnd).Text;
            string text = rchTb.Text;
            string from = FromLb.Content.ToString()!;
            string to = toLb.Content.ToString()!;
            string JsonContent = await Translate(from,to,text);
            TranslationResponse transtation = JsonConvert.DeserializeObject<TranslationResponse>(JsonContent);
            translate.Content = transtation.data.translations[0].translatedText;

        }
    }
}
