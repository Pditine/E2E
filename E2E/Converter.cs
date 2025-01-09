using System.Reflection;

namespace E2E;

public class Converter
{
    private object _converter;
    private MethodInfo _convertMethod;
    private FieldInfo _converterSetting;
    public string ExcelPath = "./Excel/";
    public string? Name { get; }
    
    public Converter(object converter)
    {
        _converter = converter;
        _convertMethod = _converter.GetType().GetMethod("Convert");
        _converterSetting = _converter.GetType().GetField("Setting");
        var nameField = _converter.GetType().GetField("Name");
        Name = (string)nameField.GetValue(_converter);
    }
    
    public Dictionary<string, string> Setting
    {
        get
        {
            var setting = _converterSetting.GetValue(_converter);
            var result = new Dictionary<string, string>();
            result["ExcelPath"] = ExcelPath;
            var type = setting.GetType();
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                result[field.Name] = field.GetValue(setting)?.ToString();
            }
            return result;
        }
        set
        {
            var setting = _converterSetting.GetValue(_converter);
            ExcelPath = value["ExcelPath"];
            foreach (var field in setting.GetType().GetFields())
            {
                if (value.ContainsKey(field.Name))
                {
                    field.SetValue(setting, value[field.Name]);
                }
            }
        }
    }
    
    public void Convert(List<List<object>> table, string fileName)
    { 
        List<(int, string)>? logs = null;
        try
        {
            logs = (List<(int, string)>)_convertMethod.Invoke(_converter, new object[] {table, fileName});
        }
        catch (Exception e)
        {
            Log.Error(e.Message + e.StackTrace);
        }

        if (logs == null)
        {
            Log.Error("Convert failed");
            return;
        }
        foreach (var log in logs)
        {
            Log.Print(log.Item1, log.Item2);
        }
        Log.Succese("Convert success");
    }
}