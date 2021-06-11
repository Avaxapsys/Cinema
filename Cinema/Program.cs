using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = 300;

            Console.WriteLine("Set films count");
            int filmsCount = Convert.ToInt32(Console.ReadLine());
            List<Film> films = new List<Film>();
            for (int i = 1; i <= filmsCount; i++)
            {
                Console.WriteLine($"Set {i} film");
                string name = Console.ReadLine();
                Console.WriteLine($"Set duration of {i} film");
                int duration = Convert.ToInt32(Console.ReadLine());
                Film addingFilm = new Film(name, duration);
                films.Add(addingFilm);
            }
            Node.Films = films;
            Node set = new Node(day);
            set.FillWithUniqueFilms();
            set.CreateGraph();

            Console.WriteLine();

            Result result = set.GetResult();

            DateTime date = new DateTime();
            foreach (Film w in result.CurrentFilms)
            {
                Console.Write(date.ToShortTimeString());
                Console.Write(" - ");
                date = date.AddMinutes(Convert.ToInt32(w.Duration));
                Console.Write(date.ToShortTimeString());
                Console.Write(" ");
                Console.Write(w.Title);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int F(int a)
        {
            if (a == 1)
            {
                return 1;
            }
            else
            {
                return a * F(a - 1);
            }
        }

        static void Booking(int number, List<string> books, List<string> current)
        {
            if (current.Count == number)
            {
                foreach (string w in current)
                {
                    Console.Write(w + " ");
                }
                Console.WriteLine();
            }
            else
            {
                foreach (string w in books)
                {
                    List<string> tmp = new List<string>();
                    foreach (string q in current)
                    {
                        tmp.Add(q);
                    }
                    tmp.Add(w);
                    Booking(number, books, tmp);
                }
            }
        }

    }
}
