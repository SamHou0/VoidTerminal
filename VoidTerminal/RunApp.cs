using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidTerminal
{
    internal static class RunApp
    {
        internal static void Run(string appName)
        {
            string location =
                Environment.GetFolderPath(Environment.SpecialFolder.Programs);
            List<string> programList = new();
                GetAllFiles(location,programList);
            List<string> targetList = new();
            foreach (string app in programList)
            {
                if (app.Contains(appName))
                {
                    Console.WriteLine(targetList.Count+"-"+app);
                    targetList.Add(app);
                }
            }
            if (targetList.Count == 0)
            {
                Console.WriteLine("虚空没有回应……");
                return;
            }
            Console.WriteLine("虚空返回了几条信息（输入对应数字）");
            Console.Write("Run>");
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                Process.Start("explorer.exe",targetList[index]);
                Console.WriteLine("滴~");
            }
            catch
            {
                Console.WriteLine(Error.Invalid);
            }
        }
        private static void GetAllFiles(string directory,List<string> output)
        {
            output.AddRange(Directory.GetFiles(directory));
            foreach (string path in Directory.GetDirectories(directory))
            {
                GetAllFiles(path, output);
            }
        }
    }
}
