using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeView.Controls.TreeView.Models;

namespace TreeView.Virtualization
{
    class Virtualization
    {
        public void RemoveCollectionItem(IEnumerable Collection, int positionid)
        {

        }
        public void AddCollectionItem(IEnumerable Collection, int positionid)
        {

        }
        public void GroupColletion(IEnumerable Collection)
        {

        }
        public IEnumerable VirtualizeItems(IEnumerable Collection, string action)
        {
            var collection = Collection;
            if(action == "Down")
            {
                RemoveCollectionItem(collection, 0);
                AddCollectionItem(collection, 0);
            }
            return collection;
        }
    }
}
