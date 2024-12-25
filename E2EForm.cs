using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace E2E
{
    public partial class E2EForm : UIForm
    {
        private const string Website = "https://github.com/Pditine/E2E";
        public const string ExcelPath = "./Excel/";
        private string FullExcelPath => Path.GetFullPath(ExcelPath);
        public const string JsonPath = "./Json/";

        // private List<string> SelectedExcelFileNames => SelectedExcelFilePaths.Select(name => name.Split("/").Last()).ToList();

        private Dictionary<string, string> _excelFilePaths = new Dictionary<string, string>();
        
        private string FullJsonPath => Path.GetFullPath(JsonPath);
        private List<string> SelectedExcelFilePaths => CheckBoxList.SelectedItems.Cast<string>().ToList();
        
        public E2EForm()
        {
            InitializeComponent();
        }
        
        private void E2E_Load(object sender, EventArgs e)
        {
            Log.Init(LogBox);
            try
            {
                InitData();
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
            }
        }

        private void Setting_Click(object sender, EventArgs e)
        {

        }

        private void Convert_Click(object sender, EventArgs e)
        {
            foreach (var path in SelectedExcelFilePaths)
            {
                Log.Debug(path);
            }
        }

        private void LinkLabel_Click(object sender, EventArgs e)
        {
            Process pro = new Process();
            pro.StartInfo.UseShellExecute = true;
            pro.StartInfo.FileName = Website;
            pro.Start();
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        
        private string LoadExcelConverter()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Assembly assembly = Assembly.LoadFile(path + "/ExcelConverter.dll");
            Type type = assembly.GetType("ExcelToEverything.ExcelConverter");
            var types = assembly.GetTypes();
            if (type == null)
            {
                return "Type not found";
            }
            object obj = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod("Convert");
            if (method == null)
            {
                return "Method not found";
            }

            return (string)method.Invoke(obj, new object[] { "this is a test" });
        }
        
        private void InitData()
        {
            // System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            // var encoding = Encoding.GetEncoding(936);
            var excelNames = PreLoadExcelFiles();
            AddExcelFileItem(excelNames);
        }

        private List<string> PreLoadExcelFiles()
        {
            if (!Directory.Exists(ExcelPath))
            {
                Directory.CreateDirectory(ExcelPath);
                Log.Info($"Excel文件夹不存在，已自动创建 {FullExcelPath}");
            }else
            {
                Log.Info($"从 {FullExcelPath} 加载文件");
            }

            if (!Directory.Exists(JsonPath))
            {
                Directory.CreateDirectory(JsonPath);
                Log.Info($"Json文件夹不存在，已自动创建 {FullJsonPath}");
            }

            var files = Directory.GetFiles(ExcelPath);
            var fileList = new List<string>(files);
            fileList.RemoveAll(f => (!f.EndsWith(".xls") && !f.EndsWith(".xlsx"))||f.Contains("~$"));
            foreach (var file in fileList)
            {
                _excelFilePaths.Add(file.Split("/").Last(),file);
            }
            return _excelFilePaths.Keys.ToList();
        }

        private void AddExcelFileItem(List<string> files)
        {
            foreach (var file in files)
            {
                AddExcelFileItem(file);
            }
        }

        private void AddExcelFileItem(string file)
        {
            CheckBoxList.Items.Add(file);
            CheckBoxList.SelectedItems.Add(file);
        }

        private void LogBoxToBottom()
        {
            LogBox.SelectionStart = LogBox.Text.Length;
            LogBox.SelectionLength = 0;
            LogBox.ScrollToCaret();
        }
    }
}
