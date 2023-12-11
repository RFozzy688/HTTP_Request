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

namespace HTTP_Request
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _strSearch;
        string _strUri;
        string _searchSystem;
        public MainWindow()
        {
            InitializeComponent();

            _searchSystem = "Google";
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (TryParseText())
            {
                switch (_searchSystem)
                {
                    case "Google":
                        if (Image.IsChecked == true)
                        {
                            _strUri = $"https://www.google.com/search?q={_strSearch}&tbm=isch";
                        }
                        else
                        {
                            _strUri = $"https://www.google.com/search?q={_strSearch}";
                        }
                        break;
                    case "Bing":
                        if (Image.IsChecked == true)
                        {
                            _strUri = $"https://www.bing.com/images/search?q={_strSearch}&form=HDRSC4";
                        }
                        else
                        {
                            _strUri = $"https://www.bing.com/search?q={_strSearch}";
                        }
                        break;
                    default: 
                        break;
                }

                Browser.Navigate(new Uri(_strUri));
            }
        }
        private bool TryParseText()
        {
            if (TextSearch.Text != string.Empty)
            {
                string[] str = TextSearch.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                _strSearch = string.Join("+", str);

                return true;
            }
            else
            {
                MessageBox.Show("Строка для поиска пустая!");
                return false;
            }
        }
        private void Google_Click(object sender, RoutedEventArgs e)
        {
            _searchSystem = "Google";
        }
        private void Bing_Click(object sender, RoutedEventArgs e)
        {
            _searchSystem = "Bing";
        }
    }
}
