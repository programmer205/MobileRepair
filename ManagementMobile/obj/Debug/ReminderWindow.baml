   M S B A M L   `   `   `  ????K  GManagementMobile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ManagementMobileManagementMobile  5   	   Q MWPFTextBoxAutoComplete, Version=1.0.0.2, Culture=neutral, PublicKeyToken=null_Dclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoCompleteWPFTextBoxAutoComplete 5   	   %    ManagementMobile.ReminderWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ManagementMobile     5   	   S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   T	behaviorsDclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoComplete  5   	   -   5          ?Name$  ReminderWPF??5   	   
??????  ? AllowsTransparency .  ? 
ResizeMode$ NoResize=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? WindowStyle$
 None=?5   	    ? Title$ ReminderWindow??5   	   $	??680??6    $
??1150??6-   .??5      ?? ???#CCD5AE$??5q?6#    ?? CornerRadius$ 10??67   ._?5   
   ? -   5         ?Name$ MyGrid??5      ???#CCD5AE ? ColumnDefinitions 5      ?? 5      ?? 5      ?? 5      ?? 5      	 ? RowDefinitions	 5      ?? 5      $??80 ?6    ?? 5      $??80 ?6    ?? 5      $	??160 ?6    ?? 5      $	??360 ?6    .+?5!      ?? ???#FAEDCD$??3q?6+   $ 10??6?   $??4??6Q   $??2??6e   $??5q?6v   ._?5"      ?? ???#FAEDCD6   5#      ? 5$      $??Center=?6   $??Center=?63   $??0??6P   $??1??6]   $??2??6m   $??0,0,0,25q?6?   .+?5%      ?? -   5        
 ??Name$
 contacts??5%   ?   $*??$افزودن یادآوری جدید??6   $??20(?67   ???#D4A373$??Center=?6Z   $??IRANSansWeb(FaNum))?6u   $
??Bold"?6?   6?   ?? 5&      $??Resources/AddReminder.png??6   $??35??6;   5'      ?? 5(      $??نام کاربر??6   ???#D4A373???#FAEDCD$??IRANSansWeb(FaNum))?6S   $??0??6s   $??3??6?   $??Right=?6?   $	??Top=?6?   $??	0,40,15,0q?6?   ?? 5)      -   5         ??Name$ txt_user??5)   ?   $??0??6   $??3??6#   $??32??63   $	??167??6?   $??Right=?6K   $??Center=?6g   $??0,40,84.8,8q?6?    ?? TextAlignment$ Center=?6?   1  +WPFTextBoxAutoComplete.AutoCompleteBehavior   AutoCompleteItemsSource 6?   ?? *	MyUsers+67  ?? 5*      $??
موضوع??6   ???#D4A373???#FAEDCD$??IRANSansWeb(FaNum))?6N   $??1??6n   $??3??6{   $??Right=?6?   $	??Top=?6?   $??0,5,15,0q?6?   ?? 5+      -   5        $ 	txt_title??5+   ?   $??1??6   $??3??6#   $	??Top=?63   $??Right=?6K   $??
0,5,84.8,0q?6g   $	??167??6{   $ Center=?6?   6?   ?? 5,      $??جزئیات??6   ???#D4A373???#FAEDCD$??IRANSansWeb(FaNum))?6O   $??1??6o   $??2??6|   $??Right=?6?   $	??Top=?6?   $??0,5,15,0q?6?   ?? 5-      -   5         ??Name$ txt_info??5-   ?   $??1??6   $??2??6'   $	??Top=?67   $??Right=?6O   $??
0,5,84.8,0q?6k   $	??167??6   $??60??6?   6?   ?? 5.      $??
تاریخ??6   ???#D4A373???#FAEDCD$??IRANSansWeb(FaNum))?6N   $??1??6n   $??1??6{   $??Right=?6?   $	??Top=?6?   $??0,10,15.2,0q?6?   -  'HandyControl.Controls.PersianDatePicker  5/      -   5          Name$ tarikh??5/   ?   $??1??6#   $??1??60   $	??167??6@   $??50??6L   $??Center=?6X   $
??Left=?6s   $??
40,10,0,20q?6?   6?   ?? 50      -   5         ??Name$ btn_register??50   ?   $??ثبت اطلاعات??6   ???#D4A373???#283618$??IRANSansWeb(FaNum))?6U   $??1??6u   $??0??6?   $??Center=?6?   $??Center=?6?   $??18(?6?    ? Cursor$
 Hand??6?    ? ToolTip$ Ctrl+S??65  ?? 51      ???#FAEDCD$??3q?6+   $ 10??6?   $??2??6Q   $??4??6^   $??5q?6r   ._?52      ?? ???#FAEDCD6   53      ? 54      $	??Top=?6   $??Center=?60   $??2??6M   $??1??6Z   $??2??6j   $??0,15,0,0q?6~   .+?55      ?? $!??جستجوی پیشرفته??6   $??20(?62   ???#D4A373$??Center=?6U   $??IRANSansWeb(FaNum))?6p   $
??Bold"?6?   ?? 56      $"??Resources/SearchCustomer.png??6   $??35??6>   57      ?? 58      -	   5        $??0??58      $??2??6$   $$??نمایش یادآوری ها??61   $??Center=?6L   $??Center=?6g   $??IRANSansWeb(FaNum))?6?   $??16(?6?   ???#D4A373???#283618$
 Hand??6?   6?   %  HandyControl.Controls.SearchBar  59      -
   5          Name$ 	SearchBar??59   ?   $??2??6   $??52??6)   $??Right=?65   $??Center=?6Q   $??3??6l   $??0,60,14.8,48q?6?   $	??740??6?   $ Center=?6?   $??IRANSansWeb(FaNum))?6?   $??1??6?   6?   &   System.Windows.Controls.DataGrid  5:      -   5          Name$ 	DataGrid1??5:      $??3??6*   $??4??67   $??	5,30,5,50q?6K   ???#FEFAE0???#F2F2F2???#F2F2F2   Attacktogrid   ColumnHeaderStyle# [  6?      CanUserResizeColumns .     CanUserAddRows .     CanUserReorderColumns .     CanUserSortColumns .     CanUserDeleteRows .     CanUserResizeRows .     
IsReadOnly .    AutoGenerateColumns .  $??RightToLeft=?6?   ? 	Resources 5;       ?? 
TargetType  ?? Property! ?? Value??%_   '??       ?? 5<      " ??6   .?5=      ??   ?@??CornerRadius$! 10??69   5>      5?      "   Columns" 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn#   Header$# آیدی??6)   $   
Visibility$$ Hidden=?6V   1  +System.Windows.Controls.DataGridBoundColumn%   Binding% 67   ?? *
ReminderId+6V     5B      $# نام کامل??6)   &   Width5  /System.Windows.Controls.DataGridLengthConverter$	& 130 6X   % 6;   ?? *
UserName+6X     5C      $# 
عنوان??6)   $	& 160 6Z   % 68   ?? *ReminderTitle+6Z     5D      $# توضیحات??6)   $	& 250 6[   % 6:   ?? *ReminderInfo+6[     5E      $# تاریخ ثبت??6)   $	& 130 6X   % 6<   ?? *	RegDate+6X     5F      $# تاریخ یادآور??6)   $	& 130 6_   % 6?   ?? *
RemindDate+6_     5G      $# 
وضعیت??6)   $	& 130 6T   % 68   ?? *IsDone+6T   5I      ?? 5J      -   5        $ dt_btn??5J   w   $??حذف??6   $??4??6"   $??3??62   $??0,0,5,0q?6?     Attacktolable#??[ 6P    5K      ??%^   '??       ?? 5L      " ??6   .?5M      ??   ?@??CornerRadius$! 5??69   5N      5O      5P      ?? 5Q      -   5        $ ed_btn??5Q   ?   ???#f2f2f2???#3E92CC$??ویرایش??6>   $??4??6O   $??3??6_   $??0,0,45,0q?6l   #??[ 6~    5R      ??%^   '??       ?? 5S      " ??6   .?5T      ??   ?@??CornerRadius$! 5??69   5U      5V      5W      ?? 5X      -   5        $ Ex_btn??5X     $??3??6   $
??Left=?6!   $??Bottom=?6<   ???#D8315B$)??#بازگشت به صفحه اصلی??6l   $??30??6?   $??	41,0,0,15q?6?   ???#F2F2F2$??IRANSansWeb(FaNum))?6?   $??11(?6?   ' J? RenderTransformOrigin$' 1.06,0.9&?6?   $
 Hand??6  $ Ctrl+L??6_  ?? 5Y      -   5        $??Resources/Left.png??5Y      $
??Left=?60   $??Bottom=?6K   $??3??6f   $??31??6s   $' 1.323,0.536&?6   $??	10,0,0,14q?6?   $
 Hand??6?   $ Ctrl+L??6?   5Z      5[      ( J? CommandBindings( 5\      )	  #System.Windows.Input.CommandBinding	  5]   
   -   5        %
   ManagementMobile.ReminderWindow) 
  ButtonLeave* 	  Command#* Z) 5]      5^      	  5_   
   -   5        + 
  ButtonSubmit#* Z+ 5_      5`      	  5a   
   -   5        , 
  ButtonCustomer#* Z, 5a      5b      	  5c   
   -   5        - 
  ButtonActivity#* Z- 5c      5d      	  5e   
   -   5        . 
  ButtonInvoice#* Z. 5e      5f      	  5g   
   -   5        / 
  ButtonPhone#* Z/ 5g      5h      	  5i   
   -   5        0 
  ButtonRepair#* Z0 5i      5j      	  5k   
   -   5        1 
  ButtonReport#* Z1 5k      5l      	  5m   
   -   5        2 
  ButtonReminder#* Z2 5m      5n      	  5o   
   -   5        3 
  
ButtonUser#* Z3 5o      5p      	  5q   
   -   5        4 
  ButtonMessage#* Z4 5q      5r      	  5s   
   -   5        5 
  ButtonSetting#* Z5 5s      5t      5v      