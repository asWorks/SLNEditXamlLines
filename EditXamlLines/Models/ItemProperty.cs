using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditXamlLines.Models
{
   public class ItemProperty
    {
        public string PropertyType { get; set; }

        public string PropertyValue { get; set; }

        public bool ReWrite { get; set; }

        public string GetProperty()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(PropertyType);
            sb.Append("=");
            sb.Append("\"" + PropertyValue + "\"");
            sb.Append(" ");

            return sb.ToString();
        }
    }
}
