﻿using System;
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
using WordGenius.windows.Words;

namespace WordGenius.Pages
{
    /// <summary>
    /// Interaction logic for WordsPage.xaml
    /// </summary>
    public partial class WordsPage : Page
    {
        public WordsPage()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            WordsCreateWindow wordsCreateWindow = new WordsCreateWindow();
            wordsCreateWindow.ShowDialog();
        }
    }
}
