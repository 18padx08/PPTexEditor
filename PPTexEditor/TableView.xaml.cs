using PPTexEditor.PPTexClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PPTexEditor
{
    public sealed partial class TableView : UserControl
    {
        public TableView()
        {
            this.InitializeComponent();
        }

        public List<string> getXHeader()
        {
            List<string> tmpX = new List<string>();
            foreach (TableValue theThing in this.Table.SelectedItems)
            {
                if (theThing.isXheader && !theThing.isYheader) tmpX.Add(theThing.value);
                continue;
            }
            return tmpX;
         }
        public List<string> getYHeader()
        {
            List<string> tmpY = new List<string>();
            foreach (TableValue theThing in this.Table.SelectedItems)
            {
                if (!theThing.isXheader && theThing.isYheader) tmpY.Add(theThing.value);
                continue;
            }
            return tmpY;
        }

        public List<List<string>> getTable()
        {
            List<List<string>> tmpTable = new List<List<string>>();
            int lastRow = -1;
            var tmpRow = new List<string>();
            var sortedSI = (from si in this.Table.SelectedItems
                            orderby (si as TableValue).id
                            select si);
            foreach (TableValue theThing in sortedSI)
            {
                if (theThing.isYheader || theThing.isXheader) continue;

                if(lastRow == -1 || theThing.Row != lastRow)
                {
                    if(lastRow != -1)
                        tmpTable.Add(tmpRow);
                    lastRow = theThing.Row;
                    tmpRow = new List<string>();
                    tmpRow.Add(theThing.value);
                }
                else
                {
                    tmpRow.Add(theThing.value);
                }
                
            }
            tmpTable.Add(tmpRow);
            return tmpTable;
        }

        public double width = 150;
        private void GridView_Loaded(object sender, RoutedEventArgs e)
        {
            //GridViewLoaded add standard table template
            this.width = this.ActualWidth / 8;
            for(int i =0; i< this.ActualHeight/50 * 8; i++)
            {
                
                this.Table.Items.Add(new TableValue() { id = i, value = "", isXheader = i / 8 ==0, isYheader = i%8==0 });
            }

        }
    }
}
