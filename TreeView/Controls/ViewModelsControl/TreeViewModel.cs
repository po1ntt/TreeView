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

namespace TreeView.Controls.ViewModelsControl
{
    public partial class TreeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ItemTree> MainDirectory { get; set; }
        public Command OpenCommand { get; set; }
        public DirectoriService directoriService { get; set; }
        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set { _IsBusy = value;
                OnPropertyChanged();
            }
        }

        public TreeViewModel()
        {
            directoriService = new DirectoriService();
            OpenCommand = new Command((object args) => FillPartenDirectory(args as ItemTree));
            MainDirectory = new ObservableCollection<ItemTree>();
            FillMainDirectory();
        }
        public async void FillMainDirectory()
        {
            List<ItemTree> listTree = await directoriService.GetInfoAboutDirecotory();
            foreach(var item in listTree) 
            {
                MainDirectory.Add(item);
            }
        }
        public async void FillPartenDirectory(ItemTree item)
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
                    var parentlist = await directoriService.GetInfoAboutDirecotory(item.PathItem);
                    foreach (var parent in parentlist)
                    {
                        item.ChildElements.Add(parent);
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
            catch(Exception ex)
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
