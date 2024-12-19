using prs.appdata;
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

namespace prs.pages
{
    /// <summary>
    /// Логика взаимодействия для sprav.xaml
    /// </summary>
    public partial class sprav : Page
    {
        public sprav()
        {
            InitializeComponent();
            ClientsLV.ItemsSource = Class1.context.spravochnaya.ToList();
        }


        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditS(null));
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditS((sender as Button).DataContext as spravochnaya));
        }
        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delClients = ClientsLV.SelectedItems.Cast<spravochnaya>().ToList();
            foreach (var delClient in delClients)
                if (Class1.context.uchetnaya.Any(x => x.Kod_tovara == delClient.Kod_Tovara))
                {
                    MessageBox.Show("Данные используются в таблице продаж", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить {delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Class1.context.spravochnaya.RemoveRange(delClients);
            try
            {
                Class1.context.SaveChanges();
                ClientsLV.ItemsSource = Class1.context.spravochnaya.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "оШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClientsLV.ItemsSource = Class1.context.spravochnaya.ToList();
        }
    }
}
