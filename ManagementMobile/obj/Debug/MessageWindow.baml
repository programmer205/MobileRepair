   M S B A M L   `   `   `  ????K  GManagementMobile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ManagementMobileManagementMobile  5   	   $    ManagementMobile.MessageWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ManagementMobile     5   	   -   5        
??????   ? AllowsTransparency  .  ? 
ResizeMode$ NoResize=?5
   	    ? WindowStyle$
 None=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Title$ MessageWindow??5   	   $	??680??6   $
??1150??6,   .??5      ?? ???#CCD5AE$??5q?6#    ?? CornerRadius$ 10??67   ._?5   
   ? ???#CCD5AE ? ColumnDefinitions 5      ?? 5      $
??286* ?6#   ?? 5      $
??420* ?6#   ?? 5      $
??150* ?6#   ?? 5      $
??285* ?6#    ? RowDefinitions 5      ?? 5      $	??15* ?6    ?? 5      $??7* ?6    .+?5      ?? ???#FAEDCD$??3q?6+   $??4??6?   $ 10??6S   $??5,5,5.8,10.8q?6e   ._?5      ?? ???#FAEDCD6   5      ?? 5      $!??:نام/شماره تلفن??6   ???#FAEDCD???#FAEDCD???#D4A373$	??Top=?6n   $??Right=?6?   $??3??6?   $??0,10,15.8,0q?6?   $??IRANSansWeb(FaNum))?6?   $??34??6?   $??99??6?   ?? 5      -   5         ??Name$ 
txt_number??5      $??0??6*   $??3??67   $	??Top=?6G   $??Right=?6_   $??0,40,15.8,0q?6{   $	??250??6?   $??30??6?   6?   &   System.Windows.Controls.DataGrid  5       -   5        	  Name$	 	DataGrid1??5       $??2??6*   $??2??6;   $??11.4,80,7.8,19.8q?6O   ???#FEFAE0???#F2F2F2???#F2F2F2   Attacktogrid
   ColumnHeaderStyle#
 [  6?      CanUserResizeColumns .     AutoGenerateColumns .     CanUserAddRows .     CanUserReorderColumns .     CanUserSortColumns .     CanUserDeleteRows .     CanUserResizeRows .     
IsReadOnly . $??RightToLeft=?6?     Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ آیدی??6)      
Visibility$ Hidden=?6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   ?? *
CustomerId+6V     5#      $ نام??6)    66   ?? *
FullName+  5$      $ تلفن??6)    67   ?? *PhoneNumber+5&      ?? 5'      $??:متن پیام??6   ???#FAEDCD???#FAEDCD???#D4A373$	??Top=?6h   $??Right=?6?   $??1??6?   $??0,10,10.8,0q?6?   $??IRANSansWeb(FaNum))?6?   ?? 5(      -   5         ??Name$ txt_info??5(      $??1??6,   $??15.4,40,14.6,226.8q?6<   $??RightToLeft=?6X   ?? 5)      -   5         ??Name$ ListBox??5)      $??1??6'   $??15.4,248,14.6,19.8q?68   ???#FEFAE06T   ?? 5*      -   5         ??Name$ btn_register??5*      $??ارسال پیام??6*   $??0??6?   ???#283618???#D4A373$??IRANSansWeb(FaNum))?6y   $??16(?6?   $??Bottom=?6?   $??Center=?6?   $??79,0,76.6,19.8q?6?   $	??130??6?    ? Cursor$
 Hand??6   ? ToolTip$ Ctrl+S??6J  ?? 5+      -   5        $??Resources/Positive.png??5+      $??35??64   $??2??6@   $	??Top=?6P   $
??Left=?6h   $??2??6?   $??129.4,40,0,0q?6?   $
 Hand??6?   ?? 5,      -   5        $ Ex_btn??5,     $??1??6   $
??Left=?6!   $??Bottom=?6<   ???#D8315B$)??#بازگشت به صفحه اصلی??6l   $??30??6?   $??32,0,0,-2.6q?6?   ???#F2F2F2$??IRANSansWeb(FaNum))?6?   $??11(?6?    J? RenderTransformOrigin$ 1.06,0.9&?6?   $
 Hand??6  $ Ctrl+L??6`  ?? 5-      -	   5        $??Resources/Left.png??5-      $
??Left=?60   $??Bottom=?6K   $??3??6f   $??31??6s   $ 1.323,0.536&?6   $??
1,0,0,-2.6q?6?   $
 Hand??6?   $ Ctrl+L??6?   ?? 5.      $ ??ارسال برای همه??6   $??2??6-   $	??Top=?6=   $
??Left=?6U   ???#FAEDCD???#FAEDCD???#D4A373$??IRANSansWeb(FaNum))?6?   $??30.4,40,0,0q?6?   ?? 5/      -
   5         ??Name$ 	CheckBox1??5/      $??2??6*   $	??Top=?6:   $
??Left=?6R   $??
9.4,50,0,0q?6m   6?   ?? 50      -   5        $??پاک کن??50      ???#FEFAE0???#D8315B$??223,248,0.4,172.8q?6O   $??IRANSansWeb(FaNum))?6j   $??63??6?   $??36??6?   $
 Hand??6?   51      52       J? CommandBindings 53      )  #System.Windows.Input.CommandBinding  54   
   -   5        $   ManagementMobile.MessageWindow   ButtonLeave    Command#  Z 54      55        56   
   -   5        !   ButtonSubmit#  Z! 56      57        58   
   -   5        "   ButtonCustomer#  Z" 58      59        5:   
   -   5        #   ButtonActivity#  Z# 5:      5;        5<   
   -   5        $   ButtonInvoice#  Z$ 5<      5=        5>   
   -   5        %   ButtonPhone#  Z% 5>      5?        5@   
   -   5        &   ButtonRepair#  Z& 5@      5A        5B   
   -   5        '   ButtonReport#  Z' 5B      5C        5D   
   -   5        (   ButtonReminder#  Z( 5D      5E        5F   
   -   5        )   
ButtonUser#  Z) 5F      5G        5H   
   -   5        *   ButtonMessage#  Z* 5H      5I        5J   
   -   5        +   ButtonSetting#  Z+ 5J      5K      5M      