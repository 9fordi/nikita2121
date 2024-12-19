using prs.appdata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для fu.xaml
    /// </summary>
    public partial class fu : Page
    {
        private ObservableCollection<uchetnaya> uch;
        public fu()
        {
            InitializeComponent();
            uch = new ObservableCollection<uchetnaya>(Class1.context.uchetnaya.ToList());
            SLV.ItemsSource = uch;
            var fioList = Class1.context.uchetnaya.OrderBy(x => x.Data).ToList();
            fioList.Insert(0, new uchetnaya { Data = "По умолчанию" });
            FiltTbx.ItemsSource = fioList;
            FiltTbx.DisplayMemberPath = "Data";
            FiltTbx.SelectedValuePath = "Data";
            FiltTbx.SelectedIndex = 0;
            Update();
        }
        void Update()
        {
            var selectedFIO = (FiltTbx.SelectedItem as uchetnaya).Data;
            SLV.ItemsSource = new ObservableCollection<uchetnaya>(uch.Where(x =>
                 string.IsNullOrEmpty(selectedFIO) || x.Data.ToLower().Contains(selectedFIO.ToLower())));
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void FiltTbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SLV.ItemsSource = Class1.context.uchetnaya.ToList();
        }
    }
}
