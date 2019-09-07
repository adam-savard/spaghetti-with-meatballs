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
using System.Windows.Shapes;
using meatballs.classes;
using meatballs.utilities;

namespace meatballs
{
    /// <summary>
    /// Interaction logic for Wizard.xaml
    /// </summary>
    public partial class Wizard : Window
    {
        private string authorName = "";
        private string authorNotes = "";
        public Wizard()
        {
            InitializeComponent();
            pnlStart.Visibility = Visibility.Visible;
            SetExplanations();
        }

        /// <summary>
        /// Sets up the explanation slides.
        /// </summary>
        public void SetExplanations()
        {
            lblExplanation.Content = @"Thanks for giving Meatballs a try!

Meatballs is an application to help you make sense of spaghetti code written 
in your favorite scripting languages.

Currently, Javascript and TypeScript are supported, 
with planned support for PHP in the future.

Click on next to begin the setup process.";

            lblProjectExplanation.Content = "Alright, " + authorName + @", I've created an Author for you.

On the next page, you'll find some questions about the project you're
working on.

Don't worry! If you have more than one, you can always add another after
we're through!

Click next to continue!";


        }

        /// <summary>
        /// Move to the next slide, please.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            pnlStart.Visibility = Visibility.Hidden;
            pnlEnterName.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// When clicked, shows a friendly message and creates a new Author in authors.xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreateAuthor_Click(object sender, RoutedEventArgs e)
        {
            authorName = txtAuthorName.Text;
            authorNotes = txtAuthorNotes.Text;
            Author a;

            MessageBoxResult result = MessageBox.Show("Hi there, " + authorName + "! It's nice to meet you. I'm going to create a new entry in the Authors file with your name on it. Is that okay? If not, press no for the default!", "Author Creation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(result == MessageBoxResult.Yes)
            {
                a = new Author(authorName, -1, DateTime.Now, authorNotes);
            }
            else
            {
                a = new Author("Defacto", -1, DateTime.Now, "The Default");
            }
            SetExplanations();
            Writer.WriteAuthor(a);
            pnlEnterName.Visibility = Visibility.Hidden;
            pnlProjectExplanation.Visibility = Visibility.Visible;
        }

        private void BtnNextProjects_Click(object sender, RoutedEventArgs e)
        {
            pnlProjectExplanation.Visibility = Visibility.Hidden;
            pnlProjectEntry.Visibility = Visibility.Visible;
        }

        private void BtnFinish_Click(object sender, RoutedEventArgs e)
        {
            Writer.WriteProject(new Project(txtProjectName.Text, -1, DateTime.Now, txtProjectLanguage.Text, XMLReader.GetAuthorFromID(0)));
            MessageBox.Show("Happy Coding!");
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
