
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeView.Controls.TreeView.Models;

namespace TreeView.Controls.TreeView
{
    public class DirectoriService
    {
        public List<ItemTree> GetInfoAboutDirecotory(string path)
        {
            List<ItemTree> itemTrees = new List<ItemTree>();
            string[] Directories = System.IO.Directory.GetDirectories(path, "*");
            string[] FilesThatDirecoty = System.IO.Directory.GetFiles(path, "*");
            foreach(var item in Directories)
            {
                DirectoryInfo di = null;
                try
                {
                    di = new DirectoryInfo(item);
                    itemTrees.Add(new ItemTree {
                        NameItem = di.Name,
                        TypeItem = "folder",
                        PathItem = item,
                        IsExpand = false
                    });
                    
                }
                catch(DirectoryNotFoundException exp)
                {
                    Console.WriteLine(exp);
                    return itemTrees;
                }
            }
            foreach (var item in FilesThatDirecoty)
            {
                FileInfo di = null;
                try
                {
                    di = new FileInfo(item);
                    itemTrees.Add(new ItemTree
                    {
                        NameItem = di.Name,
                        TypeItem = "file",
                        PathItem = item,
                        ExtensionItem = di.Extension
                    });
                }
                catch (FileNotFoundException exp)
                {
                    Console.WriteLine(exp);
                    return itemTrees;
                }
            }
            return itemTrees;
        }

        public List<ItemTree> GetInfoAboutDirecotory()
        {
            List<ItemTree> itemTrees = new List<ItemTree>();
            string[] Directories = System.IO.Directory.GetDirectories("C:\\Users\\timat\\source\\repos\\TreeView\\TreeView", "*");
            string[] FilesThatDirecoty = System.IO.Directory.GetFiles("C:\\Users\\timat\\source\\repos\\TreeView\\TreeView", "*");
            foreach (var item in Directories)
            {
                DirectoryInfo di = null;
                try
                {
                    di = new DirectoryInfo(item);
                    itemTrees.Add(new ItemTree
                    {
                        NameItem = di.Name,
                        TypeItem = "folder",
                        PathItem = item,
                        IsExpand = false
                    });
                }
                catch (DirectoryNotFoundException exp)
                {
                    Console.WriteLine(exp);
                    return itemTrees;
                }
            }
          
            
            return itemTrees;
        }

    }
}
