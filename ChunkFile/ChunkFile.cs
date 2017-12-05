using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkFile
{
    static class ChunkFile
    {
        public void chunkFile(string sourceFileFullName, int chunkSize)
        {

            int chunkRowCount = 0;
            int chunk = 1;
            string inputFileName = Path.GetFileNameWithoutExtension(sourceFileFullName);
            string extension = Path.GetExtension(sourceFileFullName);

            string outputFileName;

            if (!File.Exists(sourceFileFullName))
            {
                Console.WriteLine("Invalid input file.");
            }

            StreamWriter outPutFileWriter;

            using (StreamReader sr = new StreamReader(sourceFileFullName))
            {
                string line = null;

                outputFileName = String.Format("inputFileName_{0}.{1}", chunk, extension);
                outPutFileWriter = new StreamWriter(outputFileName);

                while ((line = sr.ReadLine()) != null)
                {
                    chunkRowCount++;
                   

                    if (chunkRowCount == chunkSize)
                    {
                        chunkRowCount = 0;
                        yield return chunkDataTable;
                        chunkDataTable = null;
                    }
                }
            }
            ////return last set of data which less then chunk size
            //if (null != chunkDataTable)
            //    yield return chunkDataTable;
        }
    }
}
