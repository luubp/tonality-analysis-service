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
using Newtonsoft.Json;
using System.IO;
using System.Net;
using Microsoft.Win32;
using ScottPlot;

namespace WpfApp1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string JSONData = JsonConvert.SerializeObject(textBox1.Text);

            /*WebRequest request = WebRequest.Create("адрес сервера");

            string text = JSONData;

            byte[] byteMsg = Encoding.UTF8.GetBytes(text);

            request.ContentType = "application/x-www-urlencoded";

            request.ContentLength = byteMsg.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(byteMsg, 0, byteMsg.Length);
            }

            WebResponse response = request.GetResponse();

            string answer = null;

            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader sR = new StreamReader(s))
                {
                    answer = sR.ReadToEnd();
                }
            }

            response.Close();*/



            double score1 = 0.9, score2 = 0.08, score3 = 0.02;
            DrawDiagram(score1, score2, score3);
        }

        private void DrawDiagram(double score1, double score2, double score3)
        {
            double[] values = { score1, score2, score3 };
            double[] positions = { 3, 5, 7 };
            string[] labels = { pozitive.Content.ToString(), neutral.Content.ToString(), negative.Content.ToString() };
            Chart.Plot.AddBar(values, positions);
            Chart.Plot.XTicks(positions, labels);
            Chart.Plot.SetAxisLimits(yMin: 0);

            Chart.Refresh();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = "Test";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";
            if (dialog.ShowDialog() == true)
            {
                textBox1.Text = File.ReadAllText(dialog.FileName);
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (s.ShowDialog() == true)
            {
                File.WriteAllText(s.FileName, textBox1.Text);
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(String.Format("Приложение позволяет узнать тональность текста (эмоциональную окраску)"));
        }
    }
}
