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
                    case "void":
                        Console.Clear();
                        Void.EnterVoid();
                        continue;
                    case "clr":
                        Console.Clear();
                        continue;
                    case "clean":
                        DesktopCleanner.CleanDesktop();
                        continue;
                    default:
                        Console.WriteLine(Error.NoReturn);
                        break;
                }
            }
        }
    }
}