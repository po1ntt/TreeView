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
            LoadChilds = new Command(async (object args) => await OpenCloseChilds(args as NodeTree));
        }
        public NodeTree ParentNode { get; set; }
        public Command LoadChilds { get; set; }
        public ObservableCollection<NodeTree> nodeTrees { get; set; }
        public ObservableCollection<NodeTree> ChildElements { get; set; }
       
        private async void InitAsync()
        {
            nodeTrees = new ObservableCollection<NodeTree>();
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
                    node.Height = -1;
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

            var itemnode = nodeTrees.Where(p => p.ParentNode == nodeTree).ToList() ;

            if (itemnode.Count == 0)
            {
              
                    var ListChilds = await LoadChildsFunctions(nodeTree);
                     int levelnode = nodeTree.LevelNode + 1;


                    foreach (NodeTree node in ListChilds)
                    {
                        node.ParentNode = nodeTree;
                         node.LevelNode = levelnode;
                        node.Height = -1;
    
                         nodeTrees.Insert(index + 1, node);
                        nodeTree.Rotation = 90;

                    }
                
            }
            else
            {
                if (itemnode[0].IsVisible)
                {
                   
                    foreach (NodeTree node in GetHideNode(nodeTree))
                    {
                        node.IsVisible = false;
                        node.Height = 0;
                        nodeTree.Rotation = 0;
                    }
                }
                else
                {
                    foreach (var node in nodeTrees.Where(p=> p.ParentNode == nodeTree).ToList())
                    {
                        node.IsVisible = true;
                        node.Height = -1;
                        nodeTree.Rotation = 90;
                    }
                }
            }
            nodeTree.isLoading = false;

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
