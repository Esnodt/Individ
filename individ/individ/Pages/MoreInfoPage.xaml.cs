using individ.Context;
using individ.sql;
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

namespace individ.Pages
{
    /// <summary>
    /// Логика взаимодействия для MoreInfoPage.xaml
    /// </summary>
    public partial class MoreInfoPage : Page
    {
        private MainInfo selecteditem;
        public MoreInfoPage(MainInfo selecteditem)
        {
            InitializeComponent();
            this.selecteditem = selecteditem;
        }
        public MoreInfoPage()
        {
            InitializeComponent();
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           DataGridMoreInfo.ItemsSource = dbContext.db.MainInfo.Where
          (item => item.IDReadiness == selecteditem.WorkInfo.ID ).ToList();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}


