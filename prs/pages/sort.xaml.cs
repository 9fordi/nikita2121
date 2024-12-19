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
    /// Логика взаимодействия для sort.xaml
    /// </summary>
    public partial class sort : Page
    {
        public sort()
        {
            InitializeComponent();
            Update();
            FioFlit.ItemsSource = new[] { "По умолчанию", "По возврастанию", "По убыванию" };
            FioFlit.SelectedIndex = 0;
        }
        void Update()
        {
            var ac = Class1.context.uchetnaya.ToList();
            switch (FioFlit.SelectedIndex)
            {
                case 1:
                    ac = ac.OrderBy(x => x.Cena).ToList();
                    break;
                case 2:
                    ac = ac.OrderByDescending(x => x.Cena).ToList();
                    break;
            }

            SLV.ItemsSource = ac;
        }

        private void FioFlit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void SLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}
