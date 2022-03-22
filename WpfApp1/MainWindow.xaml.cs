using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
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


        String MakePhrases(double Money)
        {
            string Phrases = "";
            String Sub_Phrases = "";

            int cent = (int)(Money - Math.Truncate(Money));

            int IntMoney = (int)(Money - cent);



            switch (IntMoney)
            {
                case 0:
                    Phrases = "Zero";
                    break;
                case 1:
                    Phrases = "One";
                    break;
                case 2:
                    Phrases = "Two";
                    break;
                case 3:
                    Phrases = "Three";
                    break;
                case 4:
                    Phrases = "Four";
                    break;
                case 5:
                    Phrases = "Five";
                    break;
                case 6:
                    Phrases = "Six";
                    break;
                case 7:
                    Phrases = "Seven";
                    break;
                case 8:
                    Phrases = "Eight";
                    break;
                case 9:
                    Phrases = "Nine";
                    break;
                case 10:
                    Phrases = "Ten";
                    break;
                case 11:
                    Phrases = "Eleven";
                    break;
                case 12:
                    Phrases = "Twelve";
                    break;
                case 13:
                    Phrases = "thirteen";
                    break;
                case int n when (n > 13 && n < 20):
                    Sub_Phrases = MakePhrases(n % 10);
                    Phrases = Sub_Phrases + "teen";
                    break;
                case int n when (n > 20 && n <= 99 && n % 10 != 0):
                    Sub_Phrases = MakePhrases(n % 10);
                    Phrases = MakePhrases(n / 10 * 10) + " " + Sub_Phrases.ToLower() as String;
                    // 40 плохо работает
                    break;
                case 20:
                    Phrases = "twenty";
                    break;
                case 30:
                    Phrases = "thirty";
                    break;
                case 40:
                    Phrases = "Forty";
                    break;
                case 50:
                    Phrases = "fifty";
                    break;
                case 60:
                    Phrases = "sixty";
                    break;
                case 70:
                    Phrases = "seventy";
                    break;
                case 80:
                    Phrases = "eighty";
                    break;
                case int n when (n / 10 > 6 && n / 10 < 10 && n / 10 != 8):
                    Sub_Phrases = MakePhrases(n / 10);
                    Phrases = Sub_Phrases + "ty";
                    break;

                case int n when (n / 100 >= 1 && n / 100 <= 9 && n % 100 == 0): // 100,200 - 900
                    Sub_Phrases = MakePhrases(n / 100);
                    Phrases = Sub_Phrases + " hundred";
                    break;

                case int n when (n / 100 >= 1 && n / 100 <= 9 && n % 100 != 0): // 100 etc
                    Phrases = MakePhrases((n / 100) % 10 * 100);
                    Sub_Phrases = MakePhrases(Money % 100);
                    Phrases += " and " + Sub_Phrases;
                    break;

                case int n when (n / 1000 > 0 && n % 1000 == 0 && n / 1000 < 999): //1k
                    Sub_Phrases = MakePhrases(n / 1000);
                    Phrases = Sub_Phrases + " thousand";
                    break;
                case int n when (n / 1000 > 0 && n % 1000 != 0): // 1k etc
                    Sub_Phrases = MakePhrases(n % 1000);
                    Phrases = MakePhrases(n / 1000 * 1000);
                    Phrases += ", " + Sub_Phrases.ToLower();
                    break;
                case int n when (n / 1000000 > 0 && n % 1000000 == 0 && n / 1000000 < 999): //1kk,2kk,3kk....
                    Sub_Phrases = MakePhrases(n / 1000000);
                    Phrases = Sub_Phrases + " million";
                    break;
                case int n when (n / 1000000 > 0 && n % 1000000 != 0 && n / 1000000 < 999): //1kk etc
                    Sub_Phrases = MakePhrases(n % 1000000);
                    Phrases = MakePhrases(n / 1000000 * 1000000);
                    Phrases += ", " + Sub_Phrases.ToLower();
                    break;
                case int n when (n / 1000000000 > 0 && n % 1000000000 == 0): //1kkk,2kkk
                    Sub_Phrases = MakePhrases(n / 1000000000);
                    Phrases = Sub_Phrases + " billion";
                    break;
                case int n when (n / 1000000000 > 0 && n % 1000000000 != 0): // 1kkk etc
                    Sub_Phrases = MakePhrases(n % 1000000000);
                    Phrases = MakePhrases(n / 1000000000 * 1000000000);
                    Phrases += ", " + Sub_Phrases.ToLower();
                    break;
                default:
                    Phrases = "idk";
                    break;
            }
            return Phrases;
        }

        private void OnChangeText(object sender, TextChangedEventArgs e)
        {
            double money;
            double cent;
            try
            {
                money = Convert.ToDouble(TextEdit.Text);
                cent = (money - Math.Truncate(money));
                int IntMoney = (int)(money - cent);
                String MainStr = MakePhrases(money);
                String Substr = MakePhrases((int)Math.Round(cent * 100));
                TextBox.Text = MainStr + " " + (money == 1 ? "dollar" : "dollars") + (cent == 0 ? "" : " and " + Substr.ToLower() + " " + ((int)Math.Round(cent * 100) == 1 ? "cent" : "cents"));
            }
            catch (Exception)
            {
                if (TextEdit.Text != "")
                {
                    TextBox.Text = "Convert error";
                }
                else
                {
                    TextBox.Text = "";
                }
            }
        }
    }
}
