using ModernCombat5Trainer.UserControls;
using ModernCombatTrainer.GameMemory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace ModernCombat5Trainer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ControlBoxImagesAnimations(Image img, int width, int height)
        {
            var WidthAnimation = new DoubleAnimation() { To = width, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
            var HeightAnimation = new DoubleAnimation() { To = height, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height", null));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(WidthAnimation);
            storyboard.Children.Add(HeightAnimation);
            storyboard.Begin(img);
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            var button = sender as Button;



            var WidthAnimation = new DoubleAnimation() { To = 210, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
            var WidthAnimation1 = new DoubleAnimation() { To = 150, Duration = TimeSpan.FromSeconds(0.4) };
            Storyboard.SetTargetProperty(WidthAnimation1, new PropertyPath("Width", null));
            var WidthAnimation2 = new DoubleAnimation() { To = 190, Duration = TimeSpan.FromSeconds(0.6) };
            Storyboard.SetTargetProperty(WidthAnimation2, new PropertyPath("Width", null));

            var HeightAnimation = new DoubleAnimation() { To = 70, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height", null));

            var FontAnimation = new DoubleAnimation() { To = 14, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(FontAnimation, new PropertyPath("FontSize", null));



            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(FontAnimation);
            storyboard.Children.Add(WidthAnimation);
            storyboard.Children.Add(WidthAnimation1);
            storyboard.Children.Add(WidthAnimation2);
            storyboard.Children.Add(HeightAnimation);
            storyboard.Begin(button);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            var button = sender as Button;

            var WidthAnimation = new DoubleAnimation() { To = 150, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width", null));
            var WidthAnimation1 = new DoubleAnimation() { To = 190, Duration = TimeSpan.FromSeconds(0.4) };
            Storyboard.SetTargetProperty(WidthAnimation1, new PropertyPath("Width", null));
            var WidthAnimation2 = new DoubleAnimation() { To = 170, Duration = TimeSpan.FromSeconds(0.6) };
            Storyboard.SetTargetProperty(WidthAnimation2, new PropertyPath("Width", null));

            var HeightAnimation = new DoubleAnimation() { To = 55, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height", null));

            var FontAnimation = new DoubleAnimation() { To = 12, Duration = TimeSpan.FromSeconds(0.2) };
            Storyboard.SetTargetProperty(FontAnimation, new PropertyPath("FontSize", null));


            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(FontAnimation);
            storyboard.Children.Add(WidthAnimation);
            storyboard.Children.Add(WidthAnimation1);
            storyboard.Children.Add(WidthAnimation2);
            storyboard.Children.Add(HeightAnimation);
            storyboard.Begin(button);
        }



        private void aClose_MouseLeave(object sender, MouseEventArgs e)
        {
            ControlBoxImagesAnimations(sender as Image, 30, 30);
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            new MsgInfo().ShowDialog();
        }

        private void btnInfo_MouseEnter(object sender, MouseEventArgs e)
        {
            ControlBoxImagesAnimations(Info, 38, 38);
        }

        private void btnInfo_MouseLeave(object sender, MouseEventArgs e)
        {
            ControlBoxImagesAnimations(Info, 30, 30);
        }

        private void aClose_MouseEnter(object sender, MouseEventArgs e)
        {
            ControlBoxImagesAnimations(sender as Image, 38, 38);
        }

        private void aClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void aMinimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void aMinimize_MouseEnter(object sender, MouseEventArgs e)
        {
            ControlBoxImagesAnimations(sender as Image, 38, 23);
        }

        private void aMinimize_MouseLeave(object sender, MouseEventArgs e)
        {
            ControlBoxImagesAnimations(sender as Image, 30, 15);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void FlipAnimation(UserControl ToShow, UserControl ToHide)
        {
            RotateTransform3D rotateTransform = new RotateTransform3D();
            ViewPort.Transform = rotateTransform;

            AxisAngleRotation3D rotateAxis1 = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 90);
            AxisAngleRotation3D rotateAxis2 = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);

            AxisAngleRotation3D rotateAxis3 = new AxisAngleRotation3D(new Vector3D(0, 1, 0), -90);

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

        private string CurrentInterface = "Player";

        private void Button_Click(object sender, RoutedEventArgs e)
        {



            switch ((sender as Button).Content)
            {
                case "Player":

                    switch (CurrentInterface)
                    {
                        case "Movements":
                            FlipAnimation(uc_player, uc_movements);
                            CurrentInterface = "Player";
                            break;
                        case "Weapons":
                            FlipAnimation(uc_player, uc_weapons);
                            CurrentInterface = "Player";
                            break;
                        case "Dlls":
                            FlipAnimation(uc_player, uc_dlls);
                            CurrentInterface = "Player";
                            break;
                        case "Cores":
                            FlipAnimation(uc_player, uc_cores);
                            CurrentInterface = "Player";
                            break;
                        case "Others":
                            FlipAnimation(uc_player, uc_others);
                            CurrentInterface = "Player";
                            break;
                    }
                    break;



                case "Movements":

                    switch (CurrentInterface)
                    {
                        case "Player":
                            FlipAnimation(uc_movements, uc_player);
                            CurrentInterface = "Movements";
                            break;
                        case "Weapons":
                            FlipAnimation(uc_movements, uc_weapons);
                            CurrentInterface = "Movements";
                            break;
                        case "Dlls":
                            FlipAnimation(uc_movements, uc_dlls);
                            CurrentInterface = "Movements";
                            break;
                        case "Cores":
                            FlipAnimation(uc_movements, uc_cores);
                            CurrentInterface = "Movements";
                            break;
                        case "Others":
                            FlipAnimation(uc_movements, uc_others);
                            CurrentInterface = "Movements";
                            break;
                    }
                    break;




                case "Weapons":
                    switch (CurrentInterface)
                    {
                        case "Player":
                            FlipAnimation(uc_weapons, uc_player);
                            CurrentInterface = "Weapons";
                            break;
                        case "Movements":
                            FlipAnimation(uc_weapons, uc_movements);
                            CurrentInterface = "Weapons";
                            break;
                        case "Dlls":
                            FlipAnimation(uc_weapons, uc_dlls);
                            CurrentInterface = "Weapons";
                            break;
                        case "Cores":
                            FlipAnimation(uc_weapons, uc_cores);
                            CurrentInterface = "Weapons";
                            break;
                        case "Others":
                            FlipAnimation(uc_weapons, uc_others);
                            CurrentInterface = "Weapons";
                            break;
                    }
                    break;




                case "Dlls":
                    switch (CurrentInterface)
                    {
                        case "Player":
                            FlipAnimation(uc_dlls, uc_player);
                            CurrentInterface = "Dlls";
                            break;
                        case "Movements":
                            FlipAnimation(uc_dlls, uc_movements);
                            CurrentInterface = "Dlls";
                            break;
                        case "Weapons":
                            FlipAnimation(uc_dlls, uc_weapons);
                            CurrentInterface = "Dlls";
                            break;
                        case "Cores":
                            FlipAnimation(uc_dlls, uc_cores);
                            CurrentInterface = "Dlls";
                            break;
                        case "Others":
                            FlipAnimation(uc_dlls, uc_others);
                            CurrentInterface = "Dlls";
                            break;
                    }
                    break;




                case "Cores":
                    switch (CurrentInterface)
                    {
                        case "Player":
                            FlipAnimation(uc_cores, uc_player);
                            CurrentInterface = "Cores";
                            break;
                        case "Movements":
                            FlipAnimation(uc_cores, uc_movements);
                            CurrentInterface = "Cores";
                            break;
                        case "Dlls":
                            FlipAnimation(uc_cores, uc_dlls);
                            CurrentInterface = "Cores";
                            break;
                        case "Weapons":
                            FlipAnimation(uc_cores, uc_weapons);
                            CurrentInterface = "Cores";
                            break;
                        case "Others":
                            FlipAnimation(uc_cores, uc_others);
                            CurrentInterface = "Cores";
                            break;
                    }
                    break;




                case "Others":
                    switch (CurrentInterface)
                    {
                        case "Player":
                            FlipAnimation(uc_others, uc_player);
                            CurrentInterface = "Others";
                            break;
                        case "Movements":
                            FlipAnimation(uc_others, uc_movements);
                            CurrentInterface = "Others";
                            break;
                        case "Dlls":
                            FlipAnimation(uc_others, uc_dlls);
                            CurrentInterface = "Others";
                            break;
                        case "Cores":
                            FlipAnimation(uc_others, uc_cores);
                            CurrentInterface = "Others";
                            break;
                        case "Weapons":
                            FlipAnimation(uc_others, uc_weapons);
                            CurrentInterface = "Others";
                            break;
                    }
                    break;
            }



        }

        
        bool GsChanged = true;
        int procId;
        bool canfocus = false;
        IntPtr EntityAtCursor;


        private void TmState_Tick(object sender, EventArgs e)
        {
            Cheats.GameState = Memory.AttachProcess("WindowsEntryPoint.Windows_W10");
            if (Cheats.GameState)
            {
                if (GsChanged)
                {
                    Cheats.ModuleBase = Memory.GetModuleAddress("WindowsEntryPoint.Windows_W10", "WindowsEntryPoint.Windows_W10");
                    procId = Memory.GetProcessID("WindowsEntryPoint.Windows_W10");
                    txtProcessId.Text = "Process ID: 0x" + procId.ToString("X");
                    txtGameState.Text = "Game State: Found";
                    Cheats.WallHackAllocatedMemory = IntPtr.Zero;
                    Cheats.RapidFireAllocatedMemory = IntPtr.Zero;
                    Cheats.SWAllocatedMemory = IntPtr.Zero;
                    Cheats.SpeedAllocatedMemory = IntPtr.Zero;
                    GsChanged = false;
                }
            }
            else
            {
                txtProcessId.Text = "Process ID: Null";
                txtGameState.Text = "Game State: Not Found";
                GsChanged = true;
            }
        }


        private float GetDistance(float ecX, float ecY, float ecZ, float lpX, float lpY, float lpZ)
        {
            return (float)Math.Sqrt(Math.Pow((double)(ecX - lpX), 2.0) + Math.Pow((double)(ecY - lpY), 2.0) + Math.Pow((double)(ecZ - lpZ), 2.0));
        }

        private void TmCPointers_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Cheats.GameState)
                {
                    if (Cheats.jump)
                    {
                        if (Memory.GetAsyncKeyState((ushort)Memory.VirtualKeys.V) != 0)
                        {
                            IntPtr CoordsZ = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x700, 0x0, 0x858, 0x8, 0x60 }, 5);
                            Memory.Write<float>(CoordsZ, Memory.Read<float>(CoordsZ) + 1.5f);
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                    if (Cheats.ammo)
                    {
                        IntPtr Ammo1 = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x308, 0x140, 0x8, 0x70, 0x0 }, 5);
                        IntPtr Ammo2 = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x308, 0x140, 0x8, 0x68 }, 4);
                        Memory.Write<uint>(Ammo1, 3460853931);
                        Memory.Write<uint>(Ammo2, 1999598699);
                    }
                    if (Cheats.teleport)
                    {
                        if (Memory.GetAsyncKeyState((ushort)Memory.VirtualKeys.B) != 0)
                        {
                            while (Memory.GetAsyncKeyState((ushort)Memory.VirtualKeys.B) != 0) ;
                            IntPtr CoordsX = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x700, 0x0, 0x858, 0x8, 0x58 }, 5);
                            IntPtr LookAtPos = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x308, 0x14 }, 2);
                            byte[] buffer = Memory.ReadBytes(LookAtPos, 12);
                            Memory.WriteBytes(CoordsX, buffer, 12);
                        }
                    }

                    if (Cheats.grenades)
                    {
                        IntPtr G2 = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x308, 0x1b8, 0x0 }, 3);
                        IntPtr G1 = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x308, 0x1b8, 0x8, 0x0 }, 4);
                        Memory.Write<uint>(G1, 3460853931);
                        Memory.Write<uint>(G2, 1999598699);
                    }
                    if (Cheats.autoshoot)
                    {
                        IntPtr Flag = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.TargetType_Offset, new int[] { 0x718, 0x190, 0x70, 0x190, 0x40, 0x218, 0x0 }, 7);
                        IntPtr Shoot = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.ShootState_Offset, new int[] { 0x8, 0x50, 0x58, 0x20, 0x20, 0x460 }, 6);
                        if (Memory.Read<byte>(Flag) == 7)
                        {
                            Memory.Write<byte>(Shoot, 1);
                        }

                    }

                    if (Cheats.aimfocus)
                    {

                        if (Memory.GetAsyncKeyState((ushort)Memory.VirtualKeys.RightButton) != 0)
                        {

                            if (!canfocus)
                            {
                                EntityAtCursor = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x308, 0x8, 0 }, 3);
                                if (EntityAtCursor != IntPtr.Zero)
                                    canfocus = true;
                            }

                            //IntPtr WeaponLocation = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x308, 0x68 }, 2);
                            // IntPtr HPos = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x308, 0x90 , 0x30, 0x48, 0x30, 0x8, 0x18, 0x40}, 8);
                            // IntPtr EnemyHeadPos = Memory.GetPointerAddress64Bit(EntityAtCursor + 0x160, new int[] { 0x0, 0x78, 0x0, 0x38 ,0xc8, 0x38 }, 6);

                            IntPtr
                                PitchAddress = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x700, 0x0, 0x858, 0x8, 0x6c }, 5),
                                YawAddress = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x700, 0x0, 0x610 }, 3),
                                PlayerHeadPos = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x308, 0x68 }, 2),
                                EnemyHeadPos = Memory.GetPointerAddress64Bit(EntityAtCursor + 0x160, new int[] { 0x0, 0x78, 0x0, 0x38, 0xc8, 0x30 }, 6),
                                MyTeamIdPtr = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x700, 0x0, 0x858, 0x8, 0xa0 }, 5),
                                EnemyHp = Memory.GetPointerAddress64Bit(EntityAtCursor + 0x1a8, new int[] { 0x28 }, 1);

                            int
                                MyTeamID = Memory.Read<int>(MyTeamIdPtr),
                                TargetEntityTeamId = Memory.Read<int>(EntityAtCursor + 0xa0);

                            float
                                EnemyHeadX = Memory.Read<float>(EnemyHeadPos),
                                EnemyHeadY = Memory.Read<float>(EnemyHeadPos + 4),
                                EnemyHeadZ = Memory.Read<float>(EnemyHeadPos + 8),
                                EnemyHP = Memory.Read<float>(EnemyHp),

                                PlayerHeadX = Memory.Read<float>(PlayerHeadPos),
                                PlayerHeadY = Memory.Read<float>(PlayerHeadPos + 4),
                                PlayerHeadZ = Memory.Read<float>(PlayerHeadPos + 8),

                                Yaw = (float)(Math.Asin((EnemyHeadZ - PlayerHeadZ) / GetDistance(EnemyHeadX, EnemyHeadY, EnemyHeadZ, PlayerHeadX, PlayerHeadY, PlayerHeadZ)) * 180.0f / Math.PI),
                                Pitch = -(float)(Math.Atan2(EnemyHeadX - PlayerHeadX, EnemyHeadY - PlayerHeadY) / Math.PI * 180.0f);

                            if ((MyTeamID != TargetEntityTeamId) && (EnemyHP > 34.0f))
                            {
                                Memory.Write<float>(PitchAddress, Pitch);
                                Memory.Write<float>(YawAddress, Yaw);
                            }

                        }
                        else { canfocus = false; }
                    }

                    if (Cheats.noclipv2)
                    {
                        if (Memory.GetAsyncKeyState((ushort)Memory.VirtualKeys.Space) != 0)
                        {
                            IntPtr CoordsX = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x700, 0x0, 0x858, 0x8, 0x58 }, 5);
                            IntPtr CoordsY = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x700, 0x0, 0x858, 0x8, 0x5C }, 5);
                            float roll = Memory.Read<float>(Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x700, 0x0, 0x858, 0x8, 0x6c }, 5));

                            if ((roll < 30.0f) || (roll > 320.0f))
                            {
                                Memory.Write<float>(CoordsY, Memory.Read<float>(CoordsY) + 1.0f);
                            }
                            else if ((roll < 320.0f) && (roll > 230.0f))
                            {
                                Memory.Write<float>(CoordsX, Memory.Read<float>(CoordsX) + 1.0f);
                            }
                            else if ((roll < 230.0f) && (roll > 130.0f))
                            {
                                Memory.Write<float>(CoordsY, Memory.Read<float>(CoordsY) -1.0f);
                            }
                            else
                            {
                                Memory.Write<float>(CoordsX, Memory.Read<float>(CoordsX) - 1.0f);
                            }
                            System.Threading.Thread.Sleep(100);
                        }
                    }

                    if (Cheats.unlimitedhp)
                    {
                        IntPtr HP = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x700, 0x0, 0x858, 0x8, 0x1A8 ,0x28 }, 6);
                        Memory.Write<float>(HP, 300.0f);
                        System.Threading.Thread.Sleep(50);
                    }

                }
            }
            catch { }
        }


        private void TmCores_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Cheats.GameState)
                {
                    if (Cheats.armorpiercer) 
                    {
                        IntPtr Core = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.CoresBase_Offset, new int[] { 0x380, 0xdf8 }, 2);
                        Memory.Write<float>(Core, 999.0f);
                    }

                    if (Cheats.evileye)
                    {
                        IntPtr Core = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.CoresBase_Offset, new int[] { 0x380, 0x600 }, 2);
                        Memory.Write<float>(Core, 999.0f);
                    }

                    if (Cheats.highpowered)
                    {
                        IntPtr Core = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.CoresBase_Offset, new int[] { 0x380, 0xf30 }, 2);
                        Memory.Write<float>(Core, 999.0f);
                    }

                    if (Cheats.impetum)
                    {
                        IntPtr Core = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.CoresBase_Offset, new int[] { 0x380, 0xbd0 }, 2);
                        Memory.Write<float>(Core, 999.0f);
                    }

                    if (Cheats.murderblitz)
                    {
                        IntPtr Core = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.CoresBase_Offset, new int[] { 0x380, 0x3d8 }, 2);
                        Memory.Write<float>(Core, 999.0f);
                    }

                    if (Cheats.sixthsense)
                    {
                        IntPtr Core = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.CoresBase_Offset, new int[] { 0x380, 0x2e8 }, 2);
                        Memory.Write<float>(Core, 999.0f);
                    }

                    if (Cheats.snowflake)
                    {
                        IntPtr Core = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.CoresBase_Offset, new int[] { 0x380, 0xc30 }, 2);
                        Memory.Write<float>(Core, 999.0f);
                    }

                    if (Cheats.toxicarea)
                    {
                        IntPtr Core = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.CoresBase_Offset, new int[] { 0x380, 0x228 }, 2);
                        Memory.Write<float>(Core, 999.0f);
                    }

                    if (Cheats.yokai)
                    {
                        IntPtr Core = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.CoresBase_Offset, new int[] { 0x380, 0xa08 }, 2);
                        Memory.Write<float>(Core, 999.0f);
                    }

                }
            }
            catch { }
        }


        private void MainW_Loaded(object sender, RoutedEventArgs e)
        {
            var OpacityAnimation = new DoubleAnimation() { From = 0, To = 1, Duration = TimeSpan.FromSeconds(0.3) };
            Storyboard.SetTargetProperty(OpacityAnimation, new PropertyPath("Opacity", null));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(OpacityAnimation);
            storyboard.Begin(this);

            DispatcherTimer TmState = new DispatcherTimer();
            TmState.Tick += new EventHandler(TmState_Tick);
            TmState.Interval = new TimeSpan(0, 0, 0, 0, 100);
            TmState.Start();

            DispatcherTimer TmCPointers = new DispatcherTimer();
            TmCPointers.Tick += new EventHandler(TmCPointers_Tick);
            TmCPointers.Interval = new TimeSpan(0, 0, 0, 0, 50);
            TmCPointers.Start();

            DispatcherTimer TmCores = new DispatcherTimer();
            TmCores.Tick += new EventHandler(TmCores_Tick);
            TmCores.Interval = new TimeSpan(0, 0, 0, 1, 0);
            TmCores.Start();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            var ps = new ProcessStartInfo("https://www.youtube.com/@TarekExister")
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }
    }
}