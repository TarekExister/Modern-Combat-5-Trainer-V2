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
    /// Interaction logic for WeaponsMessageBox.xaml
    /// </summary>
    public partial class WeaponsMessageBox : Window
    {
        string btnContent;
        public WeaponsMessageBox(string _btnContent)
        {
            btnContent = _btnContent;
            InitializeComponent();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            Cheats.AddWeapon(btnContent, true);
            Application.Current.MainWindow.Topmost = true;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            Cheats.AddWeapon(btnContent, false);
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
            var WidthAnimation = new DoubleAnimation() { To = 110, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
            var HeightAnimation = new DoubleAnimation() { To = 25, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height", null));
            var FontAnimation = new DoubleAnimation() { To = 14, Duration = TimeSpan.FromSeconds(0.2) };
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
            var WidthAnimation = new DoubleAnimation() { To = 100, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
            var HeightAnimation = new DoubleAnimation() { To = 20, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height", null));
            var FontAnimation = new DoubleAnimation() { To = 12, Duration = TimeSpan.FromSeconds(0.2) };
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
