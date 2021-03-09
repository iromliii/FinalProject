using System;

namespace Business.CCS
{//Bırbırlerının alternatıfı olan seylerı ımplemente edılır
    public class DataBaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Verı tabanına Loglandı");
        }
    }
}
