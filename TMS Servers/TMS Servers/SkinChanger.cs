
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;


namespace TMS_Servers
{
    public class SkinChanger
    {
        private readonly MainWindow window;

        public SkinChanger(MainWindow window)
        {
            this.window = window;
        }

       

        public void ChangeSkin(Color color1, Color color2)
        {
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0.5, 0);
            myLinearGradientBrush.EndPoint = new Point(0.5, 1);
            myLinearGradientBrush.GradientStops.Add(new GradientStop(color1, 0.0));
            myLinearGradientBrush.GradientStops.Add(new GradientStop(color2, 0.5));
            window.BGD.Fill = myLinearGradientBrush;
            window.BGD1.Fill = myLinearGradientBrush;
            (window.Tab1.Template.FindName("Border", window.Tab1) as Border).Background = new SolidColorBrush(color2);
            (window.Tab1.Template.FindName("Border", window.Tab1) as Border).BorderBrush = new SolidColorBrush(color2);
            (window.Tab2.Template.FindName("Border", window.Tab2) as Border).Background = new SolidColorBrush(color2);
            (window.Tab2.Template.FindName("Border", window.Tab2) as Border).BorderBrush = new SolidColorBrush(color2);
        }
    }
}
