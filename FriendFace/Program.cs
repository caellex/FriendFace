namespace FriendFace
{
    internal class Program
    {
        public static string userName = "";
        public static bool firstLoad;
        private static User currentUser;
        public static void Main()
        {
            firstLoad = true;
            LoadApplication();
        }

        static string UserLogIn()
        {

            Console.WriteLine("Welcome to FriendFace!\nThe new innovative way to stay in touch with friends!\n");
            Console.Write("What is your name?: ");
            var userName = Console.ReadLine();
            Console.Clear();

            currentUser = new User(userName, 8);
            currentUser.AddCurrentUser(currentUser);

            return userName;
        }

        static void FakeLoad()
        {
            Console.WriteLine("Logging in..");
            Thread.Sleep(400);
            Console.Clear();
            Console.WriteLine("Logging in...");
            Thread.Sleep(400);
            Console.Clear();
            Console.WriteLine("Logging in....");
            Thread.Sleep(700);

            Console.Clear();
            Console.WriteLine($"Successfully logged in!");
            Thread.Sleep(700);
            Console.Clear();
        }

        static void StartMenu(System.ConsoleColor originalFore)
        {
            
            
            Console.Write("Welcome ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{userName}\n");
            Console.ForegroundColor = originalFore;
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1) Show Users");
            Console.WriteLine("2) Friend List");
            Console.WriteLine("3) Exit App");
            char menuChoice = Console.ReadKey().KeyChar;


            switch (menuChoice)
            {
                case '1':
                    User.ShowUsers();
                    break;
                case '2':
                    currentUser.ShowFriendList();
                    break;
                case '3':
                    Environment.Exit(555);
                    break;
                default:
                    LoadApplication();
                    break;
            }
        }

        public static void LoadApplication()
        {
            ConsoleColor originalFore = ConsoleColor.Gray;
            
            User.LoadUsers();
            if (firstLoad == true)
            {
                Console.Clear();
                originalFore = Console.ForegroundColor;
                userName = UserLogIn();
                FakeLoad();
                firstLoad = !firstLoad;
                StartMenu(originalFore);
            }
            else
            {
                Console.Clear();
                StartMenu(originalFore);
            }
            

        }
    }
}
