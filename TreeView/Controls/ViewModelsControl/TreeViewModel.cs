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
        public void FillMainDirectory()
        {
            var listTree = directoriService.GetInfoAboutDirecotory();
            foreach(var item in listTree) 
            {
                MainDirectory.Add(item);
            }
        }
        public void FillPartenDirectory(ItemTree item)
        {
            if (IsBusy)
                return;
            try
            {
              
                IsBusy = true;
                if (item.ChildElements == null)
                {
                    item.ChildElements = new ObservableCollection<ItemTree>();
                    var parentlist = directoriService.GetInfoAboutDirecotory(item.PathItem);
                    foreach (var parent in parentlist)
                    {
                        item.ChildElements.Add(parent);
                    }
                    item.IsExpand = true;
                    
                 
                    OnPropertyChanged();


                }
                else
                {
                    if (item.IsExpand == true)
                    {
                        item.IsExpand = false;
                    }
                    else
                    {
                        item.IsExpand = true;
                    }
                    OnPropertyChanged();
                }

              
                


            }
            catch(Exception ex)
            {
                Shell.Current.DisplayAlert("Ошибка", ex.Message, "Ок");
                IsBusy = false;
            }
            finally
            {
                IsBusy = false;
               
            }
           
           
        }
       
      
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
