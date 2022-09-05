using DecisionsFramework.Design.Flow;
using System.IO;
using System.Text;
using System.Linq;

namespace Zitac.RemoveBOM
{

    [AutoRegisterMethodsOnClass(true, "File Management", "BOM")]
    public class RemoveBOMSteps {

        public byte[] RemoveBOM(byte[] File)
        {
            using (StreamReader sr = new StreamReader(new MemoryStream(File), Encoding.UTF8))
            {
                var bytesWithoutBOM = new UTF8Encoding(false).GetBytes(sr.ReadToEnd());
                return bytesWithoutBOM;
            }
        }

        public bool IsBOM(byte[] File)
        {
            var enc = new UTF8Encoding(true);
            var preamble = enc.GetPreamble();
            if (preamble.Where((p, i) => p != File[i]).Any()) 
                return false;
            else
                return true;
        }
        public byte[] AddBOM(byte[] File)
        {
            using (StreamReader sr = new StreamReader(new MemoryStream(File), Encoding.UTF8))
            {
                var bytesWithBOM = new UTF8Encoding(true).GetBytes(sr.ReadToEnd());
                return bytesWithBOM;
            }
        }
    }
}