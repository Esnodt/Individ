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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage());
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainInfo EditWork = (MainInfo)DataGridTablica.SelectedItem;
                if (EditWork != null)
                {
                    NavigationService.Navigate(new EditPage(EditWork));
                }

                else
                {
                    throw new Exception("Вы не выбрали не одного элменента!");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);


            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
           
                try
                {
                    MainInfo deleteWork = (MainInfo)DataGridTablica.SelectedItem;
                    if (MessageBox.Show(messageBoxText: "Вы действительно хотите удалить выбранную строку?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (deleteWork != null)
                        {
                            dbContext.db.MainInfo.Remove(deleteWork);
                            dbContext.db.SaveChanges();
                            Page_Loaded(sender: null, e: null);
                            MessageBox.Show("Вы удалили строку", "Оповещание", MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                        else
                            throw new Exception(message: "Вы не выбрали строку которые хотите удалить!");
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Work deleteAllWork = (Work)DataGridTablica.SelectedItem;
                if (MessageBox.Show("Вы точно хотите удалить все строки в таблице? Назад вернуть их будет не возможно!", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (MessageBox.Show("ВЫ ТОЧНО УВЕРЕНЫ???", "Последние предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (deleteAllWork != null)
                        {
                            dbContext.db.Work.RemoveRange(dbContext.db.Work);
                            dbContext.db.SaveChanges();
                            Page_Loaded(sender: null, e: null);
                            MessageBox.Show("Вы удалили все строки", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                            throw new Exception(message: "Вам надо выбрать минимум одну строку!");
                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void textboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridTablica.ItemsSource = dbContext.db.MainInfo.Where(item => item.Work.NameWork.Contains(textboxSearch.Text)
           || item.WorkInfo.Readiness.ToString().Contains(textboxSearch.Text)
           || item.Employee.FullName.ToString().Contains(textboxSearch.Text)
           || item.WorkInfo.PlannedDateFoComplite.ToString().Contains(textboxSearch.Text)
           || item.WorkInfo.DateOfComplite.ToString().Contains(textboxSearch.Text)).ToList();
        }

        private void ButtonMoreInfo_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    MainInfo EditWork = (MainInfo)DataGridTablica.SelectedItem;
                    if (EditWork != null)
                    {
                        NavigationService.Navigate(new MoreInfoPage(EditWork));
                    }

                    else
                    {
                        throw new Exception("Вы не выбрали не одного элменента!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);

                }
            
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridTablica.ItemsSource = dbContext.db.MainInfo.ToList();
        }

        private void chk1_Checked(object sender, RoutedEventArgs e)
        {
            if(chk1.IsChecked == true)
            {

                DataGridTablica.ItemsSource = dbContext.db.MainInfo.Where(item => item.WorkInfo.Readiness < 50).OrderByDescending(item => item.WorkInfo.DateOfComplite.HasValue).ToList();
            }
        }

        private void chk1_Unchecked(object sender, RoutedEventArgs e)
        {
            DataGridTablica.ItemsSource = dbContext.db.MainInfo.ToList();
        }

        private void chk2_Checked(object sender, RoutedEventArgs e)
        {
            if (chk2.IsChecked == true)
            {
                DataGridTablica.ItemsSource = dbContext.db.MainInfo.Where(item => item.WorkInfo.PlannedDateFoComplite > item.WorkInfo.DateOfComplite).ToList();
            }

        }

        private void chk2_Unchecked(object sender, RoutedEventArgs e)
        {
            DataGridTablica.ItemsSource = dbContext.db.MainInfo.ToList();
        }

        private void DataGridTablica_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }


    }
}
