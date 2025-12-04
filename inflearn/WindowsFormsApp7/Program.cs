using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Mutex 작업
            bool newForm = false;
            Mutex mutex = new Mutex(true, Assembly.GetEntryAssembly().FullName, out newForm);
            // true : initiallyOwned : bool, 생성시 호출 스레드 가 즉시 뮤텍스를 소유하는지 여부
            // Assembly.GetEntryAssembly().FullName : string, 뮤텍스의 이름
            // out newForm : bool, 뮤텍스가 새로 생성되었는지 여부를 반환하는 출력 매개변수
            // 즉 실행 중인 동일한 이름의 뮤텍스가 없으면 true, 있으면 false 반환

            if (newForm)     // 뮤택스가 이미 실행 중인지 확인
            {
                // 이미 실행 중인 경우
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                return;
            }
            else
            {

            }
        }
    }
}
