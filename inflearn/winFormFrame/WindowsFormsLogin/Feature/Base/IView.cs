using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLogin.Feature.Base
{
    public interface IView
    {
        void Close();
        string Text { get; set; }
        bool Visible { get; set; }

        void ShowMessage(string message);

        DialogResult ShowDialog(string name, string caption, MessageBoxButtons buttons);
    }
}
