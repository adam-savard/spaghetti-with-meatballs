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
using meatballs.utilities;
using meatballs.classes;
using System.Windows.Forms;

namespace meatballs
{
    /// <summary>
    /// Interaction logic for AddAuthor.xaml
    /// </summary>
    public partial class AddAuthor : Window
    {
        public AddAuthor()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Writer.WriteAuthor(new Author(txtName.Text, 0, DateTime.Now, txtNotes.Text));
            MessageBoxResult result = System.Windows.MessageBox.Show("Add another?", "A new author with the name " + txtName.Text + " was added. Add another?", MessageBoxButton.YesNo);

            if(result == MessageBoxResult.Yes)
            {
                txtName.Text = string.Empty;
                txtNotes.Text = string.Empty;
            }
            else
            {
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
