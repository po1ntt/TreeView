using TreeView.Demos.TreeViewFolderFile.Models;
using TreeView.Demos.TreeViewFolderFile.ViewModel;

namespace TreeView.Demos.TreeViewFolderFile;

public partial class ObjectTree : ContentPage
{
	public ObjectTree(WorkingObject workingObject)
	{
		InitializeComponent();
		BindingContext = new ChooseObjectsVM(workingObject);
	}
}