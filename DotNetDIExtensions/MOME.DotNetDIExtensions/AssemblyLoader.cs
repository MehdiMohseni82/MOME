using System;
using System.Reflection;
using System.Runtime.Loader;

namespace MOME.DotNetDIExtensions
{
    public class AssemblyLoader : AssemblyLoadContext
    {
        private AssemblyDependencyResolver _resolver;

        public AssemblyLoader(string assemblyDllPath)
        {
            _resolver = new AssemblyDependencyResolver(assemblyDllPath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            string assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null)
            {
                return LoadFromAssemblyPath(assemblyPath);
            }

            return null;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            string libraryPath = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (libraryPath != null)
            {
                return LoadUnmanagedDllFromPath(libraryPath);
            }

            return IntPtr.Zero;
        }
    }
}
