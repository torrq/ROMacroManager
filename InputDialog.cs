using System;
using System.Windows.Forms;

namespace ROMacroManager
{
    public partial class InputDialog : Form
    {
        public string InputText => textBox.Text;

        public InputDialog(string prompt, string title, string defaultText = "")
        {
            InitializeComponent();
            this.Text = title;
            label.Text = prompt;
            textBox.Text = defaultText;
            textBox.SelectAll();
        }
    }
}