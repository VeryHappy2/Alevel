using System;

namespace Module2_HW.CustomExeptions
{

    public sealed class BusinessException : Exception
    {
        public BusinessException() : base() { }

        public BusinessException(string message) : base(message) { }
    }

}
