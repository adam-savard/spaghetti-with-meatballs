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
using meatballs.utilities;
using meatballs.classes;

namespace meatballs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            txtTest.Content = "Config Files Exist!";
            XMLReader.CreateWorkingDirectory(); //creates all the necessary files the first time the application is loaded.
        }

        private void BtnCreateProject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not sure what everything does? Check out the documentation.");
        }

        private void BtnNewAuthor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
