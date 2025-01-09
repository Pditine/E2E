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
    }

    private void SaveSetting()
    {
        JsonObject json = new JsonObject();
        foreach (var (key, value) in _settings)
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
    
    private void LoadSetting()
    {
        if (!File.Exists("Setting.json"))
        {
            return;
        }
        var json = File.ReadAllText("Setting.json");
        var document = JsonDocument.Parse(json);
        var root = document.RootElement;
        
    }
}