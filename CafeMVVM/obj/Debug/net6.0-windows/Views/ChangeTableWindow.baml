   M S B A M L   `   `   `  ????C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels  5   	   &     CafeMVVM.Views.ChangeTableWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CafeMVVM.ViewModels     5   	   c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	   	   -   5          ?Name$  WChangeTable??5   	      MaterialDesignBody#???   5
   	   $??Regular"?5   	   $??13(?5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5   	      TextRenderingMode$
 Auto=?5   	     MaterialDesignPaper#???  5   	     MaterialDesignFont#???  5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? 
ResizeMode$ NoResize=?5   	    ? Title$ ChangeTableWindow??5   	   $	??450??6#   $	??800??60    ? DataContext 5      ,   &CafeMVVM.ViewModels.TableAreaViewModel  5   
   6%   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   6,   ?? 5      $
??Auto ?6   6,   .+?5   
   ? $??0??6    ? ColumnDefinitions 5      ?? 5      6%   ?? 5      6%   .+?5!      ? $??5,5,5,5q?6   $??0??6$    5"      ?? 5#      $
??Auto ?6$   64   ?? 5$      $
??Auto ?6$   64   .+?5&      ?? $??Center=?6   $??Segoe UI)?6<   $??15(?6R   $
??Bold"?6`   
????  ?$ ??Chọn bàn cần chuyển??6?   6?   ?? 5'      	 ?? DisplayMemberPath$	 	TableName??6?   $??1??6?   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Chọn bàn??6?   ??6   ?? *
InUseTable+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=? ?? SelectedItem 6n   ?? *SelectedInUseTable+$ OneWayToSource=?6  5(      ? 5)      $??5,5,5,5q?6   $??1??6$    5*      ?? 5+      $
??Auto ?6$   64   ?? 5,      $
??Auto ?6$   64   .+?5.      ?? $??Center=?6   $??Segoe UI)?6<   $??15(?6R   $
??Bold"?6`   
????  ?$??Bàn còn trống??6?   6?   ?? 5/      $	 	TableName??6?   $??1??6?   $
 Chọn bàn??6?   ??6   ?? *
EmptyTable+$ TwoWay=?$ PropertyChanged=? 6n   ?? *SelectedEmptyTable+$ OneWayToSource=?6  50      51      ? 52   
   $??1??6    53      ?? 54      6%   ?? 55      6%   .+?57      ?? $??Segoe UI)?6z   $??15(?6?   $
??Bold"?6?   
???   ?$??Chuyển??6?    $  MaterialDesignRaisedAccentButton#??[ 6?   $??5,5,5,5q?6  $??0??6  ??6   ?? *ConfirmChangeTableICommand+??6D   ??  ?? ElementName$ WChangeTable??61  ?? 58      -   5         ??Name$ btnExit??58      $??Segoe UI)?6<   $??15(?6R   $
??Bold"?6`   
???   ?$??Thoát??6?   #??[ 6?   $??5,5,5,5q?6?   $??1??6?   6?   59      5:      5;      