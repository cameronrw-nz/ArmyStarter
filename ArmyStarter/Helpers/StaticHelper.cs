using System.IO;
using BinaryFormatter;

namespace ArmyStarter
{
    public static class StaticHelper
    {
        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryConverter();
                formatter.Serialize(obj, ms);
                ms.Position = 0;

                return formatter.Deserialize<T>(ms.ToArray());
            }
        }
    }
}
