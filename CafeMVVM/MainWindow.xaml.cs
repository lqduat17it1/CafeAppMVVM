using CafeMVVM.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CafeMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public int currentTabIndex;
        public MainWindow()
        {
            SwitchLanguage("en");
            InitializeComponent();
            mainWindow = this;
        }

        private void Exit_Clicked(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void SwitchLanguage(String langCode)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            switch (langCode)
            {
                case "en":
                    dictionary.Source = new Uri("ResourceXAML\\Lang.en.xaml", UriKind.Relative);
                    break;
                case "vi":
                    dictionary.Source = new Uri("ResourceXAML\\Lang.vi.xaml", UriKind.Relative);
                    break;
                default:
                    break;
            }
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowInTaskbar = false;
            loginWindow.Show();
            currentTabIndex = 0;
        }

        public void GrantPermission(string role)
        {
            Window.IsEnabled = true;
            if (role.ToUpper() == "ADMIN")
            {
                PBTab.IsEnabled = true;
                AreaTab.IsEnabled = true;
                TableTab.IsEnabled = true;
                MenuTab.IsEnabled = true;
                DiscountTab.IsEnabled = true;
                StatisticTab.IsEnabled = true;
                AccountTab.IsEnabled = true;
                SettingTab.IsEnabled = true;
                ExitTab.IsEnabled = true;
                LogoutTab.IsEnabled = true;
            }
            else if (role.ToUpper() == "USER")
            {
                PBTab.IsEnabled = true;
                ExitTab.IsEnabled = true;
                LogoutTab.IsEnabled = true;
                AreaTab.IsEnabled = false;
                TableTab.IsEnabled = false;
                MenuTab.IsEnabled = false;
                DiscountTab.IsEnabled = false;
                StatisticTab.IsEnabled = false;
                AccountTab.IsEnabled = false;
                SettingTab.IsEnabled = true;
            }
        }

        private void Logout_Clicked(object sender, MouseButtonEventArgs e)
        {
            Window.IsEnabled = false;
            PBTab.IsEnabled = false;
            AreaTab.IsEnabled = false;
            TableTab.IsEnabled = false;
            MenuTab.IsEnabled = false;
            DiscountTab.IsEnabled = false;
            StatisticTab.IsEnabled = false;
            AccountTab.IsEnabled = false;
            SettingTab.IsEnabled = false;
            ExitTab.IsEnabled = false;
            LogoutTab.IsEnabled = false;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl.SelectedIndex != currentTabIndex)
            {
                currentTabIndex = tabControl.SelectedIndex;
                switch (tabControl.SelectedIndex)
                {
                    case 0:
                        frmOrder.Refresh();
                        break;
                    case 1:
                        frmArea.Refresh();
                        break;
                    case 2:
                        frmTable.Refresh();
                        break;
                    case 3:
                        frmMenu.Refresh();
                        break;
                    case 4:
                        frmDiscount.Refresh();
                        break;
                    case 5:
                        frmStatistic.Refresh();
                        break;
                    case 6:
                        frmAccount.Refresh();
                        break;
                    case 7:
                        frmSetting.Refresh();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
