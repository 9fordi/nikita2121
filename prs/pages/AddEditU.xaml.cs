using prs.appdata;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для AddEditU.xaml
    /// </summary>
    public partial class AddEditU : Page
    {
        uchetnaya tyr;
        bool checknew;
        public AddEditU(uchetnaya s)
        {
            InitializeComponent();
            if (s == null)
            {
                s = new uchetnaya();
                checknew = true;
            }
            else
                checknew = false;
            
            DataContext = tyr = s;
            
        }
        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            if (checknew)
            {
                Class1.context.uchetnaya.Add(tyr);
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
        public static bool CheckAccounting(uchetnaya inf)
        {
            return !string.IsNullOrEmpty(inf.Data) &&
                !string.IsNullOrEmpty(inf.Cena) &&
                inf.Nomer_postuplenya > 1 &&
                inf.Cena == "10000";
        }
        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

     
    }
}
