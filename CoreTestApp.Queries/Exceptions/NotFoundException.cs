using System;

namespace CoreTestApp.Queries.Exceptions
{
    [Serializable]
    internal class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) 
            : base(message)
        {
        }
    }
}
