using System;

namespace MRobot.Civilization
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
