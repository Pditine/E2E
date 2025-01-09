using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    public class Converter
    {
        private Setting Setting = new Setting();
        public const string Name = "Unity-SO";
        private readonly List<(int, string)> _logs = new List<(int, string)>();
        
        private const string CannedFormat = "%YAML 1.1\n" +
                                             "%TAG !u! tag:unity3d.com,2011:\n" +
                                             "--- !u!114 &11400000\n" +
                                             "MonoBehaviour:\n" +
                                             "  m_ObjectHideFlags: 0\n" +
                                             "  m_CorrespondingSourceObject: {fileID: 0}\n" +
                                             "  m_PrefabInstance: {fileID: 0}\n" +
                                             "  m_PrefabAsset: {fileID: 0}\n" +
                                             "  m_GameObject: {fileID: 0}\n" +
                                             "  m_Enabled: 1\n" +
                                             "  m_EditorHideFlags: 0";
        
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
                
                int nameIndex = FindTag("NAME", table[3]);
                if (nameIndex == -1)
                {
                    _logs.Add((3, "Tag \"name\" not found"));
                    return _logs;
                }
                
                string guid = Guid.NewGuid().ToString("N");
                
                // create C# file
                StringBuilder CS = new StringBuilder();
                CS.Append("using System;\n");
                CS.Append("using System.Collections.Generic;\n");
                CS.Append("using UnityEngine;\n\n");
                CS.Append("namespace " + Setting.NameSpace + "\n");
                CS.Append("{\n");
                CS.Append(Setting.Attribute + "\n");
                CS.Append("    public class " + fileName + " : ScriptableObject\n");
                CS.Append("    {\n");
                for (int i = 4; i < table.Count; i++)
                {
                        CS.Append("        public " + fileName + "Item" + " " + table[i][nameIndex] + ";\n");
                }
                CS.Append("    }\n");
                CS.Append("    [Serializable]\n");
                CS.Append("    public class " + fileName + "Item\n");
                CS.Append("    {\n");
                for (int j = 0; j < table[2].Count; j++)
                {
                    if (j == nameIndex)
                    {
                        continue;
                    }
                    string valueType = table[1][j].ToString();
                    if(valueType.ToUpper() == "COMMENT")
                    {
                        continue;
                    }
                    CS.Append("        public " + valueType + " " + table[2][j] + ";\n");
                }
                CS.Append("    }\n");
                CS.Append("}\n");
                
                // create C# meta file
                StringBuilder meta = new StringBuilder();
                meta.Append("fileFormatVersion: 2\n");
                meta.Append("guid: " + guid + "\n");
                meta.Append("MonoImporter:\n" +
                            "  externalObjects: {}\n" +
                            "  serializedVersion: 2\n" +
                            "  defaultReferences: []\n" +
                            "  executionOrder: 0\n" +
                            "  icon: {instanceID: 0}\n" +
                            "  userData: \n" +
                            "  assetBundleName: \n" +
                            "  assetBundleVariant: ");
                
                // create asset file
                StringBuilder asset = new StringBuilder();
                asset.Append(CannedFormat);
                asset.Append("\n  m_Script: {fileID: 11500000, guid: " + guid + ", type: 3}\n");
                asset.Append("  m_Name: " + fileName + "\n");
                asset.Append("  m_EditorClassIdentifier: \n");
                for (int i = 4; i < table.Count; i++)
                {
                    asset.Append("  " + table[i][nameIndex] + ":\n");
                    for (int j = 0; j < table[i].Count; j++)
                    {
                        if (j == nameIndex)
                        {
                            continue;
                        }
                        string valueType = table[1][j].ToString();
                        if(valueType.ToUpper() == "COMMENT")
                        {
                            continue;
                        }
                        asset.Append("    " + table[2][j] + ": " + GetValueString(valueType, table[i][j]) + "\n");
                    }
                }
                
                // write to file
                System.IO.Directory.CreateDirectory(Setting.ExportCSPath);
                System.IO.Directory.CreateDirectory(Setting.ExportAssetPath);
                System.IO.File.WriteAllText(Setting.ExportCSPath + fileName + ".cs", CS.ToString());
                System.IO.File.WriteAllText(Setting.ExportCSPath + fileName + ".cs.meta", meta.ToString());
                System.IO.File.WriteAllText(Setting.ExportAssetPath + fileName + ".asset", asset.ToString());
                
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
            if (type.ToUpper() == "STRING")
            {
                return $"\"{value}\"";
            }
            if (type.ToUpper() == "INT")
            {
                return value.ToString();
            }
            if (type.ToUpper() == "FLOAT")
            {
                return value.ToString();
            }
            if (type.ToUpper() == "BOOL")
            {
                return value.ToString().ToLower() == "true" ? "1" : "0";
            }
            if (type.ToUpper() == "int[]")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\n");
                foreach (var v in (List<int>)value)
                {
                    sb.Append("  - " + v + "\n");
                }
                return sb.ToString();
            }
            if (type.ToUpper() == "float[]")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\n");
                foreach (var v in (List<float>)value)
                {
                    sb.Append("  - " + v + "\n");
                }
                return sb.ToString();
            }
            if (type.ToUpper() == "string[]")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\n");
                foreach (var v in (List<string>)value)
                {
                    sb.Append("  - " + v + "\n");
                }
                return sb.ToString();
            }
            
            return value.ToString();
        }
    }
    
    public class Setting
    {
        public string ExcelPath => "./Excel/";
        public string ExportCSPath => "./CS/";
        public string ExportAssetPath => "./Asset/";
        public string NameSpace => "DefaultNamespace";
        public string Attribute => "";
    }
}