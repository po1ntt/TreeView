using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace TreeView.Controls.CustomTreeView.CustomTree
{

    internal class CustomTreeDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Folder { get; set; }
        public DataTemplate File { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((NodeTree)item).HasChilds == false ? File : Folder;
        }
    }
}
