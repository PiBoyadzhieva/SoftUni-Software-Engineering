using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AuthorAttribute : Attribute
{
    public AuthorAttribute(string Name)
    {
        this.Name = Name;
    }

    public string Name { get; set; }
}
