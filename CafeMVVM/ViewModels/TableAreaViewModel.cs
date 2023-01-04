using CafeMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows;
using CafeMVVM.DAL;
using CafeMVVM.Models;
using CafeMVVM.Views;

namespace CafeMVVM.ViewModels
{
    public class TableAreaViewModel : BaseViewModel
    {
        TableAreaDAL tableAreaDAL = new TableAreaDAL();
        MenuDAL menuDAL = new MenuDAL();
        ReceiptDAL receiptDAL = new ReceiptDAL();
        private TableAreaModel _SelectedItem;
        private MenuModel _SelectedItemMenuCategory;
        private MenuModel _SelectedItemMenuCategoryDiscount;
        private TableAreaModel _SelectedItemTable;
        private TableAreaModel _SelectedInUseTable;
        private TableAreaModel _SelectedEmptyTable;
        private TableAreaModel _SelectedTableToMerge;
        private TableAreaModel _SelectedMergedTable;
        private MenuModel _SelectedMenuTableDiscount;
        private List<TableAreaModel> _Area;
        private List<TableAreaModel> _AreaTable;
        private List<TableAreaModel> _ComparableTable;
        private List<MenuModel> _MenuCategories;
        private List<MenuModel> _Menu;
        private List<TableAreaModel> _InUseTable;
        private List<TableAreaModel> _EmptyTable;
        private List<TableAreaModel> _TableToMerge;
        private List<TableAreaModel> _MergedTable;
        private MenuModel _SelectMenuTable;
        private List<ReceiptModel> _MenuTableList;
        private List<ReceiptModel> _TableReceiptDetailToMerge;
        private List<TableAreaModel> _EmptyTableList;
        private List<ReceiptModel> _ReceiptToBePrintedList;
        private ReceiptModel _SelectMenu;
        private Boolean _EnableGridCategories;
        private object _ReceiptTotal;
        private int _SelectedIndexOfTable;
        private string _ReceiptTitle;
        private int _DiscountPercent;

        public ICommand PaymentCommand { private get; set; }
        public ICommand DeleteMenu { private get; set; }
        public ICommand ChangeTableCommand { private get; set; }
        public ICommand ConfirmChangeTableICommand { private get; set; }
        public ICommand MergeTableCommand { private get; set; }
        public ICommand ConfirmMergeTableCommand { private get; set; }
        public ICommand AddDiscountCommand { private get; set; }
        public ICommand DeleteDiscountCommand { private get; set; }
        public ICommand FindEmptyTableCommand { private get; set; }
        int areaId = 0;
        public TableAreaModel SelectedItem
        {
            get
            {
                return _SelectedItem;
            }

            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    TableArea = tableAreaDAL.LoadTableByArea(_SelectedItem.AreaId);
                    areaId = _SelectedItem.AreaId;
                    MenuTableList = null;
                }
            }
        }

        public List<TableAreaModel> Area
        {
            get
            {
                return _Area;
            }

            set
            {
                _Area = value;
                OnPropertyChanged("Area");
            }
        }

        public List<TableAreaModel> TableArea
        {
            get
            {
                return _AreaTable;
            }

            set
            {
                _AreaTable = value;
                OnPropertyChanged("TableArea");
            }
        }

        public List<MenuModel> MenuCategories
        {
            get
            {
                return _MenuCategories;
            }

            set
            {
                _MenuCategories = value;
            }
        }

        public MenuModel SelectedItemMenuCategory
        {
            get
            {
                return _SelectedItemMenuCategory;
            }

            set
            {
                _SelectedItemMenuCategory = value;
                if (_SelectedItemMenuCategory != null)
                {
                    Menu = menuDAL.LoadMenu(_SelectedItemMenuCategory.MenuId);
                }
                OnPropertyChanged("SelectedItemMenuCategory");
            }
        }

        public List<MenuModel> Menu
        {
            get
            {
                return _Menu;
            }

            set
            {
                _Menu = value;
                OnPropertyChanged("Menu");
            }
        }

        public TableAreaModel SelectedItemTable
        {
            get
            {
                return _SelectedItemTable;
            }

            set
            {
                _SelectedItemTable = value;
                if (_SelectedItemTable != null)
                {
                    index = SelectedIndexOfTable;
                    ReceiptTitle = "Hóa đơn " + SelectedItemTable.TableName + " | " + SelectedItem.AreaName;
                    // LÀM VẦY ĐỂ KHI CẬP NHẬT TRẠNG THÁI BÀN KHI THÊM HÓA ĐƠN . SELECTITEMBAN SẼ NULL VÌ LOAD LẠI TRẠNG THÁI, CÁI NÀY GÁN BIẾN TOÀN CỤC CHO MÃ BÀN VÀ TÊN BÀN
                    SelectedTableId = SelectedItemTable.TableId;
                    SelectedTableName = SelectedItemTable.TableName;
                    EnableGridCategories = true;
                    List<ReceiptModel> receiptList;
                    receiptList = receiptDAL.GetReceiptIDByTableAndArea(SelectedItemTable.TableId, SelectedItem.AreaId);
                    if (receiptList.Count > 0)
                    {
                        ReceiptId = receiptList[0].ReceiptId;
                        MenuTableList = receiptDAL.LoadMenuListOfTable(SelectedItemTable.TableId, ReceiptId);
                        Total = 0;
                        for (int i = 0; i < MenuTableList.Count; i++)
                        {
                            Total = (double)(Total + (MenuTableList[i].Quantity * double.Parse(MenuTableList[i].Price.ToString())));
                        }
                        ReceiptTotal = "Tổng " + SelectedItemTable.TableName + " | " + SelectedItem.AreaName + " : " + double.Parse(Total.ToString()).ToString("N0") + " VND";
                        ReceiptTitle = "Hóa đơn " + SelectedItemTable.TableName + " | " + SelectedItem.AreaName;
                    }
                    else
                    {
                        ReceiptTitle = "";
                        MenuTableList = null;
                        ReceiptTotal = "";
                    }
                }
            }
        }
        private int SelectedTableId = 0;
        string SelectedTableName = "";
        private int ReceiptId = 0;
        public List<ReceiptModel> MenuTableList
        {
            get
            {
                return _MenuTableList;
            }

            set
            {
                _MenuTableList = value;
                OnPropertyChanged("MenuTableList");
            }
        }

        public bool EnableGridCategories
        {
            get
            {
                return _EnableGridCategories;
            }

            set
            {
                _EnableGridCategories = value;
                OnPropertyChanged("EnableGridCategories");
            }
        }
        double Total = 0;
        public MenuModel SelectMenuTable
        {
            get
            {
                return _SelectMenuTable;
            }

            set
            {
                _SelectMenuTable = value;
                if (_SelectMenuTable != null)
                {
                    ReceiptTitle = "Hóa đơn " + SelectedTableName + " | " + SelectedItem.AreaName;
                    if (SelectedItemTable == null)
                    {
                        MessageBox.Show(GetResource("NotSelTbYet"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        List<ReceiptModel> receiptList;
                        receiptList = receiptDAL.GetReceiptIDByTableAndArea(SelectedTableId, SelectedItem.AreaId);
                        if (receiptList.Count > 0)
                        {
                            ReceiptId = receiptList[0].ReceiptId;
                            receiptDAL.AddReceiptDetail(ReceiptId, SelectMenuTable.MenuId, 1, SelectMenuTable.Discount);
                            MenuTableList = receiptDAL.LoadMenuListOfTable(SelectedTableId, ReceiptId);

                            if (MenuTableList.Count > 0)
                            {
                                double Total = 0;
                                for (int i = 0; i < MenuTableList.Count; i++)
                                {
                                    Total = Total + (MenuTableList[i].Quantity * double.Parse(MenuTableList[i].Price.ToString()));
                                }
                                ReceiptTotal = GetResource("TextTotalPrice") + " " + SelectedTableName + " | " + SelectedItem.AreaName + " : " + double.Parse(Total.ToString()).ToString("N0") + " VND";

                            }
                            else
                            {
                                ReceiptTotal = "";
                            }
                            SelectMenuTable = null;
                            OnPropertyChanged("SelectMenuTable");
                        }

                        else
                        {
                            if (SelectedItemTable == null)
                            {
                                MessageBox.Show(GetResource("NotSelTbYet"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                            else
                            {
                                receiptDAL.AddReceipt(DateTime.Now.ToString("yyyy-MM-dd"), SelectedItemTable.TableId);
                                List<ReceiptModel> receiptList1;
                                receiptList1 = receiptDAL.GetReceiptIDByTableAndArea(SelectedTableId, SelectedItem.AreaId);
                                if (receiptList1.Count > 0)
                                {
                                    ReceiptId = receiptList1[0].ReceiptId;
                                    receiptDAL.AddReceiptDetail(ReceiptId, SelectMenuTable.MenuId, 1, SelectMenuTable.Discount);
                                    MenuTableList = receiptDAL.LoadMenuListOfTable(SelectedTableId, ReceiptId);

                                    for (int i = 0; i < MenuTableList.Count; i++)
                                    {
                                        Total = Total + (MenuTableList[i].Quantity * double.Parse(MenuTableList[i].Price.ToString()));
                                    }
                                    ReceiptTotal = GetResource("TextTotalPrice") + " " + SelectedTableName + " | " + SelectedItem.AreaName + " : " + double.Parse(Total.ToString()).ToString("N0") + " VND";

                                }
                                else
                                {
                                    ReceiptTotal = "";
                                }

                                SelectMenuTable = null;
                                OnPropertyChanged("SelectMenuTable");
                            }
                        }
                        TableArea = tableAreaDAL.LoadTableByArea(SelectedItem.AreaId); // load tại trạng thái bàn    
                        SelectedIndexOfTable = index;
                    }
                }
            }
        }

        public object ReceiptTotal
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
        int index = 0;
        public int SelectedIndexOfTable
        {
            get
            {
                return _SelectedIndexOfTable;
            }

            set
            {
                _SelectedIndexOfTable = value;
                OnPropertyChanged("SelectedIndexOfTable");
            }
        }

        public string ReceiptTitle
        {
            get
            {
                return _ReceiptTitle;
            }

            set
            {
                _ReceiptTitle = value;
                OnPropertyChanged("ReceiptTitle");
            }
        }

        public ReceiptModel SelectMenu
        {
            get
            {
                return _SelectMenu;
            }

            set
            {
                _SelectMenu = value;
            }
        }

        public List<TableAreaModel> InUseTable
        {
            get
            {
                return _InUseTable;
            }

            set
            {
                _InUseTable = value;
                OnPropertyChanged("InUseTable");
            }
        }

        public List<TableAreaModel> EmptyTable
        {
            get
            {
                return _EmptyTable;
            }

            set
            {
                _EmptyTable = value;
                OnPropertyChanged("EmptyTable");
            }
        }

        public TableAreaModel SelectedInUseTable
        {
            get
            {
                return _SelectedInUseTable;
            }

            set
            {
                _SelectedInUseTable = value;
            }
        }

        public TableAreaModel SelectedEmptyTable
        {
            get
            {
                return _SelectedEmptyTable;
            }

            set
            {
                _SelectedEmptyTable = value;
            }
        }

        public List<TableAreaModel> TableToMerge
        {
            get
            {
                return _TableToMerge;
            }

            set
            {
                _TableToMerge = value;
                OnPropertyChanged("TableToMerge");
            }
        }

        public List<TableAreaModel> MergedTable
        {
            get
            {
                return _MergedTable;
            }

            set
            {
                _MergedTable = value;
                OnPropertyChanged("MergedTable");
            }
        }

        public TableAreaModel SelectedTableToMerge
        {
            get
            {
                return _SelectedTableToMerge;
            }

            set
            {
                _SelectedTableToMerge = value;
                if (_SelectedTableToMerge != null)
                {
                    MergedTable = tableAreaDAL.LoadMergeTable(SelectedItem.AreaId, _SelectedTableToMerge.TableId);
                }
            }
        }

        public TableAreaModel SelectedMergedTable
        {
            get
            {
                return _SelectedMergedTable;
            }

            set
            {
                _SelectedMergedTable = value;
            }
        }

        public List<ReceiptModel> TableReceiptDetailToMerge
        {
            get
            {
                return _TableReceiptDetailToMerge;
            }

            set
            {
                _TableReceiptDetailToMerge = value;
                OnPropertyChanged("TableReceiptDetailToMerge");
            }
        }

        public MenuModel SelectedItemMenuCategoryDiscount
        {
            get
            {
                return _SelectedItemMenuCategoryDiscount;
            }

            set
            {
                _SelectedItemMenuCategoryDiscount = value;
                if (_SelectedItemMenuCategoryDiscount != null)
                {
                    Menu = menuDAL.LoadMenu(SelectedItemMenuCategoryDiscount.Mcid);
                }
            }
        }

        public MenuModel SelectedMenuTableDiscount
        {
            get
            {
                return _SelectedMenuTableDiscount;
            }

            set
            {
                _SelectedMenuTableDiscount = value;
            }
        }

        public int DiscountPercent
        {
            get
            {
                return _DiscountPercent;
            }

            set
            {
                _DiscountPercent = value;
                OnPropertyChanged("DiscountPercent");
            }
        }

        public List<TableAreaModel> EmptyTableList
        {
            get
            {
                return _EmptyTableList;
            }

            set
            {
                _EmptyTableList = value;
                OnPropertyChanged("EmptyTableList");
            }
        }

        public List<TableAreaModel> ComparableTable
        {
            get
            {
                return _ComparableTable;
            }

            set
            {
                _ComparableTable = value;
                OnPropertyChanged("ComparableTable");
            }
        }

        public List<ReceiptModel> ReceiptToBePrintedList
        {
            get
            {
                return _ReceiptToBePrintedList;
            }

            set
            {
                _ReceiptToBePrintedList = value;
                OnPropertyChanged("ReceiptToBePrintedList");
            }
        }

        private void ReceiptPayment()
        {
            if (SelectedTableId == 0 || SelectedItem == null)
            {
                MessageBox.Show(GetResource("EmptyRecept"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                List<ReceiptModel> receiptList;
                int areaId = SelectedItem.AreaId;
                receiptList = receiptDAL.GetReceiptIDByTableAndArea(SelectedTableId, areaId);
                if (receiptList.Count > 0)
                {
                    receiptDAL.TablePayment(SelectedTableId, receiptList[0].ReceiptId, Total, Variables.accountId);
                    //ThongBao tb = new ThongBao("Thanh toán hóa đơn " + SelectedTableName + " | " + SelectedItem.AreaName + " thành công.", "ThanhCong");
                    //tb.ShowDialog();         
                    //Show hóa đơn, sau này thì chi in trực tiếp  
                    /*ReceiptRpt hdrpt = new ReceiptRpt();
                    hdrpt.RequestParameters = false;
                    hdrpt.DataSource = receiptDAL.LoadMenuListOfTable_rpt(SelectedTableId, receiptList[0].ReceiptId, DateTime.Now.ToShortTimeString().ToString().Substring(0, 5));
                    hdrpt.DataMember = null;*/
                    /*ReportPrintTool toolrpt = new ReportPrintTool(hdrpt);
                    toolrpt.AutoShowParametersPanel = false;                    
                    toolrpt.ShowRibbonPreview();*/
                    //load lại bàn và hóa đơn
                    TableArea = tableAreaDAL.LoadTableByArea(areaId);
                    EnableGridCategories = false;
                    ReceiptTotal = "";
                    ReceiptTitle = "";
                    MenuTableList = null;
                }
            }
        }

        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
        public TableAreaViewModel()
        {
            SelectedIndexOfTable = -1;
            DiscountPercent = 0;
            Area = tableAreaDAL.LoadArea();
            MenuCategories = menuDAL.LoadMenuCategories();
            EnableGridCategories = false;
            PaymentCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                ReceiptPayment();
            });
            DeleteMenu = new RelayCommand<object>((p) => true, (p) =>
            {
                if (ReceiptId == 0)
                {
                    MessageBox.Show(GetResource("EmptyRecept"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (SelectMenu == null)
                {
                    MessageBox.Show(GetResource("SelDisToDel"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    tableAreaDAL.DeleteReceiptDetail(ReceiptId, SelectMenu.MenuId, SelectMenu.Discount);
                    MenuTableList = receiptDAL.LoadMenuListOfTable(SelectedTableId, ReceiptId);
                    if (MenuTableList.Count == 0)
                    {
                        tableAreaDAL.DeleteReceiptWhenOutOfMenu(ReceiptId, SelectedItemTable.TableId);
                        int areaId = SelectedItem.AreaId;
                        TableArea = tableAreaDAL.LoadTableByArea(areaId);
                        MenuTableList = receiptDAL.LoadMenuListOfTable(SelectedTableId, ReceiptId);
                        SelectedIndexOfTable = index;
                    }
                }
            });
            ChangeTableCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedItem == null)
                {
                    MessageBox.Show(GetResource("HaveNotSelectedAnArea"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    EmptyTable = tableAreaDAL.LoadEmptyTable(SelectedItem.AreaId);
                    InUseTable = tableAreaDAL.LoadInUseTable(SelectedItem.AreaId);
                    WindowUtility.ShowFormChangeTable(false, this, (Window)p);
                }
            });
            ConfirmChangeTableICommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedInUseTable == null)
                {
                    MessageBox.Show(GetResource("NotSelTabToMove"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (SelectedEmptyTable == null)
                {
                    MessageBox.Show(GetResource("NotSelEmptyTab"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    tableAreaDAL.ChangeTable(SelectedEmptyTable.TableId, SelectedInUseTable.TableId);
                    TableArea = tableAreaDAL.LoadTableByArea(SelectedItem.AreaId);
                    WindowUtility.ShowFormChangeTable(true, this, (Window)p);
                }
            });
            MergeTableCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedItem == null)
                {
                    MessageBox.Show(GetResource("HaveNotSelectedAnArea"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    TableToMerge = tableAreaDAL.LoadInUseTable(SelectedItem.AreaId);
                    WindowUtility.ShowFormMergeTable(false, this, (Window)p);
                }
            });
            ConfirmMergeTableCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedTableToMerge == null)
                {
                    MessageBox.Show(GetResource("NotSelMergeTb"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (SelectedItem == null)
                {
                    MessageBox.Show(GetResource("HaveNotSelectedAnArea"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (SelectedMergedTable == null)
                {
                    MessageBox.Show(GetResource("NotSelTabToMerge"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    TableReceiptDetailToMerge = tableAreaDAL.LoadMergeTableReceiptDetail(SelectedTableToMerge.TableId);
                    if (TableReceiptDetailToMerge != null)
                    {
                        for (int i = 0; i < TableReceiptDetailToMerge.Count; i++)
                        {
                            receiptDAL.AddReceiptDetail(SelectedMergedTable.ReceiptId, TableReceiptDetailToMerge[i].MenuId, TableReceiptDetailToMerge[i].Quantity, TableReceiptDetailToMerge[i].Discount);
                        }
                        tableAreaDAL.DeleteMergeTableReceipt(SelectedTableToMerge.TableId);
                        TableArea = tableAreaDAL.LoadTableByArea(SelectedItem.AreaId);
                        WindowUtility.ShowFormMergeTable(true, this, (Window)p);
                    }
                }
            });
            AddDiscountCommand = new RelayCommand<object>((p) => true, ((p) =>
            {
                if (SelectedMenuTableDiscount == null)
                {
                    MessageBox.Show(GetResource("NotSelDisToDiscount"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (DiscountPercent < 0)
                {
                    MessageBox.Show(GetResource("DiscountCantBeMinus"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (DiscountPercent > 100)
                {
                    MessageBox.Show(GetResource("CantDiscountMoreThan100"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    menuDAL.AddDiscount(SelectedMenuTableDiscount.MenuId, DiscountPercent);
                    Menu = menuDAL.LoadMenu(SelectedItemMenuCategoryDiscount.Mcid);
                }
            }));
            DeleteDiscountCommand = new RelayCommand<object>((p) => true, ((p) =>
            {
                if (SelectedMenuTableDiscount == null)
                {
                    MessageBox.Show(GetResource("NotSelDisTobeUnDiscount"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    menuDAL.DeleteDiscount(SelectedMenuTableDiscount.MenuId);
                    Menu = menuDAL.LoadMenu(SelectedItemMenuCategoryDiscount.Mcid);
                }
            }));
            FindEmptyTableCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                EmptyTableList = tableAreaDAL.AreaListHasEmptyTable();
                EmptyTableAreaWindow khuvucbantrong = new EmptyTableAreaWindow { DataContext = this };
                khuvucbantrong.ShowDialog();
            });
            Thread Status = new Thread(StatusTimer);
            Status.IsBackground = false;
            Status.Start();
            Thread ThreadPrintReceipt = new Thread(PrintReceiptTimer);
            ThreadPrintReceipt.IsBackground = false;
            ThreadPrintReceipt.Start();
        }
        private void StatusTimer()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer.Start();
        }
        private void PrintReceiptTimer()
        {
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer1.Tick += new EventHandler(PrintReceiptClient);
            dispatcherTimer1.Start();
        }

        private void PrintReceiptClient(object sender, EventArgs e)
        {
            ReceiptToBePrintedList = receiptDAL.LoadReceiptToBePrinted();
            if (ReceiptToBePrintedList.Count > 0)
            {
                for (int i = 0; i < ReceiptToBePrintedList.Count; i++)
                {
                    if (ReceiptToBePrintedList[i].PrintReceipt == 1)
                    {
                        /*ReceiptRpt hdrpt = new ReceiptRpt();
                        hdrpt.RequestParameters = false;
                        hdrpt.DataSource = receiptDAL.LoadMenuListOfTable_rpt(ReceiptToBePrintedList[i].TableId, ReceiptToBePrintedList[i].ReceiptId, DateTime.Now.ToShortTimeString().ToString().Substring(0, 5));
                        hdrpt.DataMember = null;*/
                        /*ReportPrintTool toolrpt = new ReportPrintTool(hdrpt);
                        toolrpt.AutoShowParametersPanel = false;
                        toolrpt.ShowRibbonPreview();*/
                        receiptDAL.UpdatePrintedReceipt(ReceiptToBePrintedList[i].ReceiptId);
                        break;
                    }
                }
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (SelectedItem != null)
            {
                ComparableTable = tableAreaDAL.LoadTableByArea(areaId);
                for (int i = 0; i < TableArea.Count; i++)
                {
                    if (TableArea[i].TableStatus != ComparableTable[i].TableStatus)
                    {
                        TableArea = tableAreaDAL.LoadTableByArea(areaId);
                        break;
                    }
                }
            }
        }
        public String GetResource(String key)
        {
            return (String)Application.Current.Resources[key];
        }
    }
}
