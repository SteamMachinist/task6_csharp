using System.Text;

namespace task6_csharp
{
    internal class TextBoxWriter : TextWriter
    {
        private TextBox textbox;
        public TextBoxWriter(TextBox textbox)
        {
            this.textbox = textbox;
        }

        public override void Write(char value)
        {
            textbox.Text += value;
        }

        public override void Write(string value)
        {
            textbox.Text += value.Replace("\n", Environment.NewLine);
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}
