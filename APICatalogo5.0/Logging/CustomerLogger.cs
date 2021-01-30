using APICatalogo5._0.Properties;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace APICatalogo5._0.Logging
{
    public class CustomerLogger : ILogger
    {
        readonly string _loggerName;
        readonly CustomLoggerProviderConfiguration _loggerConfig;
        private string name;
        private CustomLoggerProviderConfiguration loggerConfig;

        public CustomerLogger(string name, CustomLoggerProviderConfiguration config)
        {
            _loggerName = name;
            _loggerConfig = config;

        }


        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _loggerConfig.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string mensagem = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

            EscreverTextoNoArquivo(mensagem);

        }

        private void EscreverTextoNoArquivo(string mensagem)
        {
            string caminhoArquivoLog = Resources.CaminhoLog + @"log.txt";
            using(StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, true))
            {
                try
                {
                    streamWriter.WriteLine(mensagem);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                catch(Exception ex)
                {
                    throw;
                }
            }


        }

    }
}
