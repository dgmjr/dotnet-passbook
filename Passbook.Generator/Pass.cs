using System.IO;

namespace Passbook.Generator
{
    public class Pass
    {
        private readonly string _packagePathAndName;

        public Pass(string packagePathAndName)
        {
            this._packagePathAndName = packagePathAndName;
        }

        public byte[] GetPackage() => File.ReadAllBytes(_packagePathAndName);

        public string PackageDirectory => Path.GetDirectoryName(_packagePathAndName);
    }
}
