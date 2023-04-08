namespace FunBooksAndVideos.Exceptions
{
    public class CustomerNotFoundException : NullReferenceException
    {
        public CustomerNotFoundException(string message)
        : base(message)
        {
        }
    }
}
