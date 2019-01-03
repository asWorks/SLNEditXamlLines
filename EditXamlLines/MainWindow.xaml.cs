using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using EditXamlLines.Models;

namespace EditXamlLines
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XamlEditTools Xet;
        public MainWindow()
        {
            InitializeComponent();
            Xet = new XamlEditTools();
            this.DataContext = Xet;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var f = File.Open("C:\\Data\\Test.txt", FileMode.Open);
            //using (StreamReader sr = new StreamReader(f))
            //{
            //    var content = sr.ReadToEnd();
            //    string[] lines = content.Split('\n');

            //    foreach (var item in lines)
            //    {
            //        string buf = item.Replace("\"", "'");
            //        var x = new Models.XamlItem(buf);
            //    }
            //}

           // var x = new XamlEditTools();
            Xet.ReadFromFile("C:\\Data\\Test.txt");
           //this.DataContext = x;


        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
         {

        }

        private void GetTextBox_Click(object sender, RoutedEventArgs e)
        {
           // var x = new XamlEditTools();
            // x.ReadFromTextBox(x.XamlSource);
            Xet.ReadFromTextBox(TbXamlSource.Text.ToString());
            //this.DataContext = x;
        }

        private void GetClipboard_Click(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string buf = Clipboard.GetText(TextDataFormat.Text);
               // var x = new XamlEditTools();
                Xet.ParseInputXaml(buf);
               // this.DataContext = x;
            }
        }

        private void RewriteXaml_Click(object sender, RoutedEventArgs e)
        {
          var res =   Xet.ReWriteXaml();
            Clipboard.SetText(res); 
        }
    }
}
