using System;
using System.Collections.Generic;
using System.IO;
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

namespace PROG8051_Week_11_Lec_1_Sec_7
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

        private void GenerateEmail(object sender, RoutedEventArgs e)
        {
            string fname = name.Text;
            string lname = lastname.Text;
            string userage = age.Text;

            int yob = 2024 - Convert.ToInt32(userage);

            string answer = $"{fname[0]}.{lname}{yob}@conestogac.on.ca";
            result.Text = answer;
        }

        public string Button_Click(object sender, RoutedEventArgs e)
        {
            string gender = "";

            if ((bool)male.IsChecked)
            {
                gender = "male";
            }

            else if ((bool)female.IsChecked)
            {
                gender = "female";
            }

            else if ((bool)nottosay.IsChecked)
            {
                gender = "Prefer not to say";
            }
            MessageBox.Show(gender);

            string courses = "";

            if ((bool)_1.IsChecked)
            {
                courses = courses +" "+ _1.Content;
            }

            if ((bool)_2.IsChecked)
            {
                courses = courses + " " + _2.Content;
            }

            if ((bool)_3.IsChecked)
            {
                courses = courses + " " + _3.Content;
            }

            string answer = $"First Name : {name.Text} \n Last Name: {lastname.Text} \n Age: {age.Text} \n Gender: {gender} \n Courses: {courses}";
            return answer;
        }

        void WriteText2(object sender, RoutedEventArgs e)
        {
            RadioButton li = (sender as RadioButton);
            MessageBox.Show("You clicked " + li.Content.ToString() + ".");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\namiq\Desktop\test\report.txt";

            string answer = Button_Click(sender, e);
            MessageBox.Show(answer);
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(answer);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
