using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YSUNetLogin
{
    internal class LogData
    {
        public string Message;
        public string Level;
        public LogData(string message, string level)
        {
            Message = message;
            Level = level;
        }
    }

    internal class ListLogger
    {
        private ListBox logListBox = null;
        private List<LogData> logs = new List<LogData>();
        public ListLogger(ListBox _logListBox)
        {
            logListBox = _logListBox;
        }

        private void InternalLogLastMessage(string message, string level)
        {
            logs.Add(new LogData(message, level));

            LogData log = logs.Last();
            string logStr = string.Format("[{0}] {1} ({2})",log.Level,log.Message,DateTime.Now.ToShortTimeString());

            logListBox.Items.Add(logStr);
        }
        public void InfoLog(string message)
        {
            InternalLogLastMessage(message, "INFO");
        }
        public void WarnLog(string message)
        {
            InternalLogLastMessage(message, "WARN");
        }
        public void ErrorLog(string message)
        {
            InternalLogLastMessage(message, "ERROR");
        }
        public void FatalLog(string message)
        {
            InternalLogLastMessage(message, "FATAL");
        }
    }
}
