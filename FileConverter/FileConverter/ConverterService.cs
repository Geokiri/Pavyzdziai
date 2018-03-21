using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FileConverter
{
    class ConverterService
    {
        private FileSystemWatcher _watcher;

        /// <summary>
        /// Serviso Start metodas stebi direktoriją C:\Users\Public\Documents ar nėra sukurti nauji txt tipo failai
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
                _watcher = new FileSystemWatcher(@"C:\Users\Public\Documents", "*.txt");

                _watcher.Created += FileCreated;

                _watcher.IncludeSubdirectories = false;

                _watcher.EnableRaisingEvents = true;

            return true;
        }

        /// <summary>
        /// Eventas konvertuoja failą ir jo turinį
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                string content = File.ReadAllText(e.FullPath);

                string upperContent = content.ToUpperInvariant();

                var dir = Path.GetDirectoryName(e.FullPath);

                var convertedFileName = Path.GetFileName(e.FullPath) + ".converted";

                var convertedPath = Path.Combine(dir, convertedFileName);

                File.WriteAllText(convertedPath, upperContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public bool Stop()
        {
            _watcher.Dispose();

            return true;
        }
    }
}
