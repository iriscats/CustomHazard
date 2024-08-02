using System.Text;
using UnrealDotNet.Types;

namespace UnrealDotNet.SDKTool;

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

public class DumpTool
{

    private readonly UnrealEngine _ue = UnrealEngine.GetInstance();

    public DumpTool()
    {

    }


    public void EnableConsole()
    {
        var engine = new UObject(_ue.GEngine);
        var console = new UObject(_ue.Execute(_ue.GStaticCtor,
            engine["ConsoleClass"].Value,
            engine["GameViewport"].Address,
            0, 0, 0, 0, 0, 0, 0));
        engine["GameViewport"]["ViewportConsole"] = console;
    }


    public string GetTypeFromFieldAddr(string fName, string fType, nint fAddr, out string gettersetter)
    {
        gettersetter = "";
        if (fType == "BoolProperty")
        {
            fType = "bool";
            gettersetter = "{ get { return this[nameof(" + fName + ")].Flag; } set { this[nameof(" + fName +
                           ")].Flag = value; } }";
        }
        else if (fType == "ByteProperty" || fType == "Int8Property")
        {
            fType = "byte";
            gettersetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                           ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
        }
        else if (fType == "Int16Property")
        {
            fType = "short";
            gettersetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                           ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
        }
        else if (fType == "UInt16Property")
        {
            fType = "ushort";
            gettersetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                           ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
        }
        else if (fType == "IntProperty")
        {
            fType = "int";
            gettersetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                           ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
        }
        else if (fType == "UInt32Property")
        {
            fType = "uint";
            gettersetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                           ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
        }
        else if (fType == "Int64Property")
        {
            fType = "long";
            gettersetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                           ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
        }
        else if (fType == "UInt64Property")
        {
            fType = "ulong";
            gettersetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                           ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
        }
        else if (fType == "FloatProperty")
        {
            fType = "float";
            gettersetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                           ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
        }
        else if (fType == "DoubleProperty")
        {
            fType = "double";
            gettersetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                           ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
        }
        else if (fType == "StrProperty")
        {
            fType = "unk";
        }
        else if (fType == "TextProperty")
        {
            fType = "unk";
        }
        else if (fType == "ObjectProperty")
        {
            var structFieldIndex = _ue.MemoryReadInt(
                _ue.MemoryReadPtr(fAddr + UObject.PropertySize) + UObject.NameOffset);
            fType = UObject.GetName(structFieldIndex);
            gettersetter = "{ get { return this[nameof(" + fName + ")].As<" + fType + ">(); } set { this[\"" +
                           fName + "\"] = value; } }";
        }
        else if (fType == "ClassPtrProperty")
        {
            fType = "UObject";
            gettersetter = "{ get { return this[nameof(" + fName + ")].As<" + fType + ">(); } set { this[\"" +
                           fName + "\"] = value; } } // ClassPtrProperty";
        }
        else if (fType == "ScriptTypedElementHandle")
        {
            fType = "UObject";
            gettersetter = "{ get { return this[nameof(" + fName + ")].As<" + fType + ">(); } set { this[\"" +
                           fName + "\"] = value; } } // ClassPtrProperty";
        }
        else if (fType == "StructProperty")
        {
            var structFieldIndex = _ue.MemoryReadInt(
                _ue.MemoryReadPtr(fAddr + UObject.PropertySize) + UObject.NameOffset);
            fType = UObject.GetName(structFieldIndex);
            //gettersetter = "{ get { return UnrealEngine._unrealEngine.ReadProcessMemory<" + fType + ">(this[nameof(" + fName + ")].Address); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
            gettersetter = "{ get { return this[nameof(" + fName + ")].As<" + fType + ">(); } set { this[\"" +
                           fName + "\"] = value; } }";
        }
        else if (fType == "EnumProperty")
        {
            var structFieldIndex = _ue.MemoryReadInt(
                _ue.MemoryReadPtr(fAddr + UObject.PropertySize + 8) +
                UObject.NameOffset);
            fType = UObject.GetName(structFieldIndex);
            gettersetter = "{ get { return (" + fType + ")this[nameof(" + fName +
                           ")].GetValue<int>(); } set { this[nameof(" + fName + ")].SetValue<int>((int)value); } }";
        }
        else if (fType == "NameProperty")
        {
            fType = "unk";
        }
        else if (fType == "ArrayProperty")
        {
            var inner = _ue.MemoryReadPtr(fAddr + UObject.PropertySize);
            var innerClass = _ue.MemoryReadPtr(inner + UObject.FieldClassOffset);
            var structFieldIndex = _ue.MemoryReadInt(innerClass);
            fType = UObject.GetName(structFieldIndex);
            var innerType = GetTypeFromFieldAddr(fName, fType, inner, out gettersetter);
            gettersetter = "{ get { return new UArray<" + innerType + ">(this[nameof(" + fName +
                           ")].Address); } }"; // set { this[\"" + fName + "\"] = value; } }";
            fType = "Array<" + innerType + ">";
        }
        else if (fType == "SoftObjectProperty")
        {
            fType = "unk";
        }
        else if (fType == "SoftClassProperty")
        {
            fType = "unk";
        }
        else if (fType == "WeakObjectProperty")
        {
            fType = "unk";
        }
        else if (fType == "LazyObjectProperty")
        {
            fType = "unk";
        }
        else if (fType == "DelegateProperty")
        {
            fType = "unk";
        }
        else if (fType == "MulticastSparseDelegateProperty")
        {
            fType = "unk";
        }
        else if (fType == "MulticastInlineDelegateProperty")
        {
            fType = "unk";
        }
        else if (fType == "ClassProperty")
        {
            fType = "unk";
        }
        else if (fType == "MapProperty")
        {
            fType = "unk";
        }
        else if (fType == "SetProperty")
        {
            fType = "unk";
        }
        else if (fType == "FieldPathProperty")
        {
            fType = "unk";
        }
        else if (fType == "InterfaceProperty")
        {
            fType = "unk";
        }
        else if (fType == "Enum")
        {
            fType = "UEEnum";
        }
        else if (fType == "DateTime")
        {
            fType = "UEDateTime";
        }
        else if (fType == "Guid")
        {
            fType = "UEGuid";
        }

        if (fType == "unk")
        {
            fType = "UObject";
            gettersetter = "{ get { return this[nameof(" + fName + ")]; } set { this[nameof(" + fName +
                           ")] = value; } }";
        }

        return fType;
    }


    public void DumpSdk(string location = "")
    {
        if (location == "")
            location = _ue.Process.ProcessName;

        Directory.CreateDirectory(location);
        var entityList = _ue.MemoryReadPtr(_ue.BaseAddress + _ue.GObjects);
        var count = _ue.MemoryReadInt(_ue.BaseAddress + _ue.GObjects + 0x14);
        entityList = _ue.MemoryReadPtr(entityList);
        var packages = new Dictionary<nint, List<nint>>();
        for (var i = 0; i < count; i++)
        {
            // var entityAddr = _unrealEngine.ReadProcessMemory<UInt64>((entityList + 8 * (i / 0x10400)) + 24 * (i % 0x10400));
            var entityAddr = _ue.MemoryReadPtr((entityList + 8 * (i >> 16)) + 24 * (i % 0x10000));
            if (entityAddr == 0) continue;
            var outer = entityAddr;
            while (true)
            {
                var tempOuter = _ue.MemoryReadPtr(outer + UObject.ObjectOuterOffset);
                if (tempOuter == 0) break;
                outer = tempOuter;
            }

            if (!packages.ContainsKey(outer)) packages.Add(outer, new List<nint>());
            packages[outer].Add(entityAddr);
        }
        
        var dumpedPackages = new List<Package>();
        foreach (var package in packages)
        {
            var packageObj = new UObject(package.Key);
            var fullPackageName = packageObj.GetName();
            if (fullPackageName.Contains("TypedElementFrameworkSDK"))
                Console.WriteLine("");
            var dumpedClasses = new List<string>();
            var sdkPackage = new Package { FullName = fullPackageName };
            foreach (var objAddr in package.Value)
            {
                var obj = new UObject(objAddr);
                if (dumpedClasses.Contains(obj.ClassName))
                    continue;

                dumpedClasses.Add(obj.ClassName);
                if (obj.ClassName.StartsWith("Package")) 
                    continue;

                var typeName = obj.ClassName.StartsWith("Class") ? "class" :
                    obj.ClassName.StartsWith("ScriptStruct") ? "class" :
                    obj.ClassName.StartsWith("Enum") ? "enum" : "unk";


                //if (obj.ClassName.StartsWith("BlueprintGenerated")) typeName = "class";

                var className = obj.GetName();
                if (typeName == "unk") 
                    continue;
                if (className == "UObject") 
                    continue;

                var parentClass = _ue.MemoryReadPtr(obj.Address + UObject.StructSuperOffset);
                var sdkClass = new Package.SDKClass
                {
                    Name = className,
                    Namespace = fullPackageName,
                    SdkType = typeName
                };


                if (typeName == "enum") sdkClass.Parent = "int";
                else if (parentClass != 0)
                {
                    var parentNameIndex = _ue.MemoryReadInt(parentClass + UObject.NameOffset);
                    var parentName = UObject.GetName(parentNameIndex);
                    sdkClass.Parent = parentName;
                }
                else sdkClass.Parent = "UObject";
                //else throw new Exception("unparented obj not supported");

                if (typeName == "enum")
                {
                    var enumArray = _ue.MemoryReadPtr(objAddr + 0x40);
                    var enumCount = _ue.MemoryReadInt(objAddr + 0x48);
                    for (var i = 0; i < enumCount; i++)
                    {
                        var enumNameIndex = _ue.MemoryReadInt(enumArray + i * 0x10);
                        var enumName = UObject.GetName(enumNameIndex);
                        enumName = enumName.Substring(enumName.LastIndexOf(":") + 1);
                        var enumNameRepeatedIndex =
                            _ue.MemoryReadInt(enumArray + i * 0x10 + 4);
                        if (enumNameRepeatedIndex > 0)
                            enumName += "_" + enumNameRepeatedIndex;
                        var enumVal = _ue.MemoryReadInt(enumArray + i * 0x10 + 0x8);
                        sdkClass.Fields.Add(new Package.SDKClass.SDKFields { Name = enumName, EnumVal = enumVal });
                    }
                }
                else if (typeName == "unk")
                {
                    continue;
                }
                else
                {
                    var field = obj.Address + UObject.ChildPropertiesOffset - UObject.FieldNextOffset;
                    while ((field = _ue.MemoryReadPtr(field + UObject.FieldNextOffset)) >
                           0)
                    {
                        var fName = UObject.GetName(
                            _ue.MemoryReadInt(field + UObject.FieldNameOffset));
                        var fType = obj.GetFieldType(field);
                        var fValue = "(" + field.ToString() + ")";
                        var offset = (uint)obj.GetFieldOffset(field);
                        var gettersetter =
                            "{ get { return new {0}(this[\"{1}\"].Address); } set { this[\"{1}\"] = value; } }";
                        fType = GetTypeFromFieldAddr(fName, fType, field, out gettersetter);
                        //if (typeName == "struct") gettersetter = ";";
                        if (fName == className) fName += "_value";
                        sdkClass.Fields.Add(new Package.SDKClass.SDKFields
                        { Type = fType, Name = fName, GetterSetter = gettersetter });
                    }

                    field = obj.Address + UObject.ChildrenOffset - UObject.FuncNextOffset;
                    while ((field = _ue.MemoryReadPtr(field + UObject.FuncNextOffset)) >
                           0)
                    {
                        var fName = UObject.GetName(
                            _ue.MemoryReadInt(field + UObject.NameOffset));
                        if (fName == className) fName += "_value";
                        var func = new Package.SDKClass.SDKFunctions { Name = fName };
                        var fField = field + UObject.ChildPropertiesOffset - UObject.FieldNextOffset;
                        while ((fField = _ue.MemoryReadPtr(fField +
                                   UObject.FieldNextOffset)) > 0)
                        {
                            var pName = UObject.GetName(
                                _ue.MemoryReadInt(fField + UObject.FieldNameOffset));
                            var pType = obj.GetFieldType(fField);
                            pType = GetTypeFromFieldAddr("", pType, fField, out _);
                            func.Params.Add(new Package.SDKClass.SDKFields { Name = pName, Type = pType });
                        }

                        sdkClass.Functions.Add(func);
                    }
                }

                sdkPackage.Classes.Add(sdkClass);
            }

            dumpedPackages.Add(sdkPackage);
        }

        foreach (var p in dumpedPackages)
        {
            p.Dependencies = new List<Package>();
            foreach (var c in p.Classes)
            {
                {
                    var fromPackage = dumpedPackages.Find(tp => tp.Classes.Count(tc => tc.Name == c.Parent) > 0);
                    if (fromPackage != null && fromPackage != p && !p.Dependencies.Contains(fromPackage))
                        p.Dependencies.Add(fromPackage);
                }
                foreach (var f in c.Fields)
                {
                    var fromPackage = dumpedPackages.Find(tp =>
                        tp.Classes.Count(tc => tc.Name == f.Type?.Replace("UArray<", "").Replace(">", "")) > 0);
                    if (fromPackage != null && fromPackage != p && !p.Dependencies.Contains(fromPackage))
                        p.Dependencies.Add(fromPackage);
                }

                foreach (var f in c.Functions)
                {
                    foreach (var param in f.Params)
                    {
                        var fromPackage = dumpedPackages.Find(tp =>
                            tp.Classes.Count(tc => tc.Name == param.Type?.Replace("UArray<", "").Replace(">", "")) >
                            0);
                        if (fromPackage != null && fromPackage != p && !p.Dependencies.Contains(fromPackage))
                            p.Dependencies.Add(fromPackage);
                    }
                }
            }
        }

        foreach (var p in dumpedPackages)
        {
            var sb = new StringBuilder();
            sb.AppendLine("using UnrealDotNet;");
            sb.AppendLine("using UnrealDotNet.Types;");
            sb.AppendLine("using Guid = SDK.Script.CoreUObjectSDK.Guid;");
            sb.AppendLine("using Enum = SDK.Script.CoreUObjectSDK.Enum;");
            sb.AppendLine("using DateTime = SDK.Script.CoreUObjectSDK.DateTime;");
            foreach (var d in p.Dependencies) sb.AppendLine("using SDK" + d.FullName.Replace("/", ".") + "SDK;");
            sb.AppendLine("namespace SDK" + p.FullName.Replace("/", ".") + "SDK");
            sb.AppendLine("{");
            var printedClasses = 0;
            foreach (var c in p.Classes)
            {
                if (c.Fields.Count > 0) printedClasses++;
                // sb.AppendLine("    [Namespace(\"" + c.Namespace + "\")]");
                sb.AppendLine("    public " + c.SdkType + " " + c.Name +
                              ((c.Parent == null) ? "" : (" : " + c.Parent)));
                sb.AppendLine("    {");
                if (c.SdkType != "enum")
                    sb.AppendLine("        public " + c.Name + "(nint addr) : base(addr) { }");
                foreach (var f in c.Fields)
                {
                    if (f.Name == "RelatedPlayerState") continue; // todo fix
                    if (c.SdkType == "enum")
                        sb.AppendLine("        " + f.Name + " = " + f.EnumVal + ",");
                    else
                        sb.AppendLine("        public " + f.Type + " " + f.Name + " " + f.GetterSetter);
                }

                foreach (var f in c.Functions)
                {
                    if (f.Name == "ClientReceiveLocalizedMessage") continue; // todo fix
                    var returnType = f.Params.FirstOrDefault(pa => pa.Name == "ReturnValue")?.Type ?? "void";
                    var parameters = string.Join(", ",
                        f.Params.FindAll(pa => pa.Name != "ReturnValue").Select(pa => pa.Type + " " + pa.Name));
                    var args = f.Params.FindAll(pa => pa.Name != "ReturnValue").Select(pa => pa.Name).ToList();
                    args.Insert(0, "nameof(" + f.Name + ")");
                    var argList = string.Join(", ", args);
                    var returnTypeTemplate = returnType == "void" ? "" : ("<" + returnType + ">");
                    sb.AppendLine("        public " + returnType + " " + f.Name + "(" + parameters + ") { " +
                                  (returnType == "void" ? "" : "return ") + "Invoke" + returnTypeTemplate + "(" +
                                  argList + "); }");
                }

                sb.AppendLine("    }");
            }

            sb.AppendLine("}");
            if (printedClasses == 0)
                continue;
            System.IO.File.WriteAllText(location + @"\" + p.Name + ".cs", sb.ToString());
        }
    }


    public void DumpGNames()
    {
        var testObj = new UObject(0);
        var sb = new StringBuilder();
        var i = 0;
        while (true)
        {
            var name = UObject.GetName(i);

            if (name == "badIndex")
            {
                if ((i & 0xffff) > 0xff00)
                {
                    i += 0x10000 - (i % 0x10000);
                    continue;
                }

                break;
            }

            sb.AppendLine("[" + i + " | " + (i).ToString("X") + "] " + name);
            i += name.Length / 2 + name.Length % 2 + 1;
        }

        Directory.CreateDirectory(_ue.Process.ProcessName);
        File.WriteAllText(_ue.Process.ProcessName + @"\GNamesDump.txt", sb.ToString());
    }


    public void DumpObjects()
    {
        var entityList = _ue.MemoryReadPtr(_ue.BaseAddress + _ue.GObjects);
        var count = _ue.MemoryReadInt(_ue.BaseAddress + _ue.GObjects + 0x14);

        entityList = _ue.MemoryReadPtr(entityList);
        var packages = new Dictionary<nint, List<nint>>();
        for (var i = 0; i < count; i++)
        {
            // var entityAddr = _unrealEngine.ReadProcessMemory<UInt64>((entityList + 8 * (i / 0x10400)) + 24 * (i % 0x10400));
            var entityAddr = _ue.MemoryReadPtr((entityList + 8 * (i >> 16)) + 24 * (i % 0x10000));
            if (entityAddr == 0) continue;
            var outer = entityAddr;
            while (true)
            {
                var tempOuter = _ue.MemoryReadPtr(outer + UObject.ObjectOuterOffset);
                if (tempOuter == 0) break;
                outer = tempOuter;
            }

            if (!packages.ContainsKey(outer)) packages.Add(outer, new List<nint>());
            packages[outer].Add(entityAddr);
        }
        
        var dumpedPackages = new List<Package>();
        var sb = new StringBuilder();
        foreach (var package in packages)
        {
            var packageObj = new UObject(package.Key);
            var fullPackageName = packageObj.GetName();

            if (fullPackageName.Contains("TypedElementFrameworkSDK"))
                Console.WriteLine("");

            var dumpedClasses = new List<string>();
            var sdkPackage = new Package { FullName = fullPackageName };
            foreach (var objAddr in package.Value)
            {
                var obj = new UObject(objAddr);
                if (dumpedClasses.Contains(obj.ClassName))
                    continue;

                if (obj.ClassName.IndexOf("Default__FSDGameMode") > 0)
                {

                }

                sb.AppendLine(obj.ClassName);
            }

        }

        Directory.CreateDirectory(_ue.Process.ProcessName);
        File.WriteAllText(_ue.Process.ProcessName + @"\DumpObjects.txt", sb.ToString());

    }
}
