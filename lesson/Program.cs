
using System.Drawing;

namespace lesson
{
    /// <summary>
    /// Defines a point in a 2D space.
    /// </summary>
    struct Point2D
    {
        /// <summary>
        /// The X coordinate of the point.
        /// </summary>
        public int x;

        /// <summary>
        /// The Y coordinate of the point.
        /// </summary>
        public int y;
    };

    /// <summary>
    /// Defines a point in a 3D space.
    /// </summary>
    struct Point3D
    {
        /// <summary>
        /// The X coordinate of the point.
        /// </summary>
        public int x;

        /// <summary>
        /// The Y coordinate of the point.
        /// </summary>
        public int y;

        /// <summary>
        /// The Z coordinate of the point.
        /// </summary>
        public int z;
    }

    public class Program
    {
        /// <summary>
        /// The main entrypoint of your application.
        /// </summary>
        /// <param name="args">The arguments passed to the program</param>
        public static void Main(string[] args)
        {
            LessonInformation();

            Console.ReadLine();

            Console.WriteLine("E ora gli esercizi:");
            Console.WriteLine("Esercizio 1:");
            Exercise1();

            Console.WriteLine("Esercizio 2:");
            Exercise2();

            Console.WriteLine("Esercizio 3:");
            Exercise3();
        }

        /// <summary>
        /// Represents information about a user identity
        /// </summary>
        struct UserIdentity
        {
            /// <summary>
            /// THe user first name
            /// </summary>
            public string firstName;

            /// <summary>
            /// The user last name
            /// </summary>
            public string lastName;

            /// <summary>
            /// The user birthday
            /// </summary>
            public string birthday;

            /// <summary>
            /// The user social credit score
            /// </summary>
            public int socialCredits;
        }

        /// <summary>
        /// Prints information about a user identity,
        /// from user input.
        /// </summary>
        private static void Exercise3()
        {
            bool errore;

            string firstName = "", lastName = "", birthday = "";
            int socialCredits = -1;

            Console.Write("Inserisci il nome:");
            firstName = Console.ReadLine()!;
            Console.Write("Inserisci il cognome:");
            lastName = Console.ReadLine()!;
            Console.Write("Inserisci il compleanno:");
            birthday = Console.ReadLine()!;

            do
            {
                errore = false;

                // controlliamo se l'utente inserisce realmente dei numeri
                try
                {
                    Console.Write("Inserisci i social credits:");
                    socialCredits = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    errore = true;

                    Console.WriteLine("Numero non valido");
                }
            }
            while (errore);

            UserIdentity identity = new UserIdentity();
            identity.firstName = firstName;
            identity.lastName = lastName;
            identity.birthday = birthday;
            identity.socialCredits = socialCredits;

            Console.WriteLine($"{identity.firstName} {identity.lastName}, nato il {identity.birthday}. {identity.socialCredits} punti");
        }

        /// <summary>
        /// Given the specified UserIdentity, prints the social score
        /// of the user.
        /// < 0 = very bad
        /// < 100 = bad
        /// < 1000 = normal
        /// < 2000 = good
        /// >= 2000 = very good
        /// </summary>
        private static void Exercise4()
        {
            UserIdentity identity = new UserIdentity();
            identity.firstName = "Testing";
            identity.lastName = "Tester";
            identity.birthday = "2023-11-11";
            identity.socialCredits = 1000;



        }

        /// <summary>
        /// Creates a new Point2D from user input
        /// and prints the coordinates.
        /// </summary>
        private static void Exercise1()
        {
            bool errore;

            int x = -1, y = -1;
            do
            {
                errore = false;

                // controlliamo se l'utente inserisce realmente dei numeri
                try
                {
                    Console.Write("Inserisci la coordinata X:");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Inserisci la coordinata Y:");
                    y = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    errore = true;

                    Console.WriteLine("Coordinata non valida");
                }
            }
            while (errore);

            try
            {
                // il try serve nel caso metta dei numeri negativi (che non vanno bene
                // in questo caso)
                Point2D point2D = Create2DPoint(x, y);
                Console.WriteLine($"point2d.x = {point2D.x} - point2d.y = {point2D.y}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Creates a 3D point from user input
        /// and prints the coordinates.
        /// </summary>
        private static void Exercise2()
        {
            bool errore;

            int x = -1, y = -1, z = -1;
            do
            {
                errore = false;

                // controlliamo se l'utente inserisce realmente dei numeri
                try
                {
                    Console.Write("Inserisci la coordinata X:");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Inserisci la coordinata Y:");
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Inserisci la coordinata Z:");
                    z = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    errore = true;

                    Console.WriteLine("Coordinata non valida");
                }
            }
            while (errore);

            try
            {
                // il try serve nel caso metta dei numeri negativi (che non vanno bene
                // in questo caso)
                Point3D point3D = Create3DPoint(x, y, z);
                Console.WriteLine($"point3d.x = {point3D.x} - point3d.y = {point3D.y} - point3d.z = {point3D.z}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static Point3D Create3DPoint(int x, int y, int z)
        {
            // Queste condizioni di guardia lanciano delle exceptions che vanno gestite dal
            // chiamante, questo ci permette di definire efficacemente dei vincoli da far 
            // rispettare.
            if (x <= 0)
            {
                throw new ArgumentException($"Coordinata X errata: {x} non è maggiore di 0");
            }

            if (y <= 0)
            {
                throw new ArgumentException($"Coordinata Y errata: {y} non è maggiore di 0");
            }

            if (z <= 0)
            {
                throw new ArgumentException($"Coordinata Z errata: {z} non è maggiore di 0");
            }

            // creiamo una nuova struct vuota
            Point3D point3d = new Point3D();

            // riempiamo la struct
            point3d.x = x;
            point3d.y = y;
            point3d.z = z;

            // restituiamo la struct appena creata
            return point3d;
        }

        /// <summary>
        /// Contains the informations regarding today's lesson.
        /// </summary>
        private static void LessonInformation()
        {
            Console.WriteLine("Il tipo di dato 'struct'");
            Console.WriteLine(@"Fra i tipi derivati esistono anche i cosiddetti
            'tipi di dato non omogenei'. Essi sono costituiti da campi di tipo
            potenzialmente diverso, ognuno caratterizzato da un nome e un valore.");
            Console.WriteLine("Rientrano in questa categoria i tipi 'struct' e 'class'");
            Console.WriteLine(@"In questo programma ci sono 2 esempi di definizione di struct:
            - Point2D
            - Point3D");

            Console.WriteLine("Inizializzo una variabile con la parola chiave 'new'");
            Point2D point = new Point2D();

            Console.WriteLine("Assegno dei valori ai campi usando il punto (.)");
            point.x = 0;
            point.y = 1;

            Console.WriteLine($"point.x = {point.x}, point.y = {point.y}");
            Console.WriteLine();

            Console.WriteLine(@"Tutti i valori non inizializzati hanno automaticamente lo
            zero-value");
            Point3D point3d = new Point3D();
            Console.WriteLine(
                $"point3d.x = {point3d.x}, point3d.y = {point3d.y}, point3d.z = {point3d.z}"
            );
        }

        /// <summary>
        /// Creates a new 2D point, given the specified coordinates.
        /// </summary>
        /// <param name="x">The X coordinate, must be > 0</param>
        /// <param name="y">The Y coordinate, must be > 0</param>
        /// <returns>the new 2D point</returns>
        private static Point2D Create2DPoint(int x, int y)
        {
            // Queste condizioni di guardia lanciano delle exceptions che vanno gestite dal
            // chiamante, questo ci permette di definire efficacemente dei vincoli da far 
            // rispettare.
            if (x <= 0)
            {
                throw new ArgumentException($"Coordinata X errata: {x} non è maggiore di 0");
            }

            if (y <= 0)
            {
                throw new ArgumentException($"Coordinata Y errata: {y} non è maggiore di 0");
            }

            // creiamo una nuova struct vuota
            Point2D point2d = new Point2D();

            // riempiamo la struct
            point2d.x = x;
            point2d.y = y;

            // restituiamo la struct appena creata
            return point2d;
        }
    }
}
