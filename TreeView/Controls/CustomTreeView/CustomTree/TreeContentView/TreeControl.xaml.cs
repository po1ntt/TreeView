using System.Collections.ObjectModel;

namespace TreeView.Controls.CustomTreeView.CustomTree.TreeContentView;

public partial class TreeControl : ContentView
{
    public static readonly BindableProperty NodeTreesProperty = BindableProperty.Create(nameof(NodeTrees), typeof(ObservableCollection<NodeTree>), typeof(TreeControl), null);

    public ObservableCollection<NodeTree> NodeTrees
    {
        get => (ObservableCollection<NodeTree>)GetValue(NodeTreesProperty);
        set => SetValue(NodeTreesProperty, value);
    }
   
    public TreeControl()
	{
		InitializeComponent();
	}

    private void Frame_Loaded(object sender, EventArgs e)
    {

    }
}