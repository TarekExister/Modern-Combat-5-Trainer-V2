using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ModernCombatTrainer.GameMemory
{
    public class DllPermission
    {
        public static void SetDllPermission(string dllName)
        {
            FileInfo dllinfo = new FileInfo(dllName);
            FileSecurity fs = dllinfo.GetAccessControl();
            SecurityIdentifier se = new SecurityIdentifier("S-1-15-2-1");
            FileSystemAccessRule fsar = new FileSystemAccessRule(se, FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow);
            fs.AddAccessRule(fsar);
            dllinfo.SetAccessControl(fs);
        }
    }
}
