   M S B A M L   `   `   `  ????C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels  5          CafeMVVM.Views.MenuPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CafeMVVM.ViewModels     5      c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	         MaterialDesignBody#???   5
      $??Regular"?5      $??13(?5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5         TextRenderingMode$
 Auto=?5        MaterialDesignPaper N? 
Background# ?  5        MaterialDesignFont N? 
FontFamily# ?  5       N? Title$ MenuPage??5       ? DataContext 5      '   !CafeMVVM.ViewModels.MenuViewModel  5   
   6    .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   6,   ?? 5      6   .+?5   
   (  "MaterialDesignThemes.Wpf.ColorZone  .??5      ?? $??20??6   6"   5      ? 5   
   $??1??6    ? ColumnDefinitions 5      ?? 5      6%   ?? 5       6%    ? 	Resources 5"        HeaderCateNameStyle  HeaderCateName  HeaderDisNameStyle  HeaderDisName  HeaderPriceStyle  HeaderPrice??%l   &	       &	      &	 4     ?? 5#      #???  68   ?? 5$      #???  67   ?? 5%      #???  65   5&      .+?5'      ? $??0??6    5(      ?? 5)      6&   ?? 5*      $
??Auto ?6$   64   .+?5,      &   System.Windows.Controls.DataGrid  $??5q?6   	   
IsReadOnly$
	 True??6&   
   AutoGenerateColumns$
 False??6?   ??68   ?? *MenuCategories+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=? ?? SelectedItem 6?   ?? *SelectedMCItem+$ OneWayToSource=? 5-      *  $System.Windows.Controls.DataGridCell ?? 
TargetType ?? Triggers P? Property P? Value ?? Property ?? Value??%?   '        ?? 5.      "  6     5/      P? 50   "    ?@ 
IsSelected$
 True??6M   . ?51   &   ??  ? ??
 ? ???6C   52   #   54      55         Columns 56      4  .System.Windows.Controls.DataGridTemplateColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header# [ 61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6_      HeaderStyle 58      ?? 59   "   =	  7System.Windows.Controls.Primitives.DataGridColumnHeader" 	 6(   .?5:   &   ??  ? ??$ Center=?6T   ?? 5;   &    ? ??$ Segoe UI)?6D   ?? 5<   &    ? ??$ 15(?6B   ?? 5=   &    ? ??$
 Bold"?6D   ?? 5>   &    ? ??
 ??  ?6R   5?   #      CellTemplate 5A      ?? 5B   "   .R?5C   &   ?? $??Center=?6,   $??Segoe UI)?6P   $??15(?6f   
???   ???6?   ?? *Mcname+6?   5D   #   5F      5H      ? 5I      $??1??6   .+?5J      ?  5K      ?? 5L      6.   ?? 5M      6.   .+?5O      ?? $??5q?6"   $??Center=?6-   
???   ?$??15(?6?   $??Segoe UI)?6?    	 TooltipInputCate)
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint# ? 	 6?   $??Bottom=?6  ??6d   ?? *Mcname+$ TwoWay=?$ PropertyChanged=?62  ? 5P      $??1??6    5Q      ?? 5R   "   65   ?? 5S   "   $
??Auto ?63   6B   .+?5U      ?? $??5q?6%   $??Segoe UI)?6Q   $??15(?6g   
???   ? $
  MaterialDesignRaisedAccentButton#??[
 6?    
 BtnAdd#???  6?   $??0??6?   $??Bottom=?6?   ??60   ?? *AddMCCommand+6  ?? 5V      $??5q?6%   $??Segoe UI)?6T   $??15(?6j   
???  ??#??[
 6?     	BtnDelete#???  6?   $??1??6?   $??Bottom=?6?   ??60   ?? *DeleteMCCommand+6  5W      5X      5Y      5Z      ? 5[      $??1??6    5\      ?? 5]      6&   ?? 5^      $
??Auto ?6$   64   .+?5`        $??5q?6   $
	 True??6&   $
 False??68   ??6T   ?? *
MenuList+$ TwoWay=?$ PropertyChanged=? 6?   ?? *SelectedMenuItem+$ OneWayToSource=? 5a      ??%?   '        ?? 5b      "  6     5c      P? 5d   "    ?@ 
IsSelected$
 True??6M   . ?5e   &   ??  ? ??
 ? ???6C   5f   #   5h      5i       5j        5k      # [ 61   $ * 6^    5l      ?? 5m   "   " 	 6(   .?5n   &   ??  ? ??$ Center=?6S   6d   ?? 5o   &    ? ??$ Segoe UI)?6D   ?? 5p   &    ? ??$ 15(?6B   ?? 5q   &    ? ??$
 Bold"?6D   ?? 5r   &    ? ??
 ??  ?6R   5s   #    5u      ?? 5v   "   .R?5w   &   ?? $??Center=?6,   $??15(?6P   $??Segoe UI)?6^   
???   ???6?   ?? *
MenuName+6?   5x   #   5z        5{      # [ 61   $ * 6\    5|      ?? 5}   "   " 	 6(   .?5~   &   ??  ? ??$ Center=?6S   6d   ?? 5   &    ? ??$ Segoe UI)?6D   ?? 5?   &    ? ??$ 15(?6B   ?? 5?   &    ? ??$
 Bold"?6D   ?? 5?   &    ? ??
 ??  ?6R   5?   #    5?      ?? 5?   "   .R?5?   &   ?? $??Center=?6,   $??15(?6P   $??Segoe UI)?6^   
???   ???6?   ?? *Price+6?   5?   #   5?      5?      ? 5?      $??1??6   .+?5?      ?  5?      ?? 5?      6.   ?? 5?      6.   ?? 5?      6.   .+?5?      ?? $??5q?6"   
???   ?$??Center=?6@   $??0??6d   $??15(?6?   $??Segoe UI)?6?     TooltipInputDiscName# ?  6?   $??Bottom=?6$  ??6q   ?? *Menu+$ TwoWay=?$ PropertyChanged=?6A  ?? 5?      $??5q?6"   
???   ?$??Center=?6@   $??1??6?   $??15(?6?   $??Segoe UI)?6?     TooltipInputPrice# ?  6?   $??Bottom=?6"  ??6d   ?? *Price+$ TwoWay=?$ PropertyChanged=?6@  ? 5?      $??2??6    5?      ?? 5?   "   65   ?? 5?   "   66   ?? 5?   "   $
??Auto ?63   6B   .+?5?      ?? $??5q?6&   $??Segoe UI)?6T   $??15(?6j   
???   ?#??[
 6?   #???  6?   $??0??6?   $??Bottom=?6?   ??61   ?? *AddMenuCommand+6  ?? 5?      $??5q?6%   $??Segoe UI)?6T   $??15(?6j   
???   ?#??[
 6?     BtnEdit#???  6?   $??1??6?   $??Bottom=?6?   ??60   ?? *EditMenuCommand+6  ?? 5?      $??5q?6%   $??Segoe UI)?6V   $??15(?6l   
???  ??#??[
 6?   #???  6?   $??2??6?   $??Bottom=?6?   ??60   ?? *DeleteMenuCommand+6  5?      5?      5?      5?      5?      5?      5?      