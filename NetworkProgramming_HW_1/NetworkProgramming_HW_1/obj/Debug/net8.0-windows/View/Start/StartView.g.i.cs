﻿#pragma checksum "..\..\..\..\..\View\Start\StartView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "244990EAC59A36A8CA27AC38E29905EC1BC51443"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NetworkProgramming_HW_1.View.Start;
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


namespace NetworkProgramming_HW_1.View.Start {
    
    
    /// <summary>
    /// StartView
    /// </summary>
    public partial class StartView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\..\View\Start\StartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView serverMessageList;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\View\Start\StartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button startServerButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\View\Start\StartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView userMessageList;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\View\Start\StartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button connectToServer;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\View\Start\StartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userMessage;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\View\Start\StartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sendUserMessage;
        
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
            System.Uri resourceLocater = new System.Uri("/NetworkProgramming_HW_1;V1.0.0.0;component/view/start/startview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Start\StartView.xaml"
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
            this.serverMessageList = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.startServerButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\..\View\Start\StartView.xaml"
            this.startServerButton.Click += new System.Windows.RoutedEventHandler(this.startServerButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.userMessageList = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.connectToServer = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\..\View\Start\StartView.xaml"
            this.connectToServer.Click += new System.Windows.RoutedEventHandler(this.connectToServer_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.userMessage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.sendUserMessage = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\..\View\Start\StartView.xaml"
            this.sendUserMessage.Click += new System.Windows.RoutedEventHandler(this.sendUserMessage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

