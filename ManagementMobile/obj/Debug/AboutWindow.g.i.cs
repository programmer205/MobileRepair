﻿#pragma checksum "..\..\AboutWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "08F55E4331AA16D04904B8A1AFD2B1C8A2BA60EDF4A6E29ED524C49CDCA0B1ED"
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
    /// AboutWindow
    /// </summary>
    public partial class AboutWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\AboutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ManagementMobile.AboutWindow AboutWPF;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\AboutWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/ManagementMobile;component/aboutwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AboutWindow.xaml"
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
            this.AboutWPF = ((ManagementMobile.AboutWindow)(target));
            
            #line 14 "..\..\AboutWindow.xaml"
            this.AboutWPF.KeyDown += new System.Windows.Input.KeyEventHandler(this.AboutWindow_OnKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Ex_btn = ((System.Windows.Controls.Label)(target));
            
            #line 91 "..\..\AboutWindow.xaml"
            this.Ex_btn.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Ex_btn_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 92 "..\..\AboutWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Ex_btn_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 97 "..\..\AboutWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.LeaveMethod);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 99 "..\..\AboutWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SubmitMethod);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 101 "..\..\AboutWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CustomerMethod);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 103 "..\..\AboutWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ActivityMethod);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 105 "..\..\AboutWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.InvoiceMethod);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 107 "..\..\AboutWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.PhoneMethod);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 109 "..\..\AboutWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.RepairMethod);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 111 "..\..\AboutWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ReportMethod);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 113 "..\..\AboutWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ReminderMethod);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 115 "..\..\AboutWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.UserMethod);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 117 "..\..\AboutWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.MessageMethod);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 119 "..\..\AboutWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SettingMethod);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
