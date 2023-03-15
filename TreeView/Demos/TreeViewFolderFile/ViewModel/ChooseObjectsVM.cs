using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TreeView.Controls.TreeView;
using TreeView.Controls.TreeView.Models;
using TreeView.Demos.TreeViewFolderFile.Models;

namespace TreeView.Demos.TreeViewFolderFile.ViewModel
{
    public class ChooseObjectsVM : INotifyPropertyChanged
    {
        public string TitlePage { get; set; }
      
        public ObservableCollection<ItemTree> ItemsTree { get; set; }
        public DirectoriService directoriService { get; set; }
        public Command OpenCommand { get; set; }
        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }
      
        public ChooseObjectsVM(WorkingObject workingObject)
        {
            directoriService = new DirectoriService();
            ItemsTree = new ObservableCollection<ItemTree>();
            TitlePage = workingObject.ObjectName;
            FillMainDirectory(workingObject.ObjectPath);
            OpenCommand = new Command((object args) => FillChildElement(args as ItemTree));

        }
        public async void FillMainDirectory(string path)
        {
            ItemsTree.Clear();
            List<ItemTree> listTree = await directoriService.GetInfoAboutDirectory(path);
            foreach (var item in listTree)
            {
                ItemsTree.Add(item);
            }
        }
        public async void FillChildElement(ItemTree item)
        {
            if (IsBusy)
                return;
            try
            {
                item.isLoading = true;
                IsBusy = true;
                if (item.ChildElements == null)
                {
                    item.ChildElements = new ObservableCollection<ItemTree>();
                    var childlist = await directoriService.GetInfoAboutDirectory(item.PathItem);
                    foreach (var child in childlist)
                    {
                        item.ChildElements.Add(child);

                    }
                    item.IsExpand = true;
                    item.Rotation = 90;

                }
                else
                {
                    if (item.IsExpand == true)
                    {
                        item.IsExpand = false;
                        item.Rotation = 0;
                    }
                    else
                    {
                        item.IsExpand = true;
                        item.Rotation = 90;
                    }
                }

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка", ex.Message, "Ок");
                IsBusy = false;
            }
            finally
            {
                IsBusy = false;
                item.isLoading = false;
            }


        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
