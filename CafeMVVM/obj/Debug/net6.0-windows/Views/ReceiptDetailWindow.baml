   M S B A M L   `   `   `  ????C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels  5   	   (    "CafeMVVM.Views.ReceiptDetailWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CafeMVVM.ViewModels     5   	   c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	      MaterialDesignBody#???   5	   	   $??Regular"?5
   	   $??13(?5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5   	      TextRenderingMode$
 Auto=?5   	     MaterialDesignPaper#???  5   	     MaterialDesignFont#???  5   	    ? 
ResizeMode$ NoResize=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Title$ ReceiptDetailWindow??5   	   $	??450??6%   $	??800??62    ? Triggers 5      :? 5   
    :? RoutedEvent$ Window.Loaded??6   [?5      ?? 5      .??5      ??  g? 	BeginTime 06!    g? Duration$ ForeverD?6/   .??5      W? 	 ?? 
TargetName$	 
wchitiethd??6*   $ 00:00:01D?6M   
 ?? TargetProperty$
 Opacity?6a    W? From 06?   	 W? To 16?   5      5      5       ? DataContext 5      ,   &CafeMVVM.ViewModels.StatisticViewModel  5   
   6%   .??5!      ?  ? RowDefinitions 5"   
   ?? 5#      $
??Auto ?6   6,   ?? 5$      6   ?? 5%      $
??Auto ?6   6,   .+?5'   
   (  "MaterialDesignThemes.Wpf.ColorZone  .??5(      ?? $??20??6   6"   5)      &   System.Windows.Controls.DataGrid  5*   
   $??5q?6      AutoGenerateColumns$ False??6      
IsReadOnly$
 True??6:   $??1??6?   ??6L   ?? *ReceiptDetail+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?   Columns 5+      4  .System.Windows.Controls.DataGridTemplateColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$
 Món??6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 66      HeaderStyle 5-      ?? 5.       ?? 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6    .?5/      ??  ?? Property ? ?? ?? Value$ Center=?6K   6\   ?? 50       ? ??$ Segoe UI)?6;   6N   ?? 51       ? ??$ 15(?69   6F   ?? 52       ? ??$
 Bold"?6;   6J   ?? 53       ? ??
 ??  ?6J   54         CellTemplate 56      ?? 57      .R?58      ?? $??Segoe UI)?6A   $??15(?6W   
???   ?$??Center=?6x   ??6$   ?? *
MenuName+6?   59      5;        5<      $ 
Đơn giá??6)   $ * 6:    5=      ?? 5>      "  6    .?5?      ??  ? ??$ Center=?6K   6\   ?? 5@       ? ??$ Segoe UI)?6;   6N   ?? 5A       ? ??$ 15(?69   6F   ?? 5B       ? ??$
 Bold"?6;   6J   ?? 5C       ? ??
 ??  ?6J   5D       5F      ?? 5G      .R?5H      ?? $??Segoe UI)?6>   $??15(?6T   
???   ?$??Center=?6u   ??6$   ?? *Price+6?   5I      5K        5L      $ Số lượng??6)   $ * 6;    5M      ?? 5N      "  6    .?5O      ??  ? ??$ Center=?6K   6\   ?? 5P       ? ??$ Segoe UI)?6;   6N   ?? 5Q       ? ??$ 15(?69   6F   ?? 5R       ? ??$
 Bold"?6;   6J   ?? 5S       ? ??
 ??  ?6J   5T       5V      ?? 5W      .R?5X      ?? $??Segoe UI)?6A   $??15(?6W   
???   ?$??Center=?6x   ??6$   ?? *
Quantity+6?   5Y      5[        5\      $ Giảm giá (%)??6)   $ * 6?    5]      ?? 5^      "  6    .?5_      ??  ? ??$ Center=?6K   6\   ?? 5`       ? ??$ Segoe UI)?6;   6N   ?? 5a       ? ??$ 15(?69   6F   ?? 5b       ? ??$
 Bold"?6;   6J   ?? 5c       ? ??
 ??  ?6J   5d       5f      ?? 5g      .R?5h      ?? $??Segoe UI)?6A   $??15(?6W   
???   ?$??Center=?6x   ??6$   ?? *
Discount+6?   5i      5k      5m      ?? 5n   
   -   5         ??Name$ btnthoat??5n      $??Thoát??6:   $??Segoe UI)?6J   $??15(?6`   $
??Bold"?6n   $??5q?6?   $??2??6?   6?   5o      5p      