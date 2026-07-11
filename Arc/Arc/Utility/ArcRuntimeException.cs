namespace Arc.Utility
{
    public class ArcRuntimeException: Exception
    {
        private static long serialVersionUID = 6735854402467673117L;

        public ArcRuntimeException(string message) : base(message)
        {
        }

        public ArcRuntimeException(Exception t) : base(null, t)
        {
        }

        public ArcRuntimeException(string message, Exception t) : base(message, t)
        {
        }
    }
}
