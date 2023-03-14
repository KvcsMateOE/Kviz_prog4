using System;
using System.Collections.Generic;
using System.IO;
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

namespace Kviz_prog4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //List<Question> questions = File.ReadAllLines("questions.txt")
            //    .Select(t => new Question(t.Split(';')[0], t.Split(';')[1], t.Split(';')[2], t.Split(';')[3], t.Split(';')[4], t.Split(';')[5], t.Split(';')[6])).ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Question> questions = File.ReadAllLines("questions.txt")
              .Select(t => new Question(t.Split(';')[0], t.Split(';')[1], t.Split(';')[2], t.Split(';')[3], t.Split(';')[4], t.Split(';')[5], t.Split(';')[6])).ToList();
            ;
            questions.ForEach(t =>
            {
                Label l = new Label();
                l.Tag = t;
                //l.Content = new Image()
                //{
                //    Name = "IQ",
                //    Source = new BitmapImage(new Uri("/IQ.png")),
                //    Stretch = Stretch.None,
                //    Width = 70,
                //    Height = 70
                //};
                l.HorizontalContentAlignment = HorizontalAlignment.Center;
                l.VerticalContentAlignment = VerticalAlignment.Center;
              //  l.Background = Brushes.LightBlue;
                //l.Background = new ImageBrush()
                //{
                //    TileMode = TileMode.Tile,


                //};
               l.Background = new ImageBrush(new BitmapImage(new Uri("C://Users/kovac/source/repos/Kviz_prog4/Kviz_prog4/IQ.png")));



                l.Margin = new Thickness(10);
                l.Width = this.ActualWidth / 4;
                l.Height = this.ActualHeight / 4;
                wrap.Children.Add(l);

                //l.MouseLeftButtonDown += L_MouseLeftButtonDown;
                

            }
    
            );

        
        }

        private void L_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Label l)
            {


               // Question q = (Question)(sender as Label).Tag;
                

                if (l.Tag is Question q)
                {
                    CheckAnswer ca = new CheckAnswer(q);

                    if (ca.ShowDialog() == true)
                    {
                        l.Background = Brushes.LightGreen;
                        l.IsEnabled = false;
                    }
                    else
                    {
                       l.Background = Brushes.Red;
                        l.IsEnabled = false;
                    }
                }
            }
            
        }
    }
}
