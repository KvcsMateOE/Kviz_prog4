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
using System.Windows.Threading;

namespace Kviz_prog4
{
    /// <summary>
    /// Interaction logic for CheckAnswer.xaml
    /// </summary>
    public partial class CheckAnswer : Window
    {
        Question q;
        int time = 60;
        bool selected = false;

        public CheckAnswer(Question q)
        {
            InitializeComponent();
            this.q = q;
            label_question.Content = q.Kerdes;
            label_answer1.Content = q.Valasz1;
            label_answer1.Tag = 1;
            label_answer2.Content = q.Valasz2;
            label_answer2.Tag = 2;
            label_answer3.Content = q.Valasz3;
            label_answer3.Tag = 3;
            label_answer4.Content = q.Valasz4;
            label_answer4.Tag = 4;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            //if (time > 0)
            //{
            //    time--;
            //    timer.Content = string.Format("{1}", time / 60, time % 60);

            //  //  this.DialogResult = true;

            //}
            //else
            //{
            //    this.DialogResult = false;
            //}
            time--;
            this.Dispatcher.Invoke(() =>
            {
                timer.Content = time;
            });
            if (time == 0)
            {
                this.DialogResult = false;
            }


        }
       

	
        private void label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
            
            if (e.Source is Label)
            {
                if ((e.Source as Label).Tag.ToString() == q.Megoldas && time > 0)
                {
                    q.Correct = true;
                    this.DialogResult = true;
                }
                else if ((e.Source as Label).Tag.ToString() != q.Megoldas)
                {
                    q.Correct = false;
                    this.DialogResult = false;

                }
              
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (q.Correct is null && time !=0)
            {
                var result = MessageBox.Show("Biztosan ki szeretne lépni?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }






        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (time > 0)
        //    {
        //        time--;
        //        timer.Content = string.Format("{0}:{1}", time / 60, time % 60);

        //         this.DialogResult = true;

        //    }
        //    else
        //    {
        //        this.DialogResult = false;
        //    }
        //}
    }
}
