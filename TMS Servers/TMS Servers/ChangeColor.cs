using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Servers
{
    public class ChangeColor
    {

        public void ColorChanger() { 

        LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
        myLinearGradientBrush.StartPoint = new Point(0.5, 0);
        myLinearGradientBrush.EndPoint = new Point(0.5, 1);
        myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.DarkGray, 0.0));
        myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.LightSlateGray, 0.5));
        BGD.Fill = myLinearGradientBrush;
        BGD1.Fill = myLinearGradientBrush;
        (Tab1.Template.FindName("Border", Tab1) as Border).Background = new SolidColorBrush(Colors.Gray);
        (Tab1.Template.FindName("Border", Tab1) as Border).BorderBrush = new SolidColorBrush(Colors.Gray);
        (Tab2.Template.FindName("Border", Tab2) as Border).Background = new SolidColorBrush(Colors.Gray);
        (Tab2.Template.FindName("Border", Tab2) as Border).BorderBrush = new SolidColorBrush(Colors.Gray);
        ColorIndex = 1;
         return;
        }
    }
}
