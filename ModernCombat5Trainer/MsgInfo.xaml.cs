using ModernCombatTrainer.GameMemory;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ModernCombat5Trainer
{
    /// <summary>
    /// Interaction logic for MsgInfo.xaml
    /// </summary>
    public partial class MsgInfo : Window
    {
        public MsgInfo()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var OpacityAnimation = new DoubleAnimation() { From = 0, To = 1, Duration = TimeSpan.FromSeconds(0.150) };
            Storyboard.SetTargetProperty(OpacityAnimation, new PropertyPath("Opacity", null));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(OpacityAnimation);
            storyboard.Begin(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Topmost = true;
            this.Close();
        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            var WidthAnimation = new DoubleAnimation() { To = 170, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
            var HeightAnimation = new DoubleAnimation() { To = 40, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height", null));
            var FontAnimation = new DoubleAnimation() { To = 19, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(FontAnimation, new PropertyPath("FontSize", null));
            var CAnimation = new ColorAnimation() { To = Colors.DarkRed, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(CAnimation, new PropertyPath("Background.(SolidColorBrush.Color)", null));


            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(CAnimation);
            storyboard.Children.Add(FontAnimation);
            storyboard.Children.Add(WidthAnimation);
            storyboard.Children.Add(HeightAnimation);
            storyboard.Begin(button);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            var WidthAnimation = new DoubleAnimation() { To = 150, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
            var HeightAnimation = new DoubleAnimation() { To = 35, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height", null));
            var FontAnimation = new DoubleAnimation() { To = 18, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(FontAnimation, new PropertyPath("FontSize", null));
            var CAnimation = new ColorAnimation() { To = Colors.Transparent, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(CAnimation, new PropertyPath("Background.(SolidColorBrush.Color)", null));


            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(CAnimation);
            storyboard.Children.Add(FontAnimation);
            storyboard.Children.Add(WidthAnimation);
            storyboard.Children.Add(HeightAnimation);
            storyboard.Begin(button);
        }
    }
}
