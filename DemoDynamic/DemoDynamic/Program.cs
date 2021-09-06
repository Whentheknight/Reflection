using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace DemoDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyName theName = new AssemblyName();
            theName.Name = "DemoAssembly";
            theName.Version = new Version("1.0.0.0");

            AppDomain domain = AppDomain.CurrentDomain;

            AssemblyBuilder assemBldr = domain.DefineDynamicAssembly(theName, AssemblyBuilderAccess.ReflectionOnly);

            ModuleBuilder modBldr = assemBldr.DefineDynamicModule("CodeModule", "DemoAssembly.dll");

            TypeBuilder animalBldr = modBldr.DefineType("Animal", TypeAttributes.Public);

            Type animal = animalBldr.CreateType();
            Console.WriteLine(animal.FullName);

            foreach (MemberInfo info in animal.GetMembers())
            {
                Console.WriteLine(" Member ({0}): {1}", info.MemberType, info.Name);
            }

            Console.Read();
        }
    }
}
