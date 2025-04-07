namespace laba7.Classes;

public class FirstCustomException : Exception
{
    public FirstCustomException(string error) : base(error)
    {
    }
}