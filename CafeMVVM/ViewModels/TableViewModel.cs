using CafeMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using CafeMVVM.Models;
using CafeMVVM.DAL;
using System.Collections;

namespace CafeMVVM.ViewModels
{
    public class TableViewModel : BaseViewModel
    {
        private List<TableAreaModel> _TableList;
        private List<TableAreaModel> _AreaList;
        private TableAreaModel _SelectedArea;
        private TableAreaModel _SelectedTable;
        private string _NumberOfTables;
        private string _TableName;
        public ICommand AddTableCommand { get; set; }
        public ICommand DeleteTableCommand { get; set; }
        public ICommand EditTableCommand { get; set; }
        public ICommand EditTableFormCommand { get; set; }
        TableAreaDAL areaDAL = new TableAreaDAL();

        public List<TableAreaModel> TableList
        {
            get
            {
                return _TableList;
            }

            set
            {
                _TableList = value;
                OnPropertyChanged("TableList");
            }
        }

        public List<TableAreaModel> AreaList
        {
            get
            {
                return _AreaList;
            }

            set
            {
                _AreaList = value;
            }
        }

        public string NumberOfTables
        {
            get
            {
                return _NumberOfTables;
            }

            set
            {
                _NumberOfTables = value;
                OnPropertyChanged("NumberOfTables");
            }
        }

        public TableAreaModel SelectedArea
        {
            get
            {
                return _SelectedArea;
            }

            set
            {
                _SelectedArea = value;
                if (_SelectedArea != null)
                {
                    TableList = areaDAL.TableList(_SelectedArea.AreaId);
                }
            }
        }

        public TableAreaModel SelectedTable
        {
            get
            {
                return _SelectedTable;
            }

            set
            {
                _SelectedTable = value;
            }
        }

        public string TableName
        {
            get
            {
                return _TableName;
            }

            set
            {
                _TableName = value;
                OnPropertyChanged("TableName");
            }
        }

        public TableViewModel()
        {
            AreaList = areaDAL.LoadArea();
            AddTableCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedArea == null)
                {
                    MessageBox.Show(GetResource("HaveNotSelectedAnAreaToAddATableYet"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (NumberOfTables == null || int.Parse(NumberOfTables) == 0)
                {
                    MessageBox.Show(GetResource("HaveNotEnteredTheAmountYouNeedToAdd"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    int currentNumberOfTables = 0;
                    for (int i = 1; i <= int.Parse(NumberOfTables); i++)
                    {
                        currentNumberOfTables = TableList.Count;
                        currentNumberOfTables = currentNumberOfTables + 1;
                        areaDAL.AddTable(GetResource("TableText") + " " + currentNumberOfTables, SelectedArea.AreaId);
                        TableList = areaDAL.TableList(SelectedArea.AreaId);
                    }
                }
            });
            DeleteTableCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedTable == null)
                {
                    MessageBox.Show(GetResource("SelectTheTableOnTheListToDelete"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(GetResource("DeleteText") + SelectedTable.TableName + " ?", GetResource("QuestionText"), MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        areaDAL.DeleteTable(SelectedTable.TableId);
                        TableList = areaDAL.TableList(SelectedArea.AreaId);
                    }
                }
            });
            EditTableCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                //WindowService.ShowFormSuaBan(false, this, (Window)p);
            });

            EditTableFormCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedTable == null)
                {
                    MessageBox.Show(GetResource("SelectTheTableOnTheListToEdit"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (TableName == "" || TableName == null)
                {
                    MessageBox.Show(GetResource("TheTableNameHasNotBeenEntered"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    areaDAL.EditTable(SelectedTable.TableId, TableName);
                    TableList = areaDAL.TableList(SelectedArea.AreaId);
                    //WindowService.ShowFormSuaBan(true, this, (Window)p);
                }
            });
        }
        public String GetResource(String key)
        {
            return (String)Application.Current.Resources[key];
        }
    }
}
