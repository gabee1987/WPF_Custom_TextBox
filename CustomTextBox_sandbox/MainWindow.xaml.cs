using CustomTextBox_sandbox.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CustomTextBox_sandbox
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

        private void GeometriaTextBox_PreviewTextInput( object sender, TextCompositionEventArgs e )
        {
            Regex regex = new Regex( $"^[0-9]" );
            var textBox = sender as GeometriaTextBox;

            if ( regex.IsMatch( e.Text ) )
            {
                textBox.HidePopUp();
                e.Handled = false;
            }
            else
            {
                textBox.ShowPopUp();
                e.Handled = true;
            }
        }
    }
}
