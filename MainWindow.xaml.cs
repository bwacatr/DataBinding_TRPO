using Microsoft.Win32;

using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBinding_TRPO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Wage CurrentWage = new Wage();
        WageList wageList = new WageList();
        public MainWindow()
        {
            InitializeComponent();
            

            OpenFileDialog openFileDialog = new OpenFileDialog();

            
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                wageList.Load(openFileDialog.FileName);
                CurrentWage = wageList.wages[0];

                

            }
            DataContext = CurrentWage;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == true)
            {
                wageList.Save(saveFileDialog1.FileName);
            }
        }

        private void newEntryBtn_Click(object sender, RoutedEventArgs e)
        {
            

            wageList.wages.Add((Wage)CurrentWage.Clone());
            CurrentWage.Clear();
            
            
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(idBox.Text, out int result))
            {
                Wage searchWage = wageList.Search(result);

                if (searchWage != null) 
                {
                    CurrentWage.Bonus = searchWage.Bonus;
                    CurrentWage.Salary = searchWage.Salary;
                    CurrentWage.Name = searchWage.Name;
                    CurrentWage.Id = searchWage.Id;
                    CurrentWage.Payment = searchWage.Payment;
                    CurrentWage.Deduction = searchWage.Deduction;


                }

            }
            else
            {
                MessageBox.Show("Введен посторонний символ", "Ошибка",MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }
    }
}