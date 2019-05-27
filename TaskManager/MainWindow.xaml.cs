using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Process> source = new ObservableCollection<Process>();

        public MainWindow()
        {
            InitializeComponent();
            var processes = Process.GetProcesses();
            foreach(var proc in processes)
            {
                source.Add(proc);
            }

            dataGrid.ItemsSource = source;
            
        }

        private void KillProcess(object sender, RoutedEventArgs e)
        {
            try
            {
                var selected = dataGrid.SelectedItem as Process;
                source.Remove(selected);
                selected.Kill();
            }

            catch(Exception ex)
            {
                MessageBox.Show("Отказано в доступе!", "Ошибка!");
            }
            
        }
        
    }
}
