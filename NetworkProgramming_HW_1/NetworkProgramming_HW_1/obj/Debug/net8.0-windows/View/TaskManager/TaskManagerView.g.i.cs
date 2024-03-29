﻿#pragma checksum "..\..\..\..\..\View\TaskManager\TaskManagerView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "322BE6F62ABD18D9528D757C19CA2E9B05CBB931"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NetworkProgramming_HW_1.View.TaskManager;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace NetworkProgramming_HW_1.View.TaskManager {
    
    
    /// <summary>
    /// TaskManagerView
    /// </summary>
    public partial class TaskManagerView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\..\View\TaskManager\TaskManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView serverInfoList;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\View\TaskManager\TaskManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView proccesInfoList;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\View\TaskManager\TaskManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button connectServerButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\View\TaskManager\TaskManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button getprocessButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\View\TaskManager\TaskManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button stopProcessButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\View\TaskManager\TaskManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button startProcessButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NetworkProgramming_HW_1;component/view/taskmanager/taskmanagerview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\TaskManager\TaskManagerView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.serverInfoList = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.proccesInfoList = ((System.Windows.Controls.ListView)(target));
            
            #line 25 "..\..\..\..\..\View\TaskManager\TaskManagerView.xaml"
            this.proccesInfoList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.proccesInfoList_Selected);
            
            #line default
            #line hidden
            return;
            case 3:
            this.connectServerButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\..\View\TaskManager\TaskManagerView.xaml"
            this.connectServerButton.Click += new System.Windows.RoutedEventHandler(this.connectServerButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.getprocessButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\..\View\TaskManager\TaskManagerView.xaml"
            this.getprocessButton.Click += new System.Windows.RoutedEventHandler(this.getprocessButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.stopProcessButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\..\View\TaskManager\TaskManagerView.xaml"
            this.stopProcessButton.Click += new System.Windows.RoutedEventHandler(this.stopProcessButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.startProcessButton = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\..\View\TaskManager\TaskManagerView.xaml"
            this.startProcessButton.Click += new System.Windows.RoutedEventHandler(this.startProcessButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

