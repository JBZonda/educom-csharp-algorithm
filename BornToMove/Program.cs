using System.Diagnostics;

namespace BornToMove
{
    internal class Program
    {
        static void Main(string[] args)
        {
     
            Console.WriteLine("U dient te bewegen");
            Console.WriteLine("Wilt u een sugestie? (Y/N)");

            String? sugestion = Console.ReadLine();
            while (sugestion == null || !(sugestion.ToUpper().Equals("Y") || sugestion.ToUpper().Equals("N"))) {
                sugestion = Console.ReadLine();
            }
 
            Console.WriteLine();

            MoveGiver moveGiver = new MoveGiver();
            if (sugestion.ToUpper() == "Y")
            {
                moveGiver.WriteSugestions();
            } else if (sugestion.ToUpper() == "N")
            {
                moveGiver.WriteList();
            }

            Console.WriteLine("Beoordeling:");
            int rating = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Intensiteit:");
            int intensity = Convert.ToInt32(Console.ReadLine());

        }
    }
}