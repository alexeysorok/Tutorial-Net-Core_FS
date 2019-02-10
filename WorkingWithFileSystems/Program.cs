using static System.Console;
using System.IO;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace Tutorial_Net_Core_FS
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputFileSystemInfo();
            WorkWithDrives();
        }


        // работа с путями 
        static void OutputFileSystemInfo()
        {
            WriteLine($"Path.PathSeparator: {PathSeparator}");
            WriteLine($"Path.DirectorySeparatorChar: {DirectorySeparatorChar}");
            WriteLine($"Directory.GetCurrentDirectory(): {GetCurrentDirectory()}");
            WriteLine($"Environment.CurrentDirectory: {CurrentDirectory}");
            WriteLine($"Environment.SystemDirectory: {SystemDirectory}");
            WriteLine($"Path.GetTempPath(): {GetTempPath()}");
            WriteLine($"GetFolderPath(SpecialFolder):");
            WriteLine($" System: {GetFolderPath(SpecialFolder.System)}");
            WriteLine($" ApplicationData:{ GetFolderPath(SpecialFolder.ApplicationData)}");
            WriteLine($" MyDocuments: {GetFolderPath(SpecialFolder.MyDocuments)}");
            WriteLine($" Personal: {GetFolderPath(SpecialFolder.Personal)}");
        }
        // В типе Environment реализовано много других полезных членов, в том числе
        // метод GetEnvironmentVariables, а также свойства OSVersion и ProcessorCount

        // работа с дисками 
        static void WorkWithDrives()
        {
            WriteLine($"|--------------------------------|------------|" +
                      $"-------- -| --------------------| --------------------| ");
            WriteLine($"| Name | Type | Format | Size | Free space |");
            WriteLine($"|--------------------------------|------------|" +
                       $"-------- -| --------------------| --------------------| ");
        foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    WriteLine($"| {drive.Name,-30} |" +
                        $" { drive.DriveType,-10} |" +
                        $" { drive.DriveFormat, -7} |" +
                        $" { drive.TotalSize,18:N0} | { drive.AvailableFreeSpace,18:N0} | ");
                }
                else
                {
                    WriteLine($"| {drive.Name,-30} | {drive.DriveType,-10} |");
                }
            }
            WriteLine($"|--------------------------------|------------|" +
            $"-------- -| --------------------| --------------------| ");
        }

        // работа с каталогами 
        static void WorkWithDirectories()
        {
            // определение собственного пути к папке
            string userFolder = GetFolderPath(SpecialFolder.Personal);
            var customFolder = new string[]
            { userFolder, "Code", "Chapter09", "NewFolder" };
            string dir = Combine(customFolder);
            WriteLine($"Working with: {dir}");
            // проверка существования папки
            WriteLine($"Does it exist? {Exists(dir)}");
            // создание каталога
            WriteLine("Creating it...");
            CreateDirectory(dir);

            WriteLine($"Does it exist? {Exists(dir)}");
            Write("Confirm the directory exists, and then press ENTER: ");
            ReadLine();
            // удаление каталога
            WriteLine("Deleting it...");
            Delete(dir, recursive: true);
            WriteLine($"Does it exist? {Exists(dir)}");
        }

        // управление файлами 
        static void WorkWithFiles()
        {
            // определение пути к каталогу
            string userFolder = GetFolderPath(SpecialFolder.Personal);
            var customFolder = new string[]
            { userFolder, "Code", "Chapter09", "OutputFiles" };
            string dir = Combine(customFolder);
            CreateDirectory(dir);
            // определение путей к файлам
            string textFile = Combine(dir, "Dummy.txt");
            string backupFile = Combine(dir, "Dummy.bak");
            WriteLine($"Working with: {textFile}");
            // проверка существования файла
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            // создание текстового файла и запись текстовой строки
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello, C#!");
            textWriter.Close(); // закрытие файла и высвобождение ресурсов
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            // копирование файла с перезаписью (если существует)
            File.Copy(
            sourceFileName: textFile,
            destFileName: backupFile,
            overwrite: true);
            WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");
            Write("Confirm the files exist, and then press ENTER: ");
            ReadLine();
            // удаление файла
            File.Delete(textFile);
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            // чтение содержимого текстового файла
            WriteLine($"Reading contents of {backupFile}:");
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close();

            // управление путями
            WriteLine($"File Name: {GetFileName(textFile)}");
            WriteLine($"File Name without Extension: {GetFileNameWithoutExtension(textFile)}");
            WriteLine($"File Extension: {GetExtension(textFile)}");
            WriteLine($"Random File Name: {GetRandomFileName()}");
            WriteLine($"Temporary File Name: {GetTempFileName()}");
            // Метод GetTempFileName создает файл с нулевым размером и возвращает
            //его имя, готовое к использованию. А метод GetRandomFileName просто возвращает имя файла, 
            //не создавая сам файл.

            // извлечение информации о файле
            var info = new FileInfo(backupFile);
            WriteLine($"{backupFile}:"); WriteLine($" Contains {info.Length} bytes");
            WriteLine($" Last accessed {info.LastAccessTime}");
            WriteLine($" Has readonly set to {info.IsReadOnly}");

        }




    }
 }
