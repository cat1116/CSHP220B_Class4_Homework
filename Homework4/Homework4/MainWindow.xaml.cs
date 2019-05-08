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

namespace Homework4
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

        private static readonly Regex _validRegex = new Regex(@"^(\d{5}(-\d{4})?|[A-Za-z]\d[A-Za-z]\d[A-Za-z]\d)$"); //regex that matches zip codes.


        private void UxZip_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //reference: docs.microsoft.com/en-us/dotnet/api/system.windows.input.key?view=netframework-4.8#System_Windows_Input_Key_Return
            //Allow letters and numbers and dash.  
            //Allow backspace and delete so user can fix incorrect input.
            if (e.Key != Key.A && e.Key != Key.B && e.Key != Key.C && e.Key != Key.D && e.Key != Key.E && e.Key != Key.F && e.Key != Key.G && e.Key != Key.H &&
                e.Key != Key.I && e.Key != Key.J && e.Key != Key.K && e.Key != Key.L && e.Key != Key.M && e.Key != Key.N && e.Key != Key.O && e.Key != Key.P &&
                e.Key != Key.Q && e.Key != Key.R && e.Key != Key.S && e.Key != Key.T && e.Key != Key.U && e.Key != Key.V && e.Key != Key.W && e.Key != Key.X &&
                e.Key != Key.Y && e.Key != Key.Z && e.Key != Key.D0 && e.Key != Key.D1 && e.Key != Key.D2 && e.Key != Key.D3 && e.Key != Key.D4 && e.Key != Key.D5 &&
                e.Key != Key.D6 && e.Key != Key.D7 && e.Key != Key.D8 && e.Key != Key.D9 && e.Key != Key.NumPad0 && e.Key != Key.NumPad1 && e.Key != Key.NumPad2 &&
                e.Key != Key.NumPad3 && e.Key != Key.NumPad4 && e.Key != Key.NumPad5 && e.Key != Key.NumPad6 && e.Key != Key.NumPad7 && e.Key != Key.NumPad8 &&
                e.Key != Key.NumPad9 && e.Key != Key.Back && e.Key != Key.Delete && e.Key != Key.OemMinus)
                e.Handled = true;
        }

        private void UxZip_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = (string)e.DataObject.GetData(typeof(string));

                //Don't paste if text being pasted doesn't match the regex.
                if (!_validRegex.IsMatch(text))
                {
                    e.CancelCommand();
                                        
                }
            }
            else
            {
                e.CancelCommand();

            }
        }

        private void UxZip_TextChanged(object sender, TextChangedEventArgs e)
        {
            string userInput = uxZip.Text;
                    
            //Enable submit?
            bool validInput = _validRegex.IsMatch(userInput);
            if (validInput)
            {
                uxSubmit.IsEnabled = true;
                uxSubmit.Background = Brushes.LightGreen;

            }
            else
            {
                uxSubmit.IsEnabled = false;
                uxSubmit.Background = Brushes.Transparent;

            }

        }
    }
}
