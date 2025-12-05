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

namespace ShortcutMaster.Features.Login
{
  public interface ILoginView : IView
  {
    event Action OnLogin;

    string UserId { get; set; }
    string Password { get; set; }
  }

  public partial class LoginView : Form, ILoginView
  {
    public LoginView()
    {
      InitializeComponent();
    }

    public string UserId { get => txtId.Text.Trim(); set => txtId.Text = value; }
    public string Password { get => txtPassword.Text; set => txtPassword.Text = value; }

    public event Action OnLogin = default!;

    private void btnLogin_Click(object sender, EventArgs e) => OnLogin?.Invoke();
  }
}
