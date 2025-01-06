using System.Collections.Generic;
namespace Converter
{
    public class Converter
    {
        public const string Name = "Json";
        
        public List<(int, string)> Convert(List<List<object>> table)
        {
            List<(int, string)> logs = new List<(int, string)>();
            
            for (int i = 0; i < table.Count; i++)
            {
                string line = "";
                for (int j = 0; j < table[i].Count; j++)
                {
                    line += table[i][j] + ",";
                }
                logs.Add((1, line));
            }

            return logs;
        }
        
        public bool Check(int width, List<List<object>> table)
        {
            return true;
        }
    }
    
    public static class Setting
    {
        public static string ExcelPath => "./Excel/";
        public static string ExportPath => "./Json/";
    }
}