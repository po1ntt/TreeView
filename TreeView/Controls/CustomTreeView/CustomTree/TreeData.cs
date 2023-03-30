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
        public ObservableCollection<NodeTree> nodeTrees { get; set; } = new();
        public TreeData()
        {
            
        }
        public async Task LoadNodes()
        {
            List<NodeTree> nodes =  LoadTree();
            if(nodes!= null)
            {
                foreach (NodeTree node in nodes)
                {
                    nodeTrees.Add(node);
                }
            }
            else
            {
                Shell.Current.DisplayAlert("data error","data is null","ok");
            }
        }
        public virtual List<NodeTree> LoadTree()
        {
            List<NodeTree> nodeTrees = new List<NodeTree>();
            return nodeTrees;
        }
    }
}
