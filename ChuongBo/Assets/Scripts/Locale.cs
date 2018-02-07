using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Locale
{
    private Dictionary<LocaleKey, string> dictionary;

    public Locale()
    {
        dictionary = new Dictionary<LocaleKey, string>();
    }

    /// <summary>
    /// Create all definitions into dictonary
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// Get value of this key
    /// </summary>
    /// <param name="key">Key string</param>
    /// <returns></returns>
    public string Get(LocaleKey key)
    {
        if (dictionary.ContainsKey(key))
            return dictionary[key];
        return "";
    }

    protected void Set(LocaleKey key, string text)
    {
        dictionary.Add(key, text);
    }

}

