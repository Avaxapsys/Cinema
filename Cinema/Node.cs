using System;
using System.Collections.Generic;

namespace Cinema
{
    public class Film
    {
        public string Title;
        public int Duration;

        public Film(string title, int duration)
        {
            Title = title;
            Duration = duration;
        }
    }

    public class Node
    {
        public static List<Film> Films;

        public int TimeSpace;

        public List<Film> Current;

        public List<Node> Next;

        public Node(int timeSpace, List<Film> current = null)
        {
            TimeSpace = timeSpace;

            if (current != null)
            {
                Current = current;
            }
            else
            {
                Current = new List<Film>();
            }

            Next = new List<Node>();
        }

        public void FillWithUniqueFilms()
        {
            foreach (var film in Films)
            {
                if (TimeSpace >= film.Duration)
                {
                    TimeSpace = TimeSpace - film.Duration;
                    Current.Add(film);
                }
            }
        }

        public void CreateGraph()
        {
            foreach (Film film in Films)
            {
                if (film.Duration <= TimeSpace)
                {
                    List<Film> tmp = new List<Film>();
                    foreach (Film q in Current)
                    {
                        tmp.Add(q);
                    }
                    tmp.Add(film);
                    Node node = new Node(TimeSpace - film.Duration, tmp);

                    Next.Add(node);

                    node.CreateGraph();
                }
            }
        }

        public void WriteAllEnds()
        {
            if (Next.Count == 0)
            {
                foreach (Film film in Current)
                {
                    Console.Write(film.Title + " ");
                }
                Console.WriteLine();
            }
            else
            {
                foreach (Node q in Next)
                {
                    q.WriteAllEnds();
                }
            }
        }

        public Result GetResult()
        {
            if (Next.Count == 0)
            {
                return new Result(TimeSpace, Current);
            }
            else
            {
                List<Result> results = new List<Result>();
                foreach (Node q in Next)
                {
                    results.Add(q.GetResult());
                }

                Result minResult = results[0];
                foreach (Result q in results)
                {
                    if (minResult.TimeSpace > q.TimeSpace)
                    {
                        minResult = q;
                    }
                }

                return minResult;
            }
        }
    }
}
