using System;
using System.Reflection;

namespace AssemblyDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.ServiceProcess.dll";

            BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;

            Assembly theAssembly = Assembly.LoadFrom(path);
            Console.WriteLine(theAssembly.FullName);
            Type[] types = theAssembly.GetTypes();

            foreach (Type t in types)
            {
                Console.WriteLine(" Type: {0}", t.Name);
                MemberInfo[] members = t.GetMembers(flags);

                foreach (MemberInfo member in members)
                {
                    Console.WriteLine(" {0}: {1}", member.MemberType, member.Name);
                }
            }

            Console.Read();
        }
    }
}
