using System.Windows.Forms;

namespace AnsysPlotRecognition
{
    public partial class LogForm : Form
    {
        public LogForm(string text)
        {
            InitializeComponent();
            richTextBox1.Text = text;
        }
    }
}
