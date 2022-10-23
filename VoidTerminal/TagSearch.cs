using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidTerminal
{
    internal static class TagSearch
    {
        private static readonly string configLocation = Environment.GetFolderPath
            (Environment.SpecialFolder.ApplicationData) + "\\SearchcConfig.txt";
        internal static string tag;
        internal static string engine;
        internal static void Search()
        {
            if (Init() == false)
            {
                Console.WriteLine("纳西妲：使用前要先配置哦，输入一个tag名称");
                Console.Write("tag>");
                tag = Console.ReadLine();
                Console.WriteLine(
                    "纳西妲：输入一个搜索引擎链接，用{word}代替搜索词，例如：https://cn.bing.com/search?q={word}");
                Console.Write("engine>");
                engine = Console.ReadLine();
                Save();
            }
            Console.Write("Search>");
            string input = Console.ReadLine();
            Process.Start("C:\\Program Files\\Internet Explorer\\iexplore.exe", engine.Replace("{word}", tag + "+" + input));
        }
        private static bool Init()
        {
            if (!File.Exists(configLocation))
                return false;
            string[] strings = File.ReadAllLines(configLocation);
            tag = strings[0];
            engine = strings[1];
            return true;
        }
        private static void Save()
        {
            File.WriteAllText(configLocation, tag);
            File.AppendAllText(configLocation, Environment.NewLine + engine);
        }
    }
}
