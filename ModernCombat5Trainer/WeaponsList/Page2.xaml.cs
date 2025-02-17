using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModernCombat5Trainer.WeaponsList
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : UserControl
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void GridMouseLeave(Grid myGrid)
        {

            var WidthAnimation = new DoubleAnimation() { To = 100, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
            var WidthAnimation1 = new DoubleAnimation() { To = 160, Duration = TimeSpan.FromSeconds(0.4) };
            Storyboard.SetTargetProperty(WidthAnimation1, new PropertyPath("Width", null));
            var WidthAnimation2 = new DoubleAnimation() { To = 130, Duration = TimeSpan.FromSeconds(0.6) };
            Storyboard.SetTargetProperty(WidthAnimation2, new PropertyPath("Width", null));

            var HeightAnimation = new DoubleAnimation() { To = 100, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height", null));





            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(WidthAnimation);
            storyboard.Children.Add(WidthAnimation1);
            storyboard.Children.Add(WidthAnimation2);
            storyboard.Children.Add(HeightAnimation);
            storyboard.Begin(myGrid);
        }

        private void GridMouseEnter(Grid myGrid)
        {


            var WidthAnimation = new DoubleAnimation() { To = 180, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
            var WidthAnimation1 = new DoubleAnimation() { To = 130, Duration = TimeSpan.FromSeconds(0.4) };
            Storyboard.SetTargetProperty(WidthAnimation1, new PropertyPath("Width", null));
            var WidthAnimation2 = new DoubleAnimation() { To = 160, Duration = TimeSpan.FromSeconds(0.6) };
            Storyboard.SetTargetProperty(WidthAnimation2, new PropertyPath("Width", null));

            var HeightAnimation = new DoubleAnimation() { To = 110, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height", null));





            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(WidthAnimation);
            storyboard.Children.Add(WidthAnimation1);
            storyboard.Children.Add(WidthAnimation2);
            storyboard.Children.Add(HeightAnimation);
            storyboard.Begin(myGrid);
        }












        private void CBtn_MouseEnter(object sender, MouseEventArgs e)
        {


            GridMouseEnter(sender as Grid);

        }

        private void CBtn_MouseLeave(object sender, MouseEventArgs e)
        {


            GridMouseLeave(sender as Grid);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Topmost = false;
            new WeaponsMessageBox((sender as ToggleButton).Content.ToString()).ShowDialog();
        }

    }
}
