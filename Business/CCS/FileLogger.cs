using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CCS
{//Bırbırlerının alternatıfı olan seylerı ımplemente edılır
    public class FileLogger:ILogger
    {

        public void Log()
        {
            Console.WriteLine("Dosya Loglandı");
        }
    }
}
