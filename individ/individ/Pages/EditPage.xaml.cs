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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private MainInfo selecteditems;

        public EditPage()
        {
            InitializeComponent();
        }

        public EditPage (MainInfo selecteditems)
        {
            InitializeComponent();
            this.selecteditems = selecteditems;
            tb1.Text = Convert.ToString(selecteditems.Employee.NumberEmployee);
            tb2.Text = selecteditems.Employee.FullName;
            tb3.Text = selecteditems.Employee.Position;
            tb4.Text = Convert.ToString(selecteditems.Work.NumberWork);
            tb5.Text = selecteditems.Work.NameWork;
            tb6.Text = Convert.ToString(selecteditems.WorkInfo.Laboriousness);
            tb7.SelectedDate = (DateTime) selecteditems.WorkInfo.DateOfComplite;
            tb8.SelectedDate = selecteditems.WorkInfo.PlannedDateFoComplite;
            tb9.Text = Convert.ToString(selecteditems.WorkInfo.Readiness);
        }

        private void ButtonGoBackEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditBut_Click(object sender, RoutedEventArgs e)
        {
            MainInfo Save = dbContext.db.MainInfo.FirstOrDefault(Item => Item.ID == selecteditems.ID);
            Save.Employee.NumberEmployee = Convert.ToInt32(tb1.Text);
            Save.Employee.FullName = (tb2.Text);
            Save.Employee.Position =(tb3.Text);
            Save.Work.NumberWork = Convert.ToInt32(tb4.Text);
            Save.Work.NameWork = tb5.Text;
            Save.WorkInfo.Laboriousness = Convert.ToInt32(tb6.Text);
            Save.WorkInfo.DateOfComplite = Convert.ToDateTime(tb7.Text);
            Save.WorkInfo.PlannedDateFoComplite = Convert.ToDateTime(tb8.Text);
            Save.WorkInfo.Readiness = Convert.ToInt32(tb9.Text);
            dbContext.db.SaveChanges();
            MessageBox.Show("Вы изменили данные!", "Изменение", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
        }

        private void ClearBut_Click(object sender, RoutedEventArgs e)
        {
            tb1.Text = " ";
            tb2.Text = " ";
            tb3.Text = " ";
            tb4.Text = " ";
            tb5.Text = " ";
            tb6.Text = " ";
            tb7.Text = " ";
            tb8.Text = " ";
            tb9.Text = " ";
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
