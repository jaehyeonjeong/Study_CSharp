using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.Features.Base
{
  // 모든 View는 IView를 상속받아야 한다.
  public interface IView
  {
    void Close();
    string Text { get; set; }
    bool Visible { get; set; }

    public void ShowMessage(string message)
    {
      MessageBox.Show(message);
    }

    public DialogResult ShowMessage(string message, string caption, MessageBoxButtons buttons)
    {
      return MessageBox.Show(message, caption, buttons);
    }
  }
}
