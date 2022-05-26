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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        int numOfTires;
        public AuthPage()
        {
            InitializeComponent();
        }
        private async void btnSingIn_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == String.Empty || txtPassword.Password == String.Empty)
            {
                MessageBox.Show("Поля ввода не должны быть пустыми!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            User _currentUser = DataBaseEntities.GetContext().User.FirstOrDefault(x => x.UserLogin == txtLogin.Text && x.UserPassword == txtPassword.Password);
            Manager.currentUser = _currentUser;

            try
            {
                if (Manager.currentUser == null)
                {
                    MessageBox.Show("Пользователь не найден!", "Ошибка пользователя!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    numOfTires++;

                    if (numOfTires >= 2)
                    {
                        SPCaptcha.Visibility = Visibility.Visible;

                        labelCaptcha.Content = Manager.GenerateCaptcha();

                        // Проверка ввода капчи
                        if (!(labelCaptcha.Content.ToString().Replace(" ", "") == txtCaptcha.Text))
                        {
                            MessageBox.Show("Код капчи не прошёл проверку!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }

                        if (numOfTires >= 3)
                        {
                            MessageBox.Show("Слишком много безуспешных попыток входа. Пожалуйста, подождите и повторите попытку позже", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            btnGuest.Style = FindResource("btnOff") as Style;
                            btnSingIn.Style = FindResource("btnOff") as Style;
                            btnSingUp.Style = FindResource("btnOff") as Style;

                            await Task.Delay(10000);
                            btnGuest.Style = FindResource("btnOn") as Style;
                            btnSingIn.Style = FindResource("btnOn") as Style;
                            btnSingUp.Style = FindResource("btnOn") as Style;
                        }
                    }
                    return;
                }

                switch (_currentUser.UserRole)
                {
                    case 1:
                        MessageBox.Show($"Здравствуйте, Клиент! {_currentUser.UserSurname + " " + _currentUser.UserName + " " + _currentUser.UserPatronymic}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case 2:
                        MessageBox.Show($"Здравствуйте, Менеджер! {_currentUser.UserSurname + " " + _currentUser.UserName + " " + _currentUser.UserPatronymic}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case 3:
                        MessageBox.Show($"Здравствуйте, Администратор {_currentUser.UserSurname + " " + _currentUser.UserName + " " + _currentUser.UserPatronymic}!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }
                Manager.MainFrame.Navigate(new ProductsPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnSingUp_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegistrationPage());
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ProductsPage());
        }
    }
}
