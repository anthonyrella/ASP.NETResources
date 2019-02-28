using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DALGameClub;

namespace UIGameClub
{
    class Program
    {
        static void Main(string[] args)
        {
            int op;

            

            do
            {
                Console.Clear();
                op = getUserOption();

                switch (op)
                {
                    case 0:
                        Console.WriteLine("Thanks for Using Game Club, Bye.");
                        break;
                    case 1: addNewMember(); break;
                    case 2: addNewGame(); break;
                    case 3: displayMembers(); break;
                    case 4: displayGames(); break;
                    case 5: addMemberToGame(); break;
                    case 6: addGameToMember(); break;
                    case 7: displayMembersWithGames(); break;
                    case 8: displayGamesWithMembers(); break;
                    default:
                        Console.WriteLine("Invalid Option, Please try again...");
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();

            } while (op != 0);




        }

        private static int getUserOption()
        {
            Console.WriteLine("1. Add Member.");
            Console.WriteLine("2. Add Game");
            Console.WriteLine("");

            Console.WriteLine("3. Display Members");
            Console.WriteLine("4. Display Games");
            Console.WriteLine("");

            Console.WriteLine("5. Add Member To Game");
            Console.WriteLine("6. Assign Game to Member");
            Console.WriteLine("");

            Console.WriteLine("7. Display Members with Games");
            Console.WriteLine("8. Display Games with Members");
            Console.WriteLine("");

            Console.WriteLine("0. Exit");
            Console.WriteLine("");

            Console.Write("Selection an Option:");
            return Convert.ToInt32(Console.ReadLine());


        }

        private static void addNewMember()
        {
            Console.Write("Member Name: ");
            string mName = Console.ReadLine();

            Member m = new Member();
            m.Name = mName;

            using (DBGameClubContainer DB = new DBGameClubContainer())
            {
                DB.Members.Add(m);
                DB.SaveChanges();

            }
            Console.WriteLine($"Member {m.Name} added.");
        }

        private static void addNewGame()
        {
            Console.Write("Game Title: ");
            string gTitle = Console.ReadLine();

            Console.Write("Game Studio: ");
            string gStudio = Console.ReadLine();

            Game g = new Game() { Title = gTitle, Studio = gStudio };

            using (DBGameClubContainer db = new DBGameClubContainer())
            {
                db.Games.Add(g);
                db.SaveChanges();
            }

        }

        private static void displayMembers()
        {
            using (DBGameClubContainer DB = new DBGameClubContainer())
            {
                var q = from m in DB.Members
                        orderby m.Name
                        select m;

                foreach (Member m in q)
                {
                    Console.WriteLine($"{m.Id}. - {m.Name}");
                }

            }
        }

        private static void displayGames()
        {
            using (DBGameClubContainer DB = new DBGameClubContainer())
            {
                List<Game> Games = DB.Games.ToList();
                foreach (Game g in Games)
                {
                    Console.WriteLine($"{g.Id}. - {g.Title} ({g.Studio})");
                }
            }
        }

        private static void addMemberToGame()
        {
            displayMembers();

            Console.Write("Member ID: ");
            int mID = Convert.ToInt32(Console.ReadLine());

            displayGames();
            Console.Write("Game ID:");
            int gID = Convert.ToInt32(Console.ReadLine());


            using (DBGameClubContainer DB = new DBGameClubContainer())
            {
                var qMember = from m in DB.Members
                              where m.Id == mID
                              select m;
                Member member = qMember.First();

                Game game = (from g in DB.Games
                             where g.Id == gID
                             select g).First();

                game.Members.Add(member);
                DB.SaveChanges();
            }
        }

        private static void addGameToMember()
        {
            displayGames();
            Console.Write("Game ID:");
            int gID = Convert.ToInt32(Console.ReadLine());

            displayMembers();
            Console.Write("Member ID: ");
            int mID = Convert.ToInt32(Console.ReadLine());

            using (DBGameClubContainer DB = new DBGameClubContainer())
            {
                Game game = DB.Games.Where(g => g.Id == gID).First();

                Member member = DB.Members.Where(m => m.Id == mID).First();

                member.Games.Add(game);
                DB.SaveChanges();

            }
        }

        private static void displayMembersWithGames()
        {
            using (DBGameClubContainer DB = new DBGameClubContainer())
            {
                var qMember = from m in DB.Members
                              orderby m.Id
                              select m;

                foreach(Member m in qMember)
                {
                    Console.WriteLine($"{m.Id}. - {m.Name}");

                    var qMemberGames = from g in m.Games
                                       orderby g.Id
                                       select g;
                    foreach (Game  g in qMemberGames)
                    {
                        Console.WriteLine($"\t\t{g.Id}. - {g.Title} ({g.Studio})");
                        
                    }
                                       
                }

            }
        }

        private static void displayGamesWithMembers()
        {
            using (DBGameClubContainer DB = new DBGameClubContainer())
            {
                List<Game> Games = DB.Games.ToList();
                foreach (Game g in Games)
                {
                    Console.WriteLine($"{g.Id}. - {g.Title} ({g.Studio})");

                    List<Member> GameMembers = g.Members.ToList();
                    foreach(Member m in GameMembers)
                    {
                        Console.WriteLine($"\t\t{m.Id}. - {m.Name}");
                    }
                }
            }
            
        }
    }
}
