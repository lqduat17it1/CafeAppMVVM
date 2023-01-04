using CafeMVVM.DAL;
using CafeMVVM.Models;
using CafeMVVM.ViewModel;
using CafeMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CafeMVVM.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        List<AccountModel> _AccountList;
        AccountDAL AccountDAL = new AccountDAL();
        AccountModel _SelectedAccount;
        private Boolean _ADMIN;
        private Boolean _USER;
        private string _USERNAME;
        private string _PASSWORD;
        private string _FULLNAME;
        private string _Status;
        public ICommand AddNewAccountCommand { get; set; }
        public ICommand DeleteAccountCommand { get; set; }
        public ICommand ResetPasswordCommand { get; set; }
        public ICommand rdAdmin { get; set; }
        public ICommand rdUser { get; set; }
        public ICommand LoginCommand { get; set; }
        public List<AccountModel> AccountList { get { return _AccountList; } set { _AccountList = value; OnPropertyChanged("AccountList"); } }

        public string USERNAME { get { return _USERNAME; } set { _USERNAME = value; OnPropertyChanged("USERNAME"); } }

        public string PASSWORD { get { return _PASSWORD; } set { _PASSWORD = value; OnPropertyChanged("PASSWORD"); } }

        public bool ADMIN { get { return _ADMIN; } set { _ADMIN = value; OnPropertyChanged("ADMIN"); } }

        public bool USER { get { return _USER; } set { _USER = value; OnPropertyChanged("USER"); } }

        public string FULLNAME { get { return _FULLNAME; } set { _FULLNAME = value; OnPropertyChanged("FULLNAME"); } }

        public AccountModel SelectedAccount { get { return _SelectedAccount; } set { _SelectedAccount = value; } }

        public string Status { get { return _Status; } set { _Status = value; OnPropertyChanged("Status"); } }

        public AccountViewModel()
        {
            USERNAME = "";
            AccountList = AccountDAL.LoadAccount();
            bool AdminRole = false, UserRole = false;
            rdAdmin = new RelayCommand<RadioButton>((p) => true, (p) =>
            {
                if (p.IsChecked == true)
                {
                    AdminRole = true;
                    UserRole = false;
                }
                else
                {
                    AdminRole = false;
                    UserRole = true;
                }
            });
            rdUser = new RelayCommand<RadioButton>((p) => true, (p) =>
            {
                if (p.IsChecked == true)
                {
                    UserRole = true;
                    AdminRole = false;
                }
                else
                {
                    UserRole = false;
                    AdminRole = true;
                }
            });
            AddNewAccountCommand = new RelayCommand<PasswordBox>((p) => true, (p) =>
            {
                if (FULLNAME == null || FULLNAME == "")
                {
                    MessageBox.Show(GetResource("FullNameHasNotBeenEntered"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (USERNAME == null || USERNAME == "")
                {
                    MessageBox.Show(GetResource("UsernameHasNotBeenEntered"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (p == null || string.IsNullOrEmpty(p.Password))
                {
                    MessageBox.Show(GetResource("PasswordHasNotBeenEntered"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (AdminRole == false && UserRole == false)
                {
                    MessageBox.Show(GetResource("RoleHasNotBeenSelected"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else
                {
                    try
                    {

                        AccountModel accountModel = new AccountModel();
                        accountModel.Username = USERNAME;
                        accountModel.Password = encode(p.Password);
                        accountModel.FullName = FULLNAME;
                        if (AdminRole == true)
                        {
                            accountModel.Role = "Admin";
                        }
                        else if (UserRole == true)
                        {
                            accountModel.Role = "User";
                        }
                        AccountDAL.AddNewAccount(accountModel);
                        AccountList = AccountDAL.LoadAccount();
                        USERNAME = "";
                        p.Password = "";
                        FULLNAME = "";
                    }
                    catch
                    {
                        MessageBox.Show(GetResource("UsernameAlreadyExists"), GetResource("InformationText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            });
            DeleteAccountCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedAccount == null)
                {
                    MessageBox.Show(GetResource("PleaseSelectTheAccountOnTheListToDelete"), GetResource("InformationText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(GetResource("DeleteTheAccount") + ": " + SelectedAccount.Username + " ?", GetResource("DeleteAccount"), MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        AccountModel accountModel = new AccountModel();
                        accountModel.Username = SelectedAccount.Username;
                        AccountDAL.DeleteAccount(accountModel);
                        AccountList = AccountDAL.LoadAccount();
                    }
                }
            });
            ResetPasswordCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedAccount == null)
                {
                    MessageBox.Show(GetResource(""), "Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(GetResource("PasswordWillBeResetTo") + ": 123", "Reset Password", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        AccountModel accountModel = new AccountModel();
                        accountModel.Username = SelectedAccount.Username;
                        AccountDAL.ResetPassword(accountModel);
                        AccountList = AccountDAL.LoadAccount();
                    }
                }
            });
            LoginCommand = new RelayCommand<PasswordBox>((p) => true, (p) =>
            {
                if (USERNAME == null || USERNAME == "")
                {
                    Status = GetResource("UsernameNotEntered");
                }
                else if (p == null | p.Password == "")
                {
                    Status = GetResource("PasswordNotEntered");
                }
                else
                {
                    AccountModel accountModel = new AccountModel();
                    accountModel.Username = USERNAME;
                    List<AccountModel> AccountList = new List<AccountModel>();
                    AccountList = AccountDAL.LoginCheck(accountModel);
                    if (AccountList.Count > 0)
                    {
                        if (encode(p.Password) == AccountList[0].Password)
                        {
                            //BienDungChung.idnhanvien = AccountList[0].USERNAME;
                            MainWindow.mainWindow.GrantPermission(AccountList[0].Role);
                            //PageNen.pnen.setquyen(AccountList[0].HOFULLNAME, AccountList[0].QUYEN);
                            LoginWindow.loginWindow.Close();
                        }
                        else
                        {
                            Status = GetResource("WrongPassword");
                        }
                    }
                    else
                    {
                        Status = GetResource("UsernameIsIncorrect");
                    }
                }
            });
        }

        public string encode(string password)
        {
            try
            {
                MD5 md5 = MD5.Create();
                StringBuilder strBuilder = new StringBuilder();
                Byte[] bMd5 = md5.ComputeHash(Encoding.Default.GetBytes(password));
                for (int iloop = 0; iloop < bMd5.Length; iloop++)
                {
                    strBuilder.Append(bMd5[iloop].ToString("x2"));
                }
                return strBuilder.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public String GetResource(String key)
        {
            return (String)Application.Current.Resources[key];
        }
    }
}
