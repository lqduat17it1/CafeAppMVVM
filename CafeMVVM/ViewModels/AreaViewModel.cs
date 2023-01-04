using CafeMVVM.DAL;
using CafeMVVM.Models;
using CafeMVVM.ViewModel;
using CafeMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CafeMVVM.ViewModels
{
    public class AreaViewModel : BaseViewModel
    {
        private List<TableAreaModel> _AreaList;
        private TableAreaModel _SelectedArea;
        private string _AREANAME;
        public ICommand ThongBaoYes { get; set; }
        public ICommand ThongBaoNo { get; set; }
        TableAreaDAL tableAreaDAL = new TableAreaDAL();
        public ICommand AddArea { get; set; }
        public ICommand DeleteArea { get; set; }

        public List<TableAreaModel> AreaList { get { return _AreaList; } set { _AreaList = value; OnPropertyChanged("AreaList"); } }

        public string AREANAME { get { return _AREANAME; } set { _AREANAME = value; OnPropertyChanged("AREANAME"); } }

        public TableAreaModel SelectedArea { get { return _SelectedArea; } set { _SelectedArea = value; } }

        public AreaViewModel()
        {
            bool btnYes = false, btnNo = false;
            AreaList = tableAreaDAL.LoadAreaList();
            AddArea = new RelayCommand<object>((p) => true, (p) =>
            {
                if (AREANAME == null || AREANAME == "")
                {
                    MessageBox.Show(GetResource("TheNameOfTheAreaToBeAddedHasNotBeenEntered"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    tableAreaDAL.AddArea(AREANAME);
                    AreaList = tableAreaDAL.LoadAreaList();
                    AREANAME = "";
                }
            });

            DeleteArea = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedArea == null)
                {
                    MessageBox.Show(GetResource("SelectAnAreaToDelete"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(GetResource("DeleteText") + SelectedArea.AreaName + " ?", GetResource("QuestionText"), MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        tableAreaDAL.DeleteArea(SelectedArea.AreaId);
                        AreaList = tableAreaDAL.LoadAreaList();
                    }
                }

            });
            ThongBaoYes = new RelayCommand<object>((c) => true, (c) =>
            {
                btnYes = true;
            });
            ThongBaoNo = new RelayCommand<object>((c) => true, (c) =>
            {
                btnNo = true;
            });
        }

        public String GetResource(String key)
        {
            return (String)Application.Current.Resources[key];
        }
    }
}
