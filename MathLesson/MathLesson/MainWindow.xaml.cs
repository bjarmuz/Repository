using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace MathLesson
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public int check;
        public int number1;
        public int number2;
        public int number3;
        public int Lev;
        public int SubLev;
        public static int correct;
        public static int wrong;
        public  string labelentry;
        public int losowanie;
        public string message;
        public static List<string> ListaOK = new List<string>();
        public static List<string> ListaNO = new List<string>();
        
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            RandomNum(out losowanie);
            if (losowanie == 0)
            {
                Numbers();
            }
            else
            {
                Numbers2();
            }
            
            input.Focus();
        }

        private void Numbers()
        {
            Random GetRandom = new Random();
            number1 = GetRandom.Next(1+Lev, 11+Lev);
            number2 = GetRandom.Next(1+Lev, 11+Lev);
            labelentry = number1 + " + " + number2 + " =";
            rownanie.Content = labelentry;
            check = number1 + number2;
            StartButton.IsEnabled = false;
           
        }
        private void Numbers2()
        {
            Random GetRandom = new Random();
            number1 = GetRandom.Next(1+Lev, 11+Lev);
            number2 = GetRandom.Next(1+Lev, number1);
            labelentry = number1 + " - " + number2 + " =";
            rownanie.Content = labelentry;
            check = number1 - number2;
            StartButton.IsEnabled = false;
            
        }
        private void Numbers3()
        {
            Random GetRandom = new Random();
            number1 = GetRandom.Next(0 + Lev, 6 + Lev);
            number2 = GetRandom.Next(0 + Lev, 6 + Lev);
            number3 = GetRandom.Next(0 + Lev, 6 + Lev);
            labelentry = number1 + " + " + number2 + " + " + number3 + " =";
            rownanie.Content = labelentry;
            check = number1 + number2 + number3;
            StartButton.IsEnabled = false;
            
        }

        private int RandomNum(out int a)
        {
            Random Rand = new Random();
            return a = Rand.Next(0, 2);
        }
        private int RandomHigh(out int b)
        {
            Random Rand = new Random();
            return b = Rand.Next(0, 3);
        }
        private void Sendemail()
        {
            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("everydaydevelop@gmail.com", "catalanian09");
            objeto_mail.From = new MailAddress("everydaydevelop@gmail.com");
            objeto_mail.To.Add(new MailAddress("maciej.stopienski@gmail.com"));
            objeto_mail.Subject = "Math Lesson Kuba Results";
            objeto_mail.Body = message;
            client.Send(objeto_mail);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string zlylistek = string.Join("\r", ListaNO.ToArray());
            string dobrylistek = string.Join("\r", ListaOK.ToArray());
            message = "Wyniki z dnia " + DateTime.Now.ToString() + "\rPoprawne: " + correct + "\r" + dobrylistek +
                "\rNiepoprawne: " + wrong +"\r"+ zlylistek;
            Sendemail();
            this.Close();
        }
        
        private void MW_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Okno.DragMove();     }

        private void TextBox(object sender, TextChangedEventArgs e)
        {

        }

        private void input_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                if (input.Text != "")

                {
                    if (Convert.ToInt32(input.Text) == check)
                    {
                        string dobrze = labelentry + input.Text;
                        ListaOK.Add(dobrze);
                        correct += 1;
                        wynik.Content = "OK!!!";
                        countgood.Content = correct;
                        SubLev++;
                    }
                    else
                    {
                        string blad = labelentry + input.Text;
                        ListaNO.Add(blad);
                        wrong += 1;
                        wynik.Content = "ŹLE";
                        countbad.Content = wrong;
                        if (SubLev > 0) { SubLev--; } else { };
                    }
                }
                else
                {
                    input.Focus();
                }
                if (SubLev < 5) { Lev = 0; }
                else if (SubLev >= 5 && SubLev < 10) { Lev = 1; }
                else if (SubLev >= 10 && SubLev < 15) { Lev = 2; }
                else if (SubLev >= 15 && SubLev < 20) { Lev = 3; }
                else if (SubLev >= 20 && SubLev < 25) { Lev = 4; }
                else { Lev = 5; }
                level.Content = "Level " + Lev;
                input.Text = "";
                if (Lev >= 3) { RandomHigh(out losowanie); } else { RandomNum(out losowanie); }

                if (losowanie == 0) { Numbers(); }
                else if (losowanie == 2) { Numbers3(); }
                else { Numbers2(); }
                input.Focus();
            }
        }
    }
}
