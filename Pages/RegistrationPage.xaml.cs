using Stolovie_Pribori__User_02.Class;
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

namespace Stolovie_Pribori__User_02.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private User _currentUser = new User();
        public RegistrationPage()
        {
            InitializeComponent();
            InitializeComponent();
            CBUserRole.ItemsSource = DataBaseEntities.GetContext().Role.ToList();
            DataContext = _currentUser;
        }


        private void btnReg_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentUser.UserSurname))
                errors.AppendLine("Укажите фамлиию!");
            if (string.IsNullOrWhiteSpace(_currentUser.UserName))
                errors.AppendLine("Укажите Имя!");
            if (string.IsNullOrWhiteSpace(_currentUser.UserPatronymic))
                errors.AppendLine("Укажите Отчество!");
            if (string.IsNullOrWhiteSpace(_currentUser.UserPatronymic))
                errors.AppendLine("Укажите логин!");
            if (string.IsNullOrWhiteSpace(_currentUser.UserPassword))
                errors.AppendLine("Укажите пароль!");
            if (CBUserRole.SelectedItem == null)
                errors.AppendLine("Выберите роль!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            //User _user = DataBaseEntities.GetContext().User.FirstOrDefault(x => x.UserLogin == _currentUser.Login.Text);

            //if (_user.UserLogin.Contains(_currentUser.UserLogin))
            //{
            //    MessageBox.Show("Пользователь с таким логином уже зарегистрирован!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            //    return;
            //}

            if (_currentUser.UserID == 0)
            {
                DataBaseEntities.GetContext().User.Add(_currentUser);
            }

            try
            {
                DataBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}

