
using System.Drawing;
using System.Windows.Forms;
using Sunny.UI;

namespace E2E
{
    public static class Log
    {
        private static UIRichTextBox _logBox;
        public static UIRichTextBox LogBox => _logBox;

        public static void Init(UIRichTextBox logBox)
        {
            _logBox = logBox;
        }

        public static void Print(LogLevel level, string message)
        {
            Color color;
            switch (level)
            {
                case LogLevel.Info:
                    color = Color.Blue;
                    break;
                case LogLevel.Warning:
                    color = Color.Yellow;
                    break;
                case LogLevel.Error:
                    color = Color.Red;
                    break;
                case LogLevel.Succese:
                    color = Color.Green;
                    break;
                case LogLevel.Faild:
                    color = Color.Red;
                    break;
                default:
                    color = Color.Black;
                    break;
            }

            var prefix = level.ToString();
            _logBox.AppendText("\n[");
            _logBox.SelectionColor = color;
            _logBox.AppendText(prefix);
            _logBox.SelectionColor = Color.Black;
            _logBox.AppendText($"]{message}");
        }
        
        public static void Debug(string content)
        {
            Print(LogLevel.Debug, content);
        }

        public static void Info(string content)
        {
            Print(LogLevel.Info, content);
        }
        
        public static void Warning(string content)
        {
            Print(LogLevel.Warning, content);
        }
        
        public static void Error(string content)
        {
            Print(LogLevel.Error, content);
        }
        
        public static void Succese(string content)
        {
            Print(LogLevel.Succese, content);
        }
        
        public static void Faild(string content)
        {
            Print(LogLevel.Faild, content);
        }
    }

    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error,
        Succese,
        Faild
    }
}