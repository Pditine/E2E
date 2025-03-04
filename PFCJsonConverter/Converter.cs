﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Converter
{
    public class Converter
    {
        public Setting Setting = new Setting();
        public const string Name = "PFCJson";
        private readonly List<(int, string)> _logs = new List<(int, string)>();
        public List<(int, string)> Convert(List<List<object>> table, string fileName)
        {
            _logs.Clear();
            try
            {
                // Create Json
                
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
                        string valueType = table[1][j].ToString();
                        if (valueType.ToUpper() == "COMMENT" || valueType.ToUpper() == "")
                        {
                            continue;
                        }
                        // if (j != 0)
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
                if (!Directory.Exists(Setting.ExportJsonPath))
                    Directory.CreateDirectory(Setting.ExportJsonPath);
                File.WriteAllText(Setting.ExportJsonPath + fileName + ".json", json.ToString());
                _logs.Add((1, $"Json file {fileName}.json created successfully"));
                
                // Create C#
                StringBuilder CS = new StringBuilder();
                CS.Append("// This script is auto-generated by E2E\n");
                CS.Append("// Do not modify this script manually\n");
                CS.Append("// url: https://github.com/Pditine/E2E\n");
                CS.Append("using System;\n");
                CS.Append("using PurpleFlowerCore.Config;\n\n");
                CS.Append("namespace PurpleFlowerCore\n");
                CS.Append("{\n");
                CS.Append("    public class " + fileName + " : JsonConfig< " + fileName + "Item>\n");
                CS.Append("    {\n");
                CS.Append("        protected override string GetLoadPath()\n");
                CS.Append("        {\n");
                CS.Append("            return \"" + Setting.JsonUnityPath + fileName + ".json\";\n");
                CS.Append("        }\n");
                int refIndex = FindTag("ref", table[3]);
                if (refIndex != -1)
                {
                    for (int i = 4; i < table.Count; i++)
                    {
                        CS.Append("\n        /// <summary>\n");
                        int commentIndex = FindTag("comment", table[3]);
                        if (commentIndex != -1)
                            CS.Append("        /// " + table[2][keyIndex] + ": " + table[i][keyIndex] + ", " + table[i][commentIndex] + "\n");
                        else
                            CS.Append("        /// " + table[2][keyIndex] + ": " + table[i][keyIndex] + "\n");
                        
                        CS.Append("        /// </summary>\n");
                        CS.Append("        public " + fileName + "Item " + table[i][refIndex] + " => GetItem(\"" + table[i][keyIndex] + "\"); \n");
                    }
                }
                
                CS.Append("    }\n\n");
                CS.Append("    public abstract partial class PFCConfig\n");
                CS.Append("    {\n");
                CS.Append("        public static " + fileName + " " + fileName + " = new " + fileName + "();\n");
                CS.Append("    }\n\n");
                CS.Append("    [Serializable]\n");
                CS.Append("    public class " + fileName + "Item\n");
                CS.Append("    {\n");
                for (int j = 0; j < table[2].Count; j++)
                {
                    if (j == keyIndex)
                    {
                        continue;
                    }
                    string valueType = table[1][j].ToString();
                    if (valueType.ToUpper() == "COMMENT" || valueType.ToUpper() == "")
                    {
                        continue;
                    }
                    CS.Append("        public " + valueType + " " + table[2][j] + "; // " + table[0][j] + "\n");
                }
                CS.Append("    }\n");
                CS.Append("}\n");
                if (!Directory.Exists(Setting.ExportCSPath))
                    Directory.CreateDirectory(Setting.ExportCSPath);
                File.WriteAllText(Setting.ExportCSPath + fileName + "_gen.cs", CS.ToString());
                _logs.Add((1, $"CS file {fileName}_gen.cs created successfully"));
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
                List<string> tags = row[i].ToString().ToUpper().Split(',').ToList();
                if (tags.Contains(tag.ToUpper()))
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
        public string ExportJsonPath = "./Json/";
        public string ExportCSPath = "./CS/";
        public string JsonUnityPath = "Assets/Data/Json/";
    }
}