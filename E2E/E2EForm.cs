using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Excel;

namespace E2E
{
    public partial class E2EForm : Form
    {
        private string Website = "https://github.com/Pditine/E2E";
        //todo: 使用dll中的Setting
        public string ExcelPath = "./Excel/";
        private string FullExcelPath => Path.GetFullPath(ExcelPath);
        public string ExportPath = "./Json/";
        private string FullExportPath => Path.GetFullPath(ExportPath);

        private string DllPath = "/Converter";

        // private List<string> SelectedExcelFileNames => SelectedExcelFilePaths.Select(name => name.Split("/").Last()).ToList();

        private readonly List<string> _excelFiles = new();
        private List<string> SelectedExcelFilePaths => CheckedListBox.CheckedItems.Cast<string>().ToList();
        private readonly Dictionary<string?, Converter> _conveters = new();
        public E2EForm()
        {
            InitializeComponent();
        }
        
        private void E2E_Load(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding(936);
            Init();
        }

        private void Init()
        {
            Log.Init(LogBox);
            try
            {
                InitData();
                LoadConverters();
                InitConverterOption();
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message + exception.StackTrace);
            }
        }
        
        #region Event
        private void Setting_Click(object sender, EventArgs e)
        {
            var setting = new Setting();
            setting.ShowDialog();
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            foreach (var file in SelectedExcelFilePaths)
            {
                LoadExcel(ExcelPath + file);
            }
        }

        private void LinkLabel_Click(object sender, EventArgs e)
        {
            Process pro = new Process();
            pro.StartInfo.UseShellExecute = true;
            pro.StartInfo.FileName = Website;
            pro.Start();
        }
        
        private void Refresh_Click(object sender, EventArgs e)
        {
            Log.Info("Refresh");
            Init();
        }
        
        #endregion

        #region InitConvereter

        private void LoadConverters()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            // find all Assembly
            var dllPath = path + DllPath;
            var files = Directory.GetFiles(dllPath).ToList();
            files.RemoveAll(f => !f.EndsWith(".dll"));

            foreach (var f in files)
            {
                // f is dll's full path
                LoadConverter(f);
            }
        }

        private void LoadConverter(string path)
        {
            Assembly assembly = Assembly.LoadFile(path);
            string dllName = path.Split('/').Last();
            Type type = assembly.GetType("Converter.Converter");
            if (type == null)
            {
                Log.Error("Type \"Converter.Converter\" not found in " + dllName);
            }
            object converterInstance = Activator.CreateInstance(type);
            if (converterInstance == null)
            {
                Log.Error("Instance not found");
            }
            var newConverter = new Converter(converterInstance);
            Log.Info($"Load converter {newConverter.Name}");
            if(_conveters.ContainsKey(newConverter.Name))
            {
                Log.Error($"There is already a converter named {newConverter.Name}");
                return;
            }
            _conveters.Add(newConverter.Name, newConverter);
            ConverterOption.Items.Add(newConverter.Name);
        }

        private void InitConverterOption()
        {
            if(_conveters.Count == 0)
            {
                Log.Error("No converter found");
                return;
            }
            ConverterOption.SelectedIndex = 0;
        }

        #endregion

        #region InitData

        private void InitData()
        {
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

            var files = Directory.GetFiles(ExcelPath).ToList();
            files.RemoveAll(IsExcel);
            foreach (var file in files)
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
        
        private bool IsExcel(string file)
        {
            return !file.EndsWith(".xls") && !file.EndsWith(".xlsx") || file.Contains("~$");
        }
        
        #endregion

        #region Convert

        private void LoadExcel(string excelPath)
        {
            if (!File.Exists(excelPath))
            {
                Log.Error($"文件不存在 {excelPath}");
                return;
            }
            Log.Info($"加载文件 {excelPath}");
            using var fs = File.Open(excelPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            IExcelDataReader excelDataReader;
            if(excelPath.EndsWith(".xls"))
            {
                excelDataReader = ExcelReaderFactory.CreateBinaryReader(fs);
            }
            else
            {
                excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
            }
            fs.Close();
            
            var result = excelDataReader.AsDataSet();
            if(result == null)
            {
                Log.Error($"文件读取失败 {excelPath} : {excelDataReader.ExceptionMessage}");
                return;
            }
            
            foreach (DataTable table in result.Tables)
            {
                LoadSheet(table);
            }
        }
        
        private void LoadSheet(DataTable table)
        {
            List<List<object>> data = new();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                List<object> row = new();
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    row.Add(table.Rows[i][j]);
                }
                data.Add(row);
            }
            DoConvert(data, table.TableName);
        }

        private void DoConvert(List<List<object>> table, string fileName)
        {
            var converterName = ConverterOption.SelectedItem.ToString();
            var converter = _conveters[converterName];
            converter.Convert(table, fileName);
        }

        #endregion
    }
}