using System.Text;
using UnrealDotNet.Types;

namespace UnrealDotNet;

public class UObjectCache
{

    static Dictionary<string, UObject> dumpedClasses = new Dictionary<string, UObject>();

    public static UObject FindObject(string objectName)
    {

        if (dumpedClasses.Count > 0)
        {
            return dumpedClasses[objectName];
        }

        UnrealEngine _ue = UnrealEngine.GetInstance();

        var entityList = _ue.MemoryReadPtr(_ue.BaseAddress + _ue.GObjects);
        var count = _ue.MemoryReadInt(_ue.BaseAddress + _ue.GObjects + 0x14);

        entityList = _ue.MemoryReadPtr(entityList);
        var packages = new Dictionary<nint, List<nint>>();
        for (var i = 0; i < count; i++)
        {
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
                packages.Add(outer, new List<nint>());

            packages[outer].Add(entityAddr);
        }


        foreach (var package in packages)
        {
            var packageObj = new UObject(package.Key);
            var fullPackageName = packageObj.GetName();

            if (fullPackageName.Contains("TypedElementFrameworkSDK"))
                Console.WriteLine("");


            foreach (var objAddr in package.Value)
            {
                var obj = new UObject(objAddr);
                dumpedClasses[obj.ClassName] = obj;
            }

        }

        return dumpedClasses[objectName];
    }


}