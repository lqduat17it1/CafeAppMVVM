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

namespace CafeMVVM.Views
{
    /// <summary>
    /// Interaction logic for SettingPage.xaml
    /// </summary>
    public partial class SettingPage : Page
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        private void SwitchLanguage(String langCode)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            switch (langCode)
            {
                case "en":
                    dictionary.Source = new Uri("..\\..\\ResourceXAML\\Lang.en.xaml", UriKind.Relative);
                    break;
                case "vi":
                    dictionary.Source = new Uri("..\\..\\ResourceXAML\\Lang.vi.xaml", UriKind.Relative);
                    break;
                default:
                    break;
            }
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }

        private void cbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLanguage.SelectedIndex == 0)
            {
                SwitchLanguage("en");
            }
            else
            {
                SwitchLanguage("vi");
            }
        }
    }
}
