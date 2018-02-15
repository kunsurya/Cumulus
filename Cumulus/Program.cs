using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Cumulus
{
    public class Parameters
    {
        public string Command { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string VAppName { get; set; }
    }

    class Program
    {
        private const string vCloudUrl = "<your org's base vCloud url>";

        private static void ResolveMergedAssesmblies()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => {
                String resourceName = "Cumulus." +
                   new AssemblyName(args.Name).Name + ".dll";
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
        }

        static void Main(string[] args)
        {
            ResolveMergedAssesmblies();

            string[] supportedCommands = {"reset"};

            if (args.Length != 4)
            {
                Console.WriteLine(
                    "Wrong parameters! Usage: cumulus reset -u:<username> -p:<password> -v:<vApp Name>");
                Console.ReadLine();
                return;
            }

            var parameters = new Parameters();

            for (int index = 0; index < args.Length; index++)
            {
                var arg = args[index];
                if (index == 0)
                {
                    if (!supportedCommands.Contains(arg))
                    {
                        Console.WriteLine(
                        "Wrong parameters! Usage: cumulus reset -u:<username> -p:<password> -v:<vApp Name>");
                        Console.ReadLine();
                        return;
                    }

                    parameters.Command = arg;
                    continue;
                }
                
                var param = arg.Split(':');
                if (param.Length != 2)
                {
                    Console.WriteLine(
                        "Wrong parameters! Usage: cumulus reset -u:<username> -p:<password> -v:<vApp Name>");
                    Console.ReadLine();
                    return;
                }

                switch (param[0])
                {
                    case "-u":
                        parameters.Username = param[1] + "@labs"; //user@org; Fix this for your org.
                        break;
                    case "-p":
                        parameters.Password = param[1];
                        break;
                    case "-v":
                        parameters.VAppName = param[1];
                        break;
                    default:
                        Console.WriteLine(
                            "Wrong parameters! Usage: cumulus reset -u:<username> -p:<password> -v:<vApp Name>");
                        Console.ReadLine();
                        return;
                }
            }

            if (string.IsNullOrEmpty(parameters.Command) ||
                string.IsNullOrEmpty(parameters.Username) ||
                string.IsNullOrEmpty(parameters.Password) ||
                string.IsNullOrEmpty(parameters.VAppName))
            {
                Console.WriteLine("Wrong parameters! Usage: cumulus reset -u:<username> -p:<password> -v:<vApp Name>");
                Console.ReadLine();
                return;
            }

            switch (parameters.Command)
            {
                case ("reset"):
                    string result = new VCloudClient(vCloudUrl, parameters).Reset();
                    Console.WriteLine(result);
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Unsupported Command. Usage: cumulus reset -u:<username> -p:<password> -v:<vApp Name>");
                    Console.ReadLine();
                    return;
            }
        }
    }
}
