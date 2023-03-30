using System.Collections.ObjectModel;
using TreeView.Demos.TreeViewFolderFile.Helpers;
using TreeView.Demos.TreeViewFolderFile.Models;

namespace TreeView.Demos.TreeViewFolderFile;

public partial class ChooseObject : ContentPage
{
	public ObjectsHelper objHelper = new();


	public ObservableCollection<WorkingObject> ObjectList = new();

	public ChooseObject()
	{
		
		InitializeComponent();
		ObjectList = objHelper.FillObjects();
		LvObjects.ItemsSource = ObjectList;
		
		
	}

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
	
		await Shell.Current.Navigation.PushAsync(new ObjectTree(e.Item as WorkingObject));
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {

    }
}