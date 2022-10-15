using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidTerminal
{
    internal static class Help
    {
        private static readonly string HelpText = "虚空命令列表："+Environment.NewLine+
            "run - 输入一个程序名称以启动任何一个程序"+Environment.NewLine+
            "help - 打开这个列表"+Environment.NewLine+
            "tasks - 看看原神每天需要做些什么"+Environment.NewLine+
            "void - 查看虚空数据库"+Environment.NewLine+
            "clr - 清空虚空终端";

        internal static void GetHelp()
        {
            Console.WriteLine(HelpText);
        } 
    }
}
