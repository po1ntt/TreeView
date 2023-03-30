using Microsoft.Maui.Controls.Internals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TreeView.Controls.CustomTreeView.CustomTree
{
    public class TreeData
    {

        public Command LoadChilds { get; set; }
        public ObservableCollection<NodeTree> nodeTrees { get; set; } = new();
        public TreeData()
        {
            InitAsync();
            LoadChilds = new Command(async (object args) => await OpenChilds(args as NodeTree));
        }
        private async void InitAsync()
        {
           await LoadNodes();
        }
        private async Task LoadNodes()
        {
            List<NodeTree> nodes =  await LoadTree();
            if(nodes!= null)
            {
                foreach (NodeTree node in nodes)
                {
                    nodeTrees.Add(node);
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Nodes error","Nodes is null","ok");
            }
        }
        private async Task OpenChilds(NodeTree nodeTree)
        {
            int index = nodeTrees.IndexOf(nodeTree);

            if (nodeTree.ChildElements == null)
            {
                var ListChilds = await LoadChildsFunctions(nodeTree);

                foreach (NodeTree node in ListChilds)
                {
                    nodeTrees.Insert(index + 1, node);
                    nodeTree.ChildElements.Add(node);
                }
                nodeTree.IsVisibleChildElements = true;
            }
            else
            {
                if (nodeTree.IsVisibleChildElements)
                {
                    foreach (var node in nodeTree.ChildElements)
                    {
                        var nodetohide = nodeTrees.FirstOrDefault(p => p.UniqueId == node.UniqueId);
                        nodetohide.IsVisible = false;
                    }
                    nodeTree.IsVisibleChildElements = false;
                }
                else
                {
                    foreach (var node in nodeTree.ChildElements)
                    {
                        var nodetohide = nodeTrees.FirstOrDefault(p => p.UniqueId == node.UniqueId);
                        nodetohide.IsVisible = true;
                    }
                    nodeTree.IsVisibleChildElements = true;
                }
            }

        }
        public async virtual Task<List<NodeTree>> LoadTree()
        {
            return null;
        }
        public async virtual Task<List<NodeTree>> LoadChildsFunctions(NodeTree nodeTree)
        {
            return null;
        }
        
       
    }
}
