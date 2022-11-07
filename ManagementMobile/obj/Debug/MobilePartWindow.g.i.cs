﻿#pragma checksum "..\..\MobilePartWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B2C2FB2A88BDF59C7A1AC89E8375DE58A28C0E3CDD3BDBF772473E92D2B6F689"
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
    /// MobilePartWindow
    /// </summary>
    public partial class MobilePartWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\MobilePartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock contacts;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\MobilePartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_name;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MobilePartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_price;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\MobilePartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_stock;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\MobilePartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label register;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\MobilePartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_sh;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\MobilePartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.SearchBar SearchBar;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\MobilePartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid1;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\MobilePartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label dt_btn;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\MobilePartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ed_btn;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\MobilePartWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/ManagementMobile;component/mobilepartwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MobilePartWindow.xaml"
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
            
            #line 13 "..\..\MobilePartWindow.xaml"
            ((ManagementMobile.MobilePartWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.MobilePartWindow_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.contacts = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txt_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txt_stock = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.register = ((System.Windows.Controls.Label)(target));
            
            #line 43 "..\..\MobilePartWindow.xaml"
            this.register.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Register_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lbl_sh = ((System.Windows.Controls.Label)(target));
            
            #line 51 "..\..\MobilePartWindow.xaml"
            this.lbl_sh.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Lbl_sh_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SearchBar = ((HandyControl.Controls.SearchBar)(target));
            
            #line 52 "..\..\MobilePartWindow.xaml"
            this.SearchBar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchBar_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.DataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 53 "..\..\MobilePartWindow.xaml"
            this.DataGrid1.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.DataGrid1_OnSelectedCellsChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.dt_btn = ((System.Windows.Controls.Label)(target));
            
            #line 61 "..\..\MobilePartWindow.xaml"
            this.dt_btn.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Dt_btn_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ed_btn = ((System.Windows.Controls.Label)(target));
            
            #line 68 "..\..\MobilePartWindow.xaml"
            this.ed_btn.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Ed_btn_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Ex_btn = ((System.Windows.Controls.Label)(target));
            
            #line 75 "..\..\MobilePartWindow.xaml"
            this.Ex_btn.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Ex_btn_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 76 "..\..\MobilePartWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Ex_btn_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

