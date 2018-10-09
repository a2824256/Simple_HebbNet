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

namespace HebbNet
{
    public partial class MainWindow : Window
    {
        private int input_x1;
        private int input_x2;
        private int input_b;
        private int weight_x1 = 1;
        private int weight_x2 = 1;
        private int weight_b = 1;
        private int res;
        public MainWindow()
        {
            InitializeComponent();
            Init_weight();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            string input_x1 = TextBox_x1.Text.ToString();
            string input_x2 = TextBox_x2.Text.ToString();
            string input_b = TextBox_b.Text.ToString();
        }

        private void Init_weight()
        {
            TextBox_w1.Text = this.weight_x1.ToString();
            TextBox_w2.Text = this.weight_x2.ToString();
            TextBox_wb.Text = this.weight_b.ToString();
        }
    }
}
