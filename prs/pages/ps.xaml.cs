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
    /// Логика взаимодействия для ps.xaml
    /// </summary>
    public partial class ps : Page
    {
        public ps()
        {
            InitializeComponent();
            var cmFil = Class1.context.spravochnaya.OrderBy(x => x.Edinica_izmereniya).ToList();
            Update();
        }
        void Update()
        {
            var i = Class1.context.spravochnaya.ToList();
            if (!string.IsNullOrEmpty(MonTbx.Text))
            {
                i = i.Where(x => x.Edinica_izmereniya.ToString().ToLower().Contains(MonTbx.Text.ToLower())).ToList();
            }
            SLV.ItemsSource = i;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
        private void MonTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        private void NameSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void FiltTbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}
