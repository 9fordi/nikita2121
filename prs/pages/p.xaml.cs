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
    /// Логика взаимодействия для p.xaml
    /// </summary>
    public partial class p : Page
    {
        public p()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new pu());
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new ps());
        }
        private void RefBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
