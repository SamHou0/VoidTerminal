using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace VoidTerminal
{
    internal static class Void
    {
        private static readonly string voidLocation =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\void.txt";
        internal static void EnterVoid()
        {
            while (true)
            {
                Console.WriteLine(
                    "纳西妲：一旦将罐装知识导入到虚空里后，在终端里就没办法修改了。不过既然你来自另一个世界，那么一定有打开这个的方法吧："
                    + Environment.NewLine + voidLocation);
                Console.WriteLine("1 - 创建一个新的罐装知识，然后导入虚空"
                    + Environment.NewLine + "2 - 查询虚空" + Environment.NewLine + "3 - 退出虚空");
                Console.Write("Void>");
                try
                {

                    int input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            AddKnowledge();
                            break;
                        case 2:
                            Console.Write("Search>");
                            SearchKnowledge(Console.ReadLine());
                            break;
                        case 3:
                            Console.Clear();
                            return;
                        default:
                            Console.WriteLine(Error.Invalid);
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine(Error.Invalid);
                }
            }
        }

        private static void SearchKnowledge(string searchThing)
        {
            string[] strings = File.ReadAllLines(voidLocation);
            string result="";
            foreach (string s in strings)
            {
                if (s.Contains(searchThing))
                    result += s + Environment.NewLine; 
            }
            if (string.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine(Error.NoReturn);
                return;
            }
            Console.WriteLine(result);
        }

        private static void AddKnowledge()
        {
            Console.Write("Knowledge>");
            File.AppendAllText(voidLocation, Console.ReadLine() + Environment.NewLine);
        }
    }
}
