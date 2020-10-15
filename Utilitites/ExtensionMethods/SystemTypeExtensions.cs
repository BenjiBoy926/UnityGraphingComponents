using System;

public static class SystemTypeExtensions
{
    public static bool IsSameAsOrSubclassOf(this Type src, Type other)
    {
        return src == other || src.IsSubclassOf(other);
    }
}
