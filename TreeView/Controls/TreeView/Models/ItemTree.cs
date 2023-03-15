using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TreeView.Controls.TreeView.Models
{
    public class ItemTree : INotifyPropertyChanged
    {
        public string NameItem { get; set; }
        public string PathItem { get; set; }
        public string TypeItem { get; set; }
        public string ExtensionItem { get; set; }
        private int _Height = 25;
        public int Height
        {
            get 
            {
                return _Height;
            }
            set
            {
                _Height = value;
                OnPropertyChanged();
            }
        }
        private bool _IsExpand;

        public bool IsExpand
        {
            get { return _IsExpand; }
            set { _IsExpand = value;
                OnPropertyChanged();
                ChangeHeight();
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
       
        private ObservableCollection<ItemTree> _ChildElements;

        public ObservableCollection<ItemTree> ChildElements
        {
            get { return _ChildElements; }
            set { _ChildElements = value;
                OnPropertyChanged();
            }
        }
        public void ChangeHeight()
        {
            if(IsExpand == true)
            {
                Height += ChildElements.Count * 25;
            }
            else
            {
                Height = 25;
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
   
   
}
