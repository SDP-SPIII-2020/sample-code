using System;
using System.Collections.Specialized;
using LanguageExt;
using static LanguageExt.Prelude;

namespace AppConfig
{
    public class AppConfig
    {
        NameValueCollection source;

        public AppConfig() : this(ConfigurationManager.AppSettings)
        {
        }

        public AppConfig(NameValueCollection source)
        {
            this.source = source;
        }

        public Option<T> Get<T>(string key)
            => source[key] == null
                ? None
                : Some((T) Convert.ChangeType(source[key], typeof(T)));

        public T Get<T>(string key, T defaultValue)
            => Get<T>(key).Match(
                () => defaultValue,
                (value) => value.Head);
    }

    public abstract class ConfigurationManager
    {
        public static NameValueCollection AppSettings => null;
    }

    public static class Tester
    {
        public static void Main(string[] args)
        {
            
        }
    }
}