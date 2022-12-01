using System;
using System.IO;
using System.Threading.Tasks;

namespace SCPSL_CmdBinder
{
    public class Program
    {
        public static void Main()
        {
            var gamePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SCP Secret Laboratory");

            if (!Directory.Exists(gamePath))
            {
                Console.WriteLine("SCP Secret Laboratory in AppData / .config Not Found!");
                
                Task.Delay(5000).ContinueWith(_ => Environment.Exit(0));
            }
            var bindingsTxt = Path.Combine(gamePath, "cmdbinding.txt");
            if (!File.Exists(bindingsTxt))
                File.Create(bindingsTxt).Close();
            
            // TODO: Improve the code to correctly add the binding
            try
            {
                Console.WriteLine("Enter Command: ");
                var command = Console.ReadLine();
                
                if (command is not null)
                {
                    File.WriteAllText(bindingsTxt, $"{command}\n");
                    Console.WriteLine("Command Added!");
                    return;
                }
                Console.WriteLine("Command Null!");
                Task.Delay(5000).ContinueWith(_ => Environment.Exit(0));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured while writing in the file: " + ex);
            }
        }
    }
}