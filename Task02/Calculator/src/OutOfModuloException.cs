namespace CSharpBasics.src
{
    using System;

    // custom exception for tracing arguments
    public class OutOfModuloException : Exception
    {
        // set of constructors
        public OutOfModuloException() : base() { }
        public OutOfModuloException(string str) : base(str) { }
        public OutOfModuloException(string str, Exception inner) : base(str, inner) { }

        protected OutOfModuloException(
            System.Runtime.Serialization.SerializationInfo si, 
            System.Runtime.Serialization.StreamingContext sc) : base(si, sc) { }

        public override string ToString()
        {
            return Message;
        }
    }
}
