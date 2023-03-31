using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TreeView.Controls.CustomTreeView.CustomTree
{
    public class NodeTree : INotifyPropertyChanged
    {
        public Guid UniqueId { get; set; }
        public string TitleNode { get; set; }
        public int LevelNode { get; set; }
        public string ImageUrl { get; set; }
        public bool HasChilds { get; set; }

      
        private int _MarginNode;
        public int MarginNode
        {
            get { return _MarginNode; }
            set
            {
                _MarginNode = LevelNode * 30;
            }
        }
        private bool _IsVisible;
        public bool IsVisible
        {
            get { return _IsVisible; }
            set
            {
                _IsVisible = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<NodeTree> ChildElements { get; set; }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void AddChildElements(bool HasChilds, string imageurl ,string titlenode, NodeTree node)
        {
            ChildElements.Add(new NodeTree()
            {
              UniqueId = Guid.NewGuid(),
              LevelNode = LevelNode + 1,
              HasChilds = HasChilds,
              ImageUrl = imageurl,
              TitleNode = titlenode,
              MarginNode = MarginNode,
              ChildElements= null,
              ParentNode = node
          
            });
        }
        public NodeTree ParentNode { get; set; }
       
    }
}
