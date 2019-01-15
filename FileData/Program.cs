using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            String filePath = null;
            String requiresVersion = null;
            String requiresSize = null;

            //Check there is 3 arguments, else output below string to help user.
            if (args.Length < 3)
            {
                Console.WriteLine("Please enter a file name and at least 2 argument");
                Console.WriteLine("–v, --v, /v, --version for file version | –s, --s, /s, --size for file size");
            }
            else
            {
                //By using the for method, it doesnt matter what order the user inputs the arguments.
                foreach(var a in args)
                {
                    //Assign File Path
                    if (a.Contains(":\\")){
                        filePath = a;
                        continue;
                    }

                    //Write File version if –v, --v, /v, --version is passed as an argument
                    if (a.Contains("v") || a.Contains("version"))
                    {
                        requiresVersion = a;
                        var fd = new FileDetails();
                        Console.WriteLine("File Version: " + fd.Version(filePath));
                        continue;
                    }

                    //Write file size if –s, --s, /s, --size is passed as an argument
                    if (a.Contains("s") || a.Contains("size")) 
                    {
                        requiresSize = a;
                        var fd = new FileDetails();
                        Console.WriteLine("File Size: " + fd.Size(filePath));
                    }
                }
            }

            // Keep the console open.
            Console.ReadLine(); 
        }
    }
}
