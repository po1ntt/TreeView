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
        public Thickness MarginNode => new Thickness(LevelNode * 30, 0, 0, 0);

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
        private int _Height;

        public int Height
        {
            get { return _Height; }
            set { _Height = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoading;
        public bool isLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }
        private int _Rotation;
        public int Rotation
        {
            get { return _Rotation; }
            set
            {
                _Rotation = value;
                OnPropertyChanged();
            }
        }
        public string ApiUrl { get; set; }
        public void ChangeHeight()
        {
            if(IsVisible == true)
            {
                Height = -1;
            }
            else
            {
                Height = 0;
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
       
        public NodeTree ParentNode { get; set; }
       
    }
}
