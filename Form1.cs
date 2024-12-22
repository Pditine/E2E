using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E2E
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            textBox1.Text = LoadExcelConverter();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // textBox1.Text = "has Init";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
