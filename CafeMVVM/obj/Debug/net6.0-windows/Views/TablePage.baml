   M S B A M L   `   `   `  ????C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels  5          CafeMVVM.Views.TablePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CafeMVVM.ViewModels     5      c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	         MaterialDesignBody#???   5
      $??Regular"?5      $??13(?5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5         TextRenderingMode$
 Auto=?5        MaterialDesignPaper N? 
Background# ?  5        MaterialDesignFont N? 
FontFamily# ?  5       N? Title$ 	TablePage??5       ? DataContext 5      (   "CafeMVVM.ViewModels.TableViewModel  5   
   6!   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   6,   ?? 5      6   ?? 5      $
??Auto ?6   6-   .+?5   
   (  "MaterialDesignThemes.Wpf.ColorZone  .??5      ?? $??20??6   6"   5      &   System.Windows.Controls.DataGrid  5   
   $??5,5,5,5q?6   $??1??6$      
IsReadOnly$
 True??61      AutoGenerateColumns$ False??6?   ??6D   ?? *	TableList+	 ?? Mode$	 TwoWay=?
 ?? UpdateSourceTrigger$
 PropertyChanged=? ?? SelectedItem 6?   ?? *SelectedTable+$	 OneWayToSource=? ? 	Resources 5      *  $System.Windows.Controls.DataGridCell ?? 
TargetType ?? Triggers P? Property P? Value ?? Property ?? Value  HeaderTabNameStyle  HeaderTabName??%?   '        &	 ?     ?? 5       "  6    5!      P? 5"       ?@ 
IsSelected$
 True??6E   . ?5#      ??  ? ??
 ? ???6;   5$      5&      ?? 5'      #???  67   5(         Columns 5)      4  .System.Windows.Controls.DataGridTemplateColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header# [ 6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V      HeaderStyle 5+      ?? 5,      =	  7System.Windows.Controls.Primitives.DataGridColumnHeader" 	 6    .?5-      ??  ? ??$ Center=?6K   6\   ?? 5.       ? ??$ Segoe UI)?6;   6N   ?? 5/       ? ??$ 15(?69   6F   ?? 50       ? ??$
 Bold"?6;   6J   ?? 51       ? ??
 ??  ?6J   52         CellTemplate 54      ?? 55      .R?56      ?? $??Center=?6$   $??15(?6H   $??Segoe UI)?6V   
???   ???6?   ?? *	TableName+6?   57      59      5;      ? 5<   
   $??2??6    5=      ?? 5>      6"   ?? 5?      $
??Auto ?6    60   .+?5A      ? $??0??6    5B      ?? 5C      6&   ?? 5D      6'   .+?5F      ?? $??5,5,5,5q?6    ?? DisplayMemberPath$ AreaName??6M   $??15(?6?   $??Segoe UI)?6?   $
??Bold"?6?   $??Bottom=?6?     LabelSelAreaAddTab)
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint# ?  6  $??0??6_  ??6,   ?? *
AreaList+ 6j   ?? *SelectedArea+$	 OneWayToSource=?$
 PropertyChanged=?6n  ?? 5G      $??5,5,5,5q?6   $??15(?6|   $??Segoe UI)?6?   $
??Bold"?6?   $??Bottom=?6?     LabelAddTabNum# ?  6?   $??1??6  ??6,   ?? *NumberOfTables+$	 TwoWay=?$
 PropertyChanged=?6  5H      ? 5I      $??1??6    ? ColumnDefinitions 5J      ?? 5K      6)   ?? 5L      6)   ?? 5M      6)   .+?5O      ?? $??15(?6=   $??Segoe UI)?6K   $
??Bold"?6a   
???   ? 
 BtnAdd#???  6?    $  MaterialDesignRaisedAccentButton#??[ 6?   $??5,5,5,5q?6?   $??0??6?   ??6   ?? *AddTableCommand+6  ?? 5P      $??15(?6?   $??Segoe UI)?6M   $
??Bold"?6c   
???   ? 	 BtnEdit#??? 	 6?   #??[ 6?   $??5,5,5,5q?6?   $??1??6?   ??6   ?? *EditTableCommand+6	  ?? 5Q      $??15(?6@   $??Segoe UI)?6N   $
??Bold"?6d   
???   ? 
 	BtnDelete#??? 
 6?   #??[ 6?   $??5,5,5,5q?6?   $??2??6?   ??6   ?? *DeleteTableCommand+6  5R      5S      5T      5U      