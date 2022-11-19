namespace AttributeExample.Exceptions
{
    public class MissingUsernameException : Exception
    {
        public MissingUsernameException(): base(message: "user-name must be provided via header")
        {
        }
    }
}
