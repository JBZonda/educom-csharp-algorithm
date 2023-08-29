using System.Diagnostics;
using BornToMove.Business;
using BornToMove.DAL;

namespace BornToMove
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoveContext context = new MoveContext();
            BuMove buMove = new BuMove(context);
            BuMoveRating buMoveRating = new BuMoveRating(context);
            if (!buMove.dataExists()) {
                SeedData(buMove, buMoveRating);
            }
            

            Console.WriteLine("U dient te bewegen");
            Console.WriteLine("Wilt u een sugestie? (Y/N)");

            String? sugestion = Console.ReadLine();
            while (sugestion == null || !(sugestion.ToUpper().Equals("Y") || sugestion.ToUpper().Equals("N")))
            {
                sugestion = Console.ReadLine();
            }

            Console.WriteLine();
            int chosenMoveId = 0;

            if (sugestion.ToUpper() == "Y")
            {
                chosenMoveId = buMove.WriteSugestions().Id;
            }
            else if (sugestion.ToUpper() == "N")
            {
                buMove.WriteList();
                Console.WriteLine("Geef het nummer van uw gekozen beweging:");
                chosenMoveId = Convert.ToInt32(Console.ReadLine());
                if (chosenMoveId > 0 && buMove.getMoveById(chosenMoveId) != null)
                {
                    buMove.WriteMoveById(chosenMoveId);
                }
                else
                {
                    Console.WriteLine("Maak uw eigen beweging.\nNaam:");
                    String? name = Console.ReadLine();
                    while (name == null)
                    {
                        name = Console.ReadLine();
                    }
                    Move? move1 = buMove.getMoveByName(name);
                    if (move1 != null)
                    {
                        Console.WriteLine("Naam bestaat all:\n");
                        Console.WriteLine(move1.Description.Length);
                        Console.WriteLine(move1.ToStringWhole());
                    }
                    else
                    {
                        Console.WriteLine("\nBeschrijving:");
                        String? description = Console.ReadLine();
                        while (description == null){description = Console.ReadLine();}

                        Console.WriteLine("\nSweat Rate:");
                        int? sweatRate = Convert.ToInt32(Console.ReadLine());
                        while (sweatRate == null || (sweatRate < 0 || sweatRate > 5 )) { sweatRate = Convert.ToInt32(Console.ReadLine()); }

                        Move? newMove = new Move()
                        {                           
                            Name = name,
                            Description = description,
                        };
                        buMove.SaveMove(newMove);

                        Console.WriteLine(buMove.getMoveByName(name).ToStringWhole());
                    }

                }
            }

            Console.WriteLine("Beoordeling:");
            double vote = Convert.ToDouble(Console.ReadLine());
            while (vote < 1 || vote > 5) { vote = Convert.ToDouble(Console.ReadLine());}

            Console.WriteLine("Intensiteit:");
            double intensity = Convert.ToDouble(Console.ReadLine());
            while (intensity < 1 || intensity > 5){intensity = Convert.ToDouble(Console.ReadLine());}

            MoveRating moveRating4 = new MoveRating()
            {
                Move = buMove.getMoveById(chosenMoveId),
                Rating = intensity,
                Vote = vote
            };
            buMoveRating.saveRating(moveRating4);


        }

        static private void SeedData(BuMove moveGiver, BuMoveRating buMoveRating)
        {       
 
            Move move1 = new Move()
            {
                Name = "Push up",
                Description = "Ga horizontaal liggen op teentoppen en handen. Laat het lijf langzaam zakken" +
                " tot de neus de grond bijna raakt. Duw het lijf terug nu omhoog tot de ellebogen bijna gestrekt" +
                " zijn. Vervolgens weer laten zakken. Doe dit 20 keer zonder tussenpauzes."
            };
            move1 = moveGiver.SaveMove(move1);

            Move move2 = new Move()
            {
                Name = "Planking",
                Description = "Ga horizontaal liggen op teentoppen en onderarmen. Houdt deze positie 1 minuut vast."
            };
            move2 = moveGiver.SaveMove(move2);

            Move move3 = new Move()
            {
                Name = "Squat",
                Description = "Ga staan met gestrekte armen. Zak door de knieën tot de billen de grond bijna" +
                " raken. Ga weer volledig gestrekt staan. Herhaal dit 20 keer zonder tussenpauzes."
                
            };
            move3 = moveGiver.SaveMove(move3);

            MoveRating moveRating1 = new MoveRating()
            {
                Move = move1,
                Rating = 3,
                Vote = 2
            };
            buMoveRating.saveRating(moveRating1);

            MoveRating moveRating2 = new MoveRating()
            {
                Move = move1,
                Rating = 4,
                Vote = 2
            };
            buMoveRating.saveRating(moveRating2);

            MoveRating moveRating3 = new MoveRating()
            {
                Move = move2,
                Rating = 3,
                Vote = 2
            };
            buMoveRating.saveRating(moveRating3);

            MoveRating moveRating4 = new MoveRating()
            {
                Move = move3,
                Rating = 1,
                Vote = 2
            };
            buMoveRating.saveRating(moveRating4);

        }


    }
}