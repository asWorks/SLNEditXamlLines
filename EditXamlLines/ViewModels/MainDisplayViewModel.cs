using Caliburn.Micro;
using EditXamlLines.Interfaces;
using EditXamlLines.Models;
using GongSolutions.Wpf.DragDrop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EditXamlLines.ViewModels
{
    [Export(typeof(IMainDisplayViewModel))]
    public class MainDisplayViewModel:Screen,IMainDisplayViewModel, IDropTarget
    {

        XamlEditTools Xet;

        public MainDisplayViewModel()
        {
            Xet = new XamlEditTools();
        }

        //private ObservableCollection<GridItem> _GridItems;
        public ObservableCollection<GridItem> GridItems
        {
            get { return Xet.GridItems; }
            set
            {
                if (value != Xet.GridItems)
                {
                    Xet.GridItems = value;
                    NotifyOfPropertyChange(() => GridItems);

                }
            }
        }

        //private GridItem _SelectedGridItems;
        public GridItem SelectedGridItems
        {
            get { return Xet.SelectedGridItems; }
            set
            {
                if (value != Xet.SelectedGridItems)
                {
                    Xet.SelectedGridItems = value;
                    NotifyOfPropertyChange(()=>SelectedGridItems);
                   
                }
            }
        }

        //private int _SelectedIndex;
        public int SelectedIndex
        {
            get { return Xet.SelectedIndex; }
            set
            {
                if (value != Xet.SelectedIndex)
                {
                    Xet.SelectedIndex = value;
                    NotifyOfPropertyChange(() => SelectedIndex);

                }
            }
        }


      
        public void GetClipboard()
        {
            if (Clipboard.ContainsText())
            {
                string buf = Clipboard.GetText(TextDataFormat.Text);
                Xet.ParseInputXaml(buf);
              
            }
        }

        public void RewriteXaml()
        {
            var res = Xet.ReWriteXaml();
            Clipboard.SetText(res);
        }



        public void DragOver(IDropInfo dropInfo)
        {
            GridItem sourceItem = dropInfo.Data as GridItem;
            GridItem targetItem = dropInfo.TargetItem as GridItem;

            if (sourceItem != null && targetItem != null)
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = DragDropEffects.Move;

            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            GridItem sourceItem = dropInfo.Data as GridItem;
            GridItem targetItem = dropInfo.TargetItem as GridItem;

            int IndexOld = sourceItem.LabelItem.GetPropertyToInt("Grid.Row");
            int IndexNew = targetItem.LabelItem.GetPropertyToInt("Grid.Row");

            this.GridItems.Move(IndexOld, IndexNew);

            //targetItem.GridRow = IndexOld;
            //sourceItem.GridRow = IndexNew;

            ReOrderItems();

            
        }


        public void ReOrderItems()
        {
           
            foreach (var item in GridItems)
            {
                item.GridRow = GridItems.IndexOf(item);
            }
        }
    }
}

