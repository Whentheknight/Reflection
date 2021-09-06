using System;
using System.Reflection;

namespace AssemblyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll";

            Assembly assembly = Assembly.LoadFile(path);
            ShowAssemblyInfo(assembly);


            Assembly ourAssembly = Assembly.GetExecutingAssembly();
            ShowAssemblyInfo(ourAssembly);

            Console.Read();
        }

        static void ShowAssemblyInfo(Assembly assembly)
        {
            Console.WriteLine(assembly.FullName);
            Console.WriteLine("From GAC? {0}", assembly.GlobalAssemblyCache);
            Console.WriteLine("Path: {0}", assembly.Location);
            Console.WriteLine("Version: {0}", assembly.ImageRuntimeVersion);


            foreach (Module method in assembly.GetModules())
            {
                Console.WriteLine(" Mod: {0}", method.Name);
            }

            Console.WriteLine();
        }
    }
}
