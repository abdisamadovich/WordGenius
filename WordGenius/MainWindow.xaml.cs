using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WordGenius.Pages;

namespace WordGenius
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

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else this.WindowState = WindowState.Maximized;
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rbHome_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            PageNavigator.Content = homePage;

        }

        private void rbWords_Click(object sender, RoutedEventArgs e)
        {
            WordsPage wordsPage = new WordsPage();
            PageNavigator.Content = wordsPage;
        }

        private void rbTest_Click(object sender, RoutedEventArgs e)
        {
            TestPage testPage = new TestPage();
            PageNavigator.Content = testPage;
        }

        private void rbTranslate_Click(object sender, RoutedEventArgs e)
        {
            TranslatePage translatePage = new TranslatePage();
            PageNavigator.Content = translatePage;
        }

        private void rbAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutPage aboutPage = new AboutPage();
            PageNavigator.Content = aboutPage;
        }


    }
}
