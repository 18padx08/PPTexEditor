using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PPTexEditor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static string code = "";
        public static int position = -1;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InsertEquation));
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            this.textBox.Document.GetText(Windows.UI.Text.TextGetOptions.UseCrlf,out MainPage.code);
            MainPage.position = this.textBox.Document.Selection.GetIndex(Windows.UI.Text.TextRangeUnit.Character);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter != null)
            {
                //we got any parameter, insert it into the textfield
                if (MainPage.position > -1)
                {
                    //split string into [0,pos] and [pos+1,end]
                    // var firstpart = MainPage.code.Substring(0, MainPage.position);
                    //var secondpart = MainPage.code.Substring(MainPage.position, MainPage.code.Length - firstpart.Length);
                    //this.textBox.Document.SetText(Windows.UI.Text.TextSetOptions.ApplyRtfDocumentDefaults, firstpart + e.Parameter as string + secondpart);
                    this.textBox.Document.SetText(Windows.UI.Text.TextSetOptions.ApplyRtfDocumentDefaults, MainPage.code);
                    //this.textBox.Document.Selection.SetIndex(Windows.UI.Text.TextRangeUnit.Character, MainPage.position, false);
                    this.textBox.Document.Selection.SetRange(MainPage.position, MainPage.position);
                    this.textBox.Document.Selection.Text = e.Parameter as String + "\n";

                }
                else
                {
                    this.textBox.Document.SetText(Windows.UI.Text.TextSetOptions.ApplyRtfDocumentDefaults, MainPage.code + e.Parameter as string + "\n");
                }
                
            }
        }

        public static string startlatex = @"
\documentclass[a4paper,twoside,12pt]{article}
\usepackage{graphicx}
\usepackage{mathtools}
\usepackage{siunitx}
\begin{document}
    \title{##TITLE##}
    \author{##AUTHOR##}
    \maketitle
\end{document}
        ";

        private void button_Copy3_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Document.SetText(Windows.UI.Text.TextSetOptions.ApplyRtfDocumentDefaults, MainPage.startlatex);
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CalcTablePage), null);
        }
    }
}
