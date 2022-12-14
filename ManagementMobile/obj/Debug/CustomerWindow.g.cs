#pragma checksum "..\..\CustomerWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "338F3933ED000C76ECA5534D2942D017F094D1D8A5C9970D72F0C3296211FF9B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Expression.Media;
using HandyControl.Expression.Shapes;
using HandyControl.Interactivity;
using HandyControl.Media.Animation;
using HandyControl.Media.Effects;
using HandyControl.Properties.Langs;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl.Tools.Converter;
using HandyControl.Tools.Extension;
using ManagementMobile;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ManagementMobile {
    
    
    /// <summary>
    /// CustomerWindow
    /// </summary>
    public partial class CustomerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ManagementMobile.CustomerWindow CustomerWPF;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock contacts;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_name;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_phone;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label register;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.SearchBar SearchBar;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid1;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label dt_btn;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ed_btn;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Ex_btn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ManagementMobile;component/customerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CustomerWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CustomerWPF = ((ManagementMobile.CustomerWindow)(target));
            
            #line 15 "..\..\CustomerWindow.xaml"
            this.CustomerWPF.Loaded += new System.Windows.RoutedEventHandler(this.CustomerWindow_OnLoaded);
            
            #line default
            #line hidden
            
            #line 16 "..\..\CustomerWindow.xaml"
            this.CustomerWPF.KeyDown += new System.Windows.Input.KeyEventHandler(this.CustomerWindow_OnKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.contacts = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txt_name = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\CustomerWindow.xaml"
            this.txt_name.KeyDown += new System.Windows.Input.KeyEventHandler(this.Txt_name_OnKeyDown);
            
            #line default
            #line hidden
            
            #line 41 "..\..\CustomerWindow.xaml"
            this.txt_name.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Txt_name_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_phone = ((System.Windows.Controls.TextBox)(target));
            
            #line 43 "..\..\CustomerWindow.xaml"
            this.txt_phone.KeyDown += new System.Windows.Input.KeyEventHandler(this.Txt_phone_OnKeyDown);
            
            #line default
            #line hidden
            
            #line 43 "..\..\CustomerWindow.xaml"
            this.txt_phone.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Txt_phone_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.register = ((System.Windows.Controls.Label)(target));
            
            #line 44 "..\..\CustomerWindow.xaml"
            this.register.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Register_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 52 "..\..\CustomerWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UIElement_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SearchBar = ((HandyControl.Controls.SearchBar)(target));
            
            #line 53 "..\..\CustomerWindow.xaml"
            this.SearchBar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchBar_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 54 "..\..\CustomerWindow.xaml"
            this.DataGrid1.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.DataGrid1_OnSelectedCellsChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dt_btn = ((System.Windows.Controls.Label)(target));
            
            #line 62 "..\..\CustomerWindow.xaml"
            this.dt_btn.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Dt_btn_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ed_btn = ((System.Windows.Controls.Label)(target));
            
            #line 69 "..\..\CustomerWindow.xaml"
            this.ed_btn.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Ed_btn_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Ex_btn = ((System.Windows.Controls.Label)(target));
            
            #line 76 "..\..\CustomerWindow.xaml"
            this.Ex_btn.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Ex_btn_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 77 "..\..\CustomerWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Ex_btn_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 82 "..\..\CustomerWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.LeaveMethod);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 84 "..\..\CustomerWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SubmitMethod);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 86 "..\..\CustomerWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CustomerMethod);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 88 "..\..\CustomerWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ActivityMethod);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 90 "..\..\CustomerWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.InvoiceMethod);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 92 "..\..\CustomerWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.PhoneMethod);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 94 "..\..\CustomerWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.RepairMethod);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 96 "..\..\CustomerWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ReportMethod);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 98 "..\..\CustomerWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ReminderMethod);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 100 "..\..\CustomerWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.UserMethod);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 102 "..\..\CustomerWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.MessageMethod);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 104 "..\..\CustomerWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SettingMethod);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

