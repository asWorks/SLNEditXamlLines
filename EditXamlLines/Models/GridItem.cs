using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditXamlLines.Models
{
    public class GridItem:INotifyPropertyChanged
    {
        private int _GridRow;
        public int GridRow
        {
            get { return _GridRow; }
            set
            {
                if (value != _GridRow)
                {
                    _GridRow = value;
                    LabelItem.SetProperty("Grid.Row", value.ToString());
                    LabelItem.Order = value;
                    ControlItem.SetProperty("Grid.Row", value.ToString());
                    ControlItem.Order = value;
                    OnPropertyChanged("GridRow");
                   
                }
            }
        }

        private string _LineName;
        public string LineName
        {
            get { return _LineName; }
            set
            {
                if (value != _LineName)
                {
                    _LineName = value;
                    OnPropertyChanged(LineName);
                }
            }
        }



        public GridItem(List<XamlItem> liste)
        {
            var min = liste.Min(n => n.Order);
            XamlItem label = liste.Where(n => n.Order == min && n.isLabel == true).Single();
            XamlItem control = liste.Where(n => n.Order == min && n.isLabel == false).Single();

            liste.Remove(label);
            liste.Remove(control);
            LabelItem = label;
            ControlItem = control;
            LineName = label.GetProperty("Content");
            GridRow = label.GetPropertyToInt("Grid.Row");

        }

        private int _GridColumn;
        public int GridColumn
        {
            get { return _GridColumn; }
            set
            {
                if (value != _GridColumn)
                {
                    _GridColumn = value;
                    LabelItem.SetProperty("Grid.Column", value.ToString());
                    ControlItem.SetProperty("Grid.Column", value.ToString());
                    OnPropertyChanged("GridColumn");
                }
            }
        }



      
        public XamlItem LabelItem { get; set; }
        public XamlItem ControlItem { get; set; }




        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
