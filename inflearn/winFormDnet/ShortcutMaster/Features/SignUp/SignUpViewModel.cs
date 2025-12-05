using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.Features.SignUp
{
    public record SignUpViewModel(string UserId = "", string Password = "", string ConfirmPassword = "", string Email = "");
}
