
using System.Drawing;
using System.Windows.Forms;

namespace E2E
{
    public static class Log
    {
        private static RichTextBox _logBox;
        public static RichTextBox LogBox => _logBox;

        public static void Init(RichTextBox logBox)
        {
            _logBox = logBox;
        }

        public static void Print(int level, string message)
        {
            Color color;
            switch (level)
            {
                case 1:
                    color = Color.Blue;
                    break;
                case 2:
                    color = Color.Yellow;
                    break;
                case 3:
                    color = Color.Red;
                    break;
                case 4:
                    color = Color.Green;
                    break;
                case 5:
                    color = Color.Red;
                    break;
                default:
                    color = Color.Black;
                    break;
            }

            var prefix = ((LogLevel)level).ToString();
            _logBox.AppendText("\n[");
            _logBox.SelectionColor = color;
            _logBox.AppendText(prefix);
            _logBox.SelectionColor = Color.Black;
            _logBox.AppendText($"]{message}");
            LogBoxToBottom();
        }
        
        public static void Print(LogLevel level, string message)
        {
            Print((int) level, message);
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
            Print(LogLevel.Success, content);
        }
        
        public static void Faild(string content)
        {
            Print(LogLevel.Failed, content);
        }
        
        private static void LogBoxToBottom()
        {
            LogBox.SelectionStart = LogBox.Text.Length;
            LogBox.SelectionLength = 0;
            LogBox.ScrollToCaret();
        }
    }

    public enum LogLevel
    {
        Debug = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        Success = 4,
        Failed = 5
    }
}