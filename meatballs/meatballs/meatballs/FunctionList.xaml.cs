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

namespace meatballs
{
    /// <summary>
    /// Interaction logic for FunctionList.xaml
    /// </summary>
    public partial class FunctionList : Window
    {
        public FunctionList(string fileName, List<string> functions)
        {
            InitializeComponent();

            this.Title = "Functions from " + fileName;
            lblNames.Content = "Select Functions to add: ";
            foreach(string s in functions)
            {
                lstFunctions.Items.Add(s);
            }
        }
    }
}
