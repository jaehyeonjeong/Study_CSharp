using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.Configs
{
    public interface IAppSettings
    {
        ConnectionStrings ConnectionStrings { get; }
    }

    public class AppSettings : IAppSettings // 인수 간략화를 위한 인터페이스 구현
    {
        public ConnectionStrings ConnectionStrings { get; set; } = new();
    }

    public class ConnectionStrings
    {
        public string SQLite { get; set; } = string.Empty;
    }
}
