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
        List<string> _towns;
        string _selectedObl;
        string _selectedTown;
        public MainWindow()
        {
            InitializeComponent();

            _searchSystem = "Google";

            _towns = new List<string>();
            _towns.Add("Сімферополь");
            _towns.Add("Вінниця");
            _towns.Add("Луцьк");
            _towns.Add("Дніпро");
            _towns.Add("Донецьк");
            _towns.Add("Житомир");
            _towns.Add("Ужгород");
            _towns.Add("Запоріжжя");
            _towns.Add("Івано-Франківськ");
            _towns.Add("Київ");
            _towns.Add("Кропивницький");
            _towns.Add("Луганськ");
            _towns.Add("Львів");
            _towns.Add("Миколаїв");
            _towns.Add("Одеса");
            _towns.Add("Полтава");
            _towns.Add("Рівне");
            _towns.Add("Суми");
            _towns.Add("Тернопіль");
            _towns.Add("Харків");
            _towns.Add("Херсон");
            _towns.Add("Хмельницький");
            _towns.Add("Черкаси");
            _towns.Add("Чернівці");
            _towns.Add("Чернігів");

            NameObl.Items.Add("АР Крим");
            NameObl.Items.Add("Вінницька область");
            NameObl.Items.Add("Волинська область");
            NameObl.Items.Add("Дніпропетровська область");
            NameObl.Items.Add("Донецька область");
            NameObl.Items.Add("Житомирська область");
            NameObl.Items.Add("Закарпатська область");
            NameObl.Items.Add("Запорізька область");
            NameObl.Items.Add("Івано - Франківська область");
            NameObl.Items.Add("Київська область");
            NameObl.Items.Add("Кіровоградська область");
            NameObl.Items.Add("Луганська область");
            NameObl.Items.Add("Львівська область");
            NameObl.Items.Add("Миколаївська область");
            NameObl.Items.Add("Одеська область");
            NameObl.Items.Add("Полтавська область");
            NameObl.Items.Add("Рівненська область");
            NameObl.Items.Add("Сумська область");
            NameObl.Items.Add("Тернопільська область");
            NameObl.Items.Add("Харківська область");
            NameObl.Items.Add("Херсонська область");
            NameObl.Items.Add("Хмельницька область");
            NameObl.Items.Add("Черкаська область");
            NameObl.Items.Add("Чернівецька область");
            NameObl.Items.Add("Чернігівська область");

            _selectedObl = string.Empty;
            _selectedTown = string.Empty;
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
        private void NameObl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SevenDays.IsChecked == true)
            {
                SevenDays_Click(null, null);
            }
            else if (TenDays.IsChecked == true)
            {
                TenDays_Click(null, null);
            }
        }
        private void MyTabControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NameObl.SelectedIndex = 14;
            SevenDays.IsChecked = true;

            if (MyTabControl.SelectedIndex == 1)
            {
                Browser.Navigate(new Uri($"https://ua.sinoptik.ua/погода-{_towns[NameObl.SelectedIndex]}"));
            }
            else
            {
                Browser.Navigate((Uri)null);
            }
        }
        private void WeatherOnMap_Click(object sender, RoutedEventArgs e)
        {
            if (NameObl.SelectedIndex != -1)
            {
                _selectedObl = NameObl.Items[NameObl.SelectedIndex].ToString().Replace(' ', '-').ToLower();
                Browser.Navigate(new Uri($"https://ua.sinoptik.ua/україна/{_selectedObl}"));
            }
            else
            {
                Browser.Navigate(new Uri($"https://ua.sinoptik.ua/україна"));
            }
        }
        private void SevenDays_Click(object sender, RoutedEventArgs e)
        {
            Browser.Navigate(new Uri($"https://ua.sinoptik.ua/погода-{_towns[NameObl.SelectedIndex]}"));
        }
        private void TenDays_Click(object sender, RoutedEventArgs e)
        {
            Browser.Navigate(new Uri($"https://ua.sinoptik.ua/погода-{_towns[NameObl.SelectedIndex]}/10-днів"));
        }
    }
}
