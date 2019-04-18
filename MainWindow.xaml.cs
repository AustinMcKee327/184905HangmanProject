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

namespace _184905HangmanProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] easyanswer = new string[10];
        string[] mediumanswer = new string[10];
        string[] hardanswer = new string[10];
        int counter = 0;
        string correctanswer;
        Random random = new Random();
        string discoveredanswer;
        bool foundletter = false;
        int fails;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            int randomnumber = random.Next(0, 10);
            

            counter = 0;
            OutputWords.Text = "";
            if ((bool)EasyMode.IsChecked)
            {
                
                System.IO.StreamReader easyread = new System.IO.StreamReader("Easy.txt");             
                while (!easyread.EndOfStream)
                {
                    if (counter == randomnumber)
                    {
                        easyanswer[randomnumber] = easyread.ReadLine();
                       
                        counter++;
                    }
                    else
                    {
                        easyread.ReadLine();
                        counter++;
                    }

                    correctanswer = easyanswer[randomnumber]; 
                }
              easyread.Close();
                correctanswer = "cat";
                for(int i =0; i<correctanswer.Length; i++)
                {
                    OutputWords.Text += "_ ";
                }

            }
            if ((bool)MediumMode.IsChecked)
            {
                counter = 0;
                System.IO.StreamReader mediumread = new System.IO.StreamReader("Medium.txt");
                while (!mediumread.EndOfStream)
                {
                    mediumanswer[counter] = mediumread.ReadLine();
                    OutputWords.Text += mediumanswer[counter] + Environment.NewLine;
                    counter++;
                }
                mediumread.Close();
            }
            if ((bool)HardMode.IsChecked)
            {
                counter = 0;
                System.IO.StreamReader hardread = new System.IO.StreamReader("Hard.txt");
                while (!hardread.EndOfStream)
                {
                    hardanswer[counter] = hardread.ReadLine();
                    OutputWords.Text += hardanswer[counter] + Environment.NewLine;
                    counter++;
                }            
                hardread.Close();
            }
            
        }

        private void LetterCheck_Click(object sender, RoutedEventArgs e)
        {
            discoveredanswer = OutputWords.Text;
            
            for (int i=0; i<correctanswer.Length; i++)
            {
                char lettersingle = correctanswer[i];
                
                if (lettersingle.ToString() == LetterInput.Text)
                {
                    discoveredanswer = discoveredanswer.Remove(i*2 , 1);
                   discoveredanswer = discoveredanswer.Insert(i*2, lettersingle.ToString());
                    OutputWords.Text = "";
                    OutputWords.Text += discoveredanswer;
                    foundletter = true;
                    
                }

            }
             foundletter = false; 
            if (foundletter == false)
            {
                fails += 1;
                if(fails == 1)
                {
                    Ellipse head = new Ellipse();
                    head.Width = 100;
                    head.Height = 100;
                    head.Fill = Brushes.Aqua;
                    Stickman.Children.Add(head);
                    Canvas.SetRight(head, 100);
                }
                if (fails == 2)
                {
                    Rectangle body = new Rectangle();
                    body.Width = 25;
                    body.Height = 150;
                    body.Fill = Brushes.Aqua;
                    Stickman.Children.Add(body);
                    Canvas.SetRight(body, 135);
                    Canvas.SetTop(body, 75);
                }
                if (fails == 3)
                {
                    Rectangle legs = new Rectangle();
                    legs.Width = 25;
                    legs.Height = 150;
                    legs.Fill = Brushes.Aqua;
                    Stickman.Children.Add(legs);
                    Canvas.SetRight(legs, 135);
                    Canvas.SetTop(legs, 200);
                }
            }

        }
    }
}
