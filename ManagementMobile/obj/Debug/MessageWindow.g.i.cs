﻿#pragma checksum "..\..\MessageWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A6468504523C506BCB5C843FF7228570A0DF7E0752F3D2A3CEB6E84471A7D2B8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// MessageWindow
    /// </summary>
    public partial class MessageWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\MessageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_number;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MessageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid1;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MessageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox txt_info;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MessageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\MessageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label btn_register;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\MessageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Ex_btn;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\MessageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBox1;
        
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
            System.Uri resourceLocater = new System.Uri("/ManagementMobile;component/messagewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MessageWindow.xaml"
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
            
            #line 13 "..\..\MessageWindow.xaml"
            ((ManagementMobile.MessageWindow)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.MessageWindow_OnKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_number = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\MessageWindow.xaml"
            this.txt_number.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Txt_number_OnTextChanged);
            
            #line default
            #line hidden
            
            #line 31 "..\..\MessageWindow.xaml"
            this.txt_number.KeyDown += new System.Windows.Input.KeyEventHandler(this.Txt_number_OnKeyDown);
            
            #line default
            #line hidden
            
            #line 31 "..\..\MessageWindow.xaml"
            this.txt_number.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Txt_number_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.txt_info = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 5:
            this.ListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.btn_register = ((System.Windows.Controls.Label)(target));
            
            #line 42 "..\..\MessageWindow.xaml"
            this.btn_register.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Btn_register_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 43 "..\..\MessageWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Submit_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Ex_btn = ((System.Windows.Controls.Label)(target));
            
            #line 44 "..\..\MessageWindow.xaml"
            this.Ex_btn.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Ex_btn_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 45 "..\..\MessageWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Ex_btn_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.CheckBox1 = ((System.Windows.Controls.CheckBox)(target));
            
            #line 47 "..\..\MessageWindow.xaml"
            this.CheckBox1.Checked += new System.Windows.RoutedEventHandler(this.CheckBox1_OnChecked);
            
            #line default
            #line hidden
            
            #line 47 "..\..\MessageWindow.xaml"
            this.CheckBox1.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox1_OnUnchecked);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 48 "..\..\MessageWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UIElement_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 53 "..\..\MessageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.LeaveMethod);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 55 "..\..\MessageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SubmitMethod);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 57 "..\..\MessageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CustomerMethod);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 59 "..\..\MessageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ActivityMethod);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 61 "..\..\MessageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.InvoiceMethod);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 63 "..\..\MessageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.PhoneMethod);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 65 "..\..\MessageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.RepairMethod);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 67 "..\..\MessageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ReportMethod);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 69 "..\..\MessageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ReminderMethod);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 71 "..\..\MessageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.UserMethod);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 73 "..\..\MessageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.MessageMethod);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 75 "..\..\MessageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SettingMethod);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

