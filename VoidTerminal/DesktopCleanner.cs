using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VoidTerminal
{
    internal static class DesktopCleanner
    {
        private static readonly string location = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        internal static void CleanDesktop()
        {
            Console.WriteLine(
                "纳西妲：这个操作将会自动分类所有文件放入分类文件夹，确定嘛？若分类文件夹中含有同名文件，将被覆盖(y确认)");
            if (Console.ReadLine() != "y")
                return;
            string[] files = Directory.GetFiles(location);
            List<string> filesExt = new();
            //获取所有文件后缀名
            foreach (string file in files)
            {
                if (!filesExt.Contains(Path.GetExtension(file)))
                {
                    filesExt.Add(Path.GetExtension(file));
                }
            }
            //清除链接文件
            if(filesExt.Contains(".lnk"))
            {
                filesExt.Remove(".lnk");
            }
            //创建目录
            foreach (string fileExt in filesExt)
            {
                Directory.CreateDirectory(location + "\\" + fileExt);
            }
            //移动文件
            foreach (string file in files)
            {
                //忽略系统文件
                if (Path.GetFileName(file) == "desktop.ini")
                    continue;
                foreach (string fileExt in filesExt)
                {
                    if (Path.GetExtension(file) == fileExt)
                    {
                        try
                        {
                            File.Move(file, location + "\\" + fileExt+"\\"+Path.GetFileName(file), true);
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine("[虚空提示]文件移动遇到错误："+err.Message);
                        }
                        break;
                    }
                }
            }
            Console.WriteLine("执行完毕。");
        }
        internal static void RestoreDesktop()
        {
            string[] directories= Directory.GetDirectories(location);
            //获取目标文件
            foreach (string directory in directories)
            {
                string[] files= Directory.GetFiles(directory);
                //移动所有目标文件
                foreach (string file in files)
                {
                    if (Path.GetExtension(file)==Path.GetFileName(Path.GetDirectoryName(file)))//TODO
                    {
                        File.Move(file,location+"\\"+Path.GetFileName(file));
                    }
                }
            }
            //删除空文件夹
            foreach (string directory in directories)
            {
                if(Directory.GetFiles(directory).Length==0)
                    Directory.Delete(directory, true);
            }
            Console.WriteLine("执行完毕。");
        }
    }
}
