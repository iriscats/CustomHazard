using System.Text;
using UnrealDotNet.SDKTool.Types;
using UnrealDotNet.Types;

namespace UnrealDotNet.SDKTool;

public class DumpSdkTool(string location = "")
{
    private readonly UnrealEngine _ue = UnrealEngine.GetInstance();


    public void DumpSdk()
    {
        var packages = CollectAllPackages();
        var classes = GenerateClass(packages);
        GenerateAllFiles(classes);
    }

    private string GetTypeFromFieldAddr(string fName, string fType, nint fAddr, out string getterSetter)
    {
        getterSetter = "";
        switch (fType)
        {
            case "BoolProperty":
                fType = "bool";
                getterSetter = "{ get { return this[nameof(" + fName + ")].Flag; } set { this[nameof(" + fName +
                               ")].Flag = value; } }";
                break;
            case "ByteProperty":
            case "Int8Property":
                fType = "byte";
                getterSetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                               ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
                break;
            case "Int16Property":
                fType = "short";
                getterSetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                               ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
                break;
            case "UInt16Property":
                fType = "ushort";
                getterSetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                               ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
                break;
            case "IntProperty":
                fType = "int";
                getterSetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                               ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
                break;
            case "UInt32Property":
                fType = "uint";
                getterSetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                               ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
                break;
            case "Int64Property":
                fType = "long";
                getterSetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                               ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
                break;
            case "UInt64Property":
                fType = "ulong";
                getterSetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                               ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
                break;
            case "FloatProperty":
                fType = "float";
                getterSetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                               ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
                break;
            case "DoubleProperty":
                fType = "double";
                getterSetter = "{ get { return this[nameof(" + fName + ")].GetValue<" + fType +
                               ">(); } set { this[nameof(" + fName + ")].SetValue<" + fType + ">(value); } }";
                break;
            case "StrProperty":
            case "TextProperty":
                fType = "unk";
                break;
            case "ObjectProperty":
            {
                var structFieldIndex = _ue.MemoryReadInt(
                    _ue.MemoryReadPtr(fAddr + UObject.PropertySize) + UObject.NameOffset);
                fType = UObject.GetName(structFieldIndex);
                getterSetter = "{ get { return this[nameof(" + fName + ")].As<" + fType + ">(); } set { this[\"" +
                               fName + "\"] = value; } }";
                break;
            }
            case "ClassPtrProperty":
                fType = "UObject";
                getterSetter = "{ get { return this[nameof(" + fName + ")].As<" + fType + ">(); } set { this[\"" +
                               fName + "\"] = value; } } // ClassPtrProperty";
                break;
            case "ScriptTypedElementHandle":
                fType = "UObject";
                getterSetter = "{ get { return this[nameof(" + fName + ")].As<" + fType + ">(); } set { this[\"" +
                               fName + "\"] = value; } } // ClassPtrProperty";
                break;
            case "StructProperty":
            {
                var structFieldIndex = _ue.MemoryReadInt(_ue.MemoryReadPtr(fAddr + UObject.PropertySize) + UObject.NameOffset);
                fType = UObject.GetName(structFieldIndex);
                getterSetter = "{ get { return this[nameof(" + fName + ")].As<" + fType + ">(); } set { this[\"" + fName + "\"] = value; } }";
                break;
            }
            case "EnumProperty":
            {
                var structFieldIndex = _ue.MemoryReadInt(
                    _ue.MemoryReadPtr(fAddr + UObject.PropertySize + 8) +
                    UObject.NameOffset);
                fType = UObject.GetName(structFieldIndex);
                getterSetter = "{ get { return (" + fType + ")this[nameof(" + fName +
                               ")].GetValue<int>(); } set { this[nameof(" + fName + ")].SetValue<int>((int)value); } }";
                break;
            }
            case "NameProperty":
                fType = "unk";
                break;
            case "ArrayProperty":
            {
                var inner = _ue.MemoryReadPtr(fAddr + UObject.PropertySize);
                var innerClass = _ue.MemoryReadPtr(inner + UObject.FieldClassOffset);
                var structFieldIndex = _ue.MemoryReadInt(innerClass);
                fType = UObject.GetName(structFieldIndex);
                var innerType = GetTypeFromFieldAddr(fName, fType, inner, out getterSetter);
                getterSetter = "{ get { return new UArray<" + innerType + ">(this[nameof(" + fName + ")].Address); } }"; 
                fType = "Array<" + innerType + ">";
                break;
            }
            case "SoftObjectProperty":
            case "SoftClassProperty":
            case "WeakObjectProperty":
            case "LazyObjectProperty":
            case "DelegateProperty":
            case "MulticastSparseDelegateProperty":
            case "MulticastInlineDelegateProperty":
            case "ClassProperty":
            case "MapProperty":
            case "SetProperty":
            case "FieldPathProperty":
            case "InterfaceProperty":
                fType = "unk";
                break;
            case "Enum":
                fType = "UEEnum";
                break;
            case "DateTime":
                fType = "UEDateTime";
                break;
            case "Guid":
                fType = "UEGuid";
                break;
        }

        if (fType == "unk")
        {
            fType = "UObject";
            getterSetter = "{ get { return this[nameof(" + fName + ")]; } set { this[nameof(" + fName +
                           ")] = value; } }";
        }

        return fType;
    }


    private Dictionary<nint, List<nint>> CollectAllPackages()
    {
        var entityList = _ue.MemoryReadPtr(_ue.BaseAddress + _ue.GObjects);
        var count = _ue.MemoryReadInt(_ue.BaseAddress + _ue.GObjects + 0x14);
        entityList = _ue.MemoryReadPtr(entityList);
        var packages = new Dictionary<nint, List<nint>>();
        for (var i = 0; i < count; i++)
        {
            // var entityAddr = _unrealEngine.ReadProcessMemory<UInt64>((entityList + 8 * (i / 0x10400)) + 24 * (i % 0x10400));
            var entityAddr = _ue.MemoryReadPtr((entityList + 8 * (i >> 16)) + 24 * (i % 0x10000));
            if (entityAddr == 0)
                continue;

            var outer = entityAddr;
            while (true)
            {
                var tempOuter = _ue.MemoryReadPtr(outer + UObject.ObjectOuterOffset);
                if (tempOuter == 0)
                    break;
                outer = tempOuter;
            }

            if (!packages.ContainsKey(outer))
                packages.Add(outer, []);

            packages[outer].Add(entityAddr);
        }

        return packages;
    }


    private StringBuilder GenerateUsing(StringBuilder sb, Package package)
    {
        sb.AppendLine("using UnrealDotNet;");
        sb.AppendLine("using UnrealDotNet.Types;");
        sb.AppendLine("using Guid = SDK.Script.CoreObjectSDK.Guid;");
        sb.AppendLine("using Enum = SDK.Script.CoreObjectSDK.Enum;");
        sb.AppendLine("using DateTime = SDK.Script.CoreObjectSDK.DateTime;");

        foreach (var d in package.Dependencies)
            sb.AppendLine("using SDK" + d.FullName.Replace("/", ".") + "SDK;");

        return sb;
    }


    private void GenerateAllFiles(List<Package> packages)
    {
        if (location == "")
            location = _ue.Process!.ProcessName;

        Directory.CreateDirectory(location);

        foreach (var p in packages)
        {
            var sb = new StringBuilder();
            sb = GenerateUsing(sb, p);


            sb.AppendLine("namespace SDK" + p.FullName.Replace("/", ".") + "SDK");
            sb.AppendLine("{");

            var printedClasses = 0;

            foreach (var c in p.Classes)
            {
                if (c.Fields.Count > 0)
                    printedClasses++;
                
                sb.AppendLine("    public " + c.SdkType + " " + c.Name +
                              ((c.Parent == null) ? "" : (" : " + c.Parent)));
                
                sb.AppendLine("    {");
                if (c.SdkType != "enum")
                    sb.AppendLine("        public " + c.Name + "(nint addr) : base(addr) { }");

                foreach (var f in c.Fields)
                {
                    if (f.Name == "RelatedPlayerState")
                        continue; // todo fix
                    if (c.SdkType == "enum")
                        sb.AppendLine("        " + f.Name + " = " + f.EnumVal + ",");
                    else
                        sb.AppendLine("        public " + f.Type + " " + f.Name + " " + f.GetterSetter);
                }

                foreach (var f in c.Functions)
                {
                    if (f.Name == "ClientReceiveLocalizedMessage")
                        continue; // todo fix

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

            File.WriteAllText(location + @"\" + p.Name + ".cs", sb.ToString());
        }
    }


    private List<Package> GenerateClass(Dictionary<nint, List<nint>> packages)
    {
        var dumpedPackages = new List<Package>();
        foreach (var package in packages)
        {
            var packageObj = new UObject(package.Key);
            var fullPackageName = packageObj.GetName();
            if (fullPackageName.Contains("TypedElementFrameworkSDK"))
                Console.WriteLine("TypedElementFrameworkSDK");

            var dumpedClasses = new List<string>();
            var sdkPackage = new Package
            {
                FullName = fullPackageName
            };


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


                if (className == "Object")
                    continue;


                var parentClass = _ue.MemoryReadPtr(obj.Address + UObject.StructSuperOffset);
                var sdkClass = new Package.SDKClass
                {
                    Name = className,
                    Namespace = fullPackageName,
                    SdkType = typeName
                };


                if (typeName == "enum")
                    sdkClass.Parent = "int";
                else if (parentClass != 0)
                {
                    var parentNameIndex = _ue.MemoryReadInt(parentClass + UObject.NameOffset);
                    var parentName = UObject.GetName(parentNameIndex);
                    sdkClass.Parent = parentName;
                }
                else
                    sdkClass.Parent = "Object";
                //else throw new Exception("unparented obj not supported");

                if (typeName == "enum")
                {
                    var enumArray = _ue.MemoryReadPtr(objAddr + 0x40);
                    var enumCount = _ue.MemoryReadInt(objAddr + 0x48);
                    for (var i = 0; i < enumCount; i++)
                    {
                        var enumNameIndex = _ue.MemoryReadInt(enumArray + i * 0x10);
                        var enumName = UObject.GetName(enumNameIndex);
                        enumName = enumName.Substring(enumName.LastIndexOf(':') + 1);

                        var enumNameRepeatedIndex = _ue.MemoryReadInt(enumArray + i * 0x10 + 4);

                        if (enumNameRepeatedIndex > 0)
                            enumName += "_" + enumNameRepeatedIndex;

                        var enumVal = _ue.MemoryReadInt(enumArray + i * 0x10 + 0x8);
                        sdkClass.Fields.Add(new Package.SDKClass.SDKFields
                        {
                            Name = enumName,
                            EnumVal = enumVal
                        });
                    }
                }
                else if (typeName == "unk")
                {
                    continue;
                }
                else
                {
                    var field = obj.Address + UObject.ChildPropertiesOffset - UObject.FieldNextOffset;
                    while ((field = _ue.MemoryReadPtr(field + UObject.FieldNextOffset)) > 0)
                    {
                        var fName = UObject.GetName(
                            _ue.MemoryReadInt(field + UObject.FieldNameOffset));
                        var fType = obj.GetFieldType(field);

                        fType = GetTypeFromFieldAddr(fName, fType, field, out var getterSetter);
                     
                        if (fName == className) fName += "_value";
                        sdkClass.Fields.Add(new Package.SDKClass.SDKFields
                        {
                            Type = fType,
                            Name = fName,
                            GetterSetter = getterSetter
                        });
                    }

                    field = obj.Address + UObject.ChildrenOffset - UObject.FuncNextOffset;
                    while ((field = _ue.MemoryReadPtr(field + UObject.FuncNextOffset)) > 0)
                    {
                        var fName = UObject.GetName(_ue.MemoryReadInt(field + UObject.NameOffset));
                        if (fName == className)
                            fName += "_value";

                        var func = new Package.SDKClass.SDKFunctions
                        {
                            Name = fName
                        };

                        var fField = field + UObject.ChildPropertiesOffset - UObject.FieldNextOffset;
                        while ((fField = _ue.MemoryReadPtr(fField + UObject.FieldNextOffset)) > 0)
                        {
                            var pName = UObject.GetName(
                                _ue.MemoryReadInt(fField + UObject.FieldNameOffset));
                            var pType = obj.GetFieldType(fField);
                            pType = GetTypeFromFieldAddr("", pType, fField, out _);
                            func.Params.Add(new Package.SDKClass.SDKFields
                            {
                                Name = pName,
                                Type = pType
                            });
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
                        tp.Classes.Count(tc => tc.Name == f.Type.Replace("UArray<", "").Replace(">", "")) > 0);
                    if (fromPackage != null && fromPackage != p && !p.Dependencies.Contains(fromPackage))
                        p.Dependencies.Add(fromPackage);
                }

                foreach (var f in c.Functions)
                {
                    foreach (var param in f.Params)
                    {
                        var fromPackage = dumpedPackages.Find(tp =>
                            tp.Classes.Count(tc => tc.Name == param.Type.Replace("UArray<", "").Replace(">", "")) >
                            0);
                        if (fromPackage != null && fromPackage != p && !p.Dependencies.Contains(fromPackage))
                            p.Dependencies.Add(fromPackage);
                    }
                }
            }
        }

        return dumpedPackages;
    }
}