namespace dotNet_06_Delegates_03_Logger
{
    internal static class Logger
    {
        static String? _logpfad;
        static FileStream? _fs;
        static StreamWriter? _sw;

        static public void SetPath(String path)
        {
            CloseLog();
            _logpfad = path;
        }

        public static void Log(LogHandler logmethode, String message)
        {
            logmethode(message);
        }

        public static void ToFile(String message)
        {
            if (_logpfad == null) throw new Exception("Es wurde kein Logpfad angegeben");
            else
            {
                OpenLog();
                _sw.WriteLine(message);
                CloseLog();
            }
        }

        private static void CloseLog()
        {
            if (_sw != null) _sw.Close();
            if (_fs != null) _fs.Close();
        }

        private static void OpenLog()
        {
            CloseLog();
            _fs = new FileStream(_logpfad, FileMode.Append, FileAccess.Write);
            _sw = new StreamWriter(_fs);
        }
    }
}
