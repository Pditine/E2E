using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace E2E
{
    public partial class E2EForm : Form
    {
        private const string Website = "https://github.com/Pditine/E2E";
        public const string ExcelPath = "./Excel/";
        private string FullExcelPath => Path.GetFullPath(ExcelPath);
        public const string ExportPath = "./Json/";
        private string FullExportPath => Path.GetFullPath(ExportPath);

        // private List<string> SelectedExcelFileNames => SelectedExcelFilePaths.Select(name => name.Split("/").Last()).ToList();

        private readonly List<string> _excelFiles = new List<string>();

        private List<string> SelectedExcelFilePaths => CheckedListBox.CheckedItems.Cast<string>().ToList();
        
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
            PreLoadExcelFiles();
            AddExcelFileItems(_excelFiles);
        }

        private void PreLoadExcelFiles()
        {
            if (!Directory.Exists(ExcelPath))
            {
                Directory.CreateDirectory(ExcelPath);
                Log.Info($"Excel文件夹不存在，已自动创建 {FullExcelPath}");
            }else
            {
                Log.Info($"从 {FullExcelPath} 加载文件");
            }

            if (!Directory.Exists(ExportPath))
            {
                Directory.CreateDirectory(ExportPath);
                Log.Info($"导出文件夹不存在，已自动创建 {FullExportPath}");
            }

            var files = Directory.GetFiles(ExcelPath);
            var fileList = new List<string>(files);
            fileList.RemoveAll(IsExcel);
            foreach (var file in fileList)
            {
                _excelFiles.Add(file.Split('/').Last());
            }
        }

        private void AddExcelFileItems(List<string> files)
        {
            foreach (var file in files)
            {
                AddExcelFileItem(file);
            }
        }

        private void AddExcelFileItem(string file)
        {
            CheckedListBox.Items.Add(file);
            CheckedListBox.SelectedItems.Add(file);
        }

        private void Refresh_Click(object sender, EventArgs e)
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

        private bool IsExcel(string file)
        {
            return !file.EndsWith(".xls") && !file.EndsWith(".xlsx") || file.Contains("~$");
        }
    }
}
