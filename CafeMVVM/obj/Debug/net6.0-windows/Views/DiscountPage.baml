   M S B A M L   `   `   `  ????C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels  5      !    CafeMVVM.Views.DiscountPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CafeMVVM.ViewModels     5      c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	         MaterialDesignBody#???   5
      $??Regular"?5      $??13(?5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5         TextRenderingMode$
 Auto=?5        MaterialDesignPaper N? 
Background# ?  5        MaterialDesignFont N? 
FontFamily# ?  5       N? Title$ DiscountPage??5       ? DataContext 5      ,   &CafeMVVM.ViewModels.TableAreaViewModel  5   
   6%   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   6,   ?? 5      6   .+?5   
   (  "MaterialDesignThemes.Wpf.ColorZone  .??5      ?? $??20??6   6"   5      ? 5   
   $??1??6    5      ?? 5      $
??Auto ?6    60   ?? 5       6"   ?? 5!      $
??Auto ?6    60   ?? 5"      $
??Auto ?6    60   .+?5$      ??  ?? DisplayMemberPath$ Mcname??6?   $??Segoe UI)?6?   $??15(?6?   
???   ?$
??Bold"?6?   $??Center=?6?   $??5,5,5,5q?6  $??0??6%    SelCateToDiscount)  #MaterialDesignThemes.Wpf.HintAssist   Hint# ?  62  ??6   ?? *MenuCategories+	 ?? SelectedItem	 6>   ?? *" SelectedItemMenuCategoryDiscount+
 ?? Mode$
 OneWayToSource=?6y  &   System.Windows.Controls.DataGrid  5%         
IsReadOnly$
 True??6      AutoGenerateColumns$ False??6?   $??5,5,5,5q?6?   $??1??6  ??6)   ?? *Menu+$
 TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?	 6v   ?? *SelectedMenuTableDiscount+$
 TwoWay=?$ PropertyChanged=? ? 	Resources 5&      *  $System.Windows.Controls.DataGridCell ?? 
TargetType ?? Triggers P? Property P? Value ?? Property ?? Value  HeaderDisNameStyle  HeaderDisName  HeaderPriceStyle  HeaderPrice  HeaderDiscountStyle 	 HeaderDiscount??%  '        &	 ?     &	 ?     &	 ?     ?? 5'      "  6    5(      P? 5)       ?@ 
IsSelected$
 True??6I   . ?5*   "   ??  ? ??
 ? ???6?   5+      5-      ?? 5.      #???  6;   ?? 5/      #???  69   ?? 50      #??? 	 6<   51         Columns 52      4  .System.Windows.Controls.DataGridTemplateColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header# [ 6-      Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	 6Z      HeaderStyle 54      ?? 55      =
  7System.Windows.Controls.Primitives.DataGridColumnHeader" 
 6$   .?56   "   ??  ? ??$ Center=?6O   6`   ?? 57   "    ? ??$ Segoe UI)?6?   6R   ?? 58   "    ? ??$ 15(?6=   6J   ?? 59   "    ? ??$
 Bold"?6?   6N   ?? 5:   "    ? ??
 ??  ?6N   5;         CellTemplate 5=      ?? 5>      .R?5?   "   ?? $??Segoe UI)?6(   $??15(?6>   
???   ?$??Center=?6|   ??6_   ?? *
MenuName+6?   5@      5B        5C      # [ 6-   $ *	 6X    5D      ?? 5E      " 
 6$   .?5F   "   ??  ? ??$ Center=?6O   6`   ?? 5G   "    ? ??$ Segoe UI)?6?   6R   ?? 5H   "    ? ??$ 15(?6=   6J   ?? 5I   "    ? ??$
 Bold"?6?   6N   ?? 5J   "    ? ??
 ??  ?6N   5K       5M      ?? 5N      .R?5O   "   ?? $??Segoe UI)?6(   $??15(?6>   
???   ?$??Center=?6y   ??6_   ?? *Price+6?   5P      5R        5S      # [ 6-   $ *	 6[    5T      ?? 5U      " 
 6$   .?5V   "   ??  ? ??$ Center=?6O   6`   ?? 5W   "    ? ??$ Segoe UI)?6?   6R   ?? 5X   "    ? ??$ 15(?6=   6J   ?? 5Y   "    ? ??$
 Bold"?6?   6N   ?? 5Z   "    ? ??
 ??  ?6N   5[       5]      ?? 5^      .R?5_   "   ?? $??Segoe UI)?6(   $??15(?6>   
???   ?$??Center=?6|   ??6_   ?? *
Discount+6?   5`      5b      5d      ? 5e      $??5,5,5,5q?6   $??2??6$    ? ColumnDefinitions 5f      ?? 5g      $
??Auto ?6'   66   ?? 5h      6)   .+?5j      ?? $??Segoe UI)?6   $??15(?6.   
???   ? 
 LabelInputDiscount#??? 
 6O   6?   ?? 5k      $??Center=?6k   $??Segoe UI)?6?   $??15(?6?   
???   ?$??1??6?   ??6   ?? *DiscountPercent+$
 TwoWay=?$ PropertyChanged=?6?   5l      ? 5m      $??3??6    5n      ?? 5o      6)   ?? 5p      6)   .+?5r      ??  $  MaterialDesignRaisedAccentButton#??[ 6@   $??Segoe UI)?6z   $??15(?6?   
???   ?$
??Bold"?6?     	BtnUpdate#???  6?   $??5,5,5,5q?6?   $??0??6?   ??6   ?? *AddDiscountCommand+6  ?? 5s      #??[ 6C   $??Segoe UI)?6}   $??15(?6?   
???   ?$
??Bold"?6?     	BtnCancel#???  6?   $??5,5,5,5q?6?   $??1??6?   ??6   ?? *DeleteDiscountCommand+6  5t      5u      5v      5w      