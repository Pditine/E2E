using System.Text.Json;
using System.Text.Json.Nodes;

namespace E2E;
public partial class Setting : Form
{
    private Dictionary<string, Converter> _converters;
    private Dictionary<string, Dictionary<string, string>> _settings = new();
    public Setting(Dictionary<string, Converter> converters)
    {
        InitializeComponent();
        try
        {
            _converters = converters;
            InitSettings();
        }
        catch (Exception e)
        {
            Log.Error(e.Message + e.StackTrace);
        }
    }

    private void InitSettings()
    {
        int index = 0;
        MergeSettingToConverters(_converters);
        foreach (var converter in _converters)
        {
            InitSetting(converter.Value, ref index);
        }
    }

    private void InitSetting(Converter converter, ref int index)
    {
        var setting = converter.Setting;
        _settings[converter.Name] = setting;
        var title = new Label
        {
            Text = converter.Name,
            Location = new Point(0, index * 30),
            AutoSize = true
        };
        SettingList.Controls.Add(title);

        index++;
        foreach (var (key, value) in setting)
        {
            var label = new Label
            {
                Text = key,
                Location = new Point(0, index * 30),
                AutoSize = true
            };
            var textBox = new TextBox
            {
                Text = value,
                Location = new Point(label.Width + 1, index * 30),
                AutoSize = true
            };
            textBox.TextChanged += (sender, e) =>
            {
                setting[key] = textBox.Text;
            };
            index++;
            SettingList.Controls.Add(label);
            SettingList.Controls.Add(textBox);
        }

        SettingList.Height = index * 30;
    }

    private void Setting_FormClosed(object sender, FormClosedEventArgs e)
    {
        foreach (var converter in _converters)
        {
            converter.Value.Setting = _settings[converter.Key];
        }
        SaveSetting(_settings);
    }

    private static void SaveSetting(Dictionary<string, Dictionary<string, string>> settings)
    {
        JsonObject json = new JsonObject();
        foreach (var (key, value) in settings)
        {
            JsonObject setting = new JsonObject();
            foreach (var (k, v) in value)
            {
                setting.Add(k, v);
            }
            json.Add(key, setting);
        }
        File.WriteAllText("Setting.json", json.ToString());
    }
    
    private static Dictionary<string, Dictionary<string, string>> LoadSetting()
    {
        if (!File.Exists("Setting.json"))
        {
            return null;
        }
        var json = File.ReadAllText("Setting.json");
        var root = JsonNode.Parse(json).AsObject();
        var result = new Dictionary<string, Dictionary<string, string>>();
        foreach (var (key, value) in root)
        {
            var setting = new Dictionary<string, string>();
            foreach (var (k, v) in value.AsObject())
            {
                setting[k] = v.ToString();
            }
            result[key] = setting;
        }
        return result;
    }
    
    private static Dictionary<string, string> LoadSetting(string converterName)
    {
        if (!File.Exists("Setting.json"))
        {
            return null;
        }
        var json = File.ReadAllText("Setting.json");
        var root = JsonNode.Parse(json).AsObject();
        if (!root.ContainsKey(converterName))
        {
            return null;
        }
        var setting = new Dictionary<string, string>();
        foreach (var (k, v) in root[converterName].AsObject())
        {
            setting[k] = v.ToString();
        }
        return setting;
    }
    
    public static void MergeSettingToConverters(Dictionary<string, Converter> converters)
    {
        var settings = LoadSetting();
        if(settings == null)
        {
            return;
        }
        foreach (var (key, value) in settings)
        {
            if (converters.ContainsKey(key))
            {
                converters[key].Setting = value;
            }
        }
    }
    public static void MergeSettingToConverter(Converter converter)
    {
        var setting = LoadSetting(converter.Name);
        if (setting != null)
        {
            converter.Setting = setting;
        }
    }
}