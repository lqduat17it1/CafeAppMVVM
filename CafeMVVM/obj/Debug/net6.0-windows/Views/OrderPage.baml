   M S B A M L   `   `   `  ????C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels  5          CafeMVVM.Views.OrderPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CafeMVVM.ViewModels     5      c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	         MaterialDesignBody#???   5
      $??Regular"?5      $??13(?5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5         TextRenderingMode$
 Auto=?5        MaterialDesignPaper N? 
Background# ?  5        MaterialDesignFont N? 
FontFamily# ?  5       N? Title$ 	OrderPage??5       ? DataContext 5      ,   &CafeMVVM.ViewModels.TableAreaViewModel  5   
   6%    ? 	Resources 5      &    CafeMVVM.ViewModels.ColorConvert  ColorConvert?? 5   
   %   &	         5      68   5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   6,   ?? 5      6   ?? 5      $
??Auto ?6   6,   .+?5    
   (  "MaterialDesignThemes.Wpf.ColorZone  $??0??6#   .??5!      ?? $??20??6   6"   5"      ? 5#   
   $??1??6    ? ColumnDefinitions 5$      ?? 5%      $
??Auto ?6#   62   ?? 5&      $
??Auto ?6#   62   ?? 5'      6%   ?? 5(      6%    5*        HeaderAreaStyle  
HeaderArea  HeaderTabNameStyle  HeaderTabName  HeaderStatusStyle 	 HeaderStatus 
 HeaderDisNameStyle  HeaderDisName  HeaderDisNameStyle2  HeaderPriceStyle  HeaderPrice  HeaderPriceStyle2  HeaderDiscountStyle  HeaderDiscount  HeaderNumberStyle  HeaderNumber??%D  &	       &	      &	 4     &	
 N     &	 h     &	 ?     &	 ?     &	 ?     &	 ?     ?? 5+      #???  64   ?? 5,      #???  67   ?? 5-      #??? 	 66   ?? 5.      #???  67   ?? 5/      #???  68   ?? 50      #???  65   ?? 51      #???  66   ?? 52      #???  68   ?? 53      #???  66   54      .+?55      ? $??0??6    56      ?? 57      $
??Auto ?6$   64   ?? 58      6&   .+?5:      &   System.Windows.Controls.DataGrid  $??5,5,5,5q?6   	   
IsReadOnly$
	 True??6,   $??1??6>   
   AutoGenerateColumns$
 False??6?   ??6K   ?? *Area+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=? ?? SelectedItem 6?   ?? *SelectedItem+$ OneWayToSource=? 5;      *  $System.Windows.Controls.DataGridCell ?? 
TargetType ?? Triggers P? Property P? Value ?? Property ?? Value??%?   '        ?? 5<      "  6     5=      P? 5>   "    ?@ 
IsSelected$
 True??6M   . ?5?   &   ??  ? ??
 ? ???6C   5@   #   5B      5C         Columns 5D      4  .System.Windows.Controls.DataGridTemplateColumn  5E      ,  &System.Windows.Controls.DataGridColumn   Header# [ 62      HeaderStyle 5F      ?? 5G   "   =	  7System.Windows.Controls.Primitives.DataGridColumnHeader" 	 6(   .?5H   &   ??  ? ??$ Center=?6S   6d   ?? 5I   &    ? ??$ Segoe UI)?6C   6V   ?? 5J   &    ? ??$ 15(?6A   6N   ?? 5K   &    ? ??$
 Bold"?6C   6R   ?? 5L   &    ? ??
 ??  ?6R   5M   #      CellTemplate 5O      ?? 5P   "   .R?5Q   &   ?? $??Center=?6,   
???   ?$??Segoe UI)?6c   $??15(?6y   ??6?   ?? *
AreaName+6?   5R   #   5T      5V      5W      ? 5X      $??1??6   $	??210??6$   $??Center=?60    5Y      ?? 5Z      $
??Auto ?6$   64   ?? 5[      6&   .+?5]        $??5,5,5,5q?6   $
 False??6,   $
	 True??6H   $??1??6Z   ??6g   ?? *	TableArea+$ TwoWay=?$ PropertyChanged=? 6?   ?? *SelectedItemTable+$ TwoWay=?$ PropertyChanged=? ?? SelectedIndex 6  ?? *SelectedIndexOfTable+ 5^      ??%?   '        ?? 5_      "  6     5`      P? 5a   "    ?@ 
IsSelected$
 True??6M   . ?5b   &   ??  ? ??
 ? ???6C   5c   #   5e      5f       5g        5h         Width5
  /System.Windows.Controls.DataGridLengthConverter$ *
 61   # [ 6;      
IsReadOnly$
 True??6i    5i      ?? 5j   "   " 	 6(   .?5k   &   ??  ? ??$ Center=?6S   6d   ?? 5l   &    ? ??$ Segoe UI)?6C   6V   ?? 5m   &    ? ??$ 15(?6A   6N   ?? 5n   &    ? ??$
 Bold"?6C   6R   ?? 5o   &    ? ??
 ??  ?6R   5p   #    5r      ?? 5s   "   .R?5t   &   ?? $??Center=?6-   $??Segoe UI)?6R   $??15(?6h   ??6w   ?? *	TableName+??6?   ?? *TableStatus+ ?? 	Converter# [ 6?   5u   #   5w        5x      $ *
 61   # [ 6;   $
 True??6h    5y      ?? 5z   "   " 	 6(   .?5{   &   ??  ? ??$ Center=?6S   6d   ?? 5|   &    ? ??$ Segoe UI)?6C   6V   ?? 5}   &    ? ??$ 15(?6A   6N   ?? 5~   &    ? ??$
 Bold"?6C   6R   ?? 5   &    ? ??
 ??  ?6R   5?   #    5?      ?? 5?   "   .R?5?   &   ?? $??Center=?6,   $??Segoe UI)?6P   $??15(?6f   ??6t   ?? *TableStatus+??6?   ?? *TableStatus+# [ 6?   5?   #   5?      5?      5?      ? 5?      $
??Left=?6   $??2??6\   {?6/   ?? *EnableGridCategories+ 5?      ?? 5?      $
??Auto ?6$   64   ?? 5?      $
??Auto ?6$   64   .+?5?      ?? $??5,5,5,5q?6   $??Center=?6,    ?? DisplayMemberPath$ Mcname??6?   $??15(?6?   $
??Bold"?6  $??Segoe UI)?6  $??0??6+    TooltipMenu)  #MaterialDesignThemes.Wpf.HintAssist   Hint# ?  68  ??6P   ?? *MenuCategories+ 6w   ?? *SelectedItemMenuCategory+$ TwoWay=?$ PropertyChanged=?6y    5?      $??5,5,5,5q?6   $
	 True??6,   $??1??6>   $
 False??6?   $	??440??6  $??Bottom=?6  ??6K   ?? *Menu+$ TwoWay=?$ PropertyChanged=? 6?   ?? *SelectMenuTable+$ TwoWay=?$ PropertyChanged=? 5?      ??%?   '        ?? 5?      "  6     5?      P? 5?   "    ?@ 
IsSelected$
 True??6M   . ?5?   &   ??  ? ??
 ? ???6C   5?   #   5?      5?       5?        5?      # [
 61   $ *
 6^    5?      ?? 5?   "   " 	 6(   .?5?   &   ??  ? ??$ Center=?6S   6d   ?? 5?   &    ? ??$ Segoe UI)?6C   6V   ?? 5?   &    ? ??$ 15(?6A   6N   ?? 5?   &    ? ??$
 Bold"?6C   6R   ?? 5?   &    ? ??
 ??  ?6R   5?   #    5?      ?? 5?   "   .R?5?   &   ?? $??Center=?6I   
???   ?$??Segoe UI)?6?   $??15(?6?   ??6,   ?? *
MenuName+6?   5?   #   5?        5?      # [ 61   $ *
 6\    5?      ?? 5?   "   " 	 6(   .?5?   &   ??  ? ??$ Center=?6S   6d   ?? 5?   &    ? ??$ Segoe UI)?6C   6V   ?? 5?   &    ? ??$ 15(?6A   6N   ?? 5?   &    ? ??$
 Bold"?6C   6R   ?? 5?   &    ? ??
 ??  ?6R   5?   #    5?      ?? 5?   "   .R?5?   &   ?? $??Center=?6F   
???   ?$??Segoe UI)?6}   $??15(?6?   ??6,   ?? *Price+6?   5?   #   5?        5?      # [ 61   $ *
 6_    5?      ?? 5?   "   " 	 6(   .?5?   &   ??  ? ??$ Center=?6S   6d   ?? 5?   &    ? ??$ Segoe UI)?6C   6V   ?? 5?   &    ? ??$ 15(?6A   6N   ?? 5?   &    ? ??$
 Bold"?6C   6R   ?? 5?   &    ? ??
 ??  ?6R   5?   #    5?      ?? 5?   "   .R?5?   &   ?? $??Center=?6I   
???   ?$??Segoe UI)?6?   $??15(?6?   ??6,   ?? *
Discount+6?   5?   #   5?      5?      5?      ? 5?      $??3??6    5?      ?? 5?      $
??Auto ?6$   64   ?? 5?      $
??Auto ?6$   64   ?? 5?      6&   ?? 5?      $
??Auto ?6$   64   .+?5?      ?? $??Center=?6   $??Segoe UI)?6?   $??15(?6?   $
??Bold"?6?   
???   ?$??1??6?   ??6<   ?? *ReceiptTitle+$ TwoWay=?$ PropertyChanged=?6?     5?      $??5,5,5,5q?6   $
	 True??6,   $??2??6?   $
 False??6?   ??6>   ?? *MenuTableList+$ TwoWay=?$ PropertyChanged=? 6?   ?? *
SelectMenu+$ OneWayToSource=? 5?      ??%?   '        ?? 5?      "  6     5?      P? 5?   "    ?@ 
IsSelected$
 True??6M   . ?5?   &   ??  ? ??
 ? ???6C   5?   #   5?      5?       5?        5?      $ *
 61   # [ 6<    5?      ?? 5?   "   " 	 6(   .?5?   &   ??  ? ??$ Center=?6S   6d   ?? 5?   &    ? ??$ Segoe UI)?6C   6V   ?? 5?   &    ? ??$ 15(?6A   6N   ?? 5?   &    ? ??$
 Bold"?6C   6R   ?? 5?   &    ? ??
 ??  ?6R   5?   #    5?      ?? 5?   "   .R?5?   &   ?? $??Center=?6I   
???   ?$??Segoe UI)?6?   $??15(?6?   ??6,   ?? *
MenuName+6?   5?   #   5?        5?      $ *
 61   # [ 6;    5?      ?? 5?   "   " 	 6(   .?5?   &   ??  ? ??$ Center=?6S   6d   ?? 5?   &    ? ??$ Segoe UI)?6C   6V   ?? 5?   &    ? ??$ 15(?6A   6N   ?? 5?   &    ? ??$
 Bold"?6C   6R   ?? 5?   &    ? ??
 ??  ?6R   5?   #    5?      ?? 5?   "   .R?5   &   ?? $??Center=?6F   
???   ?$??Segoe UI)?6v   $??15(?6?   ??6,   ?? *Price+6?   5  #   5       5     $ *
 61   # [ 6;    5     ?? 5  "   " 	 6(   .?5  &   ??  ? ??$ Center=?6S   6d   ?? 5  &    ? ??$ Segoe UI)?6C   6V   ?? 5	  &    ? ??$ 15(?6A   6N   ?? 5
  &    ? ??$
 Bold"?6C   6R   ?? 5  &    ? ??
 ??  ?6R   5  #    5     ?? 5  "   .R?5  &   ?? 
???   ?$??Center=?6\   $??Segoe UI)?6?   $??15(?6?   ??6,   ?? *
Quantity+6?   5  #   5     5     5     5     ?? 5  
   $??Right=?6    ?? Orientation$ 
Horizontal=?61   $??2??6J   .+?5     ?? $??5,5,5,5q?6?   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=?6P   $??Segoe UI)?6?   $??15(?6?   $
??Bold"?6?   
???   ?  BtnFindEmpArea#???  6?    $  MaterialDesignRaisedAccentButton#??[ 6?   ??6   ?? *FindEmptyTableCommand+61  ?? 5     $??Center=?6   $??Center=?68   $??Segoe UI)?6?   $??15(?6?   $
??Bold"?6?   
???  ????6Z   ?? *ReceiptTotal+$ TwoWay=?$ PropertyChanged=?6?   ?? 5     $??5,5,5,5q?64   $ Depth5=?6E   $??Segoe UI)?6v   $??15(?6?   $
??Bold"?6?   
???   ?  
BtnDelDisc#???  6?   #??[ 6?   ??6   ?? *
DeleteMenu+6"  ?? 5     $??5,5,5,5q?6<   $ Depth5=?6M   $??Segoe UI)?6~   $??15(?6?   $
??Bold"?6?   
???   ?  
BtnMoveTab#???  6?   #??[ 6?   ??6   ?? *ChangeTableCommand+6*  ?? 5     $??5,5,5,5q?65   $ Depth5=?6F   $??Segoe UI)?6w   $??15(?6?   $
??Bold"?6?   
???   ?  LabelMergeTb#???  6?   #??[ 6?   ??6   ?? *MergedTable+6%  ?? 5     $??5,5,5,5q?68   $ Depth5=?6I   $??Segoe UI)?6z   $??15(?6?   $
??Bold"?6?   
???   ? 
 BtnPay#???  6?   #??[ 6?   ??6   ?? *PaymentCommand+6"  5      5!     5"     