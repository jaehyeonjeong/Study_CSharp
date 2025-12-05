using ShortcutMaster.Features.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortcutMaster.Features.SignUp
{
    public interface ISignUpView : IView
    {

    }
    public partial class SignUpView : Form, ISignUpView
    {
        public SignUpView()
        {
            InitializeComponent();
        }
    }
}
