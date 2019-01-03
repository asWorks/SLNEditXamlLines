using System.Collections.Generic;
using System.Linq;

namespace EditXamlLines.Models
{
    public class XamlItem
    {
        public string ItemType { get; set; }

        public int Order { get; set; }

        public bool isLabel { get; set; }

        public List<ItemProperty> PropertyList { get; set; }

        public XamlItem()
        {

        }

        public XamlItem(string line)
        {
            PropertyList = new List<ItemProperty>();
            string buf = line;
          
            buf = buf.Trim();
            string[] teile = null;


            if (buf.StartsWith("Label")) // is Label Line
            {
                ProcessLabelNameAndContentField(ref buf, ref teile);

            }
            else  // is Value Control
            {
                buf = ProcessValueControlNameAndBindingPart(buf, teile);

            }

        }
        /// <summary>
        /// Set Type to Control, remove Control Name and process the binding property - needs special treatment because it comntains blanks.
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="teile"></param>
        /// <returns></returns>
        private string ProcessValueControlNameAndBindingPart(string buf, string[] teile)
        {
            int index = buf.IndexOf(" ");
            if (index != 0)
            {
                ItemType = buf.Substring(0, index);
                buf = buf.Substring(index + 1);
            }
            isLabel = false;
            buf = removeBindingBlanks(buf);
            string[] buffer = AddToPropertyList(buf, teile);
            return buf;
        }

        /// <summary>
        /// Set Type to label, remove String label and process the content property - needs special treatment because it comntains blanks.
        /// </summary>
        /// <param name="buf">The whole Xaml line</param>
        /// <param name="teile">Holds the seperate parts of the Attribute, Name and Value</param>
        private void ProcessLabelNameAndContentField(ref string buf, ref string[] teile)
        {
            isLabel = true;
            ItemType = "Label";
            buf = buf.Replace("Label ", "");
            int index = buf.IndexOf(":");
            if (index != 0)
            {
                index += 2;
                string part = buf.Substring(0, index);
                buf = buf.Substring(index + 1);
                teile = part.Split('=');
                ItemProperty ip = new ItemProperty();
                ip.PropertyType = teile[0];
                ip.PropertyValue = teile[1];
                PropertyList.Add(ip);


            }
            AddToPropertyList(buf, teile);
        }

        public string[] AddToPropertyList(string buf, string[] teile)
        {

            string[] parts = buf.Split(' ');
            foreach (var item in parts)
            {
                teile = item.Split('=');

                ItemProperty ip = new ItemProperty();
                ip.PropertyType = teile[0];
                ip.PropertyValue = teile[1];
                PropertyList.Add(ip);
            }
            Order = GetPropertyToInt("Grid.Row");
            return parts;


        }


        public string removeBindingBlanks(string buffer)
        {
            var index = buffer.IndexOf("{Binding");
            if (index > 0)
            {
                var index1 = buffer.IndexOf("}", index);
                var len = ((index1 - index) + 2);
                var BufSub = buffer.Substring(index, len);
                BufSub = BufSub.Replace(" ", "$");
                BufSub = BufSub.Replace("=", "%");

                buffer = buffer.Remove(index, len);
                buffer = buffer.Insert(index, BufSub);
              
            }
            return buffer;

        }

        public bool SetProperty(string PropertyName, string PropertyValue)
        {
            var res = PropertyList.Where
                (n => n.PropertyType == PropertyName).Single();
            if (res != null)
            {
                res.PropertyValue = "'" + PropertyValue + "'";
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetProperty(string PropertyName)
        {
            var res = PropertyList.Where
                (n => n.PropertyType == PropertyName).SingleOrDefault();
            if (res != null)
            {
                return res.PropertyValue;
            }
            else
            {
                return "";
            }
        }

        public int GetPropertyToInt(string PropertyName)
        {
            string buf = GetProperty(PropertyName);
            if (buf != "")
            {
                return int.Parse(buf.Replace("'", ""));
            }
            else
            {
                return 0;
            }
        }
    }
}
