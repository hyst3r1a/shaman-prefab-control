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

        public static string[] Enumerate()
        {
            string[] allfiles = Directory.GetFiles("/Users/mihailgorsenin/SPCTest", "*.html", SearchOption.AllDirectories);
            return allfiles;
        }

        public static void ShallowClone()
        {
            string mkdirCommand = "mkdir";
            string dirName = "SPCTest";

            string cdCommand = "cd";
            string commonPath = "/Users/mihailgorsenin/SPCTest";
            string uncommonPath = "/Users/mihailgorsenin/";

            string gitCommand = "git";
            string gitShallowCheckoutArgument = @"pull origin master";
            string gitInitArgument = @"init";
            string gitRemoteCommand = @"remote add origin https://github.com/hyst3r1a/sharplitedocs";
            string gitSparseConfig = @"config core.sparseCheckout true";



            string echo = "echo";
            string folder = "\"/1/items/\" \"\">> .git/info/sparse-checkout\"\"";
      

            Process.Start(cdCommand, uncommonPath);
            Process.Start(mkdirCommand, dirName);
            Process.Start(cdCommand, dirName);

           

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "git";
            startInfo.Arguments = "init";
            startInfo.WorkingDirectory = commonPath;
            Process.Start(startInfo);

            startInfo.Arguments = gitRemoteCommand;
            Process.Start(startInfo);
            startInfo.Arguments = gitSparseConfig;
            Process.Start(startInfo);

            startInfo.FileName = "echo";
            startInfo.Arguments = folder;
            Process.Start(echo, folder);
            //path of file

            var path = @"/Users/mihailgorsenin/SPCTest/.git/info/sparse-checkout";
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
                    webBuilder.UseStartup<Startup>();
                   
                });
    }
}
