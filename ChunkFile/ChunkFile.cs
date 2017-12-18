using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkFile
{
    public class ChunkFileModule
    {
        public void chunkFile(string sourceFileFullName, int chunkSize)
        {
            if (!File.Exists(sourceFileFullName))
            {
                Console.WriteLine("Invalid input file.");
            }

            using (StreamReader sr = new StreamReader(sourceFileFullName))
            {
                int chunk = 1;
                string line;
                int chunkRowCount = 0;
                string path = Path.GetDirectoryName(sourceFileFullName);
                string inputFileName = Path.GetFileNameWithoutExtension(sourceFileFullName);
                string extension = Path.GetExtension(sourceFileFullName);
                string outputFileName = Path.Combine(path, string.Format("{0}_{1}{2}", inputFileName, chunk, extension));

                StreamWriter outPutFileWriter = null;

                while ((line = sr.ReadLine()) != null)
                {
                    if (chunkRowCount == 0)
                    {
                        // allow rewrite
                        string outputPath = Path.Combine(path, string.Format("{0}_{1}{2}", inputFileName, chunk, extension));
                        if (File.Exists(outputPath))
                        {
                            File.Delete(outputPath);
                        }
                        outPutFileWriter = new StreamWriter(outputPath, true);
                    }
                    chunkRowCount++;
                    outPutFileWriter.WriteLine(line);

                    if (chunkRowCount == chunkSize)
                    {
                        outPutFileWriter.Close();
                        chunkRowCount = 0;
                        chunk++;
                    }  
                }
                outPutFileWriter.Close();
            }
        }
    }
}
