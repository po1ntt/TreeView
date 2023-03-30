using AndroidX.Core.View;
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
        public int TitleNode { get; set; }
        public int LevelNode { get; set; }
        public string ImageUrl { get; set; }
        public bool HasChilds { get; set; }
        private int _IsVisibleChildElements;

        public int IsVisibleChildElements
        {
            get { return _IsVisibleChildElements; }
            set { _IsVisibleChildElements = value;
                OnPropertyChanged();
            }
        }
        private int _MarginNode;
        public int MarginNode
        {
            get { return _MarginNode; }
            set
            {
                _MarginNode = LevelNode * 30;
            }
        }
        public ObservableCollection<NodeTree> ChildElements { get; set; }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
