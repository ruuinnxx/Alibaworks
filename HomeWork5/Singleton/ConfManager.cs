using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PatternsHomework.Singleton
{
    public sealed class ConfigurationManager
    {
        private static readonly Lazy<ConfigurationManager> _lazy =
            new Lazy<ConfigurationManager>(() => new ConfigurationManager(), isThreadSafe: true);

        private readonly Dictionary<string, string> _settings = new();
        private readonly object _lock = new();

        private ConfigurationManager() { }

        public static ConfigurationManager GetInstance() => _lazy.Value;

        public string Get(string key)
        {
            lock (_lock)
            {
                return _settings.TryGetValue(key, out var value) ? value : null;
            }
        }

        public void Set(string key, string value)
        {
            lock (_lock)
            {
                _settings[key] = value;
            }
        }

        public bool Remove(string key)
        {
            lock (_lock)
            {
                return _settings.Remove(key);
            }
        }

        public Dictionary<string, string> GetAll()
        {
            lock (_lock)
            {
                return new Dictionary<string, string>(_settings);
            }
        }

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path)) return;
            lock (_lock)
            {
                var json = File.ReadAllText(path);
                var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                _settings.Clear();
                if (dict != null)
                {
                    foreach (var kv in dict)
                        _settings[kv.Key] = kv.Value;
                }
            }
        }

        public void SaveToFile(string path)
        {
            Dictionary<string, string> snapshot;
            lock (_lock)
            {
                snapshot = new Dictionary<string, string>(_settings);
            }

            var json = JsonSerializer.Serialize(snapshot, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public void LoadDefaults()
        {
            lock (_lock)
            {
                _settings.Clear();
                _settings["AppName"] = "DemoApp";
                _settings["Version"] = "1.0.0";
                _settings["MaxItems"] = "100";
            }
        }
    }
}