using PPTexEditor.PPTexClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PPTexEditor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InsertEquation : Page
    {
        public InsertEquation()
        {
            this.InitializeComponent();
            this.symbols.DataContext = this.Symbols;
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null);
        }
        private ObservableCollection<PPTexClasses.Symbol> Symbols = new ObservableCollection<PPTexClasses.Symbol>();
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (this.sym.Text == "" || this.val.Text == "") return;
            this.Symbols.Add(new PPTexClasses.Symbol() { symbol=this.sym.Text, value=this.val.Text, uncert=this.uncert.Text});
            this.sym.Text = "";
            this.val.Text = "";
            this.uncert.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var arg = new Evaltex() { function = this.function.Text, fname = "t", digits = 3, errors = this.errors.IsChecked.Value, symbols = this.Symbols.ToList(), units = "" };
            Frame.Navigate(typeof(MainPage), arg.ToString());
        }

        private void symbols_Holding(object sender, HoldingRoutedEventArgs e)
        {
            MenuFlyout delete = new MenuFlyout();
            MenuFlyoutItem deleteItem = new MenuFlyoutItem() { Text = "Delete" };
            deleteItem.Click += (s, args) => 
            {
                //var listitem = s as PPTexClasses.Symbol;
               
                this.Symbols.Remove((e.OriginalSource as FrameworkElement).DataContext as PPTexClasses.Symbol);
            };
            delete.Items.Add(deleteItem);
            delete.ShowAt(sender as FrameworkElement);
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
