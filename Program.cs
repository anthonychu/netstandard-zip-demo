using System;
using System.IO;
using System.Linq;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;

namespace netstandard_demo
{
    class Program
    {
        private const string folderName = "temp";

        static void Main(string[] args)
        {
            if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
            using (Stream targetStream = new GZipOutputStream(File.Create(Path.Combine(folderName, args[0] + ".tar.gz"))))
            {
                using (var tarArchive = TarArchive.CreateOutputTarArchive(targetStream, TarBuffer.DefaultBlockFactor))
                {
                    var entry = TarEntry.CreateEntryFromFile(args[0]);
                    tarArchive.WriteEntry(entry, true);
                }
            }
            Console.WriteLine("Hello World!" + args.FirstOrDefault());
        }
    }
}
