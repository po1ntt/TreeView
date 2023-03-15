using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeView.Demos.TreeViewFolderFile.Models;

namespace TreeView.Demos.TreeViewFolderFile.Helpers
{
    public class ObjectsHelper
    {
        
        public ObservableCollection<WorkingObject> FillObjects()
        {
            var collection = new ObservableCollection<WorkingObject>
            {
                new WorkingObject
                {
                    ObjectName = "Windows",
                    ObjectPath = "C:\\Windows",
                    PositonId = 3,

                },
                new WorkingObject
                {
                    ObjectName = "Program Files (x86)",
                    ObjectPath = "C:\\Program Files (x86)",
                    PositonId = 1,

                },
                 new WorkingObject
                {
                    ObjectName = "Google",
                    ObjectPath = "C:\\Program Files (x86)\\Google",
                    PositonId = 4,

                },
                 new WorkingObject
                {
                    ObjectName = "Program files",
                    ObjectPath = "C:\\Program Files",
                    PositonId = 2,

                }
            };
            return collection;
        }
    }
}
