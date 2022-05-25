using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PR13.Classes;

namespace PR13
{
    /// <summary>
    /// Логика взаимодействия для WindowAddStudent.xaml
    /// </summary>
    public partial class WindowAddStudent : Window
    {
        int mode;
        public WindowAddStudent()
        {
            InitializeComponent();
            mode = 0;
        }
        public WindowAddStudent(STUDENT student)
        {
            InitializeComponent();
            TxbFio.Text = student.Fio;
            TxbGroup.Text = student.Group;
            TxbMath.Text = student.Math.ToString();
            TxbPhysics.Text = student.Physics.ToString();
            TxbChemistry.Text = student.Chemistry.ToString();
            TxbEnglish.Text = student.English.ToString();
            TxbRussian.Text = student.Russian.ToString();
            mode = 1;
            BtnAddStudent.Content = "Сохранить";
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            //исключения
            try
            {
                if (int.Parse(TxbMath.Text) < 0)
                {
                    MessageBox.Show("Значение не может быть отрицательным", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TxbMath.Clear();
                    TxbMath.Focus();
                    return;
                }
                else if (int.Parse(TxbPhysics.Text) < 0)
                {
                    MessageBox.Show("Значение не может быть отрицательным", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TxbPhysics.Clear();
                    TxbPhysics.Focus();
                    return;
                }
                else if (int.Parse(TxbChemistry.Text) < 0)
                {
                    MessageBox.Show("Значение не может быть отрицательным", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TxbChemistry.Clear();
                    TxbChemistry.Focus();
                    return;
                }
                else if (int.Parse(TxbEnglish.Text) < 0)
                {
                    MessageBox.Show("Значение не может быть отрицательным", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TxbEnglish.Clear();
                    TxbEnglish.Focus();
                    return;
                }
                else if (int.Parse(TxbRussian.Text) < 0)
                {
                    MessageBox.Show("Значение не может быть отрицательным", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TxbRussian.Clear();
                    TxbRussian.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Проверьте входные данные: {ex}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //добавление данных
            if (mode == 0)
            {
                try
                {
                    STUDENT library = new STUDENT()
                    {
                        Fio = TxbFio.Text,
                        Group = TxbGroup.Text,
                        Math = int.Parse(TxbMath.Text),
                        Physics = int.Parse(TxbPhysics.Text),
                        Chemistry = int.Parse(TxbChemistry.Text),
                        English = int.Parse(TxbEnglish.Text),
                        Russian = int.Parse(TxbRussian.Text)
                    };
                    ConnectHelper.students.Add(library);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Проверьте входные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            //редактирование файла
            else
            {
                try
                {
                    for (int i = 0; i < ConnectHelper.students.Count; i++)
                    {
                        if (ConnectHelper.students[i].Fio == TxbFio.Text)
                        {
                            ConnectHelper.students[i].Group = TxbGroup.Text;
                            ConnectHelper.students[i].Math = int.Parse(TxbMath.Text);
                            ConnectHelper.students[i].Physics = int.Parse(TxbPhysics.Text);
                            ConnectHelper.students[i].Chemistry = int.Parse(TxbChemistry.Text);
                            ConnectHelper.students[i].English = int.Parse(TxbEnglish.Text);
                            ConnectHelper.students[i].Russian = int.Parse(TxbRussian.Text);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Проверьте входные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            ConnectHelper.SaveListFromFile(ConnectHelper.fileName);
            this.Close();
        }
    }
}