using System;
using System.IO;
using RepairsManager.WriteOffModule.Services;

namespace RM.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllBytes(@"Price1.xlsx", StateRepository.GetWorkOffCertificate(null, DateTime.Now));
            Console.WriteLine(StateRepository.State.Director);
        }
    }
}
