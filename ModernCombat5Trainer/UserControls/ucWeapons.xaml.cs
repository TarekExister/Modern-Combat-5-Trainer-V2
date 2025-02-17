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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModernCombat5Trainer.UserControls
{
    /// <summary>
    /// Interaction logic for ucWeapons.xaml
    /// </summary>
    public partial class ucWeapons : UserControl
    {
        public ucWeapons()
        {
            InitializeComponent();
        }

        private void btnWP1_MouseEnter(object sender, MouseEventArgs e)
        {
            var button = sender as Button;



            var WidthAnimation = new DoubleAnimation() { To = 60, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
            var WidthAnimation1 = new DoubleAnimation() { To = 30, Duration = TimeSpan.FromSeconds(0.4) };
            Storyboard.SetTargetProperty(WidthAnimation1, new PropertyPath("Width", null));
            var WidthAnimation2 = new DoubleAnimation() { To = 50, Duration = TimeSpan.FromSeconds(0.6) };
            Storyboard.SetTargetProperty(WidthAnimation2, new PropertyPath("Width", null));

            var HeightAnimation = new DoubleAnimation() { To = 50, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height", null));

            var FontAnimation = new DoubleAnimation() { To = 22, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(FontAnimation, new PropertyPath("FontSize", null));

            var CAnimation = new ColorAnimation() { To = Colors.DarkRed, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(CAnimation, new PropertyPath("Background.(SolidColorBrush.Color)", null));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(FontAnimation);
            storyboard.Children.Add(WidthAnimation);
            storyboard.Children.Add(WidthAnimation1);
            storyboard.Children.Add(WidthAnimation2);
            storyboard.Children.Add(HeightAnimation);
            storyboard.Children.Add(CAnimation);
            storyboard.Begin(button);
        }

        private void btnWP1_MouseLeave(object sender, MouseEventArgs e)
        {
            var button = sender as Button;



            var WidthAnimation = new DoubleAnimation() { To = 30, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
            var WidthAnimation1 = new DoubleAnimation() { To = 50, Duration = TimeSpan.FromSeconds(0.4) };
            Storyboard.SetTargetProperty(WidthAnimation1, new PropertyPath("Width", null));
            var WidthAnimation2 = new DoubleAnimation() { To = 40, Duration = TimeSpan.FromSeconds(0.6) };
            Storyboard.SetTargetProperty(WidthAnimation2, new PropertyPath("Width", null));

            var HeightAnimation = new DoubleAnimation() { To = 40, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height", null));

            var FontAnimation = new DoubleAnimation() { To = 20, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(FontAnimation, new PropertyPath("FontSize", null));

            var CAnimation = new ColorAnimation() { To = Colors.Transparent, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(CAnimation, new PropertyPath("Background.(SolidColorBrush.Color)", null));


            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(FontAnimation);
            storyboard.Children.Add(WidthAnimation);
            storyboard.Children.Add(WidthAnimation1);
            storyboard.Children.Add(WidthAnimation2);
            storyboard.Children.Add(HeightAnimation);
            storyboard.Children.Add(CAnimation);
            storyboard.Begin(button);
        }


        private void FlipAnimation(UserControl ToShow, UserControl ToHide)
        {
            RotateTransform3D rotateTransform = new RotateTransform3D();
            ViewPort.Transform = rotateTransform;

            AxisAngleRotation3D rotateAxis1 = new AxisAngleRotation3D(new Vector3D(0, 1, 1), 180);
            AxisAngleRotation3D rotateAxis2 = new AxisAngleRotation3D(new Vector3D(0, 1, 1), 0);

            AxisAngleRotation3D rotateAxis3 = new AxisAngleRotation3D(new Vector3D(0, 1, 1), -180);

            Rotation3DAnimation rotateAnimation = new Rotation3DAnimation(rotateAxis2, rotateAxis1, TimeSpan.FromMilliseconds(300));
            Rotation3DAnimation rotateAnimation2 = new Rotation3DAnimation(rotateAxis3, rotateAxis2, TimeSpan.FromMilliseconds(300));

            // rotateAnimation.Completed += (o, s) => rotateTransform.BeginAnimation(RotateTransform3D.RotationProperty, rotateAnimation2);

            var OpacityAnimation = new DoubleAnimation() { From = 1.0, To = 0.0, Duration = TimeSpan.FromSeconds(0.300) };
            var OpacityAnimation2 = new DoubleAnimation() { From = 0, To = 1.0, Duration = TimeSpan.FromSeconds(0.300) };



            Storyboard storyboard = new Storyboard();
            Storyboard storyboard2 = new Storyboard();

            Storyboard.SetTarget(OpacityAnimation, ToHide);
            Storyboard.SetTargetProperty(OpacityAnimation, new PropertyPath("Opacity", null));


            Storyboard.SetTarget(rotateAnimation, ViewPort);
            Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(Viewport2DVisual3D.Transform).(RotateTransform3D.Rotation)", null));


            Storyboard.SetTarget(OpacityAnimation2, ToShow);
            Storyboard.SetTargetProperty(OpacityAnimation2, new PropertyPath("Opacity", null));


            Storyboard.SetTarget(rotateAnimation2, ViewPort);
            Storyboard.SetTargetProperty(rotateAnimation2, new PropertyPath("(Viewport2DVisual3D.Transform).(RotateTransform3D.Rotation)", null));

            storyboard.Children.Add(OpacityAnimation);
            storyboard.Children.Add(rotateAnimation);

            storyboard2.Children.Add(OpacityAnimation2);
            storyboard2.Children.Add(rotateAnimation2);

            // rotateTransform.BeginAnimation(RotateTransform3D.RotationProperty, rotateAnimation);

            storyboard.Completed += delegate
            {
                ToHide.Visibility = Visibility.Hidden;
                storyboard2.Begin(ToShow);
            };
            ToShow.Visibility = Visibility.Visible;
            storyboard.Begin(ToHide);
        }

        private string CurrentInterface = "btnWP1";

        private void btnWP1_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "btnWP1":

                    switch (CurrentInterface)
                    {
                        case "btnWP2":
                            FlipAnimation(wp1, wp2);
                            CurrentInterface = "btnWP1";
                            break;
                        case "btnWP3":
                            FlipAnimation(wp1, wp3);
                            CurrentInterface = "btnWP1";
                            break;
                        case "btnWP4":
                            FlipAnimation(wp1, wp4);
                            CurrentInterface = "btnWP1";
                            break;
                        case "btnWP5":
                            FlipAnimation(wp1, wp5);
                            CurrentInterface = "btnWP1";
                            break;
                    }
                    break;



                case "btnWP2":

                    switch (CurrentInterface)
                    {
                        case "btnWP1":
                            FlipAnimation(wp2, wp1);
                            CurrentInterface = "btnWP2";
                            break;
                        case "btnWP3":
                            FlipAnimation(wp2, wp3);
                            CurrentInterface = "btnWP2";
                            break;
                        case "btnWP4":
                            FlipAnimation(wp2, wp4);
                            CurrentInterface = "btnWP2";
                            break;
                        case "btnWP5":
                            FlipAnimation(wp2, wp5);
                            CurrentInterface = "btnWP2";
                            break;
                    }
                    break;




                case "btnWP3":
                    switch (CurrentInterface)
                    {
                        case "btnWP1":
                            FlipAnimation(wp3, wp1);
                            CurrentInterface = "btnWP3";
                            break;
                        case "btnWP2":
                            FlipAnimation(wp3, wp2);
                            CurrentInterface = "btnWP3";
                            break;
                        case "btnWP4":
                            FlipAnimation(wp3, wp4);
                            CurrentInterface = "btnWP3";
                            break;
                        case "btnWP5":
                            FlipAnimation(wp3, wp5);
                            CurrentInterface = "btnWP3";
                            break;
                    }
                    break;




                case "btnWP4":
                    switch (CurrentInterface)
                    {
                        case "btnWP1":
                            FlipAnimation(wp4, wp1);
                            CurrentInterface = "btnWP4";
                            break;
                        case "btnWP2":
                            FlipAnimation(wp4, wp2);
                            CurrentInterface = "btnWP4";
                            break;
                        case "btnWP3":
                            FlipAnimation(wp4, wp3);
                            CurrentInterface = "btnWP4";
                            break;
                        case "btnWP5":
                            FlipAnimation(wp4, wp5);
                            CurrentInterface = "btnWP4";
                            break;
                    }
                    break;




                case "btnWP5":
                    switch (CurrentInterface)
                    {
                        case "btnWP1":
                            FlipAnimation(wp5, wp1);
                            CurrentInterface = "btnWP5";
                            break;
                        case "btnWP2":
                            FlipAnimation(wp5, wp2);
                            CurrentInterface = "btnWP5";
                            break;
                        case "btnWP3":
                            FlipAnimation(wp5, wp3);
                            CurrentInterface = "btnWP5";
                            break;
                        case "btnWP4":
                            FlipAnimation(wp5, wp4);
                            CurrentInterface = "btnWP5";
                            break;
                    }
                    break;
            }
        }

    }
}
