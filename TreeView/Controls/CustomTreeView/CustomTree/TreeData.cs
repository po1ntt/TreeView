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
            LoadChilds = new Command(async (object args) => await OpenCloseChilds(args as NodeTree));
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
        private async Task OpenCloseChilds(NodeTree nodeTree)
        {
            int index = nodeTrees.IndexOf(nodeTree);
            nodeTree.isLoading = true;

            if (nodeTree.ChildElements == null)
            {
                if (nodeTree.ChildElements == null)
                {
                    var ListChilds = await LoadChildsFunctions(nodeTree);

                    foreach (NodeTree node in ListChilds)
                    {
                        nodeTrees.Insert(index + 1, node);
                        nodeTree.ChildElements.Add(node);
                        nodeTree.Rotation = 90;

                    }
                }
            }
            else
            {
                var itemnode = nodeTree.ChildElements[0];
                if (itemnode.IsVisible)
                {
                    bool NestingEnded = false;
                    List<NodeTree> NodesToHide = new List<NodeTree>();
                    List<NodeTree> OpenNesting = new List<NodeTree>();
                    OpenNesting.Add(nodeTree);
                    while (NestingEnded == false)
                    {
                        index++;
                        var findnodebuindex = nodeTrees[index];
                        if (OpenNesting.Contains(findnodebuindex.ParentNode))
                        {
                            NodesToHide.Add(findnodebuindex);
                            if (findnodebuindex.ChildElements != null)
                            {
                                OpenNesting.Add(findnodebuindex);
                            }
                        }
                        else
                        {
                            NestingEnded = true;
                        }
                    }
                    foreach (NodeTree node in NodesToHide)
                    {
                        node.IsVisible = false;
                        nodeTree.Rotation = 0;
                    }
                }
                else
                {
                    foreach (var node in nodeTree.ChildElements)
                    {
                        var nodetohide = nodeTrees.FirstOrDefault(p => p.UniqueId == node.UniqueId);
                        nodetohide.IsVisible = true;
                        nodeTree.Rotation = 90;
                    }
                }
            }
            nodeTree.isLoading = false;

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
