﻿#pragma checksum "..\..\NabavkaDela.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "46413E1CA4579252001CE5A6258F88A2BD3BD5483768F360C2B300CA17B9418A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Galerija;
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


namespace Galerija {
    
    
    /// <summary>
    /// NabavkaDela
    /// </summary>
    public partial class NabavkaDela : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\NabavkaDela.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridNabavkaDela;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\NabavkaDela.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCenaNabavke;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\NabavkaDela.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBrojNabavke;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\NabavkaDela.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatumNabavke;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\NabavkaDela.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txtDelaID;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\NabavkaDela.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txtKlijentID;
        
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
            System.Uri resourceLocater = new System.Uri("/Galerija;component/nabavkadela.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NabavkaDela.xaml"
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
            
            #line 13 "..\..\NabavkaDela.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDodaj_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 14 "..\..\NabavkaDela.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonIzmeni_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 15 "..\..\NabavkaDela.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonObrisi_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DataGridNabavkaDela = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\NabavkaDela.xaml"
            this.DataGridNabavkaDela.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtCenaNabavke = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtBrojNabavke = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 23 "..\..\NabavkaDela.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DatumNabavke = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.txtDelaID = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\NabavkaDela.xaml"
            this.txtDelaID.Loaded += new System.Windows.RoutedEventHandler(this.txtDelaID_Loaded);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txtKlijentID = ((System.Windows.Controls.ComboBox)(target));
            
            #line 27 "..\..\NabavkaDela.xaml"
            this.txtKlijentID.Loaded += new System.Windows.RoutedEventHandler(this.txtKlijentID_Loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

