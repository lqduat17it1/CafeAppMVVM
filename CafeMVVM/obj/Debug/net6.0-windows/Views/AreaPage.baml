   M S B A M L   `   `   `  ????C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels  5          CafeMVVM.Views.AreaPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CafeMVVM.ViewModels     5      c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	         MaterialDesignBody#???   5
      $??Regular"?5      $??13(?5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5         TextRenderingMode$
 Auto=?5        MaterialDesignPaper N? 
Background# ?  5        MaterialDesignFont N? 
FontFamily# ?  5       N? Title$ AreaPage??5       ? DataContext 5      '   !CafeMVVM.ViewModels.AreaViewModel  5   
   6    .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   6,   ?? 5      6   ?? 5      $
??Auto ?6   6,   .+?5   
   (  "MaterialDesignThemes.Wpf.ColorZone  .??5      ?? $??20??6   6"   5      &   System.Windows.Controls.DataGrid  5   
   $??5q?6   $??1??6      
IsReadOnly$
 True??6+      AutoGenerateColumns$ False??6=   ??6Y   ?? *
AreaList+	 ?? Mode$	 TwoWay=?
 ?? UpdateSourceTrigger$
 PropertyChanged=? ?? SelectedItem 6?   ?? *SelectedArea+ ? 	Resources 5      *  $System.Windows.Controls.DataGridCell ?? 
TargetType ?? Triggers P? Property P? Value ?? Property ?? Value  NumberOfTablesTextStyle  NumberOfTablesText  AreaNameTextStyle  AreaNameText??%?   '        &	 ?     &	 ?     ?? 5       "  6    5!      P? 5"       ?@ 
IsSelected$
 True??6E   . ?5#      ??  ? ??
 ? ???6;   5$      5&      ?? 5'      #???  6<   ?? 5(      #???  66   5)         Columns 5*      4  .System.Windows.Controls.DataGridTemplateColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header# [ 6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6U      HeaderStyle 5,      ?? 5-      =	  7System.Windows.Controls.Primitives.DataGridColumnHeader" 	 6    .?5.      ??  ? ??$ Center=?6K   6\   ?? 5/       ? ??$ Segoe UI)?6;   6N   ?? 50       ? ??$ 15(?69   6F   ?? 51       ? ??$
 Bold"?6;   6J   ?? 52       ? ??
 ??  ?6J   53         CellTemplate 55      ?? 56      .R?57      ?? $??15(?6$   $??Segoe UI)?62   $??Center=?6e   ??6H   ?? *
AreaName+6?   58      5:        5;      # [ 6)   $ * 6[    5<      ?? 5=      " 	 6    .?5>      ??  ? ??$ Center=?6K   6\   ?? 5?       ? ??$ Segoe UI)?6;   6N   ?? 5@       ? ??$ 15(?69   6F   ?? 5A       ? ??$
 Bold"?6;   6J   ?? 5B       ? ??
 ??  ?6J   5C       5E      ?? 5F      .R?5G      ?? $??15(?6$   $??Segoe UI)?62   $??Center=?6H   ??6l   ?? *NumberOfTables+6?   5H      5J      5L      ? 5M   
   $??5q?6   $??2??6    5N      ?? 5O      6"   ?? 5P      6"   .+?5R      ?? -   5        $??txbAreaName??5R      
???   ?$??Center=?6<   $??0,0,0,5q?6`   $??15(?6?   $??Segoe UI)?6?     EnterTheAreaNameToAdd)
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint# ?  6?   $??0??6(  ??6q   ?? *
AREANAME+$	 TwoWay=?$
 PropertyChanged=?6(  ? 5S      $??1??6    ? ColumnDefinitions 5T      ?? 5U      6)   ?? 5V      6)   .+?5X      ?? $??5q?6   $??15(?6@   $??Segoe UI)?6N   $
??Bold"?6d   
???   ?  AddText#???  6?    $	  MaterialDesignRaisedAccentButton#??[	 6?   $??Bottom=?6?   ??6$   ?? *	AddArea+6  ?? 5Y      $??5q?6   $??15(?6C   $??Segoe UI)?6Q   $
??Bold"?6g   
???   ? 
 
DeleteText#??? 
 6?   #??[	 6?   $??Bottom=?6?   $??1??6  ??6$   ?? *
DeleteArea+6  5Z      5[      5\      5]      