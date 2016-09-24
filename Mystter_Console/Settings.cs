using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Mystter_Console {
    public class Settings {
        public string Selected;
        public List<Account> Accounts = new List<Account>();

        private string SettingsFilePath = Info.Name + ".xml";
        
        // TODO: 引数をなくしたい・・・
        public void Save(Settings settings) {
            var s = new XmlSerializer(typeof(Settings));
            var w = new StreamWriter(SettingsFilePath, false, Encoding.UTF8);
            s.Serialize(w, settings);
            w.Close();
        }

        public Settings Load() {
            var _settings = new Settings();
            if (File.Exists(SettingsFilePath)) {
                var s = new XmlSerializer(typeof(Settings));
                var r = new StreamReader(SettingsFilePath);
                _settings = (Settings)s.Deserialize(r);
                r.Close();
            } else {
                Save(_settings);
            }
            return _settings;
        }
    }

    public class Account {
        public string Name;
        public string Token;
        public string Secret;
        public string Screen;
    }
}
