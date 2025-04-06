using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Final_app
{
    internal class SaveSystem
    {
        private static string directoryName = "SaveFiles";
        public string currentlySelectedList { get; private set; }
        private string path;

        public Action onRequireListSelect;
        public Action onWordAddedToList;
        private VariableWaiter waiter = new VariableWaiter();

        public SaveSystem(string programLocation)
        {
            this.path = programLocation + $@"{directoryName}\";
            //onRequireListSelect += async () => await SelectList();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Новая директория создана");
            }
            if (!Directory.Exists(path + @"Cards"))
            {
                // Создаем новую папку
                Directory.CreateDirectory(path + @"\Cards");
            }
        }
        public async Task SelectList()
        {
            onRequireListSelect?.Invoke();
            string[] dictionaryNames = GetAllDictionarys();

            //string listName = await Form1.instance.WaitForEventAsync().ConfigureAwait(false);
            await waiter.WaitForConditionAsync().ConfigureAwait(false);

            int id = dictionaryNames.ToList().FindIndex(x => x == currentlySelectedList);
            //TODO: создай выбор листа
            Console.WriteLine("List selected:"+id);
            currentlySelectedList = dictionaryNames[id];
        }
        public void SetListSelection(string listName)
        {
            currentlySelectedList = listName;
            waiter.SetCondition();
        }

        public void CreateNewList(string fileName)
        {
            if (!GetAllDictionarys().Contains(fileName))
            {
                using (StreamWriter sw = new StreamWriter(path + $@"{fileName}.txt"))
                {
                    Console.WriteLine("Новый лист создан: " + path + $@"{fileName}.txt");
                }
            }
            else
            {
                Console.WriteLine("Лист уже существует: " + path + $@"{fileName}.txt");
            }
        }
        public void CreateNewList(string fileName, string directory)
        {
            if (!GetAllDictionarys().Contains(fileName))
            {
                using (StreamWriter sw = new StreamWriter(path + directory + $@"{fileName}.txt"))
                {
                    Console.WriteLine("Новый лист создан: " + path + directory + $@"{fileName}.txt");
                }
            }
            else
            {
                Console.WriteLine("Лист уже существует: " + path + directory + $@"{fileName}.txt");
            }

        }
        public void WriteIntoFile(string fileName, string data)
        {
            using (StreamWriter sw = new StreamWriter(path + $@"{fileName}", true))
            {
                sw.WriteLine(data);
                onWordAddedToList?.Invoke();
            }
        }
        public async Task WriteIntoFile(string data)
        {
            if (currentlySelectedList == null)
            {
                await SelectList();
            }
            using (StreamWriter sw = new StreamWriter(path + $@"{currentlySelectedList}", true))
            {
                sw.WriteLine(data);
                onWordAddedToList?.Invoke();
            }
        }
        public async Task WriteIntoFileUnique(string data)
        {
            if (currentlySelectedList == null) 
            {
                await SelectList();
            }

            WriteIntoFileUnique(data,currentlySelectedList);
        }
        public void WriteIntoFileUnique(string data, string listName)
        {
            List<string> items = ReadFromFile(listName);

            using (StreamWriter sw = new StreamWriter(path + $@"{listName}", true))
            {
                if (items.Contains(data.Trim()))
                {
                    Console.WriteLine("Word already existing");
                }
                else
                {

                    sw.WriteLine(data);
                    onWordAddedToList?.Invoke();
                }
            }
        }
        public List<string> ReadFromFile(string fileName)
        {
            List<string> lines = new List<string>();
            try
            {
                if (File.Exists(path + $@"{fileName}"))
                {
                    lines = new List<string>(File.ReadAllLines(path + $@"{fileName}"));
                    foreach (var item in lines)
                    {
                        Console.Write(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Empty: " + ex);
                lines = new List<string>();
            }

            Console.WriteLine(currentlySelectedList);
            return lines;
        }

        public string[] GetAllDictionarys()
        {
            string[] txtFiles = Directory.GetFiles(path, "*.txt");

            for (int i = 0; i < txtFiles.Length; i++)
            {
                txtFiles[i] = txtFiles[i].Remove(0, path.Length);
            }

            return txtFiles;
        }
        public string GetPath()
        {
            return path  + @"Cards";
        }
    }
}
