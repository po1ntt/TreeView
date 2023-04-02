using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TreeView.Controls.CustomTreeView.CustomTree;
using TreeView.Controls.TreeView;

namespace TreeView.Demos.CustomTree
{
    class DataWorker : TreeData
    {

        public ServiceApi serviceApi = new ServiceApi();
        public override async Task<List<NodeTree>> LoadTree()
        {

            var listTree = await serviceApi.GetInfoAboutDirectory("C:\\Games\\This Is the Police");
          
            return listTree;
        }
        public override async Task<List<NodeTree>> LoadChildsFunctions(NodeTree nodeTree)
        {
            List<NodeTree> itemTrees = new List<NodeTree>();
            itemTrees = await serviceApi.GetInfoAboutDirectory(nodeTree.ApiUrl);
  
            return itemTrees;
        }
  
    }
}
    