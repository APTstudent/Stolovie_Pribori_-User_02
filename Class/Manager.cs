using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace Stolovie_Pribori__User_02.Class
{
    internal class Manager
    {

        public static Frame MainFrame;
        public static User currentUser;

        // Метод для генерации капчи на основе вывода рандомного символа из строки.
        public static string GenerateCaptcha()
        {
            Random rnd = new Random();
            string charsList = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890!@&";
            char[] chars = charsList.ToCharArray();

            return $"{chars[rnd.Next(0, 64)]} {chars[rnd.Next(0, 64)]} {chars[rnd.Next(0, 64)]} {chars[rnd.Next(0, 64)]}";
        }
    }
}
