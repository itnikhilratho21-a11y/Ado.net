using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TrainerDB db = new TrainerDB();
            
            List<Student> students;
            List<Trainer> trainers;
            db.AllTrainer(out trainers, out students);
            foreach(var t in trainers)
            {
                Console.WriteLine($"{t.Id} {t.Name} {t.City} {t.Experience}");


            }
            foreach(var s in students)
            {
                Console.WriteLine($"{s.Rollnumber} {s.Name} {s.TrainerId}");
            }

        }
    }
}
