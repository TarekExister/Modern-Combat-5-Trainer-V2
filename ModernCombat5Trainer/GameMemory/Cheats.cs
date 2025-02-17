using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;

namespace ModernCombatTrainer.GameMemory
{
    public static class Cheats
    {

        public static bool jump, ammo, noclipv2,unlimitedhp, teleport, grenades, autoshoot, aimfocus ,GameState = false;
        public static bool armorpiercer, evileye, highpowered, impetum, murderblitz, sixthsense, snowflake, toxicarea, yokai = false;
        public static IntPtr ModuleBase = IntPtr.Zero;
        public static IntPtr WallHackAllocatedMemory = IntPtr.Zero; //0x10000
        public static IntPtr RapidFireAllocatedMemory = IntPtr.Zero; //0x20000
        public static IntPtr SWAllocatedMemory = IntPtr.Zero;  //0x30000
        public static IntPtr SpeedAllocatedMemory = IntPtr.Zero; //0x40000


        private static void CodeInjection32Bit(IntPtr Origin, IntPtr Dest, int LengthOfBytesTohook, byte[] _asmCode)
        {
            List<byte> jmp = new List<byte>();
            jmp.Add(0xE9);
            jmp.AddRange(BitConverter.GetBytes(((Int32)((ulong)Dest - (ulong)Origin)) - 5));
            if (LengthOfBytesTohook > 5)
            {
                for (int x = 0; x < (LengthOfBytesTohook - 5); x++)
                {
                    jmp.Add(0x90);
                }
            }
            List<byte> jmpBack = new List<byte>();
            jmpBack.Add(0xE9);
            jmpBack.AddRange(BitConverter.GetBytes(((Int32)(((ulong)Origin + (ulong)LengthOfBytesTohook) - ((ulong)Dest + (ulong)_asmCode.Length)) - 5)));

            Memory.WriteBytes(Dest, _asmCode, _asmCode.Length);
            Memory.WriteBytes(Dest + _asmCode.Length, jmpBack.ToArray(), 5);

            Memory.WriteBytes(Origin, jmp.ToArray(), jmp.Count);
        }

        private static void Accuracy(bool IsEnabled)
        {
            try
            {
                IntPtr BaseAddress = ModuleBase + Offsets.Accuracy_Offset;
                if (IsEnabled)
                {
                    byte[] buffer = { 0xF3, 0x0F, 0x5C, 0xC0 };
                    Memory.WriteBytes(BaseAddress, buffer, 4);
                }
                else 
                {
                    byte[] buffer = { 0xF3, 0x0F, 0x5C, 0xC2 };
                    Memory.WriteBytes(BaseAddress, buffer, 4);
                }
            }
            catch { }
        }

        private static void WallBang(bool IsEnabled)
        {
            try
            {
                IntPtr BaseAddress = ModuleBase + Offsets.ShootThroughWalls_Offset;
                if (IsEnabled)
                {
                    byte[] buffer = { 0x90, 0x90, 0x90 };
                    Memory.WriteBytes(BaseAddress, buffer, 3);
                    
                }
                else 
                {
                    byte[] buffer = { 0x83, 0xf8, 0x08 };
                    Memory.WriteBytes(BaseAddress, buffer, 3);
                }
            }
            catch { }
        }

        private static void EPatch(bool IsEnabled)
        {
            try
            {
                IntPtr ResetWhenDeployBase = ModuleBase + Offsets.ResetWhenDeploy_Offset;
                IntPtr ResetWhenQuitBase = ModuleBase + Offsets.ResetWhenQuitInventory_Offset;
                if (IsEnabled)
                {
                    byte[] buffer = { 0x90, 0x90, 0x90, 0x90, 0x90 };
                    Memory.WriteBytes(ResetWhenDeployBase, buffer, 5);
                    byte[] buffe2 = { 0x90, 0x90, 0x90, 0x90 };
                    Memory.WriteBytes(ResetWhenQuitBase, buffe2, 4);
                }
                else 
                {
                    byte[] buffer = { 0x41, 0x89, 0x5C, 0x08, 0x18 };
                    Memory.WriteBytes(ResetWhenDeployBase, buffer, 5);
                    byte[] buffe2 = { 0x41, 0x89, 0x49, 0x18 };
                    Memory.WriteBytes(ResetWhenQuitBase, buffe2, 4);
                }
            }
            catch { }
        }

        private static void Radar(bool IsEnabled)
        {
            try
            {
                IntPtr BaseAddress = ModuleBase + Offsets.Radar_Offset;
                if (IsEnabled)
                {
                    byte[] buffer = { 0xb8, 0xd0, 0x07, 0x00, 0x00, 0x90 };
                    Memory.WriteBytes(BaseAddress, buffer, 6);
                }
                else 
                {
                    byte[] buffer = { 0x8b, 0x83, 0xe4, 0x03, 0x00, 0x00 };
                    Memory.WriteBytes(BaseAddress, buffer, 6);
                }
            }
            catch { }
        }

        private static void VerrPower(bool IsEnabled)
        {
            try
            {
                IntPtr BaseAddress = ModuleBase + Offsets.VerrPower_Offset;
                if (IsEnabled)
                {
                    byte[] buffer = { 0xf3, 0x0f, 0x5c, 0xf6, 0x90 };
                    Memory.WriteBytes(BaseAddress, buffer, 5);
                }
                else 
                {
                    byte[] buffer = { 0xf3, 0x0f, 0x58, 0x73, 0x28 };
                    Memory.WriteBytes(BaseAddress, buffer, 5);
                }
            }
            catch { }
        }

        private static void NoClip(bool IsEnabled)
        {
            try
            {
                IntPtr BaseAddress = ModuleBase + Offsets.NoClip_Offset;
                if (IsEnabled)
                {
                    byte[] buffer = { 0x90, 0x90, 0x90, 0x90, 0x90 };
                    Memory.WriteBytes(BaseAddress, buffer, 5);
                }
                else 
                {
                    byte[] buffer = { 0xE8, 0xC7, 0x13, 0x01, 0x00 };
                    Memory.WriteBytes(BaseAddress, buffer, 5);
                }
            }
            catch { }
        }

        private static void AirWalk(bool IsEnabled)
        {
            try
            {
                IntPtr BaseAddress = ModuleBase + Offsets.AirWalk_Offset;
                if (IsEnabled)
                {
                    byte[] buffer = { 0xc6, 0x83, 0xd4, 0x00, 0x00, 0x00, 0x00 };
                    Memory.WriteBytes(BaseAddress, buffer, 7);
                }
                else
                {
                    byte[] buffer = { 0xc6, 0x83, 0xd4, 0x00, 0x00, 0x00, 0x01 };
                    Memory.WriteBytes(BaseAddress, buffer, 7);
                }
            }
            catch { }
        }

        private static void NoRecoil(bool IsEnabled)
        {
            try
            {
                IntPtr BaseAddress = ModuleBase + Offsets.NoRecoil_Offset;
                if (IsEnabled)
                {
                    byte[] buffer = { 0xf3, 0x0f, 0x10, 0xb3, 0x30, 0x06, 0x00, 0x00 };
                    Memory.WriteBytes(BaseAddress, buffer, 7);
                }
                else 
                {
                    byte[] buffer = { 0xf3, 0x0f, 0x58, 0xb3, 0x30, 0x06, 0x00, 0x00 };
                    Memory.WriteBytes(BaseAddress, buffer, 7);
                }
            }
            catch { }
        }

        private static void WallHack(bool IsEnabled)
        {
            try
            {
                IntPtr BaseAddress = ModuleBase + Offsets.WallHack_Offset;
                if (IsEnabled)
                {
                    if (WallHackAllocatedMemory == IntPtr.Zero)
                        WallHackAllocatedMemory = Memory.VirtualAllocEx(Memory.handle, ModuleBase - 0x10000, 100, (uint)Memory.AllocationType.Commit | (uint)Memory.AllocationType.Reserve, (uint)Memory.MemoryProtection.ExecuteReadWrite);
                    byte[] BytesToWrite = 
                        {0x41 ,0x83 ,0x7D ,0x0C ,0x00,//-------------------// cmp dword ptr [r13+0C],00
                         0x75 ,0x08,//-------------------------------------// jne 08 (next 8 bytes)
                         0x41 ,0xC7 ,0x45 ,0x0C ,0x00,0x02,0x00,0x00,//----// mov [r13+0C],00000200
                         0x41 ,0xF6 ,0x45 ,0x0C ,0x04,//-------------------// test byte ptr [r13+0C],04

                        };
                    CodeInjection32Bit(BaseAddress, WallHackAllocatedMemory, 5, BytesToWrite);
                }
                else 
                {
                    byte[] buffer = { 0x41, 0xF6, 0x45, 0x0C, 0x04 };
                    Memory.WriteBytes(BaseAddress, buffer,5);
                }
            }
            catch { }
        }

        public static void RapidFire(bool IsEnabled)
        {
            try
            {

                if (IsEnabled)
                {
                    if (RapidFireAllocatedMemory == IntPtr.Zero)
                        RapidFireAllocatedMemory = Memory.VirtualAllocEx(Memory.handle, ModuleBase - 0x20000, 100, (uint)Memory.AllocationType.Commit | (uint)Memory.AllocationType.Reserve, (uint)Memory.MemoryProtection.ExecuteReadWrite);
                    List<byte> asmCode = new List<byte>();
                    asmCode.Add(0x53); //push rbx
                    asmCode.AddRange(new byte[] { 0x48, 0x8b, 0x1d }); //mov rbx ,[offset]
                    asmCode.AddRange(BitConverter.GetBytes((Int32)((((ulong)(ModuleBase + Offsets.PlayerBase_Offset)) - ((ulong)RapidFireAllocatedMemory + 1))) - 7)); //offset
                    asmCode.AddRange(new byte[] { 0x48, 0x8B, 0x9B, 0x08, 0x03, 0x00, 0x00 });//mov rbx,[rbx+00000308]
                    asmCode.AddRange(new byte[] {0x48 ,0x8B ,0x9B ,0x90 ,0x00 ,0x00 ,0x00 });//mov rbx,[rbx+00000090]
                    asmCode.AddRange(new byte[] {0x48 ,0x8B ,0x9B ,0x60, 0x01, 0x00, 0x00 });//mov rbx,[rbx+00000160]
                    asmCode.AddRange(new byte[] {0x48 ,0x8B ,0x5B ,0x38 });//mov rbx,[rbx+38]
                    asmCode.AddRange(new byte[] {0x48 ,0x8B ,0x9B ,0xE0, 0x04, 0x00, 0x00 });//mov rbx,[rbx+000004E0]
                    asmCode.AddRange(new byte[] {0x48 ,0x8B ,0x5B ,0x08 });//mov rbx,[rbx+08]
                    asmCode.AddRange(new byte[] {0x48 ,0x83 ,0xC3, 0x40 });//add rbx,40
                    asmCode.AddRange(new byte[] {0x48, 0x39, 0xD3 });//cmp rbx,rdx
                    asmCode.Add(0x5B);//pop rbx
                    asmCode.AddRange(new byte[] {0x0F ,0x85 ,0x22 ,0x00, 0x00, 0x00 });//jne 
                    asmCode.AddRange(new byte[] {0x80 ,0x7A ,0x08 ,0x0B });//cmp byte ptr [rdx+08],0B
                    asmCode.AddRange(new byte[] {0x0F ,0x84 ,0x0F ,0x00, 0x00, 0x00 });//je
                    asmCode.AddRange(new byte[] {0x80 ,0x7A ,0x08 ,0x10 });//cmp byte ptr [rdx+08],10
                    asmCode.AddRange(new byte[] {0x0F ,0x84 ,0x05 ,0x00, 0x00, 0x00 });//je
                    asmCode.AddRange(new byte[] {0xE9 ,0x09 ,0x00 ,0x00, 0x00 });//jmp
                    asmCode.AddRange(new byte[] {0xC6 ,0x42 ,0x08 ,0x03 });//mov byte ptr [rdx+08],03
                    asmCode.AddRange(new byte[] {0xE9 ,0x00 ,0x00 ,0x00, 0x00 });//jmp
                    asmCode.AddRange(new byte[] {0x4C, 0x63, 0x7A, 0x08 });//movsxd  r15,dword ptr [rdx+08]
                    asmCode.AddRange(new byte[] { 0x4D, 0x8B, 0xE0 });//mov r12,r8
                    CodeInjection32Bit(ModuleBase + Offsets.RapidFire_Offset, RapidFireAllocatedMemory, 7, asmCode.ToArray());
                }
                else 
                {
                    byte[] buffer = { 0x4C , 0x63, 0x7A, 0x08, 0x4D, 0x8B, 0xE0 };
                    Memory.WriteBytes(ModuleBase+Offsets.RapidFire_Offset, buffer, 7);
                }

            }
            catch { }
        }

        private static void SafeWalk(bool IsEnabled)
        {
            try
            {
                if (IsEnabled)
                {
                    if (SWAllocatedMemory == IntPtr.Zero)
                        SWAllocatedMemory = Memory.VirtualAllocEx(Memory.handle, ModuleBase - 0x30000, 100, (uint)Memory.AllocationType.Commit | (uint)Memory.AllocationType.Reserve, (uint)Memory.MemoryProtection.ExecuteReadWrite);
                    List<byte> asmCode = new List<byte>();
                    asmCode.Add(0x53); //push rbx
                    asmCode.AddRange(new byte[] { 0x48, 0x8b, 0x1d }); //mov rbx ,[offset]
                    asmCode.AddRange(BitConverter.GetBytes( (Int32) ((((ulong)( ModuleBase+Offsets.PlayerBase_Offset ))  - ((ulong)SWAllocatedMemory + 1))) -7 )); //offset
                    asmCode.AddRange(new byte[] {0x48, 0x8B, 0x9B, 0x00, 0x07, 0x00, 0x00 }); //mov rbx,[rbx+00000700]
                    asmCode.AddRange(new byte[] { 0x48, 0x8B, 0x1B }); //mov rbx,[rbx]
                    asmCode.AddRange(new byte[] { 0x48, 0x8B, 0x9B, 0x58, 0x08, 0x00, 0x00 }); //mov rbx,[rbx+00000858]
                    asmCode.AddRange(new byte[] { 0x48, 0x8B, 0x9B, 0xD8, 0x00, 0x00, 0x00 }); //mov rbx,[rbx+000000D8]
                    asmCode.AddRange(new byte[] { 0x48, 0x8B, 0x9B, 0x20, 0x04, 0x00, 0x00 }); //mov rbx,[rbx+00000420]
                    asmCode.AddRange(new byte[] { 0x48, 0x83, 0xC3, 0x38 }); //add rbx,38
                    asmCode.AddRange(new byte[] { 0x48, 0x39, 0xD9 }); //cmp rcx,rbx
                    asmCode.Add( 0x5b ); //pop rbx
                    asmCode.AddRange(new byte[] { 0x75, 0x01 }); //jne next 1 byte
                    asmCode.Add(0xc3); //ret
                    asmCode.AddRange(new byte[] { 0x48, 0x39, 0xD1 }); //cmp rcx,rdx
                    asmCode.AddRange(new byte[] { 0x0f, 0x84 }); //je offset
                    asmCode.AddRange(BitConverter.GetBytes((Int32)((((ulong)(ModuleBase + 0x6FCEAD)) - ((ulong)SWAllocatedMemory + 53))) - 6)); //offset
                    CodeInjection32Bit(ModuleBase + Offsets.SafeWalk_Offset, SWAllocatedMemory,9, asmCode.ToArray());

                }
                else 
                {
                    List<byte> BytesToWrite = new List<byte>();
                    BytesToWrite.AddRange(new byte[] { 0x48 ,0x3B ,0xCA }); //cmp rcx , rdx
                    BytesToWrite.AddRange(new byte[] { 0x0f, 0x84 }); //je offset
                    BytesToWrite.AddRange(BitConverter.GetBytes((Int32)((((ulong)(ModuleBase + 0x6f719d)) - ((ulong)(ModuleBase + Offsets.SafeWalk_Offset+3)))) - 6)); //offset
                    Memory.WriteBytes(ModuleBase + Offsets.SafeWalk_Offset, BytesToWrite.ToArray(), BytesToWrite.Count);
                }
            }
            catch { }
        }

        private static void SafeWalkPitchYaw(bool IsEnabled)
        {
            
            try
            {
                if (IsEnabled)
                {
                    byte[] buffer = { 0xC3, 0x90, 0x90 };
                    Memory.WriteBytes(ModuleBase + Offsets.SafeWalkYawPitch_Offset, buffer, 3);
                }
                else 
                {
                    byte[] buffer = { 0x48, 0x8B, 0xC4 };
                    Memory.WriteBytes(ModuleBase + Offsets.SafeWalkYawPitch_Offset, buffer, 3);
                }
            }
            catch { }
        }

        private static void SpeedHack(bool IsEnabled) 
        {
            try 
            {
                if (IsEnabled)
                {
                    if (SpeedAllocatedMemory == IntPtr.Zero)
                        SpeedAllocatedMemory = Memory.VirtualAllocEx(Memory.handle, ModuleBase - 0x40000, 100, (uint)Memory.AllocationType.Commit | (uint)Memory.AllocationType.Reserve, (uint)Memory.MemoryProtection.ExecuteReadWrite);
                    List<byte> asmCode = new List<byte>();
                    asmCode.AddRange(new byte[] {0xC7, 0x87, 0x9C, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x41 }); //mov [rdi+0000079C],41000000
                    asmCode.AddRange(new byte[] { 0xF3, 0x0F, 0x10, 0x87, 0x9C, 0x07, 0x00, 0x00 }); //movss xmm0,[rdi+0000079C]
                    asmCode.AddRange(new byte[] { 0xF3, 0x0F, 0x11, 0x87, 0x9C, 0x07, 0x00, 0x00 }); //movss [rdi+0000079C],xmm0
                    CodeInjection32Bit(ModuleBase + Offsets.Speed_Offset, SpeedAllocatedMemory,8, asmCode.ToArray());
                }
                else 
                {
                    byte[] buffer = {0xF3, 0x0F, 0x11, 0x87, 0x9C, 0x07, 0x00, 0x00 }; //movss [rdi+0000079C],xmm0
                    Memory.WriteBytes(ModuleBase + Offsets.Speed_Offset, buffer, 8);
                }

            } catch { }
        }

        private enum WeaponsId : uint
        {
            LavaGrinder = 0xC1B22220,
            SnowBallLauncher = 0x89E00010,
            GoldenEER15 = 0xBB101010,
            LavaERG10 = 0xBF804030,
            FireFly = 0x9DB01000,
            TONI = 0x86411000,
            goldenimp5 = 0xB9F05A30,
            candycaneimp5 = 0xCE505A30,
            goldenbosk3 = 0xB6E08939,
            goldenred34 = 0xB5A08939,
            platinumred34 = 0xC4208B38,
            jadestonekogv = 0xC2608B38,
            goldenseverance = 0xBBE01020,
            goldenjglt313 = 0xBBD01000,
            goldendbs4 = 0xBED01000,
            lavapr39 = 0xBFD01000,
            goldenshred4 = 0xBAA01000,
            goldenfs80 = 0xBA101000,
            MORTx = 0xB1101000,
            seringplag9model = 0xB1501000,
            sklrcc45 = 0xB1A01000,
            hawk1z = 0xB1C01000,
            l1n4588 = 0xB1D01000,
            thezapper = 0xB2301000,
            zombifiedred34 = 0xB3501000,
            zombifiedbosk3 = 0xB3F01000,
            goldenmesn = 0xB4F01000,
            goldensixmg = 0xB5501000,
            goldenlgr35 = 0xBD201000,
            jadestoneimp5 = 0xC2701000,
            icedbuckshot = 0xCE601000,
            icedspec38a = 0xCEC01000,
            icedbramson = 0xCFA01000,
            icedblomr = 0xCF101000,
            icedshred4 = 0xCFE01000,
            lavared34 = 0xCAA01000,
            jadestonebramstone = 0xCAF01000,
            overchargedlak = 0xCBA01000,
            poisonouskogv = 0xCCA01000,
            gingerbreader10 = 0xCDA01000,
            gingerbreadred34 = 0xCDB01000,
            lavadbs4 = 0xCC501000,
            lavabosk3 = 0xCA501000,
            overchargedjglt313 = 0xCA201000,
            pacificbsw77 = 0xC9A01000,
            bloodyetherl = 0xC9201000,
            bloodywhisperer = 0xC8A01000,
            pacifickogv = 0xC8201000,
            forestgrinder = 0xC7201000,
            forestvice = 0xC7A01000,
            jadestonebsw77 = 0xC6201000,
            jadestonewhisperer = 0xC6501000,
            zombifiedmicrocov = 0xC6A01000,
            goldenbasu = 0xB7A00000,
            goldenslak7h = 0xBE500000,
            kv4l = 0xB3000000,
            goldenkogv = 0xB9001110,
            theroaster = 0xB2700000,
            lavawes = 0xC0001110,
            jadestoneerg10 = 0xC3100000,
            lavabsw77 = 0xC0800000,
            goldengrinder = 0xC0E01110,
            platinumkogv = 0xC4301110,
            platinumimp5 = 0xC4E01110,
            lavabramson = 0xC5001110,
            lavaimp5 = 0xC5601110,
            jadestonecaspol = 0xC7000000,
            bloodydbs4 = 0xC9000000,
            gingerbreadrokk = 0xCD000000,
            icedseverance = 0xD0100000,
            flamedaestx84 = 0xD0D00000,
            flamedfirecracker = 0xD1500000,
            flamedlgr35 = 0xD1A00000,
            flamedtwig = 0xD2200000,
            flamedratog = 0xD2500000,
            flamedmrager = 0xD2A00000,
            goldensering9 = 0x8AF00000,
            goldenrokk = 0x8C000000

        }

        public static void AddWeapon(string btnContent, bool IsPrimary)
        {
            try
            {
                if (GameState)
                {

                    IntPtr SlotsBase = ModuleBase + Offsets.WeaponsSlot1_Offset;
                    IntPtr WeaponAddress = IntPtr.Zero;

                    if (IsPrimary) WeaponAddress = Memory.GetPointerAddress64Bit(SlotsBase, new int[] { 0x568, 0x18 }, 2);

                    else WeaponAddress = Memory.GetPointerAddress64Bit(SlotsBase, new int[] { 0x568, 0x40 }, 2);
                           

                    switch (btnContent)
                    {
                        case "1":
                        case "Lava Grinder":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.LavaGrinder);
                            break;
                        case "FireFly":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.FireFly);
                            break;
                        case "G. Severance":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldenseverance);
                            break;
                        case "8":
                        case "Lava Pr39":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.lavapr39);
                            break;
                        case "12":
                        case "L1n4-588":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.l1n4588);
                            break;
                        case "17":
                        case "Iced Buckshot":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.icedbuckshot);
                            break;
                        case "18":
                        case "Iced Spec38a":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.icedspec38a);
                            break;
                        case "27":
                        case "Lava Dbs 4":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.lavadbs4);
                            break;
                        case "28":
                        case "O.C.Jglt-313":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.overchargedjglt313);
                            break;
                        case "31":
                        case "B. Whisperer":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.bloodywhisperer);
                            break;
                        case "32":
                        case "Pacific kog v":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.pacifickogv);
                            break;
                        case "33":
                        case "Forest Grinder":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.forestgrinder);
                            break;
                        case "34":
                        case "Forest Vice":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.forestvice);
                            break;
                        case "38":
                        case "G. Slak 7h":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldenslak7h);
                            break;
                        case "39":
                        case "K-V4l":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.kv4l);
                            break;
                        case "44":
                        case "Lava Imp-s":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.lavaimp5);
                            break;
                        case "41":
                        case "Lava Bsw77":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.lavabsw77);
                            break;
                        case "42":
                        case "G. Grinder":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldengrinder);
                            break;
                        case "3":
                        case "S.B.Launcher":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.SnowBallLauncher);
                            break;



                        case "golden eer 15":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.GoldenEER15);
                            break;
                        case "2":
                        case "lava erg 10":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.LavaERG10);
                            break;


                        case "golden imp-5":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldenimp5);
                            break;
                        case "4":
                        case "candycane imp-5":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.candycaneimp5);
                            break;
                        case "golden bosk 3":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldenbosk3);
                            break;
                        case "golden red-34":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldenred34);
                            break;
                        case "platinum red-34":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.platinumred34);
                            break;
                        case "5":
                        case "jadestone kog v":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.jadestonekogv);
                            break;
                        case "6":
                        case "golden jglt-313":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldenjglt313);
                            break;
                        case "7":
                        case "golden dbs 4":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldendbs4);
                            break;

                        case "golden shred-4":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldenshred4);
                            break;
                        case "golden fs80":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldenfs80);
                            break;
                        case "9":
                        case "M.O.R.T.-x":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.MORTx);
                            break;
                        case "10":
                        case "sering plag-9 model":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.seringplag9model);
                            break;
                        case "11":
                        case "skl-rcc-45":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.sklrcc45);
                            break;
                        case "hawk-1z":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.hawk1z);
                            break;
                        case "13":
                        case "the zapper":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.thezapper);
                            break;
                        case "14":
                        case "zombified red-34":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.zombifiedred34);
                            break;
                        case "15":
                        case "zombified bosk 3":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.zombifiedbosk3);
                            break;
                        case "golden mes-n":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldenmesn);
                            break;
                        case "golden six-mg":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldensixmg);
                            break;
                        case "golden lgr 35":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldenlgr35);
                            break;
                        case "16":
                        case "jadestone imp-5":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.jadestoneimp5);
                            break;
                        case "19":
                        case "iced bramson":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.icedbramson);
                            break;
                        case "20":
                        case "iced blom-r":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.icedblomr);
                            break;
                        case "21":
                        case "iced shred-4":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.icedshred4);
                            break;
                        case "lava red-34":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.lavared34);
                            break;
                        case "22":
                        case "jadestone bramstone":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.jadestonebramstone);
                            break;
                        case "23":
                        case "overcharged l.a.k":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.overchargedlak);
                            break;
                        case "24":
                        case "poisonous kog v":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.poisonouskogv);
                            break;
                        case "25":
                        case "gingerbread er 10":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.gingerbreader10);
                            break;
                        case "gingerbread red-34":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.gingerbreadred34);
                            break;
                        case "26":
                        case "lava bosk 3":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.lavabosk3);
                            break;
                        case "29":
                        case "pacific bsw 77":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.pacificbsw77);
                            break;
                        case "30":
                        case "bloody ether-l":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.bloodyetherl);
                            break;
                        case "35":
                        case "jadestone bsw 77":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.jadestonebsw77);
                            break;
                        case "36":
                        case "jadestone whisperer":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.jadestonewhisperer);
                            break;
                        case "37":
                        case "zombified micro cov":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.zombifiedmicrocov);
                            break;

                        case "golden b.a.s.u.":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldenbasu);
                            break;

                        case "golden kog v":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldenkogv);
                            break;
                        case "the roaster":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.theroaster);
                            break;
                        case "40":
                        case "lava wes":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.lavawes);
                            break;
                        case "jadestone erg 10":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.jadestoneerg10);
                            break;

                        case "platinum kog v":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.platinumkogv);
                            break;
                        case "platinum imp-5":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.platinumimp5);
                            break;
                        case "43":
                        case "lava bramson":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.lavabramson);
                            break;

                        case "jadestone cas&pol":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.jadestonecaspol);
                            break;
                        case "bloody dbs 4":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.bloodydbs4);
                            break;
                        case "45":
                        case "gingerbread rokk":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.gingerbreadrokk);
                            break;

                        case "iced severance":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.icedseverance);
                            break;
                        case "flamed a.e.s.t.-x84":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.flamedaestx84);
                            break;
                        case "flamed firecracker":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.flamedfirecracker);
                            break;
                        case "flamed lgr 35":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.flamedlgr35);
                            break;
                        case "flamed twig":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.flamedtwig);
                            break;
                        case "flamed ratog":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.flamedratog);
                            break;
                        case "flamed mrager":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.flamedmrager);
                            break;
                        case "golden sering 9":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldensering9);
                            break;
                        case "golden rokk":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.goldenrokk);
                            break;

                        case "t.o.n.i.":
                            Memory.Write<uint>(WeaponAddress, (uint)WeaponsId.TONI);
                            break;

                    }
                }

            }
            catch { }
        }

        public static void DisableAmmo()
        {
            ammo = false;
            try
            {
                IntPtr Ammo1 = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x308, 0x140, 0x8, 0x70, 0x0 }, 5);
                IntPtr Ammo2 = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x308, 0x140, 0x8, 0x68 }, 4);
                Memory.Write<uint>(Ammo1, 0);
                Memory.Write<uint>(Ammo2, 0);
            }
            catch { }
        }

        public static void DisableGrenades()
        {
            grenades = false;
            try
            {
                IntPtr G2 = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x308, 0x1b8, 0x0 }, 3);
                IntPtr G1 = Memory.GetPointerAddress64Bit(Cheats.ModuleBase + Offsets.PlayerBase_Offset, new int[] { 0x308, 0x1b8, 0x8, 0x0 }, 4);
                Memory.Write<uint>(G1, 0);
                Memory.Write<uint>(G2, 0);
            }
            catch { }
        }

        private static void DisableAllPointers()
        {
            jump = false;
            ammo = false;
            teleport = false;
            grenades = false;
            autoshoot = false;
            aimfocus = false;
            noclipv2 = false;
            unlimitedhp = false;
        }

        public static void Enable(string Text, bool GameStat)
        {
            if (!GameStat) { DisableAllPointers(); return; }
            try
            {
                switch (Text)
                {

                    case "Radar":
                        Radar(true);
                        break;
                    case "Jump":
                        jump = true;
                        break;
                    case "Unlimited Ammo":
                        ammo = true;
                        break;
                    case "Air Walk":
                        AirWalk(true);
                        break;
                    case "Wall Hack":
                        WallHack(true);
                        break;
                    case "Unlimited V.Power":
                        VerrPower(true);
                        break;
                    case "Cursor TP":
                        teleport = true;
                        break;
                    case "Accuracy":
                        Accuracy(true);
                        break;
                    case "Auto Shoot":
                        autoshoot = true;
                        break;
                    case "Aim Lock":
                        aimfocus = true;
                        break;
                    case "Unlimited Frag":
                        grenades = true;
                        break;
                    case "No Clip":
                        NoClip(true);
                        break;
                    case "No Recoil":
                        NoRecoil(true);
                        break;
                    case "Inventory Patch":
                        EPatch(true);
                        break;
                    case "Wall Bang":
                        WallBang(true);
                        break;
                    case "Rapid Fire":
                        RapidFire(true);
                        break;
                    case "Ghost":
                        SafeWalk(true);
                        SafeWalkPitchYaw(true);
                        break;
                    case "Speed":
                        SpeedHack(true);
                        break;
                    case "Unlimited HP":
                        unlimitedhp = true;
                        break;
                    case "No Clip V2":
                        noclipv2 = true;
                        break;



                    case "Armor Piercer":
                        armorpiercer = true;
                        break;
                    case "Evil Eye":
                        evileye = true;
                        break;
                    case "High Powered":
                        highpowered = true;
                        break;
                    case "Impetum":
                        impetum = true;
                        break;
                    case "Murder Blitz":
                        murderblitz = true;
                        break;
                    case "Sixth Sense":
                        sixthsense = true;
                        break;
                    case "Snowflake":
                        snowflake = true;
                        break;
                    case "Toxic Area":
                        toxicarea = true;
                        break;
                    case "Yokai":
                        yokai = true;
                        break;

                }
            }
            catch { }
        }

        public static void Disable(string Text, bool GameStat)
        {
            if (!GameStat) { DisableAllPointers(); return; }
            try
            {
                switch (Text)
                {
                    case "Radar":
                        Radar(false);
                        break;
                    case "Jump":
                        jump = false;
                        break;
                    case "Unlimited Ammo":
                        ammo = false;
                        break;
                    case "Air Walk":
                        AirWalk(false);
                        break;
                    case "Wall Hack":
                        WallHack(false);
                        break;
                    case "Unlimited V.Power":
                        VerrPower(false);
                        break;
                    case "Cursor TP":
                        teleport = false;
                        break;
                    case "Accuracy":
                        Accuracy(false);
                        break;
                    case "Auto Shoot":
                        autoshoot = false;
                        break;
                    case "Aim Lock":
                        aimfocus = false;
                        break;
                    case "Unlimited Frag":
                        grenades = false;
                        break;
                    case "No Clip":
                        NoClip(false);
                        break;
                    case "No Recoil":
                        NoRecoil(false);
                        break;
                    case "Inventory Patch":
                        EPatch(false);
                        break;
                    case "Wall Bang":
                        WallBang(false);
                        break;
                    case "Rapid Fire":
                        RapidFire(false);
                        break;
                    case "Ghost":
                        SafeWalk(false);
                        SafeWalkPitchYaw(false);
                        break;
                    case "Speed":
                        SpeedHack(false);
                        break;
                    case "Unlimited HP":
                        unlimitedhp = false;
                        break;
                    case "No Clip V2":
                        noclipv2 = false;
                        break;



                    case "Armor Piercer":
                        armorpiercer = false;
                        break;
                    case "Evil Eye":
                        evileye = false;
                        break;
                    case "High Powered":
                        highpowered = false;
                        break;
                    case "Impetum":
                        impetum = false;
                        break;
                    case "Murder Blitz":
                        murderblitz = false;
                        break;
                    case "Sixth Sense":
                        sixthsense = false;
                        break;
                    case "Snowflake":
                        snowflake = false;
                        break;
                    case "Toxic Area":
                        toxicarea = false;
                        break;
                    case "Yokai":
                        yokai = false;
                        break;

                }
            }
            catch { }
        }

    }
}
