
namespace xls2json
{
    public class Log(RichTextBox logBox)
    {
        public RichTextBox LogBox => logBox;

        public void Print(LogLevel level, string message)
        {
            var color = level switch
            {
                LogLevel.Info => Color.Blue,
                LogLevel.Warning => Color.Yellow,
                LogLevel.Error => Color.Red,
                LogLevel.Succese => Color.Green,
                LogLevel.Faild => Color.Red,
                _ => Color.Black
            };
            var prefix = level.ToString();
            //logBox.SelectionStart = logBox.TextLength;
            logBox.AppendText("\n[");
            logBox.SelectionColor = color;
            logBox.AppendText(prefix);
            logBox.SelectionColor = Color.Black;
            // logBox.SelectionColor = Color.Black;
            logBox.AppendText($"]{message}");
            //logBox.SelectedText = message;

            //logBox.SelectionLength = prefix.Length;


        }
        
        public void Debug(string content)
        {
            Print(LogLevel.Debug, content);
        }

        public void Info(string content)
        {
            Print(LogLevel.Info, content);
        }
        
        public void Warning(string content)
        {
            Print(LogLevel.Warning, content);
        }
        
        public void Error(string content)
        {
            Print(LogLevel.Error, content);
        }
        
        public void Succese(string content)
        {
            Print(LogLevel.Succese, content);
        }
        
        public void Faild(string content)
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
