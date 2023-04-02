using ControlsApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ControlsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreeView : Controller
    {
        [HttpGet("GetThisDirectoryInfo")]
       
        public List<ItemTree> GetThisDirectoryInfo()
        {
            List<ItemTree> itemTrees = new List<ItemTree>();
            string workingdirectory = System.IO.Directory.GetCurrentDirectory();
            string[] Directories = System.IO.Directory.GetDirectories(workingdirectory, "*");
            string[] FilesThatDirecoty = System.IO.Directory.GetFiles(workingdirectory, "*");

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
                    });
                }
                catch (DirectoryNotFoundException exp)
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
        [HttpGet("GetParentInfo")]
        public List<ItemTree> GetParenInfo(string path)
        {
            List<ItemTree> itemTrees = new List<ItemTree>();
            string[] Directories = System.IO.Directory.GetDirectories(path, "*");
            string[] FilesThatDirecoty = System.IO.Directory.GetFiles(path, "*");
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
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
                    });

                }
                catch (DirectoryNotFoundException exp)
                {
                    Console.WriteLine(exp);
                    throw;
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
                    throw;
                }
            }
            return itemTrees;
        }
        [HttpGet("GetNodeTree")]
        public List<NodeTree> GetNodeTree(string path)
        {
            List<NodeTree> itemTrees = new List<NodeTree>();
            string[] Directories = System.IO.Directory.GetDirectories(path, "*");
            string[] FilesThatDirecoty = System.IO.Directory.GetFiles(path, "*");
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            foreach (var item in Directories)
            {
                DirectoryInfo di = null;
                try
                {
                    di = new DirectoryInfo(item);
                    itemTrees.Add(new NodeTree
                    {
                        TitleNode = di.Name,
                        ApiUrl = item,
                        HasChilds= true,
                        LevelNode = 0,
                        IsVisible= true,
                        
                        
                    });

                }
                catch (DirectoryNotFoundException exp)
                {
                    Console.WriteLine(exp);
                    throw;
                }
            }
            foreach (var item in FilesThatDirecoty)
            {
                FileInfo di = null;
                try
                {
                    di = new FileInfo(item);
                    itemTrees.Add(new NodeTree
                    {
                        TitleNode = di.Name,
                        ApiUrl = item,
                        HasChilds = false,
                        LevelNode = 0,
                        IsVisible= true
                        
                    });
                }
                catch (FileNotFoundException exp)
                {
                    Console.WriteLine(exp);
                    throw;
                }
            }
            return itemTrees;
        }

    }
}
