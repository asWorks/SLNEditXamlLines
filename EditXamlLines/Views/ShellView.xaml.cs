using EditXamlLines.ViewModels;
using EditXamlLines.Models;
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
using System.Windows.Shapes;

namespace EditXamlLines.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {


        //ShellViewModel vModel;
      
        public ShellView()
        {
            InitializeComponent();
            //vModel = new ShellViewModel();
            //this.DataContext = vModel;

        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            //var dataObj = e.Data as DataObject;
            //var dragged = dataObj.GetData(typeof(TerminData)) as TerminData;

            //MessageBox.Show(dragged.PatientenName);

        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            //ListBox rect = sender as ListBox;
            //if (rect != null && e.LeftButton == MouseButtonState.Pressed)
            //{

            //    var td = new TerminData { Behandler = "Mariann", PatientenName = "Michael Stöver", ID = "0401234567" };

            //    //System.Windows.DragDrop.DoDragDrop(rect,
            //    //              DateTime.Now.ToLongTimeString(),

            //    //                     System.Windows.DragDropEffects.Copy);

            //    var dragData = new DataObject(typeof(TerminData), td);
            //    DragDrop.DoDragDrop(rect, dragData, DragDropEffects.Copy);


            //}

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            var buf = e;
            
            

           // ListBox lb1 = (ListBox)e.Source as ListBox;

            //Get the position
            //var currp = e.GetPosition(lb1);
            //Get whats under that position
            //var elem = lb1.InputHitTest(currp);




            //DependencyObject Par = (DependencyObject)elem;

            //while (!Par.GetType().Equals(typeof(ListViewItem)))
            //{

            //    Par = VisualTreeHelper.GetParent((DependencyObject)Par);
            //    Console.WriteLine(Par.GetType().ToString());


            //}


            //var item = (ListViewItem)Par;
            //var termin = (TerminDataViewModel)item;

            //var box = Par;

            //while (!box.GetType().Equals(typeof(ListView)))
            //{

            //    box = VisualTreeHelper.GetParent((DependencyObject)box);
            //    Console.WriteLine(box.GetType().ToString());


            //}


            //ListView ParentBox = (ListView)box;
            
            //TerminDataViewModel termin =  ParentBox.ItemContainerGenerator.ContainerFromItem((TerminDataViewModel)item);


            //var par= VisualTreeHelper.GetParent((DependencyObject)elem);

            //var res = VisualTreeHelper.GetChildrenCount((DependencyObject)elem);
            //for (int i = 0; i <res; i++)
            //{
            //    var buffer = VisualTreeHelper.GetChild((DependencyObject)elem,i);
            //}

            //if (res!= null)
            //{

            //}

            ////Your ListView or DataGrid will have set the DataContext to your bound item 
            //if (elem is FrameworkElement && (elem as FrameworkElement).DataContext != null)
            //{
            //    var target = lb1.ItemContainerGenerator.ContainerFromItem((elem as FrameworkElement).DataContext);
            //}


            //ListBox lb2 = (ListBox)lb1.SelectedItem as ListBox;
            //TerminDataViewModel vm = (TerminDataViewModel)lb2.SelectedItem as TerminDataViewModel;

                 

            //MessageBox.Show(vm.Behandler);
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
          //Rectangle rect = sender as Rectangle;
          //  if (rect != null && e.LeftButton == MouseButtonState.Pressed)
          //  {

          //      //Just as commnt for a commit

          //      var td = new TerminDataViewModel {  ID = 10 };

          //      //System.Windows.DragDrop.DoDragDrop(rect,
          //      //              DateTime.Now.ToLongTimeString(),

          //      //                     System.Windows.DragDropEffects.Copy);

          //      var dragData = new DataObject(typeof(TerminDataViewModel), td);
          //      DragDrop.DoDragDrop(rect, dragData, DragDropEffects.Copy);


            //}
        }

        private void TextBlock_Drop(object sender, DragEventArgs e)
        {

            var s = (Rectangle)sender;



        }
    }
}
