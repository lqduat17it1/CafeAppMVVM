using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CafeMVVM.Views;

namespace CafeMVVM.ViewModels
{
    public class WindowUtility : Window
    {
        public static void ShowFormEditTable(bool closeForm, TableViewModel tableViewModel, Window wd)
        {
            EditTableWindow editTableWindow = new EditTableWindow { DataContext = tableViewModel };
            if (closeForm == false)
            {
                editTableWindow.ShowDialog();
            }
            else if (closeForm == true)
            {
                editTableWindow.Close();
                wd.Close();
            }
        }
        public static void ShowFormChangeTable(bool closeForm, TableAreaViewModel areaViewModel, Window wd)
        {
            ChangeTableWindow changeTableWindow = new ChangeTableWindow { DataContext = areaViewModel };
            if (closeForm == false)
            {
                changeTableWindow.ShowDialog();
            }
            else if (closeForm == true)
            {
                changeTableWindow.Close();
                wd.Close();
            }
        }
        public static void ShowFormMergeTable(bool closeForm, TableAreaViewModel areaViewModel, Window wd)
        {
            MergeTableWindow mergeTableWindow = new MergeTableWindow { DataContext = areaViewModel };
            if (closeForm == false)
            {
                mergeTableWindow.ShowDialog();
            }
            else if (closeForm == true)
            {
                mergeTableWindow.Close();
                wd.Close();
            }
        }
    }
}
