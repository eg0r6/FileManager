using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class FileManagers
{
    static string exePath = AppDomain.CurrentDomain.BaseDirectory;
    public string filePath;
    static void Main()
    {
        string filePath = (exePath + "last_directory.txt");
        //создание файла
        if (File.Exists(filePath))
        {
            string lastDirectory = File.ReadAllText(filePath);
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
                lastDirectory = lines[0];
                Directory.SetCurrentDirectory(lastDirectory);
            }
        }
        else
        {
            File.CreateText(filePath);
        }

        var p = new FileManagers();
        Console.WriteLine("1.Создать");
        Console.WriteLine("2.Копировать");
        Console.WriteLine("3.Удалить");
        Console.WriteLine("4.Информация");
        int Vibor = Convert.ToInt32(Console.ReadLine());
        switch (Vibor)
        {
            case 1:
                Console.Clear();
                p.Create();
                break;
            case 2:
                Console.Clear();
                p.Copy();
                break;
            case 3:
                Console.Clear();
                p.Delete();
                break;
            case 4:
                Console.Clear();
                p.Info();
                break;
            default:
                break;
        }
    }
    public int cd = 0;
    public void Info()
    {
        Console.WriteLine("1.Информация о папке \n 2.Информация о файле");
        int Vibor = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (Vibor)
        {
            case 1:
                Console.WriteLine("Введите путь к нужной вам папке. \n Например: C:\\Users\\Owner\\Desktop\\newFloader");
                string folderPath = Console.ReadLine();
                Console.Clear();
                try
                {
                    // Проверка существования исходного файла
                    if (Directory.Exists(folderPath))
                    {
                        string[] files1 = Directory.GetFiles(folderPath);
                cd = 0;
                        Console.WriteLine("Все объекты в папке:");
                while(cd < files1.Length)
                {
                    Console.WriteLine(files1[cd]);
                    cd++;
                }
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);

                // Дата создания директории
                Console.WriteLine("Дата создания: " + directoryInfo.CreationTime);
                // Дата последнего изменения
                Console.WriteLine("Дата последнего изменения: " + directoryInfo.LastWriteTime);
                long totalSize = 0;
                FileInfo[] files = directoryInfo.GetFiles("*", SearchOption.AllDirectories);
                foreach (FileInfo file in files)
                {
                    totalSize += file.Length; // Суммируем длину каждого файла
                }
                Console.WriteLine("Общий размер папки: " + totalSize + " байт");
                    }
                    else
                    {
                        Console.WriteLine("Исходная папка не найдена.");
                        Console.WriteLine("Нажмите Enter чтобы продолжить");
                        Console.ReadLine();
                        Console.Clear();
                        Main();
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                    Console.WriteLine("Нажмите Enter чтобы продолжить");
                    Console.ReadLine();
                    Console.Clear();
                    Main();
                }
                break;
            case 2:
                Console.WriteLine("Введите путь к нужному вам файлу. \n Например: C:\\Users\\Owner\\Desktop\\newFloader.txt");
                string filePath = Console.ReadLine();
                try
                {
                    // Проверка существования исходного файла
                    if (File.Exists(filePath))
                    {
                        DirectoryInfo directoryInfo1 = new DirectoryInfo(filePath);

                // Дата создания директории
                Console.WriteLine("Дата создания: " + directoryInfo1.CreationTime);
                // Дата последнего изменения
                Console.WriteLine("Дата последнего изменения: " + directoryInfo1.LastWriteTime);
                FileInfo fileInfo = new FileInfo(filePath);
                long fileSize = fileInfo.Length;
                Console.WriteLine("Размер файла: " + fileSize + " байт");
                    }
                    else
                    {
                        Console.WriteLine("Исходный файл не найден.");
                        Console.WriteLine("Нажмите Enter чтобы продолжить");
                        Console.ReadLine();
                        Console.Clear();
                        Main();
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                    Console.WriteLine("Нажмите Enter чтобы продолжить");
                    Console.ReadLine();
                    Console.Clear();
                    Main();
                }
                break;
            default:
                break;
        }
        Console.WriteLine("Желаете продолжить?");
        Console.WriteLine("1.Да");
        Console.WriteLine("2.Нет");
        int Vibor1 = Convert.ToInt32(Console.ReadLine());
        switch (Vibor1)
        {
            case 1:
                Console.Clear();
                Main();
                break;
            case 2:
                string filePath = (exePath + "last_directory.txt");
                string filePath1 = Directory.GetCurrentDirectory();
                using (StreamWriter writer = new StreamWriter(filePath, false)) // false означает перезапись
                {
                    writer.WriteLine(filePath1); // Записываем новое содержимое
                }
                break;
            default:
                break;
        }
    }

    public void Create()
    {
        Console.WriteLine("1.Создать папку \n 2.Создать файл");
        int Vibor = Convert.ToInt32(Console.ReadLine());
        switch (Vibor)
        {
            case 1:
                Console.WriteLine("Введите путь к новой папке. \n Например: C:\\Users\\Owner\\Desktop\\newFloader");
                string folderPath = Console.ReadLine();
                try
                {
                    // Проверка существования исходного файла
                    if (Directory.Exists(folderPath))
                    {
                        // Создание папки
                        Directory.CreateDirectory(folderPath);
                        Console.WriteLine("Папка создана: " + folderPath);
                    }
                    else
                    {
                        Console.WriteLine("Исходная папка не найдена.");
                        Console.WriteLine("Нажмите Enter чтобы продолжить");
                        Console.ReadLine();
                        Console.Clear();
                        Main();
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                    Console.WriteLine("Нажмите Enter чтобы продолжить");
                    Console.ReadLine();
                    Console.Clear();
                    Main();
                }
                break;
            case 2:
                Console.WriteLine("Введите путь к новому файлу. \n Например: C:\\Users\\Owner\\Desktop\\newFile.txt");
                string filePath2 = Console.ReadLine();
                try
                {
                    // Проверка существования исходного файла
                    if (File.Exists(filePath2))
                    {
                        Console.WriteLine("Файл с таким именем уже существует");
                        Console.WriteLine("Нажмите Enter чтобы продолжить");
                        Console.ReadLine();
                        Console.Clear();
                        Main();
                    }
                    else
                    {
                        //создание файла
                        File.CreateText(filePath2);
                        Console.WriteLine("Файл создан: " + filePath2);
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                    Console.WriteLine("Нажмите Enter чтобы продолжить");
                    Console.ReadLine();
                    Console.Clear();
                    Main();
                }
                break;
            default:
                break;
        }
        Console.Clear();
        Console.WriteLine("Желаете продолжить?");
        Console.WriteLine("1.Да");
        Console.WriteLine("2.Нет");
        int Vibor1 = Convert.ToInt32(Console.ReadLine());
        switch (Vibor1)
        {
            case 1:
                Console.Clear();
                Main();
                break;
            case 2:
                string filePath = (exePath + "last_directory.txt");
                string filePath1 = Directory.GetCurrentDirectory();
                using (StreamWriter writer = new StreamWriter(filePath, false)) // false означает перезапись
                {
                    writer.WriteLine(filePath1); // Записываем новое содержимое
                }
                break;
            default:
                break;
        }
    }
    public void Copy()
    {
        Console.WriteLine("1.Скопировать папку \n 2.Скопировать файл");
        int Vibor = Convert.ToInt32(Console.ReadLine());
        switch (Vibor)
        {
            case 2:
                Console.WriteLine("Введите путь к объекту который хотите скопировать. \n Например: C:\\Users\\Owner\\Desktop\\file.txt");
                string sourceFilePath = Console.ReadLine();
                Console.WriteLine("Введите путь в который хотите скопировать объект. \n Например: C:\\Users\\Owner\\Desktop\\file2.txt");
                string destinationFilePath = Console.ReadLine();
                try
                {
                    // Проверка существования исходного файла
                    if (File.Exists(sourceFilePath))
                    {
                        if (File.Exists(destinationFilePath))
                        {
                            Console.WriteLine($"Желаете перезаписать файл {destinationFilePath}?");
                            Console.WriteLine("1.Да \n 2.Нет");
                            int filePath3 = Convert.ToInt32(Console.ReadLine());
                            if(filePath3==2)
                            {
                                Console.Clear();
                                Main();
                            }
                        }
                            // Копируем файл
                            File.Copy(sourceFilePath, destinationFilePath, overwrite: true);
                            Console.WriteLine("Файл успешно скопирован: " + destinationFilePath);
                    }
                    else
                    {
                        Console.WriteLine("Файл с таким именем не найден");
                        Console.WriteLine("Нажмите Enter чтобы продолжить");
                        Console.ReadLine();
                        Console.Clear();
                        Main();
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                    Console.WriteLine("Нажмите Enter чтобы продолжить");
                    Console.ReadLine();
                    Console.Clear();
                    Main();
                }
                break;
            case 1:
                Console.WriteLine("Введите путь к объекту который хотите скопировать. \n Например: C:\\Users\\Owner\\Desktop\\floader");
                string sourceDirectory = Console.ReadLine();
                Console.WriteLine("Введите путь в который хотите скопировать объект. \n Например: C:\\Users\\Owner\\Desktop\\floaderNew");
                string destinationDirectory = Console.ReadLine();
                try
                {
                    // Проверка существования исходного файла
                    if (Directory.Exists(sourceDirectory))
                    {
                        if (Directory.Exists(destinationDirectory))
                        {
                            Console.WriteLine($"Желаете перезаписать папку {destinationDirectory}?");
                            Console.WriteLine("1.Да \n 2.Нет");
                            int filePath4 = Convert.ToInt32(Console.ReadLine());
                            if (filePath4 == 2)
                            {
                                Console.Clear();
                                Main();
                            }
                        }
                        CopyDirectory(sourceDirectory, destinationDirectory);
                        Console.WriteLine("Папка успешно скопирована.");
                    }
                    else
                    {
                        Console.WriteLine("Папка с таким именем не найдена");
                        Console.WriteLine("Нажмите Enter чтобы продолжить");
                        Console.ReadLine();
                        Console.Clear();
                        Main();
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                    Console.WriteLine("Нажмите Enter чтобы продолжить");
                    Console.ReadLine();
                    Console.Clear();
                    Main();
                }
                break;
            default:
                break;
        }
        Console.Clear();
        Console.WriteLine("Желаете продолжить?");
        Console.WriteLine("1.Да");
        Console.WriteLine("2.Нет");
        int Vibor1 = Convert.ToInt32(Console.ReadLine());
        switch (Vibor1)
        {
            case 1:
                Console.Clear();
                Main();
                break;
            case 2:
                string filePath = (exePath + "last_directory.txt");
                string filePath1 = Directory.GetCurrentDirectory();
                using (StreamWriter writer = new StreamWriter(filePath, false)) // false означает перезапись
                {
                    writer.WriteLine(filePath1); // Записываем новое содержимое
                }
                break;
            default:
                break;
        }
    }
    static void CopyDirectory(string sourceDir, string destinationDir)
    {
        // Создание каталога назначения, если он не существует
        Directory.CreateDirectory(destinationDir);

        // Копирование файлов
        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(destinationDir, fileName);
            File.Copy(file, destFile, true); // true для перезаписи существующих файлов
        }

        // копирование вложенных каталогов
        foreach (string directory in Directory.GetDirectories(sourceDir))
        {
            string dirName = Path.GetFileName(directory);
            string destDir = Path.Combine(destinationDir, dirName);
            CopyDirectory(directory, destDir);
        }
    }
    public void Delete()
    {
        Console.WriteLine("1.Удалить папку \n 2.Удалить файл");
        int Vibor = Convert.ToInt32(Console.ReadLine());
        switch (Vibor)
        {
            case 2:
                Console.WriteLine("Введите путь к объекту который хотите удалить. \n Например: C:\\Users\\Owner\\Desktop\\file.txt");
                string filePath = Console.ReadLine();
                try
                {
                    // Проверка существования исходного файла
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        Console.WriteLine("Файл успешно удален: " + filePath);
                    }
                    else
                    {
                        Console.WriteLine("Файл с таким именем не найден");
                        Console.WriteLine("Нажмите Enter чтобы продолжить");
                        Console.ReadLine();
                        Console.Clear();
                        Main();
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                    Console.WriteLine("Нажмите Enter чтобы продолжить");
                    Console.ReadLine();
                    Console.Clear();
                    Main();
                }
                break;
            case 1:
                Console.WriteLine("Введите путь к объекту который хотите удалить. \n Например: C:\\Users\\Owner\\Desktop\\floader");
                string directoryPath = Console.ReadLine();
                try
                {
                    // Проверка существования исходного файла
                    if (Directory.Exists(directoryPath))
                    {
                        DeleteDirectory(directoryPath);
                        Console.WriteLine("Папка и её содержимое успешно удалены: " + directoryPath);
                    }
                    else
                    {
                        Console.WriteLine("Папка с таким именем не найдена");
                        Console.WriteLine("Нажмите Enter чтобы продолжить");
                        Console.ReadLine();
                        Console.Clear();
                        Main();
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                    Console.WriteLine("Нажмите Enter чтобы продолжить");
                    Console.ReadLine();
                    Console.Clear();
                    Main();
                }
                break;
            default:
                break;
        }
        Console.Clear();
        Console.WriteLine("Желаете продолжить?");
        Console.WriteLine("1.Да");
        Console.WriteLine("2.Нет");
        int Vibor1 = Convert.ToInt32(Console.ReadLine());
        switch (Vibor1)
        {
            case 1:
                Console.Clear();
                Main();
                break;
            case 2:
                string filePath = (exePath + "last_directory.txt");
                string filePath1 = Directory.GetCurrentDirectory();
                using (StreamWriter writer = new StreamWriter(filePath, false)) // false означает перезапись
                {
                    writer.WriteLine(filePath1); // Записываем новое содержимое
                }
                break;
            default:
                break;
        }
    }

    static void DeleteDirectory(string dirPath)
    {
        // Удаляем все файлы и подкаталоги
        foreach (string file in Directory.GetFiles(dirPath))
        {
            File.Delete(file);
        }

        foreach (string subDir in Directory.GetDirectories(dirPath))
        {
            DeleteDirectory(subDir);
        }

        // Удаляем саму директорию
        Directory.Delete(dirPath);
    }
}