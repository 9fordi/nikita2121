using prs.appdata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace prs.pages
{
    /// <summary>
    /// Логика взаимодействия для uchet.xaml
    /// </summary>
    public partial class uchet : Page
    {
        public uchet()
        {
            InitializeComponent();
            ClientsLV.ItemsSource = Class1.context.uchetnaya.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditU(null));
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditU((sender as Button).DataContext as uchetnaya));
        }
        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delClients = ClientsLV.SelectedItems.Cast<uchetnaya>().ToList();
            if (MessageBox.Show($"Удалить {delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Class1.context.uchetnaya.RemoveRange(delClients);
            try
            {
                Class1.context.SaveChanges();
                ClientsLV.ItemsSource = Class1.context.uchetnaya.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClientsLV.ItemsSource = Class1.context.uchetnaya.ToList();
        }
    }
}
