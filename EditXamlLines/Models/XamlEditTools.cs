using GongSolutions.Wpf.DragDrop;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;

namespace EditXamlLines.Models
{
    public class XamlEditTools : INotifyPropertyChanged, IDropTarget
    {


        private string _XamlSource;
        public string XamlSource
        {
            get { return _XamlSource; }
            set
            {
                if (value != _XamlSource)
                {
                    _XamlSource = value;
                   OnPropertyChanged("XamlSource");
                    
                }
            }
        }



        private ObservableCollection<GridItem> _GridItems;
        public ObservableCollection<GridItem> GridItems
        {
            get { return _GridItems; }
            set
            {
                if (value != _GridItems)
                {
                    _GridItems = value;
                    OnPropertyChanged("GridItems");

                }
            }
        }

        private GridItem _SelectedGridItems;
        public GridItem SelectedGridItems
        {
            get { return _SelectedGridItems; }
            set
            {
                if (value != _SelectedGridItems)
                {
                    _SelectedGridItems = value;
                    OnPropertyChanged("SelectedGridItems");
                }
            }
        }

        private int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (value != _SelectedIndex)
                {
                    _SelectedIndex = value;
                    OnPropertyChanged("SelectedIndex");

                }
            }
        }

        private List<XamlItem> xamlitems;

        public void ReadFromFile(string filename)
        {
            string content = "";
            //"C:\\Data\\Test.txt"
            var f = File.Open(filename, FileMode.Open);
            using (StreamReader sr = new StreamReader(f))
            {
                content = sr.ReadToEnd();
            }

            ParseInputXaml(content);
        }


        public void ReadFromTextBox(string text)
        {
            ParseInputXaml(text);
        }


        public void ParseInputXaml(string filename)
        {



            string[] lines = filename.Split('\n');

            foreach (var item in lines)
            {
                if (item.Trim().Length > 5)
                {
                    string buf = item.Replace("\"", "'");  //Replace all double quotes with single  quotes

                    buf = buf.Replace("<", "");            //Remove angle brackets        
                    buf = buf.Replace("/>", "");           // ditto
                    buf = buf.Replace(", ", ",");          //Remove blank followuing commas 

                    var x = new Models.XamlItem(buf);
                    xamlitems.Add(x);
                }

            }
            CreateGridItems();
        }




        public void CreateGridItems()
        {
             while (xamlitems.Count >= 2)
            {
                var res = new GridItem(xamlitems);
                GridItems.Add(res);
            }

         }

        public void ReOrderItems()
        {
            // GridItems = new ObservableCollection<GridItem>(GridItems.OrderBy(n => n.GridRow));
            foreach (var item in GridItems)
            {
                item.GridRow = GridItems.IndexOf(item);
            }
        }


        public XamlEditTools()
        {
            GridItems = new ObservableCollection<GridItem>();
            xamlitems = new List<XamlItem>();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
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

        public string ReWriteXaml()
        {
            string buf = string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (var item in GridItems)
            {
               
                List<XamlItem> xamlitems = new List<XamlItem>();
                xamlitems.Add(item.LabelItem);
                xamlitems.Add(item.ControlItem);

                foreach (var xi in xamlitems)
                {
                    sb.Append("<");
                    sb.Append(xi.ItemType.Trim());
                    sb.Append(" ");
                    foreach (var prop in xi.PropertyList)
                    {
                        sb.Append(prop.PropertyType);
                        sb.Append("=");
                        sb.Append("\"" + prop.PropertyValue + "\"");
                        sb.Append(" ");
                 
                    }
                    sb.Append("/>");
                    sb.AppendLine();

                }
            }

            buf = sb.ToString();
            buf = buf.Replace("$", " ");
            buf = buf.Replace("%", "=");
            buf = buf.Replace("'", "");


            return buf;
        }
    }
}
