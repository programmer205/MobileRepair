   M S B A M L   `   `   `  ????K  GManagementMobile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ManagementMobileManagementMobile  5   	   $    ManagementMobile.SettingWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ManagementMobile     5   	   -   5        
??????   ? AllowsTransparency  .  ? 
ResizeMode$ NoResize=?5
   	    ? WindowStyle$
 None=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Title$ SettingWindow??5   	   $	??680??6   $
??1150??6,   .??5      ?? ???#CCD5AE$??5q?6#    ?? CornerRadius$ 10??67   ._?5   
   ? ???#CCD5AE ? RowDefinitions 5      ?? 5      $	??110 ?6    ?? 5      $??235.2 ?6    ?? 5      $
??109* ?6    ?? 5      $
??166* ?6    ?? 5      $??50 ?6     ? ColumnDefinitions 5      ?? 5      ?? 5      ?? 5      ?? 5      .+?5      ?? ???#FAEDCD$??5q?6+   $ 10??6?   $??5,5,4.8,3.6q?6Q   $??2??6f   $??0??6w   $??4??6?   ._?5       ?? ???#FAEDCD6   5!      ? 5"      $	??Top=?6   $??Center=?60   $??0??6M   $??1??6Z   $??2??6j   $??197.4,15,197,0q?6~   $??35??6?   $	??176??6?   .+?5#      ?? -   5         ??Name$ contacts??5#   ?   $#??تنظیمات دیتابیس??6   $??20(?63   ???#D4A373$??Center=?6V   $??IRANSansWeb(FaNum))?6q   $
??Bold"?6?   6?   ?? 5$      $??Resources/DataBase.png??6   $??35??68   5%      ?? 5&      -   5        	 ??Name$	 ButtonBackup??5&      $"??بکاپ از دیتابیس??6*   $??0??6D   $??2??6Q   $??Bottom=?6a   $??Right=?6|   $??IRANSansWeb(FaNum))?6?   ???#283618???#D4A373$??15(?6?   
 ? Cursor$

 Hand??6?   $??38??67  $??	0,0,0,0.4q?6C  $	??140??6V   ? ToolTip$ Alt+Z??6b  ?? 5'      -   5        $	 ButtonRestore??5'      $'??!بازگردانی دیتابیس??6+   $??0??6G   $??1??6T   $??Bottom=?6d   $
??Left=?6   $??IRANSansWeb(FaNum))?6?   ???#283618???#D4A373$??15(?6?   $

 Hand??6?   $??38??6:  $??0.4,0,0,0.4q?6F  $	??140??6[  $ Alt+X??6g  &   System.Windows.Controls.DataGrid  5)      -   5          Name$ 	DataGrid1??5)      $??1??6*   $??4??67   $??5,29.6,4.8,3.6q?6K   ???#FEFAE0???#F2F2F2???#F2F2F2   Attacktogrid   ColumnHeaderStyle# [  6?      CanUserResizeColumns .     AutoGenerateColumns .     CanUserAddRows .     CanUserReorderColumns .     CanUserSortColumns .     CanUserDeleteRows .     CanUserResizeRows .     
IsReadOnly . $??RightToLeft=?6?     Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ آیدی??6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   ?? *
BackupId+6T     5,      $ نام??6)   $	 120 6O    66   ?? *Name+6O     5-      $ آدرس??6)   $	 300 6S    67   ?? *	Address+6S    ? 	Resources 5/       ?? 
TargetType ?? Property ?? Value??%f   '??       ?? 50      " ??6   .?51      ??  ?@??CornerRadius$ 	0,0,10,10??69   52      53      54      ?? 55      -   5        $	 dt_btn??55   s   $??بازگردانی??6   $??3??6(   $??
0,110,15,0q?68     Attacktolable#??[ 6L   $??2??6?   $??51??6?    56      ??%^   '??       ?? 57      " ??6   .?58      ??  ?@??CornerRadius$ 5??69   59      5:      5;      ?? 5<      -   5        $	 Ex_btn??5<     $??4??6   $
??Left=?6!   $??Bottom=?6<   ???#D8315B$)??#بازگشت به صفحه اصلی??6l   $??30??6?   $??
32,0,0,0.4q?6?   ???#F2F2F2$??IRANSansWeb(FaNum))?6?   $??11(?6?    J? RenderTransformOrigin$ 1.06,0.9&?6?   $

 Hand??6Q  $	??130??6_  $ Ctrl+L??6k  ?? 5=      -   5        $??Resources/Left.png??5=      $
??Left=?60   $??Bottom=?6K   $??4??6f   $??31??6s   $ 1.323,0.536&?6   $??
1,0,0,-2.6q?6?   $

 Hand??6?   $ Ctrl+L??6?   5>      5?       J? CommandBindings 5@      )  #System.Windows.Input.CommandBinding  5A   
   -	   5        $   ManagementMobile.SettingWindow    ButtonLeave!   Command#! Z  5A      5B        5C   
   -
   5        "   ButtonCustomer#! Z" 5C      5D        5E   
   -   5        #   ButtonActivity#! Z# 5E      5F        5G   
   -   5        $   ButtonInvoice#! Z$ 5G      5H        5I   
   -   5        %   ButtonPhone#! Z% 5I      5J        5K   
   -   5        &   ButtonRepair#! Z& 5K      5L        5M   
   -   5        '   ButtonReport#! Z' 5M      5N        5O   
   -   5        (   ButtonReminder#! Z( 5O      5P        5Q   
   -   5        )   
ButtonUser#! Z) 5Q      5R        5S   
   -   5        *   ButtonMessage#! Z* 5S      5T        5U   
   -   5        +   
btn_Backup#! Z+ 5U      5V        5W   
   -   5        ,   btn_Restore#! Z, 5W      5X        5Y   
   -   5        -   ButtonSetting#! Z- 5Y      5Z      5\      