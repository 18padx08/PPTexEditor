using PPTexEditor.PPTexClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class CalcTablePage : Page
    {
        public CalcTablePage()
        {
            this.InitializeComponent();
            this.Figures = new ObservableCollection<Figure>();
            this.DataContext = this;
        }

        public ObservableCollection<Figure> Figures { get; set; }

        //Abbort button
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null);
        }

        //InsertButton
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            List<string> xheaders = this.theTable.getXHeader();
            List<string> yheaders = this.theTable.getYHeader();
            List<List<string>> table = this.theTable.getTable();
            CalcTable cTable = new CalcTable() { xheader = xheaders, yheader = yheaders, description = this.Description.Text, extended = true, figures = this.Figures.ToList(), table = table };
            Frame.Navigate(typeof(MainPage), cTable.ToString());
        }

        //Addbutton
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Figure fig = new Figure() { title = this.Title.Text, caption = "", desc = this.Description.Text, reference = "blub", xrow = int.Parse(this.x.Text), yrow = int.Parse(this.y.Text), xlabel = "x", ylabel = "y" };
            this.Figures.Add(fig);
        }
    }
}
