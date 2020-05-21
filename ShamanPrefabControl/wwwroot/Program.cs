using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LibGit2Sharp;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;


namespace ShamanPrefabControl
{
    public class Program
    {
        public static string debugString = String.Empty;

        public static List<String> Enumerate()
        {
            //string[] allfiles = Directory.GetFiles("/Users/mihailgorsenin/SPCTest", "*.html", SearchOption.AllDirectories);
            string[] allfiles = Directory.GetFiles("/tmp/SPCTest", "*.prefab", SearchOption.AllDirectories);
            debugString = "enumeration succesful";
            return allfiles.ToList();
        }

        public static void ShallowClone()
        {
            
            
            string mkdirCommand = "mkdir";
            string dirName = "/tmp/SPCTest";

            string cdCommand = "cd";
            //string commonPath = "/Users/mihailgorsenin/SPCTest";
            //string uncommonPath = "/Users/mihailgorsenin/";

            string commonPath = "/tmp/SPCTest";
            string uncommonPath = "/tmp/";

            string gitCommand = "git";
            string gitCheckout = "checkout develop";
            string gitShallowCheckoutArgument = @"pull origin develop";
            string gitInitArgument = @"init";
            string gitRemoteCommand = @"remote add origin https://hyst3r1a:jnrMqqcGu7zabzW6EV2q@bitbucket.org/shaman_games/witchs-tales-1-mobile.git";
            string gitSparseConfig = @"config core.sparseCheckout true";



            string echo = "echo";
            string folder = "\"/Assets/Resources/Prefabs/\" \"\">> .git/info/sparse-checkout\"\"";

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ls";
            startInfo.Arguments = "/tmp";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            var a = Process.Start(startInfo);
            while (!a.StandardOutput.EndOfStream)
            {
                var line = a.StandardOutput.ReadLine();
                debugString += line;
                Console.WriteLine(line);
            }
            
            debugString = "ShallowClone started.";
           
            Process.Start(mkdirCommand, dirName);
            debugString = "mkdir run";


            //var path = @"/app/sparse-checkout";

            //using (StreamWriter sw = new StreamWriter(path))
            //{
            //    sw.Write("/1/");
                
            //}




            startInfo.FileName = "git";
            startInfo.Arguments = "init";
            startInfo.WorkingDirectory = commonPath;
            Process.Start(startInfo);
            debugString = "run git init";

            startInfo.Arguments = gitRemoteCommand;
            Process.Start(startInfo);
            debugString = "run git remote add";
            startInfo.Arguments = gitSparseConfig;
            Process.Start(startInfo);
            debugString = "add strings to git config";

            startInfo.FileName = "echo";
            startInfo.Arguments = folder;
            Process.Start(echo, folder);
            debugString = "SPARSE!";
            //path of file

            var path = @"/tmp/SPCTest/.git/info/sparse-checkout";
            //path = @".git/info/sparse-checkout";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write("/Assets/Resources/Prefabs");
            }

            startInfo.FileName = gitCommand;
            startInfo.Arguments = gitShallowCheckoutArgument;
            Process.Start(startInfo);




        }
       
        public static void Main(string[] args)
         {
            CreateHostBuilder(args).Build().Run();

        }

     
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
                   
                });
    }
}
