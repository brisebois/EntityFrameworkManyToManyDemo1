using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.WindowsAzure;
using Model;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new InitializeDatabase());

            var cs = CloudConfigurationManager.GetSetting("DatabaesConnectionString");

            var logs = ReliableModel.Query(m =>
                {
                    var query = m.FlightLogs
                                    .Include(f => f.Airplane)
                                    .Include(f => f.Airports);

                    Console.WriteLine("SQL\n\n"
                                    + query.ToString());

                    return query.ToList();
                }
                ,
                () => new Model.Model(cs));

            Console.WriteLine("\n\nResult\n\n");

            logs.ForEach(l =>
                {
                    Console.WriteLine("{0} {1}",
                        l.Airplane.Name,
                        l.Airplane.TailNumber);

                    Console.WriteLine("Last updated " + l.LastUpdate);

                    l.Airports.ToList().ForEach(p =>
                        {
                            Console.WriteLine("{0} {1}",
                                p.Code,
                                p.Name);
                        });
                });

            Console.ReadLine();
        }
    }
}
