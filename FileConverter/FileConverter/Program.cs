using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace FileConverter
{
    class Program
    {
        /// <summary>
        /// Servisas skirta failu konvertavimui, gali buti instaliuotas kaip windows servisas, gali buti paleistas kaip consoline aplikacija
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            HostFactory.Run(serviceConfig =>
            {
                serviceConfig.Service<ConverterService>(serviceInstance =>
                {
                    serviceInstance.ConstructUsing(() => new ConverterService());

                    serviceInstance.WhenStarted(execute => execute.Start());

                    serviceInstance.WhenStopped(execute => execute.Stop());
                });

                serviceConfig.SetServiceName("FileConverter");
                serviceConfig.SetDisplayName("File Converter");
                serviceConfig.SetDescription("File converter service");

                serviceConfig.StartAutomatically();
            });
        }
    }
}
