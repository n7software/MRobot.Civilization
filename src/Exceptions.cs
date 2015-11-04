using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV
{
    [Serializable]
    public class InvalidValueException : Exception
    {
        public InvalidValueException() : base() { }
        public InvalidValueException(string message) : base(message) { }
    }

    [Serializable]
    public class InvalidSaveException : Exception
    {
        public InvalidSaveException() : base() { }
        public InvalidSaveException(string message) : base(message) { }
    }
}
