using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeView.Controls.CustomTreeView.CustomTree
{
    internal interface ITree
    {
        ObservableCollection<NodeTree> nodeTrees { get; set; }
        Command LoadingChildren { get; set; }
        
    }
}
