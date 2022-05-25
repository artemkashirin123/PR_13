using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace PR13.Classes
{
    class ConnectHelper
    {   //список
        public static List<STUDENT> students = new List<STUDENT>();

        public static string fileName;

        //Чтение из файла
        public static void ReadListFromFile(string filename)
        {
            students.Clear();
            try
            {
                StreamReader sr = new StreamReader(filename, Encoding.UTF8);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] items = line.Split(';');
                    STUDENT studenty = new STUDENT
                    {
                        Fio = items[0].Trim(),
                        Group = items[1].Trim(),
                        Math = int.Parse(items[2].Trim()),
                        Physics = int.Parse(items[3].Trim()),
                        Chemistry = int.Parse(items[4].Trim()),
                        English = int.Parse(items[5].Trim()),
                        Russian = int.Parse(items[6].Trim())
                    };
                    students.Add(studenty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неверный формат файла!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        //Запись в файл
        public static void SaveListFromFile(string filename)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8);
                foreach (STUDENT st in students)
                {
                    sw.WriteLine($"{st.Fio}; {st.Group}; {st.Math}; {st.Physics}; {st.Chemistry}; {st.English}; {st.Russian}");
                }
                sw.Close();
            }
            catch
            {
                MessageBox.Show($"Файл не выбран!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
