   M S B A M L   `   `   `  ????C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels  5   	   $    CafeMVVM.Views.EditTableWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CafeMVVM.ViewModels     5   	   c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5
   	   -   5          ?Name$  
WEditTable??5	   	      MaterialDesignBody#???   5   	   $??Regular"?5   	   $??13(?5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5   	      TextRenderingMode$
 Auto=?5   	     MaterialDesignPaper#???  5   	     MaterialDesignFont#???  5   	    ? 
ResizeMode$ NoResize=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Title$ 
Edit Table??5   	   $	??120??6   $	??300??6)    ? DataContext 5      (   "CafeMVVM.ViewModels.TableViewModel  5   
   6!   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   6,   ?? 5      $
??Auto ?6   6,   .+?5   
   ?? $??5,5,5,5q?6]   $??Center=?6n   $??15(?6?   $??Segoe UI)?6?   
???   ?  TooltipEnterTbName)  #MaterialDesignThemes.Wpf.HintAssist   Hint# ?  6?   ??6   ?? *	TableName+	 ?? Mode$	 TwoWay=?
 ?? UpdateSourceTrigger$
 PropertyChanged=?6  ? 5   
   $??1??6    ? ColumnDefinitions 5      ?? 5       6%   ?? 5!      6%   .+?5#      ?? $??Segoe UI)?6r   $??15(?6?   
???   ?  BtnSave#???  6?   $
??Bold"?6?    $  MaterialDesignRaisedAccentButton#??[ 6?   $??5,5,5,5q?6  ??6   ?? *EditTableFormCommand+??6>   ??  ?? ElementName$ 
WEditTable??6.  ?? 5$      -   5         ??Name$ btnClose??5$      $??Segoe UI)?6>   $??15(?6T   
???   ?  BtnExit#???  6w   $
??Bold"?6?   #??[ 6?   $??5,5,5,5q?6?   $??1??6?   6
  5%      5&      5'      