using CafeMVVM.DAL;
using CafeMVVM.Models;
using CafeMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CafeMVVM.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        List<MenuModel> _MenuCategories;
        List<MenuModel> _MenuList;
        private MenuModel _SelectedMCItem;
        private MenuModel _SelectedMenuItem;
        private string _MCName;
        private string _Menu;
        private object _Price;
        public ICommand AddMCCommand { get; set; }
        public ICommand DeleteMCCommand { get; set; }
        public ICommand AddMenuCommand { get; set; }
        public ICommand DeleteMenuCommand { get; set; }
        public ICommand EditMenuCommand { get; set; }
        MenuDAL menuDAL = new MenuDAL();
        public List<MenuModel> MenuCategories
        {
            get
            {
                return _MenuCategories;
            }

            set
            {
                _MenuCategories = value;
                OnPropertyChanged("MenuCategories");
            }
        }

        public MenuModel SelectedMCItem
        {
            get
            {
                return _SelectedMCItem;
            }

            set
            {
                _SelectedMCItem = value;
                if (_SelectedMCItem != null)
                {
                    MenuList = menuDAL.LoadMenu(SelectedMCItem.Mcid);
                }
            }
        }

        public string Mcname
        {
            get
            {
                return _MCName;
            }

            set
            {
                _MCName = value;
                OnPropertyChanged("Mcname");
            }
        }

        public List<MenuModel> MenuList
        {
            get
            {
                return _MenuList;
            }

            set
            {
                _MenuList = value;
                OnPropertyChanged("MenuList");
            }
        }

        public string Menu
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

        public object Price
        {
            get
            {
                return _Price;
            }

            set
            {
                _Price = double.Parse(value.ToString()).ToString("N0");
            }
        }

        public MenuModel SelectedMenuItem
        {
            get
            {
                return _SelectedMenuItem;
            }

            set
            {
                _SelectedMenuItem = value;
            }
        }

        public MenuViewModel()
        {
            MenuCategories = menuDAL.LoadMenuCategories();
            AddMCCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (Mcname == "" || Mcname == null)
                {
                    MessageBox.Show(GetResource("NotEnterCate"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    menuDAL.AddMenuCategories(Mcname);
                    MenuCategories = menuDAL.LoadMenuCategories();
                }
            });
            DeleteMCCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedMCItem == null)
                {
                    MessageBox.Show(GetResource("SelCateToDel"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(GetResource("DelCate") + ": " + SelectedMCItem.Mcname, "QuestionText", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        menuDAL.DeleteMenuCategories(SelectedMCItem.Mcid);
                        MenuCategories = menuDAL.LoadMenuCategories();
                    }
                }
            });
            AddMenuCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedMCItem == null)
                {
                    MessageBox.Show(GetResource("SelCateToDisplayDisc"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (Menu == "" || Menu == null)
                {
                    MessageBox.Show(GetResource("NotSelDisToAdd"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (Price.ToString() == "" || Price == null)
                {
                    MessageBox.Show(GetResource("NotInputPrice"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    menuDAL.AddMenu(Menu, double.Parse(Price.ToString()), SelectedMCItem.Mcid);
                    MenuList = menuDAL.LoadMenu(SelectedMCItem.Mcid);
                }
            });
            DeleteMenuCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedMenuItem == null)
                {
                    MessageBox.Show(GetResource("SelFoodToDel"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Xóa món: " + SelectedMenuItem.MenuName, "QuestionText", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        menuDAL.DeleteMenu(SelectedMenuItem.MenuId);
                        MenuList = menuDAL.LoadMenu(SelectedMCItem.Mcid);
                    }
                }
            });
            EditMenuCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedMenuItem == null)
                {
                    MessageBox.Show(GetResource("SelDisToEdit"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    menuDAL.EditMenuPrice(SelectedMenuItem.MenuId, double.Parse(Price.ToString()));
                    MenuList = menuDAL.LoadMenu(SelectedMCItem.Mcid);
                }
            });
        }

        public String GetResource(String key)
        {
            return (String)Application.Current.Resources[key];
        }
    }
}
