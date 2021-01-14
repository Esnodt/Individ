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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void ButtonGoBackEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
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

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            MainInfo newMainInfo = new MainInfo();
            Employee newEmployee = new Employee();
            Work newWork = new Work();
            WorkInfo newWorkInfo = new WorkInfo();

            newEmployee.NumberEmployee = Convert.ToInt32(tb1.Text);
            newEmployee.FullName = tb2.Text;
            newEmployee.Position = tb3.Text;
            newWork.NumberWork = Convert.ToInt32(tb4.Text);
            newWork.NameWork = (tb5.Text);
            newWorkInfo.Laboriousness = Convert.ToInt32(tb6.Text);
            newWorkInfo.DateOfComplite = Convert.ToDateTime(tb7.SelectedDate);
            newWorkInfo.PlannedDateFoComplite = Convert.ToDateTime(tb8.SelectedDate);
            newWorkInfo.Readiness = Convert.ToInt32(tb9.Text);

            dbContext.db.Employee.Add(newEmployee);
            dbContext.db.Work.Add(newWork);
            dbContext.db.WorkInfo.Add(newWorkInfo);

            newMainInfo.IDNameWork = newWork.ID;
            newMainInfo.IDFullName = newWork.ID;
            newMainInfo.IDReadiness = newWork.ID;

            dbContext.db.MainInfo.Add(newMainInfo);
            dbContext.db.SaveChanges();

            MessageBox.Show("Вы добавили новые данные!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
