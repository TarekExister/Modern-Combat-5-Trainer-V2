using ModernCombatTrainer.GameMemory;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModernCombat5Trainer.UserControls
{
    /// <summary>
    /// Interaction logic for ucCores.xaml
    /// </summary>
    public partial class ucCores : UserControl
    {
        public ucCores()
        {
            InitializeComponent();
        }

        private void GridMouseLeave(Grid myGrid)
        {

            var WidthAnimation = new DoubleAnimation() { To = 120, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
            var WidthAnimation1 = new DoubleAnimation() { To = 180, Duration = TimeSpan.FromSeconds(0.4) };
            Storyboard.SetTargetProperty(WidthAnimation1, new PropertyPath("Width", null));
            var WidthAnimation2 = new DoubleAnimation() { To = 150, Duration = TimeSpan.FromSeconds(0.6) };
            Storyboard.SetTargetProperty(WidthAnimation2, new PropertyPath("Width", null));

            var HeightAnimation = new DoubleAnimation() { To = 80, Duration = TimeSpan.FromSeconds(0.2) };
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


            var WidthAnimation = new DoubleAnimation() { To = 200, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
            var WidthAnimation1 = new DoubleAnimation() { To = 150, Duration = TimeSpan.FromSeconds(0.4) };
            Storyboard.SetTargetProperty(WidthAnimation1, new PropertyPath("Width", null));
            var WidthAnimation2 = new DoubleAnimation() { To = 180, Duration = TimeSpan.FromSeconds(0.6) };
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

        private void SetColorEffectsMouseEnter(Grid myGrid)
        {
            switch (myGrid.Name)
            {
                case "CBtn":
                    if (brdS.Background == Brushes.LightGreen) break;
                    brdS.Background = Brushes.Red;
                    brdS.BorderBrush = Brushes.Red;

                    DropShadowEffect dse = new DropShadowEffect();

                    dse.BlurRadius = 35;
                    dse.Opacity = 1.0;
                    dse.ShadowDepth = 0;
                    dse.Color = Colors.Red;

                    brdS.Effect = dse;
                    break;



                case "CBtn1":
                    if (brdS1.Background == Brushes.LightGreen) break;
                    brdS1.Background = Brushes.Red;
                    brdS1.BorderBrush = Brushes.Red;

                    DropShadowEffect dse1 = new DropShadowEffect();

                    dse1.BlurRadius = 35;
                    dse1.Opacity = 1.0;
                    dse1.ShadowDepth = 0;
                    dse1.Color = Colors.Red;

                    brdS1.Effect = dse1;
                    break;




                case "CBtn2":
                    if (brdS2.Background == Brushes.LightGreen) break;
                    brdS2.Background = Brushes.Red;
                    brdS2.BorderBrush = Brushes.Red;

                    DropShadowEffect dse2 = new DropShadowEffect();

                    dse2.BlurRadius = 35;
                    dse2.Opacity = 1.0;
                    dse2.ShadowDepth = 0;
                    dse2.Color = Colors.Red;

                    brdS2.Effect = dse2;
                    break;




                case "CBtn3":
                    if (brdS3.Background == Brushes.LightGreen) break;
                    brdS3.Background = Brushes.Red;
                    brdS3.BorderBrush = Brushes.Red;

                    DropShadowEffect dse3 = new DropShadowEffect();

                    dse3.BlurRadius = 35;
                    dse3.Opacity = 1.0;
                    dse3.ShadowDepth = 0;
                    dse3.Color = Colors.Red;

                    brdS3.Effect = dse3;
                    break;




                case "CBtn4":
                    if (brdS4.Background == Brushes.LightGreen) break;
                    brdS4.Background = Brushes.Red;
                    brdS4.BorderBrush = Brushes.Red;

                    DropShadowEffect dse4 = new DropShadowEffect();

                    dse4.BlurRadius = 35;
                    dse4.Opacity = 1.0;
                    dse4.ShadowDepth = 0;
                    dse4.Color = Colors.Red;

                    brdS4.Effect = dse4;
                    break;



                case "CBtn5":
                    if (brdS5.Background == Brushes.LightGreen) break;
                    brdS5.Background = Brushes.Red;
                    brdS5.BorderBrush = Brushes.Red;

                    DropShadowEffect dse5 = new DropShadowEffect();

                    dse5.BlurRadius = 35;
                    dse5.Opacity = 1.0;
                    dse5.ShadowDepth = 0;
                    dse5.Color = Colors.Red;

                    brdS5.Effect = dse5;
                    break;



                case "CBtn6":
                    if (brdS6.Background == Brushes.LightGreen) break;
                    brdS6.Background = Brushes.Red;
                    brdS6.BorderBrush = Brushes.Red;

                    DropShadowEffect dse6 = new DropShadowEffect();

                    dse6.BlurRadius = 35;
                    dse6.Opacity = 1.0;
                    dse6.ShadowDepth = 0;
                    dse6.Color = Colors.Red;

                    brdS6.Effect = dse6;
                    break;



                case "CBtn7":
                    if (brdS7.Background == Brushes.LightGreen) break;
                    brdS7.Background = Brushes.Red;
                    brdS7.BorderBrush = Brushes.Red;

                    DropShadowEffect dse7 = new DropShadowEffect();

                    dse7.BlurRadius = 35;
                    dse7.Opacity = 1.0;
                    dse7.ShadowDepth = 0;
                    dse7.Color = Colors.Red;

                    brdS7.Effect = dse7;
                    break;


                case "CBtn8":
                    if (brdS8.Background == Brushes.LightGreen) break;
                    brdS8.Background = Brushes.Red;
                    brdS8.BorderBrush = Brushes.Red;

                    DropShadowEffect dse8 = new DropShadowEffect();

                    dse8.BlurRadius = 35;
                    dse8.Opacity = 1.0;
                    dse8.ShadowDepth = 0;
                    dse8.Color = Colors.Red;

                    brdS8.Effect = dse8;
                    break;
            }
        }

        private void SetColorEffectsMouseLeave(Grid myGrid)
        {
            switch (myGrid.Name)
            {
                case "CBtn":
                    if (brdS.Background == Brushes.LightGreen) break;
                    brdS.Background = Brushes.Azure;
                    brdS.BorderBrush = Brushes.Azure;

                    DropShadowEffect dse = new DropShadowEffect();

                    dse.BlurRadius = 35;
                    dse.Opacity = 1.0;
                    dse.ShadowDepth = 0;
                    dse.Color = Colors.Azure;

                    brdS.Effect = dse;
                    break;



                case "CBtn1":
                    if (brdS1.Background == Brushes.LightGreen) break;
                    brdS1.Background = Brushes.Azure;
                    brdS1.BorderBrush = Brushes.Azure;

                    DropShadowEffect dse1 = new DropShadowEffect();

                    dse1.BlurRadius = 35;
                    dse1.Opacity = 1.0;
                    dse1.ShadowDepth = 0;
                    dse1.Color = Colors.Azure;

                    brdS1.Effect = dse1;
                    break;




                case "CBtn2":
                    if (brdS2.Background == Brushes.LightGreen) break;
                    brdS2.Background = Brushes.Azure;
                    brdS2.BorderBrush = Brushes.Azure;

                    DropShadowEffect dse2 = new DropShadowEffect();

                    dse2.BlurRadius = 35;
                    dse2.Opacity = 1.0;
                    dse2.ShadowDepth = 0;
                    dse2.Color = Colors.Azure;

                    brdS2.Effect = dse2;
                    break;




                case "CBtn3":
                    if (brdS3.Background == Brushes.LightGreen) break;
                    brdS3.Background = Brushes.Azure;
                    brdS3.BorderBrush = Brushes.Azure;

                    DropShadowEffect dse3 = new DropShadowEffect();

                    dse3.BlurRadius = 35;
                    dse3.Opacity = 1.0;
                    dse3.ShadowDepth = 0;
                    dse3.Color = Colors.Azure;

                    brdS3.Effect = dse3;
                    break;




                case "CBtn4":
                    if (brdS4.Background == Brushes.LightGreen) break;
                    brdS4.Background = Brushes.Azure;
                    brdS4.BorderBrush = Brushes.Azure;

                    DropShadowEffect dse4 = new DropShadowEffect();

                    dse4.BlurRadius = 35;
                    dse4.Opacity = 1.0;
                    dse4.ShadowDepth = 0;
                    dse4.Color = Colors.Azure;

                    brdS4.Effect = dse4;
                    break;



                case "CBtn5":
                    if (brdS5.Background == Brushes.LightGreen) break;
                    brdS5.Background = Brushes.Azure;
                    brdS5.BorderBrush = Brushes.Azure;

                    DropShadowEffect dse5 = new DropShadowEffect();

                    dse5.BlurRadius = 35;
                    dse5.Opacity = 1.0;
                    dse5.ShadowDepth = 0;
                    dse5.Color = Colors.Azure;

                    brdS5.Effect = dse5;
                    break;



                case "CBtn6":
                    if (brdS6.Background == Brushes.LightGreen) break;
                    brdS6.Background = Brushes.Azure;
                    brdS6.BorderBrush = Brushes.Azure;

                    DropShadowEffect dse6 = new DropShadowEffect();

                    dse6.BlurRadius = 35;
                    dse6.Opacity = 1.0;
                    dse6.ShadowDepth = 0;
                    dse6.Color = Colors.Azure;

                    brdS6.Effect = dse6;
                    break;



                case "CBtn7":
                    if (brdS7.Background == Brushes.LightGreen) break;
                    brdS7.Background = Brushes.Azure;
                    brdS7.BorderBrush = Brushes.Azure;

                    DropShadowEffect dse7 = new DropShadowEffect();

                    dse7.BlurRadius = 35;
                    dse7.Opacity = 1.0;
                    dse7.ShadowDepth = 0;
                    dse7.Color = Colors.Azure;

                    brdS7.Effect = dse7;
                    break;


                case "CBtn8":
                    if (brdS8.Background == Brushes.LightGreen) break;
                    brdS8.Background = Brushes.Azure;
                    brdS8.BorderBrush = Brushes.Azure;

                    DropShadowEffect dse8 = new DropShadowEffect();

                    dse8.BlurRadius = 35;
                    dse8.Opacity = 1.0;
                    dse8.ShadowDepth = 0;
                    dse8.Color = Colors.Azure;

                    brdS8.Effect = dse8;
                    break;
            }
        }


        private void SetColorEffectsMouseClick(ToggleButton btn)
        {
            switch (btn.Name)
            {
                case "btn":
                    if (brdS.Background != Brushes.LightGreen)
                    {
                        brdS.Background = Brushes.LightGreen;
                        brdS.BorderBrush = Brushes.LightGreen;

                        DropShadowEffect dse = new DropShadowEffect();

                        dse.BlurRadius = 35;
                        dse.Opacity = 1.0;
                        dse.ShadowDepth = 0;
                        dse.Color = Colors.LightGreen;

                        brdS.Effect = dse;
                        Cheats.Enable(btn.Content.ToString(), Cheats.GameState);
                    }

                    else
                    {
                        brdS.Background = Brushes.Red;
                        brdS.BorderBrush = Brushes.Red;

                        DropShadowEffect dse = new DropShadowEffect();

                        dse.BlurRadius = 35;
                        dse.Opacity = 1.0;
                        dse.ShadowDepth = 0;
                        dse.Color = Colors.Red;

                        brdS.Effect = dse;
                        Cheats.Disable(btn.Content.ToString(), Cheats.GameState);
                    }
                    break;



                case "btn1":
                    if (brdS1.Background != Brushes.LightGreen)
                    {
                        brdS1.Background = Brushes.LightGreen;
                        brdS1.BorderBrush = Brushes.LightGreen;

                        DropShadowEffect dse1 = new DropShadowEffect();

                        dse1.BlurRadius = 35;
                        dse1.Opacity = 1.0;
                        dse1.ShadowDepth = 0;
                        dse1.Color = Colors.LightGreen;

                        brdS1.Effect = dse1;
                        Cheats.Enable(btn.Content.ToString(), Cheats.GameState);
                    }

                    else
                    {
                        brdS1.Background = Brushes.Red;
                        brdS1.BorderBrush = Brushes.Red;

                        DropShadowEffect dse1 = new DropShadowEffect();

                        dse1.BlurRadius = 35;
                        dse1.Opacity = 1.0;
                        dse1.ShadowDepth = 0;
                        dse1.Color = Colors.Red;

                        brdS1.Effect = dse1;
                        Cheats.Disable(btn.Content.ToString(), Cheats.GameState);
                    }
                    break;




                case "btn2":
                    if (brdS2.Background != Brushes.LightGreen)
                    {
                        brdS2.Background = Brushes.LightGreen;
                        brdS2.BorderBrush = Brushes.LightGreen;

                        DropShadowEffect dse2 = new DropShadowEffect();

                        dse2.BlurRadius = 35;
                        dse2.Opacity = 1.0;
                        dse2.ShadowDepth = 0;
                        dse2.Color = Colors.LightGreen;

                        brdS2.Effect = dse2;
                        Cheats.Enable(btn.Content.ToString(), Cheats.GameState);
                    }
                    else
                    {
                        brdS2.Background = Brushes.Red;
                        brdS2.BorderBrush = Brushes.Red;

                        DropShadowEffect dse2 = new DropShadowEffect();

                        dse2.BlurRadius = 35;
                        dse2.Opacity = 1.0;
                        dse2.ShadowDepth = 0;
                        dse2.Color = Colors.Red;

                        brdS2.Effect = dse2;
                        Cheats.Disable(btn.Content.ToString(), Cheats.GameState);
                    }
                    break;




                case "btn3":
                    if (brdS3.Background != Brushes.LightGreen)
                    {
                        brdS3.Background = Brushes.LightGreen;
                        brdS3.BorderBrush = Brushes.LightGreen;

                        DropShadowEffect dse3 = new DropShadowEffect();

                        dse3.BlurRadius = 35;
                        dse3.Opacity = 1.0;
                        dse3.ShadowDepth = 0;
                        dse3.Color = Colors.LightGreen;

                        brdS3.Effect = dse3;
                        Cheats.Enable(btn.Content.ToString(), Cheats.GameState);
                    }
                    else
                    {
                        brdS3.Background = Brushes.Red;
                        brdS3.BorderBrush = Brushes.Red;

                        DropShadowEffect dse3 = new DropShadowEffect();

                        dse3.BlurRadius = 35;
                        dse3.Opacity = 1.0;
                        dse3.ShadowDepth = 0;
                        dse3.Color = Colors.Red;

                        brdS3.Effect = dse3;
                        Cheats.Disable(btn.Content.ToString(), Cheats.GameState);
                    }
                    break;




                case "btn4":
                    if (brdS4.Background != Brushes.LightGreen)
                    {
                        brdS4.Background = Brushes.LightGreen;
                        brdS4.BorderBrush = Brushes.LightGreen;

                        DropShadowEffect dse4 = new DropShadowEffect();

                        dse4.BlurRadius = 35;
                        dse4.Opacity = 1.0;
                        dse4.ShadowDepth = 0;
                        dse4.Color = Colors.LightGreen;

                        brdS4.Effect = dse4;
                        Cheats.Enable(btn.Content.ToString(), Cheats.GameState);
                    }
                    else
                    {
                        brdS4.Background = Brushes.Red;
                        brdS4.BorderBrush = Brushes.Red;

                        DropShadowEffect dse4 = new DropShadowEffect();

                        dse4.BlurRadius = 35;
                        dse4.Opacity = 1.0;
                        dse4.ShadowDepth = 0;
                        dse4.Color = Colors.Red;

                        brdS4.Effect = dse4;
                        Cheats.Disable(btn.Content.ToString(), Cheats.GameState);

                    }
                    break;



                case "btn5":
                    if (brdS5.Background != Brushes.LightGreen)
                    {
                        brdS5.Background = Brushes.LightGreen;
                        brdS5.BorderBrush = Brushes.LightGreen;

                        DropShadowEffect dse5 = new DropShadowEffect();

                        dse5.BlurRadius = 35;
                        dse5.Opacity = 1.0;
                        dse5.ShadowDepth = 0;
                        dse5.Color = Colors.LightGreen;

                        brdS5.Effect = dse5;
                        Cheats.Enable(btn.Content.ToString(), Cheats.GameState);
                    }
                    else
                    {
                        brdS5.Background = Brushes.Red;
                        brdS5.BorderBrush = Brushes.Red;

                        DropShadowEffect dse5 = new DropShadowEffect();

                        dse5.BlurRadius = 35;
                        dse5.Opacity = 1.0;
                        dse5.ShadowDepth = 0;
                        dse5.Color = Colors.Red;

                        brdS5.Effect = dse5;
                        Cheats.Disable(btn.Content.ToString(), Cheats.GameState);
                    }
                    break;



                case "btn6":
                    if (brdS6.Background != Brushes.LightGreen)
                    {
                        brdS6.Background = Brushes.LightGreen;
                        brdS6.BorderBrush = Brushes.LightGreen;

                        DropShadowEffect dse6 = new DropShadowEffect();

                        dse6.BlurRadius = 35;
                        dse6.Opacity = 1.0;
                        dse6.ShadowDepth = 0;
                        dse6.Color = Colors.LightGreen;

                        brdS6.Effect = dse6;
                        Cheats.Enable(btn.Content.ToString(), Cheats.GameState);
                    }
                    else
                    {
                        brdS6.Background = Brushes.Red;
                        brdS6.BorderBrush = Brushes.Red;

                        DropShadowEffect dse6 = new DropShadowEffect();

                        dse6.BlurRadius = 35;
                        dse6.Opacity = 1.0;
                        dse6.ShadowDepth = 0;
                        dse6.Color = Colors.Red;

                        brdS6.Effect = dse6;
                        Cheats.Disable(btn.Content.ToString(), Cheats.GameState);
                    }
                    break;



                case "btn7":
                    if (brdS7.Background != Brushes.LightGreen)
                    {
                        brdS7.Background = Brushes.LightGreen;
                        brdS7.BorderBrush = Brushes.LightGreen;

                        DropShadowEffect dse7 = new DropShadowEffect();

                        dse7.BlurRadius = 35;
                        dse7.Opacity = 1.0;
                        dse7.ShadowDepth = 0;
                        dse7.Color = Colors.LightGreen;

                        brdS7.Effect = dse7;
                        Cheats.Enable(btn.Content.ToString(), Cheats.GameState);

                    }
                    else
                    {
                        brdS7.Background = Brushes.Red;
                        brdS7.BorderBrush = Brushes.Red;

                        DropShadowEffect dse7 = new DropShadowEffect();

                        dse7.BlurRadius = 35;
                        dse7.Opacity = 1.0;
                        dse7.ShadowDepth = 0;
                        dse7.Color = Colors.Red;

                        brdS7.Effect = dse7;
                        Cheats.Disable(btn.Content.ToString(), Cheats.GameState);
                    }
                    break;


                case "btn8":
                    if (brdS8.Background != Brushes.LightGreen)
                    {
                        brdS8.Background = Brushes.LightGreen;
                        brdS8.BorderBrush = Brushes.LightGreen;

                        DropShadowEffect dse8 = new DropShadowEffect();

                        dse8.BlurRadius = 35;
                        dse8.Opacity = 1.0;
                        dse8.ShadowDepth = 0;
                        dse8.Color = Colors.LightGreen;

                        brdS8.Effect = dse8;
                        Cheats.Enable(btn.Content.ToString(), Cheats.GameState);
                    }
                    else
                    {
                        brdS8.Background = Brushes.Red;
                        brdS8.BorderBrush = Brushes.Red;

                        DropShadowEffect dse8 = new DropShadowEffect();

                        dse8.BlurRadius = 35;
                        dse8.Opacity = 1.0;
                        dse8.ShadowDepth = 0;
                        dse8.Color = Colors.Red;

                        brdS8.Effect = dse8;
                        Cheats.Disable(btn.Content.ToString(), Cheats.GameState);
                    }
                    break;
            }
        }





        private void CBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            SetColorEffectsMouseEnter(sender as Grid);

            GridMouseEnter(sender as Grid);

        }

        private void CBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            SetColorEffectsMouseLeave(sender as Grid);

            GridMouseLeave(sender as Grid);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            SetColorEffectsMouseClick(sender as ToggleButton);
        }

    }
}
