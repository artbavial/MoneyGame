using System;
using System.Drawing;
using System.Windows.Forms;

namespace MoneyGame
{
    public class PlaceholderedTextBox : TextBox
    {
        private string placeholder;

        public PlaceholderedTextBox()
        {
            GotFocus += (s, e) => UpdatePlaceholder();
            LostFocus += (s, e) => UpdatePlaceholder();
        }

        public string Placeholder
        {
            get => placeholder;
            set
            {
                placeholder = value;
                UpdatePlaceholder();
            }
        }

        public override string Text
        {
            get => base.Text; set
            {
                base.Text = value;
                UpdatePlaceholder();
            }
        }

        public bool IsEmpty() => string.IsNullOrWhiteSpace(Text) || string.Equals(Text, Placeholder);

        private void UpdatePlaceholder()
        {
            if (Focused)
            {
                if (string.Equals(Text, Placeholder))
                {
                    Text = string.Empty;
                }
                SetTextStyle();
            }
            else
            {
                if (string.Equals(Text, string.Empty))
                {
                    Text = Placeholder;
                    SetPlaceholderStyle();
                }
                else
                {
                    SetTextStyle();
                }
            }
        }

        private void SetPlaceholderStyle()
        {
            ForeColor = Color.Silver;
        }

        private void SetTextStyle()
        {
            ForeColor = Color.Black;
        }
    }
}
