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
    /// Логика взаимодействия для pu.xaml
    /// </summary>
    public partial class pu : Page
    {
        public pu()
        {
            InitializeComponent();
            SLV.ItemsSource = Class1.context.uchetnaya.ToList();
        }
        void Update()
        {
            var ac = Class1.context.uchetnaya.ToList();

            if (!string.IsNullOrEmpty(FiOTbx.Text))
            {
                ac = ac.Where(x => x.Data.Contains(FiOTbx.Text)).ToList();
            }
            SLV.ItemsSource = ac;
        }
       
      
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void FiOTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
