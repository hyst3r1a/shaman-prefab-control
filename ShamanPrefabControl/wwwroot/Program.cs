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
using Bitbucket.Net;
using System.Diagnostics;


namespace ShamanPrefabControl
{
    public class Program
    {
        public static string debugString = String.Empty;

        public static string[] Enumerate()
        {
            //string[] allfiles = Directory.GetFiles("/Users/mihailgorsenin/SPCTest", "*.html", SearchOption.AllDirectories);
            string[] allfiles = Directory.GetFiles("/app/ShamanPrefabControl/SPCTest", "*.html", SearchOption.AllDirectories);
            debugString = "enumeration succesful";
            return allfiles;
        }

        public static void ShallowClone()
        {
            
            
            string mkdirCommand = "mkdir";
            string dirName = "SPCTest";

            string cdCommand = "cd";
            //string commonPath = "/Users/mihailgorsenin/SPCTest";
            //string uncommonPath = "/Users/mihailgorsenin/";

            string commonPath = "/app/ShamanPrefabControl/SPCTest";
            string uncommonPath = "/app/ShamanPrefabControl/";

            string gitCommand = "git";
            string gitShallowCheckoutArgument = @"pull origin master";
            string gitInitArgument = @"init";
            string gitRemoteCommand = @"remote add origin https://github.com/hyst3r1a/sharplitedocs";
            string gitSparseConfig = @"config core.sparseCheckout true";



            string echo = "echo";
            string folder = "\"/1/items/\" \"\">> .git/info/sparse-checkout\"\"";


            

            debugString = "ShallowClone started.";
            Process.Start(cdCommand, uncommonPath);
            debugString = "cd success";
            Process.Start(mkdirCommand, dirName);
            debugString = "mkdir run";
            Process.Start(cdCommand, dirName);
            debugString = "cd success 2";


            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = "ls";
            startInfo.Arguments = "/app";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            var a = Process.Start(startInfo);
            while (!a.StandardOutput.EndOfStream)
            {
                var line = a.StandardOutput.ReadLine();
                debugString += line;
                Console.WriteLine("Pi");
            }

            System.Threading.Thread.Sleep(10000);

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

            //var path = @"/Users/mihailgorsenin/SPCTest/.git/info/sparse-checkout";
            var path = @"/app/ShamanPrefabControl/SPCTest.git/info/sparse-checkout";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write("/1/");
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
