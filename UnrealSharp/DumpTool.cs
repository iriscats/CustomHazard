using SDK.Script.FSDSDK;
using System.Text;

namespace UnrealSharp
{

    public class DumpTool
    {
        public class Package
        {
            public String FullName;
            public String Name => FullName.Substring(FullName.LastIndexOf("/") + 1);
            public List<SDKClass> Classes = new List<SDKClass>();
            public List<Package> Dependencies = new List<Package>();

            public class SDKClass
            {
                public String SdkType;
                public String Namespace;
                public String Name;
                public String Parent;
                public List<SDKFields> Fields = new List<SDKFields>();
                public List<SDKFunctions> Functions = new List<SDKFunctions>();

                public class SDKFields
                {
                    public String Type;
                    public String Name;
                    public String GetterSetter;
                    public Int32 EnumVal;
                }

                public class SDKFunctions
                {
                    public String ReturnType;
                    public String Name;
                    public List<SDKFields> Params = new List<SDKFields>();
                }
            }
        }


        public static Memory Memory;
        public static nint GObjects;
        public static nint GEngine;
        public static nint GStaticCtor;


        public DumpTool()
        {
            Memory = UnrealEngine.Memory;
            GObjects = UnrealEngine.GObjects;
            GEngine = UnrealEngine.GEngine;
            GStaticCtor = UnrealEngine.GStaticCtor;
        }


        public void EnableConsole()
        {
            var engine = new UEObject(GEngine);
            var console = new UEObject(Memory.Execute(GStaticCtor,
                engine["ConsoleClass"].Value,
                engine["GameViewport"].Address,
                0, 0, 0, 0, 0, 0, 0));
            engine["GameViewport"]["ViewportConsole"] = console;
        }


        public String GetTypeFromFieldAddr(String fName, String fType, nint fAddr, out String gettersetter)
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
                var structFieldIndex = UnrealEngine.Memory.ReadProcessMemory<Int32>(
                    UnrealEngine.Memory.ReadProcessMemory<nint>(fAddr + UEObject.propertySize) + UEObject.nameOffset);
                fType = UEObject.GetName(structFieldIndex);
                gettersetter = "{ get { return this[nameof(" + fName + ")].As<" + fType + ">(); } set { this[\"" +
                               fName + "\"] = value; } }";
            }
            else if (fType == "ClassPtrProperty")
            {
                fType = "Object";
                gettersetter = "{ get { return this[nameof(" + fName + ")].As<" + fType + ">(); } set { this[\"" +
                               fName + "\"] = value; } } // ClassPtrProperty";
            }
            else if (fType == "ScriptTypedElementHandle")
            {
                fType = "Object";
                gettersetter = "{ get { return this[nameof(" + fName + ")].As<" + fType + ">(); } set { this[\"" +
                               fName + "\"] = value; } } // ClassPtrProperty";
            }
            else if (fType == "StructProperty")
            {
                var structFieldIndex = UnrealEngine.Memory.ReadProcessMemory<Int32>(
                    UnrealEngine.Memory.ReadProcessMemory<nint>(fAddr + UEObject.propertySize) + UEObject.nameOffset);
                fType = UEObject.GetName(structFieldIndex);
                //gettersetter = "{ get { return UnrealEngine.Memory.ReadProcessMemory<" + fType + ">(this[nameof(" + fName + ")].Address); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
                gettersetter = "{ get { return this[nameof(" + fName + ")].As<" + fType + ">(); } set { this[\"" +
                               fName + "\"] = value; } }";
            }
            else if (fType == "EnumProperty")
            {
                var structFieldIndex = UnrealEngine.Memory.ReadProcessMemory<Int32>(
                    UnrealEngine.Memory.ReadProcessMemory<nint>(fAddr + UEObject.propertySize + 8) +
                    UEObject.nameOffset);
                fType = UEObject.GetName(structFieldIndex);
                gettersetter = "{ get { return (" + fType + ")this[nameof(" + fName +
                               ")].GetValue<int>(); } set { this[nameof(" + fName + ")].SetValue<int>((int)value); } }";
            }
            else if (fType == "NameProperty")
            {
                fType = "unk";
            }
            else if (fType == "ArrayProperty")
            {
                var inner = UnrealEngine.Memory.ReadProcessMemory<nint>(fAddr + UEObject.propertySize);
                var innerClass = UnrealEngine.Memory.ReadProcessMemory<nint>(inner + UEObject.fieldClassOffset);
                var structFieldIndex = UnrealEngine.Memory.ReadProcessMemory<Int32>(innerClass);
                fType = UEObject.GetName(structFieldIndex);
                var innerType = GetTypeFromFieldAddr(fName, fType, inner, out gettersetter);
                gettersetter = "{ get { return new Array<" + innerType + ">(this[nameof(" + fName +
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
                fType = "Object";
                gettersetter = "{ get { return this[nameof(" + fName + ")]; } set { this[nameof(" + fName +
                               ")] = value; } }";
            }

            return fType;
        }


        public void DumpSdk(String location = "")
        {
            if (location == "")
                location = Memory.Process.ProcessName;

            Directory.CreateDirectory(location);
            var entityList = Memory.ReadProcessMemory<nint>(Memory.BaseAddress + GObjects);
            var count = Memory.ReadProcessMemory<UInt32>(Memory.BaseAddress + GObjects + 0x14);
            entityList = Memory.ReadProcessMemory<nint>(entityList);
            var packages = new Dictionary<nint, List<nint>>();
            for (var i = 0; i < count; i++)
            {
                // var entityAddr = Memory.ReadProcessMemory<UInt64>((entityList + 8 * (i / 0x10400)) + 24 * (i % 0x10400));
                var entityAddr = Memory.ReadProcessMemory<nint>((entityList + 8 * (i >> 16)) + 24 * (i % 0x10000));
                if (entityAddr == 0) continue;
                var outer = entityAddr;
                while (true)
                {
                    var tempOuter = Memory.ReadProcessMemory<nint>(outer + UEObject.objectOuterOffset);
                    if (tempOuter == 0) break;
                    outer = tempOuter;
                }

                if (!packages.ContainsKey(outer)) packages.Add(outer, new List<nint>());
                packages[outer].Add(entityAddr);
            }

            var ii = 0;
            var dumpedPackages = new List<Package>();
            foreach (var package in packages)
            {
                var packageObj = new UEObject(package.Key);
                var fullPackageName = packageObj.GetName();
                if (fullPackageName.Contains("TypedElementFrameworkSDK"))
                    Console.WriteLine("");
                var dumpedClasses = new List<String>();
                var sdkPackage = new Package { FullName = fullPackageName };
                foreach (var objAddr in package.Value)
                {
                    var obj = new UEObject(objAddr);
                    if (dumpedClasses.Contains(obj.ClassName)) continue;
                    dumpedClasses.Add(obj.ClassName);
                    if (obj.ClassName.StartsWith("Package")) continue;
                    var typeName = obj.ClassName.StartsWith("Class") ? "class" :
                        obj.ClassName.StartsWith("ScriptStruct") ? "class" :
                        obj.ClassName.StartsWith("Enum") ? "enum" : "unk";
                    //if (obj.ClassName.StartsWith("BlueprintGenerated")) typeName = "class";
                    var className = obj.GetName();
                    if (typeName == "unk") continue;
                    if (className == "Object") continue;
                    var parentClass =
                        UnrealEngine.Memory.ReadProcessMemory<nint>(obj.Address + UEObject.structSuperOffset);
                    var sdkClass = new Package.SDKClass
                    { Name = className, Namespace = fullPackageName, SdkType = typeName };
                    if (typeName == "enum") sdkClass.Parent = "int";
                    else if (parentClass != 0)
                    {
                        var parentNameIndex =
                            UnrealEngine.Memory.ReadProcessMemory<Int32>(parentClass + UEObject.nameOffset);
                        var parentName = UEObject.GetName(parentNameIndex);
                        sdkClass.Parent = parentName;
                    }
                    else sdkClass.Parent = "Object";
                    //else throw new Exception("unparented obj not supported");

                    if (typeName == "enum")
                    {
                        var enumArray = UnrealEngine.Memory.ReadProcessMemory<nint>(objAddr + 0x40);
                        var enumCount = UnrealEngine.Memory.ReadProcessMemory<int>(objAddr + 0x48);
                        for (var i = 0; i < enumCount; i++)
                        {
                            var enumNameIndex = UnrealEngine.Memory.ReadProcessMemory<Int32>(enumArray + i * 0x10);
                            var enumName = UEObject.GetName(enumNameIndex);
                            enumName = enumName.Substring(enumName.LastIndexOf(":") + 1);
                            var enumNameRepeatedIndex =
                                UnrealEngine.Memory.ReadProcessMemory<Int32>(enumArray + i * 0x10 + 4);
                            if (enumNameRepeatedIndex > 0)
                                enumName += "_" + enumNameRepeatedIndex;
                            var enumVal = UnrealEngine.Memory.ReadProcessMemory<Int32>(enumArray + i * 0x10 + 0x8);
                            sdkClass.Fields.Add(new Package.SDKClass.SDKFields { Name = enumName, EnumVal = enumVal });
                        }
                    }
                    else if (typeName == "unk")
                    {
                        continue;
                    }
                    else
                    {
                        var field = obj.Address + UEObject.childPropertiesOffset - UEObject.fieldNextOffset;
                        while ((field = UnrealEngine.Memory.ReadProcessMemory<nint>(field + UEObject.fieldNextOffset)) >
                               0)
                        {
                            var fName = UEObject.GetName(
                                UnrealEngine.Memory.ReadProcessMemory<Int32>(field + UEObject.fieldNameOffset));
                            var fType = obj.GetFieldType(field);
                            var fValue = "(" + field.ToString() + ")";
                            var offset = (UInt32)obj.GetFieldOffset(field);
                            var gettersetter =
                                "{ get { return new {0}(this[\"{1}\"].Address); } set { this[\"{1}\"] = value; } }";
                            fType = GetTypeFromFieldAddr(fName, fType, field, out gettersetter);
                            //if (typeName == "struct") gettersetter = ";";
                            if (fName == className) fName += "_value";
                            sdkClass.Fields.Add(new Package.SDKClass.SDKFields
                            { Type = fType, Name = fName, GetterSetter = gettersetter });
                        }

                        field = obj.Address + UEObject.childrenOffset - UEObject.funcNextOffset;
                        while ((field = UnrealEngine.Memory.ReadProcessMemory<nint>(field + UEObject.funcNextOffset)) >
                               0)
                        {
                            var fName = UEObject.GetName(
                                UnrealEngine.Memory.ReadProcessMemory<Int32>(field + UEObject.nameOffset));
                            if (fName == className) fName += "_value";
                            var func = new Package.SDKClass.SDKFunctions { Name = fName };
                            var fField = field + UEObject.childPropertiesOffset - UEObject.fieldNextOffset;
                            while ((fField = UnrealEngine.Memory.ReadProcessMemory<nint>(fField +
                                       UEObject.fieldNextOffset)) > 0)
                            {
                                var pName = UEObject.GetName(
                                    UnrealEngine.Memory.ReadProcessMemory<Int32>(fField + UEObject.fieldNameOffset));
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
                            tp.Classes.Count(tc => tc.Name == f.Type?.Replace("Array<", "").Replace(">", "")) > 0);
                        if (fromPackage != null && fromPackage != p && !p.Dependencies.Contains(fromPackage))
                            p.Dependencies.Add(fromPackage);
                    }

                    foreach (var f in c.Functions)
                    {
                        foreach (var param in f.Params)
                        {
                            var fromPackage = dumpedPackages.Find(tp =>
                                tp.Classes.Count(tc => tc.Name == param.Type?.Replace("Array<", "").Replace(">", "")) >
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
                sb.AppendLine("using UnrealSharp;");
                sb.AppendLine("using Object = UnrealSharp.UEObject;");
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
                        var parameters = String.Join(", ",
                            f.Params.FindAll(pa => pa.Name != "ReturnValue").Select(pa => pa.Type + " " + pa.Name));
                        var args = f.Params.FindAll(pa => pa.Name != "ReturnValue").Select(pa => pa.Name).ToList();
                        args.Insert(0, "nameof(" + f.Name + ")");
                        var argList = String.Join(", ", args);
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
            var testObj = new UEObject(0);
            var sb = new StringBuilder();
            var i = 0;
            while (true)
            {
                var name = UEObject.GetName(i);

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

            Directory.CreateDirectory(Memory.Process.ProcessName);
            File.WriteAllText(Memory.Process.ProcessName + @"\GNamesDump.txt", sb.ToString());
        }


        public void DumpObjects()
        {
            var entityList = Memory.ReadProcessMemory<nint>(Memory.BaseAddress + GObjects);
            var count = Memory.ReadProcessMemory<UInt32>(Memory.BaseAddress + GObjects + 0x14);

            entityList = Memory.ReadProcessMemory<nint>(entityList);
            var packages = new Dictionary<nint, List<nint>>();
            for (var i = 0; i < count; i++)
            {
                // var entityAddr = Memory.ReadProcessMemory<UInt64>((entityList + 8 * (i / 0x10400)) + 24 * (i % 0x10400));
                var entityAddr = Memory.ReadProcessMemory<nint>((entityList + 8 * (i >> 16)) + 24 * (i % 0x10000));
                if (entityAddr == 0) continue;
                var outer = entityAddr;
                while (true)
                {
                    var tempOuter = Memory.ReadProcessMemory<nint>(outer + UEObject.objectOuterOffset);
                    if (tempOuter == 0) break;
                    outer = tempOuter;
                }

                if (!packages.ContainsKey(outer)) packages.Add(outer, new List<nint>());
                packages[outer].Add(entityAddr);
            }


            var ii = 0;
            var dumpedPackages = new List<Package>();
            foreach (var package in packages)
            {
                var packageObj = new UEObject(package.Key);
                var fullPackageName = packageObj.GetName();

                if (fullPackageName.Contains("TypedElementFrameworkSDK"))
                    Console.WriteLine("");


                var dumpedClasses = new List<String>();
                var sdkPackage = new Package { FullName = fullPackageName };
                foreach (var objAddr in package.Value)
                {
                    var obj = new UEObject(objAddr);
                    if (dumpedClasses.Contains(obj.ClassName))
                        continue;

                    if (obj.ClassName.IndexOf("GameFunctionLibrary") > 0)
                    {
                        Console.WriteLine(obj);

                        var game = obj.As<GameFunctionLibrary>();
                        game.GetFSDGameMode(new UEObject(UnrealEngine.GWorldPtr));

                    }


                    dumpedClasses.Add(obj.ClassName);


                    if (obj.ClassName.StartsWith("Package"))
                        continue;


                    var typeName = obj.ClassName.StartsWith("Class") ? "class" :
                        obj.ClassName.StartsWith("ScriptStruct") ? "class" :
                        obj.ClassName.StartsWith("Enum") ? "enum" : "unk";
                    //if (obj.ClassName.StartsWith("BlueprintGenerated")) typeName = "class";



                    var className = obj.GetName();
                    if (typeName == "unk") continue;
                    if (className == "Object") continue;
                    var parentClass =
                        UnrealEngine.Memory.ReadProcessMemory<nint>(obj.Address + UEObject.structSuperOffset);


                    var sdkClass = new Package.SDKClass
                    {
                        Name = className,
                        Namespace = fullPackageName,
                        SdkType = typeName
                    };


                    if (typeName == "enum") sdkClass.Parent = "int";
                    else if (parentClass != 0)
                    {
                        var parentNameIndex =
                            UnrealEngine.Memory.ReadProcessMemory<Int32>(parentClass + UEObject.nameOffset);
                        var parentName = UEObject.GetName(parentNameIndex);
                        sdkClass.Parent = parentName;
                    }
                    else sdkClass.Parent = "Object";
                    //else throw new Exception("unparented obj not supported");

                    if (typeName == "enum")
                    {
                        var enumArray = UnrealEngine.Memory.ReadProcessMemory<nint>(objAddr + 0x40);
                        var enumCount = UnrealEngine.Memory.ReadProcessMemory<int>(objAddr + 0x48);
                        for (var i = 0; i < enumCount; i++)
                        {
                            var enumNameIndex = UnrealEngine.Memory.ReadProcessMemory<Int32>(enumArray + i * 0x10);
                            var enumName = UEObject.GetName(enumNameIndex);
                            enumName = enumName.Substring(enumName.LastIndexOf(":") + 1);
                            var enumNameRepeatedIndex =
                                UnrealEngine.Memory.ReadProcessMemory<Int32>(enumArray + i * 0x10 + 4);
                            if (enumNameRepeatedIndex > 0)
                                enumName += "_" + enumNameRepeatedIndex;
                            var enumVal = UnrealEngine.Memory.ReadProcessMemory<Int32>(enumArray + i * 0x10 + 0x8);
                            sdkClass.Fields.Add(new Package.SDKClass.SDKFields { Name = enumName, EnumVal = enumVal });
                        }
                    }
                    else if (typeName == "unk")
                    {
                        continue;
                    }
                    else
                    {
                        var field = obj.Address + UEObject.childPropertiesOffset - UEObject.fieldNextOffset;
                        while ((field = UnrealEngine.Memory.ReadProcessMemory<nint>(field + UEObject.fieldNextOffset)) >
                               0)
                        {
                            var fName = UEObject.GetName(
                                UnrealEngine.Memory.ReadProcessMemory<Int32>(field + UEObject.fieldNameOffset));
                            var fType = obj.GetFieldType(field);
                            var fValue = "(" + field.ToString() + ")";
                            var offset = (UInt32)obj.GetFieldOffset(field);
                            var gettersetter =
                                "{ get { return new {0}(this[\"{1}\"].Address); } set { this[\"{1}\"] = value; } }";
                            fType = GetTypeFromFieldAddr(fName, fType, field, out gettersetter);
                            //if (typeName == "struct") gettersetter = ";";
                            if (fName == className) fName += "_value";
                            sdkClass.Fields.Add(new Package.SDKClass.SDKFields
                            { Type = fType, Name = fName, GetterSetter = gettersetter });
                        }

                        field = obj.Address + UEObject.childrenOffset - UEObject.funcNextOffset;
                        while ((field = UnrealEngine.Memory.ReadProcessMemory<nint>(field + UEObject.funcNextOffset)) >
                               0)
                        {
                            var fName = UEObject.GetName(
                                UnrealEngine.Memory.ReadProcessMemory<Int32>(field + UEObject.nameOffset));
                            if (fName == className) fName += "_value";
                            var func = new Package.SDKClass.SDKFunctions { Name = fName };
                            var fField = field + UEObject.childPropertiesOffset - UEObject.fieldNextOffset;
                            while ((fField = UnrealEngine.Memory.ReadProcessMemory<nint>(fField +
                                       UEObject.fieldNextOffset)) > 0)
                            {
                                var pName = UEObject.GetName(
                                    UnrealEngine.Memory.ReadProcessMemory<Int32>(fField + UEObject.fieldNameOffset));
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
                foreach (var c in p.Classes)
                {
                    Console.WriteLine(c.SdkType + " " + c.Name);
                    if (c.Name == "GameFunctionLibrary")
                    {
                        Console.WriteLine(c);
                    }
                }
            }



        }
    }
}