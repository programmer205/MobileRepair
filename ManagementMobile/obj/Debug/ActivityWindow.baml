   M S B A M L   `   `   `  ????K  GManagementMobile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ManagementMobileManagementMobile  5   	   Q MWPFTextBoxAutoComplete, Version=1.0.0.2, Culture=neutral, PublicKeyToken=null_Dclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoCompleteWPFTextBoxAutoComplete 5   	   %    ManagementMobile.ActivityWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ManagementMobile     5   	   S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   T	behaviorsDclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoComplete  5   	   -   5          ?Name$  ActivityWPF??5   	   
??????  ? AllowsTransparency .  ? 
ResizeMode$ NoResize=?5   	    ? WindowStyle$
 None=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Title$ ActivityWindow??5   	   $	??680??6    $
??1150??6-   .??5      ?? ???#D4A373$??5q?6#    ?? CornerRadius$ 10??67   ._?5   
   ? -   5         ?Name$ MyGrid??5   $   ???#D4A373 ? ColumnDefinitions 5      ?? 5      ?? 5      ?? 5      ?? 5      	 ? RowDefinitions	 5      ?? 5      $	??100 ?6    ?? 5      $	??100 ?6    ?? 5      $	??150 ?6    ?? 5      $	??330 ?6    .+?5!      ?? $??4??6   $??2??6)   $??5q?6:   ???#FAEDCD$??3q?6[   $ 10??6o   ._?5"      ?? ???#FAEDCD6   5#      ? 5$      $	??Top=?6   $??Center=?60   $??0??6M   $??1??6Z   $??2??6j   $??0,15,0,0q?6~   .+?5%      ?? -   5        
 ??Name$
 contacts??5%   ?   $(??"افزودن فعالیت جدید??6   $??20(?66   ???#D4A373$??Center=?6Y   $??IRANSansWeb(FaNum))?6t   $
??Bold"?6?   6?   ?? 5&      $"??Resources/ActivityWindow.png??6   $??35??6>   5'      ?? 5(      $??0??6   $??3??6!   $??Right=?61   $	??Top=?6M   $??تلفن مشتری??6e   ???#D4A373???#FAEDCD???#FAEDCD$??IRANSansWeb(FaNum))?6?   $??0,90,14.8,0q?6?   $??2??6?   ?? 5)      -   5         ??Name$ txt_customer??5)      $??0??6-   $??3??6:   $??Right=?6J   $	??Top=?6f   $??0,86,89.8,0q?6~   $??32??6?   $	??185??6?   $??2??6?   1  +WPFTextBoxAutoComplete.AutoCompleteBehavior   AutoCompleteItemsSource 6?   ?? *MyCustomers+6;  ?? 5*      $??3??6   $??Right=?6$   $??Center=?6@   $??نام کاربر??6[   ???#D4A373???#FAEDCD???#FAEDCD$??IRANSansWeb(FaNum))?6?   $??0,25,14.8,42q?6?   $??1??6?    J? RenderTransformOrigin$ 0.469,0.221&?6?   $??33??6  ?? 5+      -   5        $ txt_user??5+      $??3??6)   $??Right=?69   $??Center=?6U   $??0,25,89.8,43q?6p   $??32??6?   $	??185??6?   $??1??6?    6?   ?? *	MyUsers+6!  ?? 5,      $??1??6   $??3??6!   $??Bottom=?61   $??Right=?6L   $??
موضوع??6h   ???#D4A373???#FAEDCD???#FAEDCD$??IRANSansWeb(FaNum))?6?   $??0,0,15,8q?6?   ?? 5-      -   5        $ 	txt_title??5-      $??1??6)   $??3??66   $??Bottom=?6F   $??Right=?6a   $??
0,0,89.8,8q?6}   $	??185??6?   6?   ?? 5.      $??2??6   $??2??6%   $??Right=?65   $??توضیحات??6Q   ???#D4A373???#FAEDCD???#FAEDCD$??IRANSansWeb(FaNum))?6?   $??0,0,5,0q?6?   ?? 5/      -   5         ??Name$ txt_info??5/      $??2??6,   $??1??6=   $??Right=?6M   $	??485??6i   $??
0,75,75,10q?6u   $??2??6?   6?   ?? 50      $??0??6   $??Right=?6!   $	??Top=?6=   $C??=برای این فعالیت یادآورد تنظیم شود??6U   ???#D4A373???#FAEDCD???#FAEDCD$??IRANSansWeb(FaNum))?6?   $??	0,45,15,0q?6?   ?? 51      -   5         ??Name$ 	CheckBox1??51      $??0??6*   $	??Top=?67   $
??Left=?6O   $??	58,54,0,0q?6j   6?   ?? 52      -	   5         ??Name$ 
Label_Date??52      $??2??6)   $??Right=?6:   $??Center=?6V   $??
تاریخ??6q   ???#D4A373???#FAEDCD???#FAEDCD$??IRANSansWeb(FaNum))?6?   $??0,0,15,0q?6?   {?.  6?   -  'HandyControl.Controls.PersianDatePicker  53      -
   5          Name$ Tarikh??53   #   $??2??63   $??50??6D   $??25,75,56.6,75q?6P   {?.  6g   ?? 54      -   5        $ btn_register??54      $??ثبت اطلاعات??6*   $??1??6@   $??Bottom=?6M   $
??Left=?6h   $??	70,0,0,24q?6?   ???#283618???#D4A373$??IRANSansWeb(FaNum))?6?    ? Cursor$
 Hand??6   ? ToolTip$ Ctrl+S??6'  ?? 55      ???#FAEDCD$??3q?6+   $??4??6?   $??2??6S   $ 10??6`   $??5q?6r   ._?56      ?? ???#FAEDCD6   57      ? 58      $	??Top=?6   $??Center=?60   $??2??6M   $??1??6Z   $??2??6j   $??0,15,0,0q?6~   .+?59      ?? $!??جستجوی پیشرفته??6   $??20(?62   ???#D4A373$??Center=?6U   $??IRANSansWeb(FaNum))?6p   $
??Bold"?6?   ?? 5:      $"??Resources/SearchCustomer.png??6   $??35??6>   5;      ?? 5<      -   5        $??0??5<      $??2??6$   $'??!نمایش کل فعالیت ها??61   $??Center=?6N   $??Center=?6i   $??IRANSansWeb(FaNum))?6?   $??16(?6?   ???#D4A373???#283618$
 Hand??6?   6?   %  HandyControl.Controls.SearchBar  5=      -   5          Name$ 	SearchBar??5=   ?   $??2??6   $??55??6)   $??Right=?65   $??Center=?6Q   $??3??6l   $??0,57.2,19.8,32.6q?6?   $	??740??6?    ?? TextAlignment$ Center=?6?   $??IRANSansWeb(FaNum))?6?   $??1??6?   6  &   System.Windows.Controls.DataGrid  5>      -   5          Name$ 	DataGrid1??5>      $??3??6*   $??4??67   $??	5,30,5,40q?6K   ???#FEFAE0???#F2F2F2???#F2F2F2   Attacktogrid   ColumnHeaderStyle# [  6?      CanUserResizeColumns .     AutoGenerateColumns .     CanUserAddRows .     CanUserReorderColumns .     CanUserSortColumns .     CanUserDeleteRows .     CanUserResizeRows .     
IsReadOnly . $??RightToLeft=?6?      Columns  5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn!   Header$! 	آیدی ??6)   "   
Visibility$" Hidden=?6W   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 68   ?? *
ActivityId+6W     5A      $! 
عنوان??6)   $   Width5  /System.Windows.Controls.DataGridLengthConverter$	$ 150 6R   # 68   ?? *Title+6R     5B      $! نام کاربری??6)   $	$ 150 6Z   # 6=   ?? *
UserName+6Z     5C      $! نام مشتری??6)   $	$ 150 6]   # 6<   ?? *CustomerName+6]     5D      $! توضیحات??6)   $	$ 300 6S   # 6:   ?? *Info+6S     5E      $! 
تاریخ??6)   $	$ 150 6T   # 68   ?? *	RegDate+6T   5G      ?? 5H      -   5        $ dt_btn??5H   w   $??حذف??6   $??4??6"   $??3??62   $??0,0,5,0q?6?     Attacktolable#??[ 6P   % ? 	Resources% 5I      & ?? 
TargetType' ?? Property( ?? Value??%^   '??       ?? 5J      "& ??6   .?5K      ?? ' ?@??CornerRadius$( 5??69   5L      5M      5N      ?? 5O      -   5        $ ed_btn??5O   ?   ???#3E92CC$??ویرایش??6)   $??4??6:   $??3??6J   $??0,0,45,0q?6W   #??[ 6i   % 5P      ??%^   '??       ?? 5Q      "& ??6   .?5R      ?? ' ?@??CornerRadius$( 5??69   5S      5T      5U      ?? 5V      -   5        $ Ex_btn??5V     $??3??6   $
??Left=?6!   $??Bottom=?6<   ???#D8315B$)??#بازگشت به صفحه اصلی??6l   $??30??6?   $??	32,0,0,10q?6?   ???#F2F2F2$??IRANSansWeb(FaNum))?6?   $??11(?6?   $ 1.06,0.9&?6?   $
 Hand??6  $ Ctrl+L??6^  ?? 5W      -   5        $??Resources/Left.png??5W      $
??Left=?60   $??Bottom=?6K   $??3??6f   $??31??6s   $ 1.323,0.536&?6   $??1,0,0,10q?6?   $
 Hand??6?   $ Ctrl+L??6?   5X      5Y      ) J? CommandBindings) 5Z      )	  #System.Windows.Input.CommandBinding	  5[   
   -   5        %
   ManagementMobile.ActivityWindow* 
  ButtonLeave+ 	  Command#+ Z* 5[      5\      	  5]   
   -   5        , 
  ButtonSubmit#+ Z, 5]      5^      	  5_   
   -   5        - 
  ButtonCustomer#+ Z- 5_      5`      	  5a   
   -   5        . 
  ButtonActivity#+ Z. 5a      5b      	  5c   
   -   5        / 
  ButtonInvoice#+ Z/ 5c      5d      	  5e   
   -   5        0 
  ButtonPhone#+ Z0 5e      5f      	  5g   
   -   5        1 
  ButtonRepair#+ Z1 5g      5h      	  5i   
   -   5        2 
  ButtonReport#+ Z2 5i      5j      	  5k   
   -   5        3 
  ButtonReminder#+ Z3 5k      5l      	  5m   
   -   5        4 
  
ButtonUser#+ Z4 5m      5n      	  5o   
   -   5        5 
  ButtonMessage#+ Z5 5o      5p      	  5q   
   -   5        6 
  ButtonSetting#+ Z6 5q      5r      5t      