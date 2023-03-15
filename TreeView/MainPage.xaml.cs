

using System.Collections.ObjectModel;
using System.Security.AccessControl;
using TreeView.Controls.TreeView;
using TreeView.Controls.TreeView.Models;


namespace TreeView;

public partial class MainPage : ContentPage
{
    int count = 0;
    public ObservableCollection<ItemTree> itemTrees { get; set; }
    public MainPage()
    {
        InitializeComponent();
        itemTrees = new ObservableCollection<ItemTree>();
        BindingContext = this;

    }
}
   

