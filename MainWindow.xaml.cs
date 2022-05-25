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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using PR13.Classes;

namespace PR13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //открыть
        private void MiOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if ((bool)openFileDialog.ShowDialog())
            {
                ConnectHelper.fileName = openFileDialog.FileName;
                ConnectHelper.ReadListFromFile(ConnectHelper.fileName);
            }
            else
                return;
            dtgListStudent.ItemsSource = ConnectHelper.students.ToList();
        }
        //сохранить 
        private void MiSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if ((bool)saveFileDialog.ShowDialog())
            {
                string file = saveFileDialog.FileName;
                ConnectHelper.SaveListFromFile(file);
            }
        }
        //выйти
        private void MiExit_Click(object sender, RoutedEventArgs e) =>
           Close();
        //вывести список
        private void MiPrint_Click(object sender, RoutedEventArgs e)
        {
            dtgListStudent.ItemsSource = ConnectHelper.students.ToList();
            dtgListStudent.SelectedIndex = -1;            
        }
        //очистить список
        private void MiClear_Click(object sender, RoutedEventArgs e)
        {
            dtgListStudent.ItemsSource = null;
        }
        //добавить студента
        private void MiAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddStudent windowAdd = new WindowAddStudent();
            windowAdd.ShowDialog();
        }
        //редактировать
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowAddStudent windowAdd = new WindowAddStudent((sender as Button).DataContext as STUDENT);
            windowAdd.ShowDialog();
        }
        //удалить с подтверждением
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show($"Вы точно хотите удалить запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (message == MessageBoxResult.Yes)
            {
                int ind = dtgListStudent.SelectedIndex;
                ConnectHelper.students.RemoveAt(ind);
                dtgListStudent.ItemsSource = ConnectHelper.students.ToList();
                ConnectHelper.SaveListFromFile(ConnectHelper.fileName);
            }
        }
        //сотрировка от а до я
        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            dtgListStudent.ItemsSource = ConnectHelper.students.OrderBy(x => x.Fio).ToList();
        }
        //сотрировка от я до а
        private void RbDoun_Checked(object sender, RoutedEventArgs e)
        {
            dtgListStudent.ItemsSource = ConnectHelper.students.OrderByDescending(x => x.Fio).ToList();
        }
        //Поиск
        private void TxbSerch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dtgListStudent.ItemsSource = ConnectHelper.students.Where(x =>
            x.Fio.ToLower().Contains(TxbSerch.Text.ToLower())).ToList();
        }
        //фильтрация
        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbFiltr.SelectedIndex == 0)
            {
                dtgListStudent.ItemsSource = ConnectHelper.students.Where(x =>
                x.Group == "ИСП.21А").ToList();
                MessageBox.Show("Студенты группы ИСП21.А!",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            if (CmbFiltr.SelectedIndex == 1)
            {
                dtgListStudent.ItemsSource = ConnectHelper.students.Where(x =>
                x.Group == "ТМ.20").ToList();
                MessageBox.Show("Студенты группы ТМ.20!",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                dtgListStudent.ItemsSource = ConnectHelper.students.Where(x =>
                x.Group == "ОПУТ.18").ToList();
                MessageBox.Show("Студенты группы ОПУТ.18!",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }        
        //контекстное меню
        private void IncreaseFont_Click(object sender, RoutedEventArgs e)
        {
            if (TxbSerch.FontSize < 18)
            {
                TxbSerch.FontSize += 2;
            }
        }

        private void DecreaseFont_Click(object sender, RoutedEventArgs e)
        {
            if (TxbSerch.FontSize > 10)
            {
                TxbSerch.FontSize -= 2;
            }
        }
        //кол-во студентов
        private void SrcCounting_Click(object sender, RoutedEventArgs e)
        {
            TxbCount.Text = ConnectHelper.students.Count().ToString();
        }
    }
}
