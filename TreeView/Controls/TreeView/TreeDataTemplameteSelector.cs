using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeView.Controls.TreeView.Models;

namespace TreeView.Controls.TreeView
{
    internal class TreeDataTemplameteSelector : DataTemplateSelector
    {
        public DataTemplate Folder { get; set; }
        public DataTemplate File { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((ItemTree)item).TypeItem == "file" ? File : Folder;
        }
    }
}
