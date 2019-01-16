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

namespace EditXamlLines.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainDisplayView : UserControl
    {
        XamlEditTools Xet;
        public MainDisplayView()
        {
            InitializeComponent();
            Xet = new XamlEditTools();
            //this.DataContext = Xet;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.DataContext.ToString());
        }

            //private void GetTextBox_Click(object sender, RoutedEventArgs e)
            //{
            //   // var x = new XamlEditTools();
            //    // x.ReadFromTextBox(x.XamlSource);
            //    Xet.ReadFromTextBox(TbXamlSource.Text.ToString());
            //    //this.DataContext = x;
            //}

            //private void GetClipboard_Click(object sender, RoutedEventArgs e)
            //{
            //    if (Clipboard.ContainsText())
            //    {
            //        string buf = Clipboard.GetText(TextDataFormat.Text);
            //       // var x = new XamlEditTools();
            //        Xet.ParseInputXaml(buf);
            //       // this.DataContext = x;
            //    }
            //}

            //private void RewriteXaml_Click(object sender, RoutedEventArgs e)
            //{
            //  var res =   Xet.ReWriteXaml();
            //    Clipboard.SetText(res); 
            //}
        }
}
