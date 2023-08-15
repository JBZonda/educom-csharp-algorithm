using System.Diagnostics;

namespace BornToMove
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoveGiver moveGiver = new MoveGiver();
            //MakeData(moveGiver);

            Console.WriteLine("U dient te bewegen");
            Console.WriteLine("Wilt u een sugestie? (Y/N)");

            String? sugestion = Console.ReadLine();
            while (sugestion == null || !(sugestion.ToUpper().Equals("Y") || sugestion.ToUpper().Equals("N")))
            {
                sugestion = Console.ReadLine();
            }

            Console.WriteLine();

            if (sugestion.ToUpper() == "Y")
            {
                moveGiver.WriteSugestions();
            }
            else if (sugestion.ToUpper() == "N")
            {
                moveGiver.WriteList();
                Console.WriteLine("Geef het nummer van uw gekozen beweging:");
                int chosenMoveId = Convert.ToInt32(Console.ReadLine());
                if (chosenMoveId > 0)
                {
                    moveGiver.WriteMoveById(chosenMoveId);
                }
                else
                {
                    Console.WriteLine("Maak uw eigen beweging.\nNaam:");
                    String? name = Console.ReadLine();
                    while (name == null)
                    {
                        name = Console.ReadLine();
                    }
                    Move? move1 = moveGiver.getMoveByName(name);
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
                            SweatRate = (int)sweatRate
                        };
                        moveGiver.SaveMove(newMove);

                        Console.WriteLine(moveGiver.getMoveByName(name).ToStringWhole());
                    }




                }
            }

            Console.WriteLine("Beoordeling:");
            int? rating = Convert.ToInt32(Console.ReadLine());
            while (rating < 1 || rating > 5)
            {
                rating = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Intensiteit:");
            int? intensity = Convert.ToInt32(Console.ReadLine());
            while (intensity < 1 || intensity > 5)
            {
                intensity = Convert.ToInt32(Console.ReadLine());
            }
        }

        static private void MakeData(MoveGiver moveGiver)
        {
 
            Move move1 = new Move()
            {
                Name = "Push up",
                Description = "Ga horizontaal liggen op teentoppen en handen. Laat het lijf langzaam zakken" +
                " tot de neus de grond bijna raakt. Duw het lijf terug nu omhoog tot de ellebogen bijna gestrekt" +
                " zijn. Vervolgens weer laten zakken. Doe dit 20 keer zonder tussenpauzes.",
                SweatRate = 3
            };
            moveGiver.SaveMove(move1);

            Move move2 = new Move()
            {
                Name = "Planking",
                Description = "Ga horizontaal liggen op teentoppen en onderarmen. Houdt deze positie 1 minuut vast.",
                SweatRate = 3
            };
            moveGiver.SaveMove(move2);

            Move move3 = new Move()
            {
                Name = "Squat",
                Description = "Ga staan met gestrekte armen. Zak door de knieën tot de billen de grond bijna" +
                " raken. Ga weer volledig gestrekt staan. Herhaal dit 20 keer zonder tussenpauzes.",
                SweatRate = 5
            };
            moveGiver.SaveMove(move3);

        }


    }
}