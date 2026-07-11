namespace Arc
{
    public interface IApplication: IDisposable
    {
        IList<IApplicationListener> Listeners
        {
            get;
        }

        void AddListener(IApplicationListener listener)
        {
            lock (Listeners)
            {
                Listeners.Add(listener);
            }
        }
    }
}
