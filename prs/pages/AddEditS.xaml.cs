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
    /// Логика взаимодействия для AddEditS.xaml
    /// </summary>
    public partial class AddEditS : Page
    {
        spravochnaya sprav;
        bool checkNew;
        public AddEditS(spravochnaya c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new spravochnaya();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = sprav = c;
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Class1.context.spravochnaya.Add(sprav);
            }
            try
            {
                Class1.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.MainFrame.GoBack();

        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
