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
        public class TrainingRecords
        {
            public string X1 { get; set; }
            public string X2 { get; set; }
            public string B { get; set; }
            public string W1 { get; set; }
            public string W2 { get; set; }
            public string WB { get; set; }
            public string Target { get; set; }
            public string Type { get; set; }
        }

        private int input_x1;
        private int input_x2;
        private static int input_b = 1;
        private int target = 1;
        private int weight_x1 = 0;
        private int weight_x2 = 0;
        private int weight_b = 0;
        private int training_times = 0;
        private List<TrainingRecords> records = new List<TrainingRecords>();
        public MainWindow()
        {
            InitializeComponent();
            InitWeight();
        }

        public void Train(object sender, RoutedEventArgs e)
        {
            try
            {
                this.input_x1 = Convert.ToInt32(TextBox_x1.Text.Trim());
                this.input_x2 = Convert.ToInt32(TextBox_x2.Text.Trim());
                this.target = Convert.ToInt32(TextBox_target.Text.Trim());
                //训练权重
                this.weight_x1 += this.target * this.input_x1;
                this.weight_x2 += this.target * this.input_x2;
                this.weight_b += this.target * input_b;
                TrainingRecords rec = new TrainingRecords();
                rec.X1 = this.input_x1.ToString();
                rec.X2 = this.input_x2.ToString();
                rec.B = input_b.ToString();
                rec.W1 = this.weight_x1.ToString();
                rec.W2 = this.weight_x2.ToString();
                rec.WB = this.weight_b.ToString();
                rec.Target = this.target.ToString();
                rec.Type = "train";
                this.records.Add(rec);
                DG1.DataContext = null;
                DG1.DataContext = records;
                this.training_times += 1;
                UpdateWeight();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Test(object sender, RoutedEventArgs e)
        {
            try
            {
                this.input_x1 = Convert.ToInt32(TextBox_x1.Text.Trim());
                this.input_x2 = Convert.ToInt32(TextBox_x2.Text.Trim());
                this.target = this.input_x1 * this.weight_x1 + this.input_x2 * this.weight_x2 + this.input_b * this.weight_b;
                TextBox_target.Text = this.target.ToString();
                TrainingRecords rec = new TrainingRecords();
                rec.X1 = this.input_x1.ToString();
                rec.X2 = this.input_x2.ToString();
                rec.B = input_b.ToString();
                rec.W1 = this.weight_x1.ToString();
                rec.W2 = this.weight_x2.ToString();
                rec.WB = this.weight_b.ToString();
                rec.Target = this.target.ToString();
                rec.Type = "test";
                this.records.Add(rec);
                DG1.DataContext = null;
                DG1.DataContext = records;
                this.training_times += 1;
                UpdateWeight();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Reset(object sender, RoutedEventArgs e)
        {
            this.weight_x1 = 0;
            this.weight_x2 = 0;
            this.weight_b = 0;
            this.training_times = 0;
            this.target = 1;
            DG1.DataContext = null;
            this.records.Clear();
            UpdateWeight();
        }

        private void InitWeight()
        {
            UpdateWeight();
            TextBox_b.Text = input_b.ToString();
        }

        private void UpdateWeight()
        {
            TextBox_w1.Text = this.weight_x1.ToString();
            TextBox_w2.Text = this.weight_x2.ToString();
            TextBox_wb.Text = this.weight_b.ToString();
        }
    }
}
