using System.Security.Principal;

namespace EsercizioW1D4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continua = true;

            while (continua)
            {


            




            Console.WriteLine("\n- ===============OPERAZIONI==============");
            Console.WriteLine("1. : Login");
            Console.WriteLine("2. : LogOut");
            Console.WriteLine("3. : Lista degli accessi ");
            Console.WriteLine("4. : Verifica ora e data di tutti i login");
            Console.WriteLine("5. : Esci");

            Console.WriteLine("Scegli una opzione tra 1-5");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                        Console.Clear();
                        if (Utente.isLogged == false)
                        {
                            Console.WriteLine("Login: \n- Nome: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("-Password :");
                            string password = Console.ReadLine();
                            Console.WriteLine("-Riscrivi la tua password :");
                            string passwordCheck = Console.ReadLine();

                            Utente.SetLogin(name, password, passwordCheck);
                        }
                        else
                        {
                            Console.WriteLine("Sei già loggato");
                        }
                    break;


                case "2":
                        Console.Clear();
                        Console.WriteLine("LogOut");
                        Utente.LogOutCheck();
                        break;

                case "3":
                        Console.Clear();
                        if (Utente.isLogged == true)
                        {
                            Utente.LogDates();
                        }
                        else
                        {
                            Console.WriteLine("Devi loggare prima!");
                        }
                        break;

                case "4":
                        Console.Clear();
                        if (Utente.isLogged == true)
                        {
                            Utente.LastLogDate();
                        }
                        else
                        {
                            Console.WriteLine("Devi loggare prima!");
                        }
                        break;

                case "5":
                        Console.Clear();
                        continua = false;
                        Console.WriteLine("Grazie per aver utilizzato il nostro servizio.");
                        break;

                default:
                        Console.Clear();
                        Console.WriteLine("Opzione non valida");
                        break;
                }

            }

        }

        class Utente
        {
            static string Nome { get; set; }
            static string Password { get; set; }

           public static bool isLogged { get; set; } = false;
            public static List<DateTime> DateTimes = new List<DateTime>();


            public static void SetLogin (string username, string password, string passwordCheck)
            {
                if (isLogged == false)
                {
                    Nome = username;

                    if (password == passwordCheck)
                    {
                        Password = password;
                        Console.WriteLine("Sei loggato");
                        isLogged = true;
                        DateTimes.Add(DateTime.Now);

                    }
                    else
                    {
                        Console.Write("le password non coincidono");
                    }
                }
                else
                {
                    Console.WriteLine("Sei già loggato!");
                }
               
            }


            public static void LogOutCheck ()
            {

                
                if (isLogged) 
                {
                        isLogged = false;
                        Console.WriteLine("Hai effettuato il log out!");
                }
                else
                {
                    Console.WriteLine("devi effettuare l'accesso prima");
                }
               
            }

            public static void LogDates()
            {
                Console.WriteLine("Queste sono le volte che hai loggato!");

                foreach (var date in DateTimes)
                {
                    Console.WriteLine(date);
                    
                }
            }

            public static void LastLogDate()
            {
                Console.WriteLine("Questa è la data del tuo ultimo login");
                Console.WriteLine(DateTimes.Last());
            }
        }

    }
}
