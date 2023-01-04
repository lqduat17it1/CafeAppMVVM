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
        private Boolean _Admin;
        private Boolean _User;
        private string _Username;
        private string _Password;
        private string _FullName;
        private string _Status;
        public ICommand AddNewAccountCommand { get; set; }
        public ICommand DeleteAccountCommand { get; set; }
        public ICommand ResetPasswordCommand { get; set; }
        public ICommand rdAdmin { get; set; }
        public ICommand rdUser { get; set; }
        public ICommand LoginCommand { get; set; }
        public List<AccountModel> AccountList { get { return _AccountList; } set { _AccountList = value; OnPropertyChanged("AccountList"); } }

        public string Username { get { return _Username; } set { _Username = value; OnPropertyChanged("Username"); } }

        public string Password { get { return _Password; } set { _Password = value; OnPropertyChanged("Password"); } }

        public bool Admin { get { return _Admin; } set { _Admin = value; OnPropertyChanged("Admin"); } }

        public bool User { get { return _User; } set { _User = value; OnPropertyChanged("User"); } }

        public string FullName { get { return _FullName; } set { _FullName = value; OnPropertyChanged("FullName"); } }

        public AccountModel SelectedAccount { get { return _SelectedAccount; } set { _SelectedAccount = value; } }

        public string Status { get { return _Status; } set { _Status = value; OnPropertyChanged("Status"); } }

        public AccountViewModel()
        {
            Username = "";
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
                if (FullName == null || FullName == "")
                {
                    MessageBox.Show(GetResource("FullNameHasNotBeenEntered"), GetResource("WarningText"), MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (Username == null || Username == "")
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
                        accountModel.Username = Username;
                        accountModel.Password = encode(p.Password);
                        accountModel.FullName = FullName;
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
                        Username = "";
                        p.Password = "";
                        FullName = "";
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
                    MessageBox.Show(GetResource("PleaseSelectTheAccountOnTheListToResetThePassword"), GetResource("InformationText"), MessageBoxButton.OK, MessageBoxImage.Warning);
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
                if (String.IsNullOrEmpty(Username))
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
                    accountModel.Username = Username;
                    List<AccountModel> AccountList = new List<AccountModel>();
                    AccountList = AccountDAL.LoginCheck(accountModel);
                    if (AccountList.Count > 0)
                    {
                        if (encode(p.Password) == AccountList[0].Password)
                        {
                            //BienDungChung.idnhanvien = AccountList[0].Username;
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
