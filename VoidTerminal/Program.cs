using System.Reflection;

namespace VoidTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Void Terminal v" + Assembly.GetExecutingAssembly().GetName().Version);
            Console.WriteLine("输入help获取帮助，按下Ctrl+C可退出。");
            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "help":
                        Help.GetHelp();
                        continue;
                    case "run":
                        Console.Write("Run>");
                        input = Console.ReadLine();
                        RunApp.Run(input);
                        continue;
                    case "tasks":
                        Console.WriteLine(
                            "一个原神玩家每天必须做的事情：| 米游社 | 委托 | 树脂 | 纪行 | 活动 |");
                        continue;
                    case "void":
                        Console.Clear();
                        Void.EnterVoid();
                        continue;
                    case "clr":
                        Console.Clear();
                        continue;
                    default:
                        Console.WriteLine(Error.NoReturn);
                        break;
                }
            }
        }
    }
}