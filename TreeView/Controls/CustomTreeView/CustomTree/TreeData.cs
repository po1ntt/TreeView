using Microsoft.Maui.Controls.Internals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TreeView.Controls.CustomTreeView.CustomTree
{
    abstract class TreeData
    {
        public TreeData()
        {
            InitAsync();
        }
        public Command LoadChilds { get; set; }
        public ObservableCollection<NodeTree> nodeTrees { get; set; } = new();       
        private async void InitAsync()
        {
            LoadChilds = new Command(async (object args) => await OpenCloseChilds(args as NodeTree));
            await LoadNodes();
        }
        private async Task LoadNodes()
        {
            var nodes =  await LoadTree();
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
            nodeTree.isLoading = true;

            if (nodeTree.Childrens.Count == 0)
            {
                await LazyLoadChildren(nodeTree);
            }
            else
            {
                if(nodeTree.IsVisibleChildElements == true)
                {
                    foreach (NodeTree node in GetHideNode(nodeTree))
                    {
                        nodeTrees.Remove(node);
                    }
                    nodeTree.Rotation = 0;
                    nodeTree.IsVisibleChildElements = false;

                }
                else
                {
                    int index = nodeTrees.IndexOf(nodeTree);
                    foreach (NodeTree node in nodeTree.Childrens)
                    {
                        nodeTrees.Insert(index+ 1, node);

                    }
                    nodeTree.Rotation = 90;
                    nodeTree.IsVisibleChildElements = true;

                }

            }
            nodeTree.isLoading = false;

        }
        private async Task LazyLoadChildren(NodeTree node)
        {
            int index = nodeTrees.IndexOf(node);
            int levelnode = node.LevelNode + 1;
            foreach (NodeTree item in await LoadChildsFunctions(node))
            {
                item.ParentNode = node;
                item.LevelNode = levelnode;
                node.Childrens.Add(item);
                nodeTrees.Insert(index + 1, item);

            }
            node.Rotation = 90;
            node.IsVisibleChildElements = true;
        }
        private List<NodeTree> GetHideNode(NodeTree nodeTree)
        {
            bool NestingEnded = false;
            List<NodeTree> NodesToHide = new List<NodeTree>();
            List<NodeTree> OpenNesting = new List<NodeTree>();
            int index = nodeTrees.IndexOf(nodeTree);

            OpenNesting.Add(nodeTree);
            while (NestingEnded == false)
            {
                index++;
                var findnodebuindex = nodeTrees[index];
                if (OpenNesting.Contains(findnodebuindex.ParentNode))
                {
                    NodesToHide.Add(findnodebuindex);
                    if (nodeTrees.FirstOrDefault(p=> p.ParentNode == findnodebuindex) != null)
                    {
                        OpenNesting.Add(findnodebuindex);
                    }
                }
                else
                {
                    NestingEnded = true;
                }
              
            }
            return NodesToHide;

        }
        public  abstract Task<List<NodeTree>> LoadTree();

        public abstract Task<List<NodeTree>> LoadChildsFunctions(NodeTree nodeTree);
       

        
    }
}
