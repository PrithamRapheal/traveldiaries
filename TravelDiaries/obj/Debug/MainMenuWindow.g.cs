﻿#pragma checksum "..\..\MainMenuWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3F1388358F20D0BF50221C32C885F688B39087F1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using TravelDiaries;


namespace TravelDiaries {
    
    
    /// <summary>
    /// MainMenuWindow
    /// </summary>
    public partial class MainMenuWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\MainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUser;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTour;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPackages;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChauffer;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\MainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHotel;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\MainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExcursion;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\MainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCustomer;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\MainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOther;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\MainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReports;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\MainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogOut;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\MainMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDashboard;
        
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
            System.Uri resourceLocater = new System.Uri("/TravelDiaries;component/mainmenuwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainMenuWindow.xaml"
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
            
            #line 8 "..\..\MainMenuWindow.xaml"
            ((TravelDiaries.MainMenuWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnUser = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\MainMenuWindow.xaml"
            this.btnUser.Click += new System.Windows.RoutedEventHandler(this.BtnUser_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnTour = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\MainMenuWindow.xaml"
            this.btnTour.Click += new System.Windows.RoutedEventHandler(this.BtnBookTour_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnPackages = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\MainMenuWindow.xaml"
            this.btnPackages.Click += new System.Windows.RoutedEventHandler(this.BtnPackages_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnChauffer = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\MainMenuWindow.xaml"
            this.btnChauffer.Click += new System.Windows.RoutedEventHandler(this.BtnChauffer_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnHotel = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\MainMenuWindow.xaml"
            this.btnHotel.Click += new System.Windows.RoutedEventHandler(this.BtnHotel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnExcursion = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\MainMenuWindow.xaml"
            this.btnExcursion.Click += new System.Windows.RoutedEventHandler(this.BtnExcursion_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\MainMenuWindow.xaml"
            this.btnCustomer.Click += new System.Windows.RoutedEventHandler(this.BtnCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnOther = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\MainMenuWindow.xaml"
            this.btnOther.Click += new System.Windows.RoutedEventHandler(this.BtnOther_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnReports = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\MainMenuWindow.xaml"
            this.btnReports.Click += new System.Windows.RoutedEventHandler(this.BtnReports_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnLogOut = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\MainMenuWindow.xaml"
            this.btnLogOut.Click += new System.Windows.RoutedEventHandler(this.btnExit_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnDashboard = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\MainMenuWindow.xaml"
            this.btnDashboard.Click += new System.Windows.RoutedEventHandler(this.BtnDashboard_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

