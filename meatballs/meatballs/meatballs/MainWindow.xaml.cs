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
using Microsoft.Win32;
using System.IO;

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

            if (XMLReader.BlankXMLCheck())
            {
                Wizard w = new Wizard();
                w.ShowDialog();
               this.Visibility = Visibility.Hidden;
               this.Close();
           }
        }

        private void BtnCreateProject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Note: function scanning is FAR from perfect. Double check names.");
        }

        private void BtnNewAuthor_Click(object sender, RoutedEventArgs e)
        {
            AddAuthor newAuthor = new AddAuthor();
            newAuthor.ShowDialog();
        }

        private void BtnFunctionScan_Click(object sender, RoutedEventArgs e)
        {
            var fileContent = string.Empty;
            var fileName = string.Empty;
            List<string> functions = new List<string>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "javascript files (*.js)|*.js|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;
                bool result = (bool)openFileDialog.ShowDialog();

                if (result)
                {
                    //Get the path of specified file
                    fileName = openFileDialog.SafeFileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                    string line;
                        while((line = reader.ReadLine()) != null)
                            {
                             if (FunctionReader.LineContainsFunction(line))
                             {
                                 functions.Add(FunctionReader.GetFunctionName(line));
                             }
                            }
                    }

                FunctionList newListBox = new FunctionList(fileName, functions);
                newListBox.ShowDialog();
                }
            
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            Function f = new Function("test", "test", "test", XMLReader.GetAuthorFromID(0), XMLReader.GetFileFromID(0), 0);
            f.Calls.Add(new Function("test2", "test2", "test2", XMLReader.GetAuthorFromID(0), XMLReader.GetFileFromID(0), 1));
            f.Calls.Add(new Function("test3", "test3", "test3", XMLReader.GetAuthorFromID(0), XMLReader.GetFileFromID(0), 1));
            f.Calls.Add(new Function("test4", "test4", "test4", XMLReader.GetAuthorFromID(0), XMLReader.GetFileFromID(0), 1));
            f.Calls.Add(new Function("test5", "test5", "test5", XMLReader.GetAuthorFromID(0), XMLReader.GetFileFromID(0), 1));
            f.Calls.Add(new Function("test6", "test6", "test6", XMLReader.GetAuthorFromID(0), XMLReader.GetFileFromID(0), 1));
            f.Calls.Add(new Function("test7", "test7", "test7", XMLReader.GetAuthorFromID(0), XMLReader.GetFileFromID(0), 1));
            Writer.WriteFunction(f);

            XMLReader.GetFunctionByID(6);
        }
    }
}
