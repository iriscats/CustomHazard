using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object = UnrealSharp.UEObject;


namespace SDK.Script.DeveloperSettingsSDK
{
    public class DeveloperSettings : Object
    {
        public DeveloperSettings(nint addr) : base(addr) { }
    }
}
