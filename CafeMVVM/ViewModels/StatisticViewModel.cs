using CafeMVVM.DAL;
using CafeMVVM.Models;
using CafeMVVM.ViewModel;
using CafeMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CafeMVVM.ViewModels
{
    public class StatisticViewModel : BaseViewModel
    {
        private List<StatisticModel> _MenuStatisticList;
        private List<StatisticModel> _DefaultList;
        private List<StatisticModel> _ReceiptDetail;
        private StatisticModel _SelectedDefaultRevenue;
        private string _CbDay_Menu;
        private string _CbMonth_Menu;
        private object _Date_Elective_Menu;
        private string _CbDay_Revenue;
        private string _CbMonth_Revenue;
        private object _Date_Elective_Revenue;
        public ICommand MenuStatisticCommand { get; set; }
        public ICommand RevenueStatisticCommand { get; set; }
        public ICommand rdDayCommand { get; set; }
        public ICommand rdMonthCommand { get; set; }
        public ICommand rdElectiveCommand { get; set; }
        public ICommand rdDayCommand_dt { get; set; }
        public ICommand rdMonthCommand_dt { get; set; }
        public ICommand rdElectiveCommand_dt { get; set; }
        private string _NumberOfReceipt;
        private string _ReceiptTotal;
        StatisticDAL statisticDAL = new StatisticDAL();

        public List<StatisticModel> MenuStatisticList
        {
            get
            {
                return _MenuStatisticList;
            }

            set
            {
                _MenuStatisticList = value;
                OnPropertyChanged("MenuStatisticList");
            }
        }

        public List<StatisticModel> DefaultList
        {
            get
            {
                return _DefaultList;
            }

            set
            {
                _DefaultList = value;
                OnPropertyChanged("DefaultList");
            }
        }

        public string NumberOfReceipt
        {
            get
            {
                return _NumberOfReceipt;
            }

            set
            {
                _NumberOfReceipt = value;
                OnPropertyChanged("NumberOfReceipt");
            }
        }

        public string ReceiptTotal
        {
            get
            {
                return _ReceiptTotal;
            }

            set
            {
                _ReceiptTotal = value;
                OnPropertyChanged("ReceiptTotal");
            }
        }

        public StatisticModel SelectedDefaultRevenue
        {
            get
            {
                return _SelectedDefaultRevenue;
            }

            set
            {
                _SelectedDefaultRevenue = value;
                if (_SelectedDefaultRevenue != null)
                {
                    ReceiptDetail = statisticDAL.LoadMenuListOfTable_Statistics(SelectedDefaultRevenue.ReceiptID);
                    ReceiptDetailWindow detail = new ReceiptDetailWindow { DataContext = this };
                    detail.ShowDialog();
                }
                OnPropertyChanged("SelectedDefaultRevenue");
            }
        }

        public List<StatisticModel> ReceiptDetail
        {
            get
            {
                return _ReceiptDetail;
            }

            set
            {
                _ReceiptDetail = value;
                OnPropertyChanged("ReceiptDetail");
            }
        }

        public string CbDay_Menu
        {
            get
            {
                return _CbDay_Menu;
            }

            set
            {
                _CbDay_Menu = value;
                OnPropertyChanged("CbDay_Menu");
            }
        }

        public string CbMonth_Menu
        {
            get
            {
                return _CbMonth_Menu;
            }

            set
            {
                _CbMonth_Menu = value;
                OnPropertyChanged("CbMonth_Menu");
            }
        }

        public object Date_Elective_Menu
        {
            get
            {
                return _Date_Elective_Menu;
            }

            set
            {
                _Date_Elective_Menu = value;
                OnPropertyChanged("Date_Elective_Menu");
            }
        }

        public string CbDay_Revenue
        {
            get
            {
                return _CbDay_Revenue;
            }

            set
            {
                _CbDay_Revenue = value;
                OnPropertyChanged("CbDay_Revenue");
            }
        }

        public string CbMonth_Revenue
        {
            get
            {
                return _CbMonth_Revenue;
            }

            set
            {
                _CbMonth_Revenue = value;
                OnPropertyChanged("CbMonth_Revenue");
            }
        }

        public object Date_Elective_Revenue
        {
            get
            {
                return _Date_Elective_Revenue;
            }

            set
            {
                _Date_Elective_Revenue = value;
                OnPropertyChanged("Date_Elective_Revenue");
            }
        }
        private void ReceiptBill()
        {
            if (DefaultList != null)
            {
                double total = 0;
                for (int i = 0; i < DefaultList.Count; i++)
                {
                    total = total + double.Parse(DefaultList[i].TotalPayment.ToString());
                }
                NumberOfReceipt = "Tổng số lượng hóa đơn: " + DefaultList.Count.ToString();
                ReceiptTotal = "Tồng tiền: " + double.Parse(total.ToString()).ToString("N0") + " Vnđ";
            }
            else
            {
                NumberOfReceipt = "";
                ReceiptTotal = "";
            }
        }
        private void MenuBill()
        {
            if (MenuStatisticList != null)
            {
                double total = 0;
                for (int i = 0; i < MenuStatisticList.Count; i++)
                {
                    total = total + double.Parse(MenuStatisticList[i].TotalPayment.ToString());
                }
                NumberOfReceipt = "";
                ReceiptTotal = "Tồng tiền: " + double.Parse(total.ToString()).ToString("N0") + " Vnđ";
            }
            else
            {
                NumberOfReceipt = "";
                ReceiptTotal = "";
            }
        }
        public StatisticViewModel()
        {
            bool daymenu = false, monthmenu = false, electivemenu = false;
            bool dayrevenue = false, monthrevenue = false, electiverevenue = false;
            DefaultList = statisticDAL.RevenueByDay(DateTime.Now.Day);
            ReceiptBill();
            rdDayCommand = new RelayCommand<object>((p) => true, (p) => { daymenu = true; monthmenu = false; electivemenu = false; });
            rdMonthCommand = new RelayCommand<object>((p) => true, (p) => { daymenu = false; monthmenu = true; electivemenu = false; });
            rdElectiveCommand = new RelayCommand<object>((p) => true, (p) => { daymenu = false; monthmenu = false; electivemenu = true; });
            rdDayCommand_dt = new RelayCommand<object>((p) => true, (p) => { dayrevenue = true; monthrevenue = false; electiverevenue = false; });
            rdMonthCommand_dt = new RelayCommand<object>((p) => true, (p) => { dayrevenue = false; monthrevenue = true; electiverevenue = false; });
            rdElectiveCommand_dt = new RelayCommand<object>((p) => true, (p) => { dayrevenue = false; monthrevenue = false; electiverevenue = true; });
            MenuStatisticCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (daymenu == true)
                {
                    if (CbDay_Menu == null || CbDay_Menu == "")
                    {
                        MessageBox.Show("Chưa chọn ngày", GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        MenuStatisticList = statisticDAL.MenuStatisticsByDay(int.Parse(CbDay_Menu.ToString()));
                        MenuBill();
                    }
                }
                else if (monthmenu == true)
                {
                    if (CbMonth_Menu == null || CbMonth_Menu == "")
                    {
                        MessageBox.Show("Chưa chọn tháng", GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        MenuStatisticList = statisticDAL.MenuStatisticsByMonth(int.Parse(CbMonth_Menu.ToString()));
                        MenuBill();
                    }
                }
                else if (electivemenu == true)
                {
                    if (Date_Elective_Menu == null || Date_Elective_Menu.ToString() == "")
                    {
                        MessageBox.Show("Chưa chọn ngày cụ thể", GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        MenuStatisticList = statisticDAL.MenuStatisticsByYear(DateTime.Parse(Date_Elective_Menu.ToString()).ToString("yyyy-MM-dd"));
                        MenuBill();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn thời gian cần thống kê!", GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                    MenuBill();
                }

            });
            RevenueStatisticCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (dayrevenue == true)
                {
                    if (CbDay_Revenue == null || CbDay_Revenue == "")
                    {
                        MessageBox.Show("Chưa chọn ngày", GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        DefaultList = statisticDAL.RevenueByDay(int.Parse(CbDay_Revenue));
                        ReceiptBill();
                    }
                }
                else if (monthrevenue == true)
                {
                    if (CbMonth_Revenue == null || CbMonth_Revenue == "")
                    {
                        MessageBox.Show("Chưa chọn tháng", GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        DefaultList = statisticDAL.RevenueByMonth(int.Parse(CbMonth_Revenue));
                        ReceiptBill();
                    }
                }
                else if (electiverevenue == true)
                {
                    if (Date_Elective_Revenue == null || Date_Elective_Revenue.ToString() == "")
                    {
                        MessageBox.Show("Chưa chọn ngày cụ thể", GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        DefaultList = statisticDAL.RevenueByYear(DateTime.Parse(Date_Elective_Revenue.ToString()).ToString("yyyy-MM-dd"));
                        ReceiptBill();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn thời gian cần thống kê!", GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                    ReceiptBill();
                }

            });
        }
        public String GetResource(String key)
        {
            return (String)Application.Current.Resources[key];
        }
    }
}
