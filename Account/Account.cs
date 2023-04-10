namespace Account;

public class Account
{
    [Flags]
    public enum Access
    {
        Delete = 1,
        Publish = 2,
        Submit = 4,
        Comment = 8,
        Modify = 16,
        Writer = Submit | Modify,
        Editor = Delete | Publish | Comment,
        Owner = Writer | Editor
    }
}