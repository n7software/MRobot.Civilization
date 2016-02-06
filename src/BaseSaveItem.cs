using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization
{
    public abstract class BaseSaveItem : ISaveItem
    {
        protected BaseSaveItem(string prefix, string name, bool allCaps = true)
        {
            SaveName = new SaveString(prefix, name, allCaps);
        }

        public virtual string Name
        { 
            get { return SaveName.Value; }
            set { SaveName.Value = value; }
        }

        public SaveString SaveName { get; protected set; }
    }
}
