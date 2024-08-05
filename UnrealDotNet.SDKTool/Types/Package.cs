using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealDotNet.SDKTool.Types
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
    public class NamespaceAttribute : Attribute
    {
        public string name;

        public NamespaceAttribute(string name)
        {
            this.name = name;
        }
    }

    public class Package
    {
        public string FullName;
        public string Name => FullName.Substring(FullName.LastIndexOf("/") + 1);
        public List<SDKClass> Classes = new();
        public List<Package> Dependencies = new();

        public class SDKClass
        {
            public string SdkType;
            public string Namespace;
            public string Name;
            public string Parent;
            public List<SDKFields> Fields = new();
            public List<SDKFunctions> Functions = new();

            public class SDKFields
            {
                public string Type;
                public string Name;
                public string GetterSetter;
                public int EnumVal;
            }

            public class SDKFunctions
            {
                public string ReturnType;
                public string Name;
                public List<SDKFields> Params = new();
            }
        }
    }
}
