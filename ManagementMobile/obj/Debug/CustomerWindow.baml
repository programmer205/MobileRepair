   M S B A M L   `   `   `  ????K  GManagementMobile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ManagementMobileManagementMobile  5   	   %    ManagementMobile.CustomerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ManagementMobile     5   	   S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   -   5          ?Name$  CustomerWPF??5   	   
??????  ? AllowsTransparency .  ? 
ResizeMode$ NoResize=?5   	    ? WindowStyle$
 None=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Title$ CustomerWindow??5   	   $	??680??6    $
??1150??6-   .??5      ?? ???#CCD5AE$??5q?6#    ?? CornerRadius$ 10??67   ._?5   
   ? ???#CCD5AE ? ColumnDefinitions 5      ?? 5      ?? 5      ?? 5      ?? 5       ? RowDefinitions 5      ?? 5      $??50 ?6    ?? 5      $??70 ?6    ?? 5      $
??145* ?6    ?? 5      $
??346* ?6    .+?5!      ?? $??4??6   $??2??6)   $??5q?6:   ???#FAEDCD$??3q?6[   $ 10??6o   ._?5"      ?? ???#FAEDCD6   5#      ? 5$      $	??Top=?6   $??Center=?60   $??0??6M   $??1??6Z   $??2??6j   $??0,15,0,0q?6~   .+?5%      ?? -   5        	 ??Name$	 contacts??5%   ?   $&?? افزودن مشتری جدید??6   $??20(?65   ???#D4A373$??Center=?6X   $??IRANSansWeb(FaNum))?6s   $
??Bold"?6?   6?   ?? 5&      $"??Resources/PersonCustomer.png??6   $??35??6>   5'      ?? 5(      $??نام مشتری??6   $??12(?6(   $??1??66   $??3??6C   $??Center=?6S   $??Center=?6n   $??191,13.6,19.8,25.8q?6?   $??74??6?   $??31??6?   ???#D4A373???#FAEDCD$??IRANSansWeb(FaNum))?6?   ?? 5)      -   5        
 ??Name$
 txt_name??5)       J? RenderTransformOrigin$ 1.446,1.425&?6(   $??2??6L   $??118.8,14.6,107.8,24.8q?6\   $??1??6{   $??2??6?   $??IRANSansWeb(FaNum))?6?    ?? TextAlignment$ Center=?6?   6?   ?? 5*      $??2??6   $??شماره تلفن ??6$   $??12(?6:   $ -0.109,2.824&?6H   $??28.6,14.6,0,25.8q?6m   $??1??6?   ???#D4A373???#FAEDCD$??IRANSansWeb(FaNum))?6?   $??30??6?   $??79??6?   $
??Left=?6?   ?? 5+      -   5        $
 	txt_phone??5+      $??3??6)   $??IRANSansWeb(FaNum))?6=   $??251,14.6,262,24.8q?6^   $??1??6y   $ 0.588,2.475&?6?   $ Center=?6?    ?? 	MaxLength$ 11??6?   6?   ?? 5,      -   5         ??Name$ register??5,   =  $??ثبت اطلاعات??6   $??1??6*   $??Center=?67   $??Center=?6R   ???#D4A373???#283618$??IRANSansWeb(FaNum))?6?   $??14(?6?   $ 0.704,1.746&?6?   $??87,9.6,89.6,24.8q?6?   $	??109??6  $
??Bold"?6  $??36??6#   ? Cursor$
 Hand??6/   ? ToolTip$ Ctrl+S??6?  ?? 5-      ???#FAEDCD$??3q?6+   $ 10??6?   $??2??6Q   $??4??6^   $??5q?6r   ._?5.      ?? ???#FAEDCD6   5/      ? 50      $	??Top=?6   $??Center=?60   $??2??6M   $??1??6Z   $??2??6j   $??0,15,0,0q?6~   .+?51      ?? $!??جستجوی پیشرفته??6   $??20(?62   ???#D4A373$??Center=?6U   $??IRANSansWeb(FaNum))?6p   $
??Bold"?6?   ?? 52      $"??Resources/SearchCustomer.png??6   $??35??6>   53      ?? 54      -   5        $??0??54      $??2??6$   $$??نمایش کل مشتریان??61   $??Center=?6L   $??Center=?6g   $??IRANSansWeb(FaNum))?6?   $??16(?6?   ???#D4A373???#283618$
 Hand??6?   6?   %  HandyControl.Controls.SearchBar  55      -   5          Name$ 	SearchBar??55   ?   $??2??6   $??55??6)   $??Right=?65   $??Center=?6Q   $??3??6l   $??0,57.2,19.8,32.6q?6?   $	??740??6?   $ Center=?6?   $??IRANSansWeb(FaNum))?6?   $??1??6?   6  &   System.Windows.Controls.DataGrid  56      -   5          Name$ 	DataGrid1??56      $??3??6*   $??4??67   $??	5,30,5,30q?6K   ???#FEFAE0???#F2F2F2???#F2F2F2   Attacktogrid   ColumnHeaderStyle# [  6?      CanUserResizeColumns .     AutoGenerateColumns .     CanUserAddRows .     CanUserReorderColumns .     CanUserSortColumns .     CanUserDeleteRows .     CanUserResizeRows .     
IsReadOnly . $??RightToLeft=?6?     Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ آیدی??6)      
Visibility$ Hidden=?6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   ?? *
CustomerId+6V     59      $ نام??6)       Width5  /System.Windows.Controls.DataGridLengthConverter$	  150 6S    66   ?? *
FullName+6S     5:      $ تلفن??6)   $	  150 6X    67   ?? *PhoneNumber+6X     5;      $ 
تاریخ??6)   $	  150 6T    68   ?? *	RegDate+6T   5=      ?? 5>      -	   5        $ dt_btn??5>   w   $??حذف??6   $??4??6"   $??3??62   $??0,0,5,0q?6?     Attacktolable#??[ 6P   ! ? 	Resources! 5?      " ?? 
TargetType# ?? Property$ ?? Value??%^   '??       ?? 5@      "" ??6   .?5A      ?? # ?@??CornerRadius$$ 5??69   5B      5C      5D      ?? 5E      -
   5        $ ed_btn??5E   ?   ???#3E92CC$??ویرایش??6)   $??4??6:   $??3??6J   $??0,0,45,0q?6W   #??[ 6i   ! 5F      ??%^   '??       ?? 5G      "" ??6   .?5H      ?? # ?@??CornerRadius$$ 5??69   5I      5J      5K      ?? 5L      -   5        $ Ex_btn??5L     $??3??6   $
??Left=?6!   $??Bottom=?6<   ???#D8315B$)??#بازگشت به صفحه اصلی??6l   $??30??6?   $??32,0,0,-2.6q?6?   ???#F2F2F2$??IRANSansWeb(FaNum))?6?   $??11(?6?   $ 1.06,0.9&?6?   $
 Hand??6  $ Ctrl+L??6a  ?? 5M      -   5        $??Resources/Left.png??5M      $
??Left=?60   $??Bottom=?6K   $??3??6f   $??31??6s   $ 1.323,0.536&?6   $??
1,0,0,-2.6q?6?   $
 Hand??6?   $ Ctrl+L??6?   5N      5O      % J? CommandBindings% 5P      )  #System.Windows.Input.CommandBinding  5Q   
   -   5        %   ManagementMobile.CustomerWindow&   	btn_leave'   Command#' Z& 5Q      5R        5S   
   -   5        (   
btn_submit#' Z( 5S      5T        5U   
   -   5        )   ButtonCustomer#' Z) 5U      5V        5W   
   -   5        *   ButtonActivity#' Z* 5W      5X        5Y   
   -   5        +   ButtonInvoice#' Z+ 5Y      5Z        5[   
   -   5        ,   ButtonPhone#' Z, 5[      5\        5]   
   -   5        -   ButtonRepair#' Z- 5]      5^        5_   
   -   5        .   ButtonReport#' Z. 5_      5`        5a   
   -   5        /   ButtonReminder#' Z/ 5a      5b        5c   
   -   5        0   
ButtonUser#' Z0 5c      5d        5e   
   -   5        1   ButtonMessage#' Z1 5e      5f        5g   
   -   5        2   ButtonSetting#' Z2 5g      5h      5j      