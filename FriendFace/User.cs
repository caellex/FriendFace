using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FriendFace;

public class User
{
    private string _name;
    private List<int> _friendsList = new List<int>();

    private int _userId;
    private static List<User> users = new List<User>();

    private static User currentUser;



    public User(string name, int userId)
    {
        _name = name;
        _userId = userId;

    }


    public static void ShowUsers()
    {
        Console.Clear();
        Console.WriteLine("Users: \n");
        foreach (User user in users)
        {
            if (currentUser._friendsList.Contains(user._userId))
            {
                Console.Write(user._userId + ") ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(user._name+"\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.WriteLine(user._userId + ") " + user._name);
            }

            

        }
        Console.ReadKey();
        Program.LoadApplication();
    }

    public static void LoadUsers()
        {
            if (users.Count <= 7)
            {
                users.Add(new User("Kjell", 0));
                users.Add(new User("Olav", 1));
                users.Add(new User("Ingrid", 2));
                users.Add(new User("Kari", 3));
                users.Add(new User("Lars", 4));
                users.Add(new User("Mette", 5));
                users.Add(new User("Stein", 6));
                users.Add(new User("Astrid", 7));
            }


        }

        public void AddCurrentUser(User user)
        {
            users.Add(user);
            currentUser = user;
        }

        private void AddFriendToCurrent()
        {
            Console.Write("\nWho would you like to add? (Use the number): ");
            string indexToAddStr = Console.ReadLine();

            if (Int32.TryParse(indexToAddStr, out int IndexToAdd))
            {
                if (!currentUser._friendsList.Contains(IndexToAdd))
                {
                    if (IndexToAdd >= -1 && IndexToAdd <= users.Count - 1)
                    {
                        int indexToAdd = Int32.Parse(indexToAddStr);
                        currentUser._friendsList.Add(users[indexToAdd]._userId);
                        ShowFriendList();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Not a user. Please try again.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(3000);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("User is already your friend.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(3000);
                }

            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Invalid input, please input a number between 0 and {users.Count - 1}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(3000);
            }
        }

        public void ShowFriendList()
        {
            Console.Clear();
            Console.WriteLine("Friends:\n");
            foreach (var friend in _friendsList)
            {
                for(var i = 0; i<currentUser._friendsList.Count; i++) {
                Console.WriteLine($"{users[friend]._userId}" + ") " + users[friend]._name);
                Console.WriteLine();
                }
        }



            Console.WriteLine("1) Add Friend");
            Console.WriteLine("2) Remove Friend");
            Console.WriteLine("3) Back");
            char menuChoice = Console.ReadKey(true).KeyChar;

            switch (menuChoice)
            {
                case '1':
                    AddFriendToCurrent();
                    break;
                case '2':
                    RemoveFriendFromCurrent();
                    break;
                case '3':
                    Program.LoadApplication();
                    break;
                default:
                    ShowFriendList();
                    break;
            }

            Program.LoadApplication();
        }

        private void RemoveFriendFromCurrent()
        {
            Console.Write("Who would you like to remove? Please input a number: ");
            string indexToRemoveStr = Console.ReadLine();
            if (Int32.TryParse(indexToRemoveStr, out int indexToRemove))
            {
                if (currentUser._friendsList.Contains(indexToRemove))
                {
                
                if(indexToRemove >= -1)
                {
                    currentUser._friendsList.Remove(indexToRemove);
                    ShowFriendList();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Not a user. Please try again.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(3000);
                }

            }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Invalid input, please input one of the numbers on screen.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(3000);
        }
        }
}
