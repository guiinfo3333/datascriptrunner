using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DatabaseScriptRunner.Infraestructure.DataManager;
using DatabaseScriptRunner.Infraestructure.RunnerScript;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DatabaseScriptRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // DatabaseManager alan = new DatabaseManager();
       //    Connection cc = new Connection("Server = db4free.net;Database = bancodedadostuf; Uid = admintoin; Pwd = 12345678t;");
       //   cc.AbrirConexao();
            CreateWebHostBuilder(args).Build().Run();
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
