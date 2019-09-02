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

            txtTest.Content = "Config Files Created In: " + XMLReader.DocPath;
            XMLReader.CreateWorkingDirectory(); //creates all the necessary files the first time the application is loaded.
            Writer.WriteAuthor(new Author("Test", -1, DateTime.Now, "Test"));
        }
    }
}
