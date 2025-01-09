using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Converter
{
    public class Converter
    {
        public Setting Setting = new Setting();
        public const string Name = "Json";
        private readonly List<(int, string)> _logs = new List<(int, string)>();
        public List<(int, string)> Convert(List<List<object>> table, string fileName)
        {
            _logs.Clear();
            try
            {
                int keyIndex = FindTag("KEY", table[3]);
                
                if (keyIndex == -1)
                {
                    _logs.Add((3, "Tag \"key\" not found"));
                    return _logs;
                }
                
                StringBuilder json = new StringBuilder();
                json.Append("{\n");
                
                for (int i = 4; i < table.Count; i++)
                {
                    json.Append("\t\"");
                    json.Append(table[i][keyIndex]);
                    json.Append("\":{");
                    for (int j = 0; j < table[i].Count; j++)
                    {
                        if (j == keyIndex)
                        {
                            continue;
                        }
                        string valueType = table[1][j].ToString();
                        if(valueType.ToUpper() == "COMMENT")
                        {
                            continue;
                        }
                        if(j != 0)
                            json.Append("\n");
                        json.Append("\t\t");
                        json.Append("\"");
                        json.Append(table[2][j]);
                        json.Append("\":");
                        json.Append(GetValueString(valueType, table[i][j]));
                        json.Append(",");
                    }
                    json.Remove(json.Length - 1, 1);
                    json.Append("\n\t\t},\n");
                }
                json.Remove(json.Length - 2, 1);
                json.Append("}");
                
                File.WriteAllText(Setting.ExportPath + fileName + ".json", json.ToString());
            }
            catch (Exception e)
            {
                _logs.Add((3, e.Message + e.StackTrace));
            }
            return _logs;
        }
        
        private int FindTag(string tag, List<object> row)
        {
            for (int i = 0; i < row.Count; i++)
            {
                if (row[i].ToString().ToUpper() == tag)
                {
                    return i;
                }
            }
            return -1;
        }

        private string GetValueString(string type, object value)
        {
            if (type == "string")
            {
                return $"\"{value}\"";
            }
            if (type == "int[]")
            {
                int[] array = value.ToString().Split(',').Select(int.Parse).ToArray();
                return $"[{string.Join(",", array)}]";
            }
            return value.ToString();
        }
    }
    
    public class Setting
    {
        public string ExcelPath = "./Excel/";
        public string ExportPath = "./Json/";
    }
}