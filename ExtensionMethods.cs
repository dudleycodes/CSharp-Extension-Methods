using System;
using System.Linq;

/// <summary>The goal of this collection of extension methods is to make c# code throughout the project more readable.</summary>
internal static class ExtensionMethods
{
    /// <summary>Returns a value indicating whether the specified char occurs within this char array</summary>
    /// <param name="haystack">The char array to search</param>
    /// <param name="needle">The char to seek</param>
    /// <param name="caseInsensitive">Set to true to do a case-insensitive search</param>
    /// <returns>true if the needle parameter occurs within this char array; otherwise false.</returns>
    public static bool Contains(this char[] haystack, char needle, bool caseInsensitive = false)
    {
        char[] haystackCopy = haystack;

        if (caseInsensitive)
        {
            haystackCopy = haystack.Select(s => char.ToLower(s)).ToArray();
            needle = char.ToLower(needle);
        }

        if (Array.IndexOf(haystack, needle) >= 0)
        {
            return true;
        }

        return false;
    }

    /// <summary>Returns a value indicating whether the specified string occurs within this string array</summary>
    /// <param name="haystack">The string array to search</param>
    /// <param name="needle">The string to seek</param>
    /// <param name="caseInsensitive">Set to true to do a case-insensitive search</param>
    /// <returns>true if the needle parameter occurs within this string array, or if needle is the empty string (""); otherwise false.</returns>
    public static bool Contains(this string[] haystack, string needle, bool caseInsensitive = false)
    {
        string[] haystackCopy = haystack;

        if (caseInsensitive)
        {
            haystackCopy = haystack.Select(s => s.ToLower()).ToArray();
            needle = needle.ToLower();
        }

        if (Array.IndexOf(haystackCopy, needle) >= 0 || needle == string.Empty)
        {
            return true;
        }

        return false;
    }

    /// <summary>Counts the number of non-default valued elements in an array</summary>
    /// <typeparam name="T">The element type of the array</typeparam>
    /// <param name="array">Array to analyze</param>
    /// <returns>The number of elements contained in <paramref name="array"/> that do not have a default value</returns>
    public static int CountNonDefault<T>(T[] array)
    {
        int count = 0;

        foreach (var item in array)
        {
            // Catch to prevent .Equals() from throwing NullReferenceException
            if (default(T) == null)
            {
                if (item != null)
                {
                    count++;
                }
            }
            else if (!item.Equals(default(T)))
            {
                count++;
            }
        }

        return count;
    }

    /// <summary>Reverse the contents of the string</summary>
    /// <param name="s">The string to reverse</param>
    /// <returns>The string with contents reversed</returns>
    public static string Reverse(this string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
	
	/// <summary>Truncate a string to a maximum length.</summary>
	/// <param name="str">The string to truncate.</param>
	/// <param name="maxLength">The maximum length of the string after truncation.</param>
	/// <param name="trailingAnnotationText">Trailing text annotation (if any) to indicate that the string has been truncated (e.g. "...").</param>
	/// <returns>The truncated string.</returns>
	public static string Truncate(this string str, int maxLength, string trailingAnnotationText = null)
	{
		if (str.Length > maxLength)
		{
			if (string.IsNullOrEmpty(trailingAnnotationText))
			{
				str = str.Substring(0, maxLength);
			}
			else if (str.Length <= trailingAnnotationText.Length)
			{
				str = trailingAnnotationText.Substring(0, maxLength);
			}
			else
			{
				str = str.Substring(0, maxLength - trailingAnnotationText.Length) + trailingAnnotationText;
			}
		}

		return str;
	}
}
