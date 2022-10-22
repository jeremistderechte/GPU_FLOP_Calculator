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

namespace GPU_FLOP_Calculator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Clock.Text != "" && TextBox_Shaders.Text != "")
            {
                uint shaders = 0;
                uint clock = 0;


                double result = 0.0;

                clock = Convert.ToUInt32(TextBox_Clock.Text);
                shaders = Convert.ToUInt32(TextBox_Shaders.Text);

                result = Math.Round((shaders * (clock / 1000.0) * 2.0) / 1000.0, 2);

                if (CheckBox_Overclocked.IsChecked.Value && TextBox_Clock_OC.Text != "")
                {
                    uint clock_oc = 0;
                    clock_oc = Convert.ToUInt32(TextBox_Clock_OC.Text);
                    double result_oc = 0.0;
                    result_oc = Math.Round((shaders * (clock_oc / 1000.0) * 2.0) / 1000.0, 2);
                    double per_bet = Math.Round(((result_oc / result) -1) * 100, 2);

                    TextBox_Result.Text = "Your GPU has a theoretical floating performance (FP32) of " + Convert.ToString(result) + " TFLOPS and your overclock brought you to " + Convert.ToString(result_oc) + " TFLOPS, which is an increase of approximately " + Convert.ToString(per_bet) + "%";
                }
                else
                {
                    TextBox_Result.Text = "Your GPU has a theoretical floating performance (FP32) of " + Convert.ToString(result) + " TFLOPS";
                }

            }
            else
            {
                TextBox_Result.Text = "Please fill in any values!";
            }






        }
    }
}
