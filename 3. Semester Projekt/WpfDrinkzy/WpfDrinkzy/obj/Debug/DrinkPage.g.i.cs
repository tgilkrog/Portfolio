﻿#pragma checksum "..\..\DrinkPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4CC539E31118A6F84811251BD1658BD0"
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
using WpfDrinkzy;


namespace WpfDrinkzy {
    
    
    /// <summary>
    /// DrinkPage
    /// </summary>
    public partial class DrinkPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\DrinkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView DrinkList;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\DrinkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDesc;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\DrinkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrice;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\DrinkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtImg;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\DrinkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\DrinkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView IngredientList;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\DrinkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView AllIngredientList;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfDrinkzy;component/drinkpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DrinkPage.xaml"
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
            this.DrinkList = ((System.Windows.Controls.ListView)(target));
            
            #line 13 "..\..\DrinkPage.xaml"
            this.DrinkList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Changer);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtDesc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtImg = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 30 "..\..\DrinkPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.createDrink_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 31 "..\..\DrinkPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.drinkUpdate_click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 32 "..\..\DrinkPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteDrink_click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 33 "..\..\DrinkPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.cleanBoxes_click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.IngredientList = ((System.Windows.Controls.ListView)(target));
            return;
            case 11:
            this.AllIngredientList = ((System.Windows.Controls.ListView)(target));
            
            #line 42 "..\..\DrinkPage.xaml"
            this.AllIngredientList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Changer);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 52 "..\..\DrinkPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddIngredient_click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 53 "..\..\DrinkPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteIng_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
