using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Utils
{
    public class LogManager
    {
        /// <summary>
        /// Função para gerar relatorio de erros do programa nos logs do windows
        /// </summary>
        /// <param name="erro"></param>
        public static void LogErros(string erro)
        {
            try
            {
                if (!EventLog.SourceExists("AgendamentoOnline"))
                {
                    EventLog.CreateEventSource("AgendamentoOnline", "AgendamentoOnline - ErrorReport");
                }
                EventLog myLog = new EventLog();
                myLog.Source = "AgendamentoOnline";
                myLog.WriteEntry(erro);
            }
            catch (Exception exp)
            {
            }

        }
    }
}