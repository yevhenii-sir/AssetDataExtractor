using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetDataExtractorPro
{
    public class FormattingTextEntry
    {
        public string Text { get; set; }

        [Browsable(false)]
        public bool IsComboBoxEnabled { get; set; }

        public FormattingTextEntry(string text, bool isButtonEnabled)
        {
            Text = text;
            IsComboBoxEnabled = isButtonEnabled;
        }
    }
}
