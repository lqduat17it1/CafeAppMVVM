   M S B A M L   `   `   `  ????C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels  5   	   )    #CafeMVVM.Views.EmptyTableAreaWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CafeMVVM.ViewModels     5   	   c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   -   5          ?Name$  	wbantrong??5   	      MaterialDesignBody#???   5	   	   $??Regular"?5
   	   $??13(?5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5   	      TextRenderingMode$
 Auto=?5   	     MaterialDesignPaper#???  5   	     MaterialDesignFont#???  5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? 
ResizeMode$ NoResize=?5   	    ? Title$ Empty Table??5   	   $	??450??6   $	??800??6*    ? Triggers 5      :? 5   
    :? RoutedEvent$ Window.Loaded??6   [?5      ?? 5      .??5      ??  g? 	BeginTime 06!   	 g? Duration$	 ForeverD?6/   .??5      W? 
 ?? 
TargetName$
 	wbantrong??6*   $	 00:00:01D?6L    ?? TargetProperty$ Opacity?6`    W? From 06?   	 W? To 16?   5      5      5       ? DataContext 5      ,   &CafeMVVM.ViewModels.TableAreaViewModel  5    
   6%   .??5"      ?  ? RowDefinitions 5#   
   ?? 5$      $
??Auto ?6   6,   ?? 5%      6   ?? 5&      $
??Auto ?6   6,   .+?5(   
   (  "MaterialDesignThemes.Wpf.ColorZone  .??5)      ?? $??20??6   6"   5*      &   System.Windows.Controls.DataGrid  5+   
   $??1??6      AutoGenerateColumns$ False??6!      
IsReadOnly$
 True??6=   $??5q?6?   ??6O   ?? *EmptyTableList+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=? ? 	Resources 5,      *  $System.Windows.Controls.DataGridCell ?? 
TargetType ?? Triggers P? Property P? Value ?? Property ?? Value  HeaderTabNameStyle  HeaderTabName  HeaderAreaNameStyle  HeaderAreaName  HeaderStatusStyle  HeaderStatus??%  '        &	 ?     &	 ?     &	 ?     ?? 5-      "  6    5.      P? 5/       ?@ 
IsSelected$
 True??6E   . ?50      ??  ? ??
 ? ???6;   51      53      ?? 54      #???  67   ?? 55      #???  68   ?? 56      #???  66   57         Columns 58      4  .System.Windows.Controls.DataGridTemplateColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header# [ 6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V      HeaderStyle 5:      ?? 5;      =	  7System.Windows.Controls.Primitives.DataGridColumnHeader" 	 6    .?5<      ??  ? ??$ Center=?6K   6\   ?? 5=       ? ??$ Segoe UI)?6;   6N   ?? 5>       ? ??$ 15(?69   6F   ?? 5?       ? ??$
 Bold"?6;   6J   ?? 5@       ? ??
 ??  ?6J   5A         CellTemplate 5C      ?? 5D      .R?5E      ?? $??Center=?6$   $??Segoe UI)?6f   $??15(?6|   
???   ???6H   ?? *	TableName+6?   5F      5H        5I      # [ 6)   $ * 6W    5J      ?? 5K      " 	 6    .?5L      ??  ? ??$ Center=?6K   6\   ?? 5M       ? ??$ Segoe UI)?6;   6N   ?? 5N       ? ??$ 15(?69   6F   ?? 5O       ? ??$
 Bold"?6;   6J   ?? 5P       ? ??
 ??  ?6J   5Q       5S      ?? 5T      .R?5U      ?? $??Center=?6$   $??Segoe UI)?6e   $??15(?6{   
???   ???6H   ?? *
AreaName+6?   5V      5X        5Y      # [ 6)   $ * 6U    5Z      ?? 5[      " 	 6    .?5\      ??  ? ??$ Center=?6K   6\   ?? 5]       ? ??$ Segoe UI)?6;   6N   ?? 5^       ? ??$ 15(?69   6F   ?? 5_       ? ??$
 Bold"?6;   6J   ?? 5`       ? ??
 ??  ?6J   5a       5c      ?? 5d      .R?5e      ?? $??Center=?6$   $??Segoe UI)?6h   $??15(?6~   
???   ???6H   ?? *TableStatus+6?   5f      5h      5j      ?? 5k   
   -   5          ??Name$  btnExit??5k      $??Segoe UI)?68   $??15(?6N   $
??Bold"?6\   
??????? 	 BtnExit#??? 	 6?    "
 MaterialDesignRaisedDarkButton#??[
 6?   $??5,5,5,5q?6?   $??2??6?   6?   5l      5m      