using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using ModernCombatTrainer.GameMemory;

namespace ModernCombat5Trainer.UserControls
{
    /// <summary>
    /// Interaction logic for ucDlls.xaml
    /// </summary>
    public partial class ucDlls : UserControl
    {
        public ucDlls()
        {
            InitializeComponent();
        }


        private void GridMouseLeave(Grid myGrid)
        {

            switch (myGrid.Name) 
            {
                case "CBtn":
                    var WidthAnimation = new DoubleAnimation() { To = 120, Duration = TimeSpan.FromSeconds(0.2) };
                    Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
                    var WidthAnimation1 = new DoubleAnimation() { To = 180, Duration = TimeSpan.FromSeconds(0.4) };
                    Storyboard.SetTargetProperty(WidthAnimation1, new PropertyPath("Width", null));
                    var WidthAnimation2 = new DoubleAnimation() { To = 150, Duration = TimeSpan.FromSeconds(0.6) };
                    Storyboard.SetTargetProperty(WidthAnimation2, new PropertyPath("Width", null));
                    var HeightAnimation = new DoubleAnimation() { To = 50, Duration = TimeSpan.FromSeconds(0.2) };
                    Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height", null));
                    Storyboard storyboard = new Storyboard();
                    storyboard.Children.Add(WidthAnimation);
                    storyboard.Children.Add(WidthAnimation1);
                    storyboard.Children.Add(WidthAnimation2);
                    storyboard.Children.Add(HeightAnimation);
                    storyboard.Begin(myGrid);
                    break;

                case "CBtn1":
                    var cWidthAnimation = new DoubleAnimation() { To = 420, Duration = TimeSpan.FromSeconds(0.2) };
                    Storyboard.SetTargetProperty(cWidthAnimation, new PropertyPath("Width", null));
                    var cWidthAnimation1 = new DoubleAnimation() { To = 480, Duration = TimeSpan.FromSeconds(0.4) };
                    Storyboard.SetTargetProperty(cWidthAnimation1, new PropertyPath("Width", null));
                    var cWidthAnimation2 = new DoubleAnimation() { To = 450, Duration = TimeSpan.FromSeconds(0.6) };
                    Storyboard.SetTargetProperty(cWidthAnimation2, new PropertyPath("Width", null));
                    var cHeightAnimation = new DoubleAnimation() { To = 50, Duration = TimeSpan.FromSeconds(0.2) };
                    Storyboard.SetTargetProperty(cHeightAnimation, new PropertyPath("Height", null));
                    Storyboard cstoryboard = new Storyboard();
                    cstoryboard.Children.Add(cWidthAnimation);
                    cstoryboard.Children.Add(cWidthAnimation1);
                    cstoryboard.Children.Add(cWidthAnimation2);
                    cstoryboard.Children.Add(cHeightAnimation);
                    cstoryboard.Begin(myGrid);
                    break;
            }
        }

        private void GridMouseEnter(Grid myGrid)
        {

            switch (myGrid.Name) 
            {
                case "CBtn":
                    var WidthAnimation = new DoubleAnimation() { To = 200, Duration = TimeSpan.FromSeconds(0.2) };
                    Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
                    var WidthAnimation1 = new DoubleAnimation() { To = 150, Duration = TimeSpan.FromSeconds(0.4) };
                    Storyboard.SetTargetProperty(WidthAnimation1, new PropertyPath("Width", null));
                    var WidthAnimation2 = new DoubleAnimation() { To = 180, Duration = TimeSpan.FromSeconds(0.6) };
                    Storyboard.SetTargetProperty(WidthAnimation2, new PropertyPath("Width", null));
                    var HeightAnimation = new DoubleAnimation() { To = 70, Duration = TimeSpan.FromSeconds(0.2) };
                    Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height", null));
                    Storyboard storyboard = new Storyboard();
                    storyboard.Children.Add(WidthAnimation);
                    storyboard.Children.Add(WidthAnimation1);
                    storyboard.Children.Add(WidthAnimation2);
                    storyboard.Children.Add(HeightAnimation);
                    storyboard.Begin(myGrid);
                    break;
                case "CBtn1":
                    var cWidthAnimation = new DoubleAnimation() { To = 500, Duration = TimeSpan.FromSeconds(0.2) };
                    Storyboard.SetTargetProperty(cWidthAnimation, new PropertyPath("Width", null));
                    var cWidthAnimation1 = new DoubleAnimation() { To = 450, Duration = TimeSpan.FromSeconds(0.4) };
                    Storyboard.SetTargetProperty(cWidthAnimation1, new PropertyPath("Width", null));
                    var cWidthAnimation2 = new DoubleAnimation() { To = 480, Duration = TimeSpan.FromSeconds(0.6) };
                    Storyboard.SetTargetProperty(cWidthAnimation2, new PropertyPath("Width", null));
                    var cHeightAnimation = new DoubleAnimation() { To = 70, Duration = TimeSpan.FromSeconds(0.2) };
                    Storyboard.SetTargetProperty(cHeightAnimation, new PropertyPath("Height", null));
                    Storyboard cstoryboard = new Storyboard();
                    cstoryboard.Children.Add(cWidthAnimation);
                    cstoryboard.Children.Add(cWidthAnimation1);
                    cstoryboard.Children.Add(cWidthAnimation2);
                    cstoryboard.Children.Add(cHeightAnimation);
                    cstoryboard.Begin(myGrid);
                    break;
            }
        }


        private void SetColorEffectsMouseEnter(Grid myGrid)
        {
            switch (myGrid.Name)
            {
                case "CBtn":

                    brdS.Background = System.Windows.Media.Brushes.Red;
                    brdS.BorderBrush = System.Windows.Media.Brushes.Red;
                    brdS1.Background = System.Windows.Media.Brushes.Red;
                    brdS1.BorderBrush = System.Windows.Media.Brushes.Red;

                    DropShadowEffect dse = new DropShadowEffect();
                    dse.BlurRadius = 35;
                    dse.Opacity = 1.0;
                    dse.ShadowDepth = 0;
                    dse.Color = Colors.Red;
                    brdS.Effect = dse;
                    brdS1.Effect = dse;
                    break;



                case "CBtn1":
                    brdS2.Background = System.Windows.Media.Brushes.Red;
                    brdS2.BorderBrush = System.Windows.Media.Brushes.Red;
                    brdS3.Background = System.Windows.Media.Brushes.Red;
                    brdS3.BorderBrush = System.Windows.Media.Brushes.Red;

                    DropShadowEffect dse2 = new DropShadowEffect();
                    dse2.BlurRadius = 35;
                    dse2.Opacity = 1.0;
                    dse2.ShadowDepth = 0;
                    dse2.Color = Colors.Red;
                    brdS2.Effect = dse2;
                    brdS3.Effect = dse2;
                    break;
            }
        }

        private void SetColorEffectsMouseLeave(Grid myGrid)
        {
            switch (myGrid.Name)
            {
                case "CBtn":
                    brdS.Background =  System.Windows.Media.Brushes.Azure;
                    brdS.BorderBrush = System.Windows.Media.Brushes.Azure;
                    brdS1.Background = System.Windows.Media.Brushes.Azure;
                    brdS1.BorderBrush =System.Windows.Media.Brushes.Azure;

                    DropShadowEffect dse = new DropShadowEffect();
                    dse.BlurRadius = 35;
                    dse.Opacity = 1.0;
                    dse.ShadowDepth = 0;
                    dse.Color = Colors.Azure;
                    brdS.Effect = dse;
                    brdS1.Effect = dse;
                    break;



                case "CBtn1":
                    brdS2.Background =  System.Windows.Media.Brushes.Azure;
                    brdS2.BorderBrush = System.Windows.Media.Brushes.Azure;
                    brdS3.Background =  System.Windows.Media.Brushes.Azure;
                    brdS3.BorderBrush = System.Windows.Media.Brushes.Azure;

                    DropShadowEffect dse2 = new DropShadowEffect();
                    dse2.BlurRadius = 35;
                    dse2.Opacity = 1.0;
                    dse2.ShadowDepth = 0;
                    dse2.Color = Colors.Azure;
                    brdS2.Effect = dse2;
                    brdS3.Effect = dse2;
                    break;
            }
        }


        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (lblPath.Content.Equals("Dll Path"))
            {
                Application.Current.MainWindow.Topmost = false;
                new CustomMessageBox("Wrong Path!").ShowDialog();
                return;
            }
            else 
            {
                if (Cheats.GameState)
                {
                    int pid = Memory.GetProcessID("WindowsEntryPoint.Windows_W10");
                    string dllPath = lblPath.Content.ToString();
                    DllPermission.SetDllPermission(dllPath);
                    InjectDll.Injectlibrary(pid, dllPath);

                    Application.Current.MainWindow.Topmost = false;
                    new CustomMessageBox("Dll Has Been Injected Successfully").ShowDialog();
                }
                else 
                {
                    Application.Current.MainWindow.Topmost = false;
                    new CustomMessageBox("Game Not Found!").ShowDialog();
                }
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

        private void btnPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Dll Files(.dll)| *.dll";

            if (ofd.ShowDialog() == true)
            {
                lblPath.Content = ofd.FileName;
            }
            else
            {
                return;
            }
        }
    }
}
