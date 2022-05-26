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

namespace Stolovie_Pribori__User_02
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            Manager.MainFrame.Navigate(new Views.Pages.AuthPage());
        }

        private void MainFrame_ContentRendered(object sender, System.EventArgs e)
        {
            if (Manager.currentUser == null)
            {
                return;
            }
            else
            {
                txtUserFullName.Text = Manager.currentUser.UserSurname + " " + Manager.currentUser.UserName + " " + Manager.currentUser.UserPatronymic;
            }
        }
    }
}
