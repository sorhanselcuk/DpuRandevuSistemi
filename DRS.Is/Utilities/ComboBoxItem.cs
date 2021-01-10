using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.Is.Utilities
{
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
// (cbxFakulteler.SelectedItem as ComboBoxItem).Value 
// Örnek kullanım