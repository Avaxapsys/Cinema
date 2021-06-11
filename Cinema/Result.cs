using System.Collections.Generic;

namespace Cinema
{
    public class Result
    {
        public int TimeSpace;

        public List<Film> CurrentFilms;

        public Result(int timeSpace, List<Film> currentFilms)
        {
            TimeSpace = timeSpace;
            CurrentFilms = currentFilms;
        }
    }
}