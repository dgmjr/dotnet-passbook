using System.IO;

namespace Passbook.Generator
{
    public class Pass(string packagePathAndName)
    {
        private readonly string _packagePathAndName = packagePathAndName;

        public byte[] GetPackage() => File.ReadAllBytes(_packagePathAndName);

        public string PackageDirectory => Path.GetDirectoryName(_packagePathAndName);
    }
}
