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

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool intFlag = false;
        bool crashFlag = false;
        bool charFlag = false;
        public string GeneratePass()
        {
            int passLength = Convert.ToInt32(CB_PassLenght.SelectedIndex + 4);

            string charArchiv = "qwertzuiopüasdfghjklöäyxcvbnmQWERTZUIOPÜASDFGHJKLÖÄYXCVBNM";
            string integerArchiv = "1234567890";
            string crashArchiv = "qwertQ80W3ERT1Z9zuiopüUIOasPdfghÜfghj4kjlASDnmFGH2JKLÖ75ÄkökäYXC6VxyvcyxvBN0M";

            string passOut = "";
            Random rnd = new Random();

            for (int i = 1; i <= passLength; i++)
            {
                if (crashFlag)
                {
                    int iRnd = rnd.Next(0, crashArchiv.Length - 1);
                    passOut += crashArchiv.Substring(iRnd, 1);
                }
                if (charFlag)
                {
                    int iRnd = rnd.Next(0, charArchiv.Length - 1);
                    passOut += charArchiv.Substring(iRnd, 1);
                }
                if (intFlag)
                {
                    int iRnd = rnd.Next(0, integerArchiv.Length - 1);
                    passOut += integerArchiv.Substring(iRnd, 1);
                }

            }

            return passOut;
        }

        private void CB_PassLenght_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TB_PassOutput.Clear();
            TB_PassOutput.Text += GeneratePass() + "    ";
        }

        private void RB_Integer(object sender, RoutedEventArgs e)
        {
            intFlag = true;
            charFlag = false;
            crashFlag= false;
        }

        private void RB_Character(object sender, RoutedEventArgs e)
        {
            charFlag = true;
            intFlag = false;
            crashFlag= false;
        }

        private void RB_Crash(object sender, RoutedEventArgs e)
        {
            crashFlag = true;
            intFlag= false;
            charFlag= false;
        }
    }
}
