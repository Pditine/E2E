namespace E2E;

public partial class Setting : Form
{
    private Dictionary<string, Converter> _converters;
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
                // todo: 保存设置
                setting[key] = textBox.Text;
            };
            index++;
            SettingList.Controls.Add(label);
            SettingList.Controls.Add(textBox);
        }
        
        SettingList.Height = index * 30;
    }
}