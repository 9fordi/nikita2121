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
    /// Логика взаимодействия для fs.xaml
    /// </summary>
    public partial class fs : Page
    {
        private ObservableCollection<spravochnaya> spr;
        public fs()
        {
            InitializeComponent();
            spr = new ObservableCollection<spravochnaya>(Class1.context.spravochnaya.ToList());
            SLV.ItemsSource = spr;
            var fioList = Class1.context.spravochnaya.OrderBy(x => x.Edinica_izmereniya).ToList();
            fioList.Insert(0, new spravochnaya { Edinica_izmereniya = "По умолчанию" });
            FiltTbx.ItemsSource = fioList;
            FiltTbx.DisplayMemberPath = "Edinica_izmereniya";
            FiltTbx.SelectedValuePath = "Edinica_izmereniya";
            FiltTbx.SelectedIndex = 0;
            Update();
        }
        void Update()
        {
            var selectedFIO = (FiltTbx.SelectedItem as spravochnaya).Edinica_izmereniya;
            SLV.ItemsSource = new ObservableCollection<spravochnaya>(spr.Where(x =>
                 string.IsNullOrEmpty(selectedFIO) || x.Edinica_izmereniya.ToLower().Contains(selectedFIO.ToLower())));
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
            SLV.ItemsSource = Class1.context.spravochnaya.ToList();
        }
    }
}
