﻿#pragma checksum "..\..\..\..\Views\SearchViews\SearchHotelView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7BE3185E249BF0FC53690329F73E0CF58B20B895"
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
using TravelDiaries.Views.SearchViews;


namespace TravelDiaries.Views.SearchViews {
    
    
    /// <summary>
    /// SearchHotelView
    /// </summary>
    public partial class SearchHotelView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Views\SearchViews\SearchHotelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listHotel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\SearchViews\SearchHotelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listRates;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\SearchViews\SearchHotelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnok;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\SearchViews\SearchHotelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtID;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Views\SearchViews\SearchHotelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Views\SearchViews\SearchHotelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
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
            System.Uri resourceLocater = new System.Uri("/TravelDiaries;component/views/searchviews/searchhotelview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\SearchViews\SearchHotelView.xaml"
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
            this.listHotel = ((System.Windows.Controls.ListView)(target));
            
            #line 11 "..\..\..\..\Views\SearchViews\SearchHotelView.xaml"
            this.listHotel.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListHotel_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listRates = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.btnok = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Views\SearchViews\SearchHotelView.xaml"
            this.btnok.Click += new System.Windows.RoutedEventHandler(this.btnok_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtID = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\..\Views\SearchViews\SearchHotelView.xaml"
            this.txtID.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtID_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\..\Views\SearchViews\SearchHotelView.xaml"
            this.txtName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\Views\SearchViews\SearchHotelView.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.BtnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

