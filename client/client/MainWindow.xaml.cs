using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Win32;
using ScottPlot;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        private readonly HttpClient client = new HttpClient();
        
        public MainWindow()
        {
            InitializeComponent();
            double[] positions = { 3, 5, 7 };
            double[] values = { 0.0f, 0.0f, 0.0f };
            string[] labels = { pozitive.Content.ToString(), neutral.Content.ToString(), negative.Content.ToString() };
            Chart.Plot.AddBar(values, positions, color: Color.Cyan);
            Chart.Plot.XTicks(positions, labels);
            Chart.Plot.SetAxisLimits(yMax: 1, yMin: 0);
            Chart.Refresh();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var url = "http://localhost:80/predict";
            var data = textBox1.Text;  // данные для отправки
            

            try
            {
                download.Visibility = Visibility.Visible;
                // Запуск асинхронного метода для выполнения запроса
                string jsonResponse = await SendGetRequestAsync($"{url}?text={Uri.EscapeDataString(data)}");

                // Обработка jsonResponse (десериализация JSON)
                JObject jsonObject = JObject.Parse(jsonResponse);


                if ((string)jsonObject["label_1"] == "positive" && (string)jsonObject["label_2"] == "neutral" && (string)jsonObject["label_3"] == "negative")
                    DrawDiagram((double)jsonObject["score_1"], (double)jsonObject["score_2"], (double)jsonObject["score_3"]);
                else if ((string)jsonObject["label_1"] == "positive" && (string)jsonObject["label_3"] == "neutral" && (string)jsonObject["label_2"] == "negative")
                    DrawDiagram((double)jsonObject["score_1"], (double)jsonObject["score_3"], (double)jsonObject["score_2"]);
                else if ((string)jsonObject["label_2"] == "positive" && (string)jsonObject["label_3"] == "neutral" && (string)jsonObject["label_1"] == "negative")
                    DrawDiagram((double)jsonObject["score_2"], (double)jsonObject["score_3"], (double)jsonObject["score_1"]);
                else if ((string)jsonObject["label_2"] == "positive" && (string)jsonObject["label_1"] == "neutral" && (string)jsonObject["label_3"] == "negative")
                    DrawDiagram((double)jsonObject["score_2"], (double)jsonObject["score_1"], (double)jsonObject["score_3"]);
                else if ((string)jsonObject["label_3"] == "positive" && (string)jsonObject["label_1"] == "neutral" && (string)jsonObject["label_2"] == "negative")
                    DrawDiagram((double)jsonObject["score_3"], (double)jsonObject["score_1"], (double)jsonObject["score_2"]);
                else
                    DrawDiagram((double)jsonObject["score_3"], (double)jsonObject["score_2"], (double)jsonObject["score_1"]);

            }
            catch (Exception ex)
            {
                // Обработка исключений при выполнении запроса
                MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                download.Visibility = Visibility.Hidden;
            }

            
            finally
            {
                download.Visibility = Visibility.Hidden;
            }

            
        }

        private async Task<string> SendGetRequestAsync(string url)
        {
            try
            {

                // Отправить GET-запрос асинхронно
                HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);

                // Проверить успешность ответа
                response.EnsureSuccessStatusCode();

                // Чтение ответа в виде строки
                string responseContent = await response.Content.ReadAsStringAsync();


                return responseContent;
            }
            catch (Exception ex)
            {
                // Обработка исключений при выполнении запроса
                MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                download.Visibility = Visibility.Hidden;
                return null;
            }
        }


        private void DrawDiagram(double score1, double score2, double score3)
        {
            Chart.Plot.Clear();
            double[] values = { score1, score2, score3 };
            double[] positions = { 3, 5, 7 };
            string[] labels = { pozitive.Content.ToString(), neutral.Content.ToString(), negative.Content.ToString() };
            Chart.Plot.AddBar(values, positions);
            Chart.Plot.XTicks(positions, labels);
            Chart.Plot.SetAxisLimits(yMax: 1, yMin: 0);

            Chart.Refresh();
            download.Visibility = Visibility.Hidden;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";
            if (dialog.ShowDialog() == true)
            {
                textBox1.Text = File.ReadAllText(dialog.FileName);
            }
            labelFileName.Content = dialog.FileName;
            labelFileName.Visibility = Visibility.Visible;
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";

            if (s.ShowDialog() == true)
            {
                Chart.Plot.SaveFig(s.FileName);
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(String.Format("Приложение позволяет узнать тональность текста (эмоциональную окраску)"));
        }
    }

    

}
