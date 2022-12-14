#pragma checksum "..\..\Notification.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F42834670AEF109BE7EC87299336366E8536B6CD644DA8C11A14041816F1825C"
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
    /// Notification
    /// </summary>
    public partial class Notification : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\Notification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_code;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Notification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_model;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Notification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_date;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Notification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_id;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Notification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_phoneId;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Notification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label btn_confirm;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Notification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label btn_cancel;
        
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
            System.Uri resourceLocater = new System.Uri("/ManagementMobile;component/notification.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Notification.xaml"
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
            this.txt_code = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txt_model = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txt_date = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txt_id = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txt_phoneId = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.btn_confirm = ((System.Windows.Controls.Label)(target));
            
            #line 23 "..\..\Notification.xaml"
            this.btn_confirm.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Btn_confirm_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_cancel = ((System.Windows.Controls.Label)(target));
            
            #line 24 "..\..\Notification.xaml"
            this.btn_cancel.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Btn_cancel_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

