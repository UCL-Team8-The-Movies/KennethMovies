using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using TheMovies.Model;

namespace TheMovies.Persistence;

internal class MovieRepo : IRepo
{
    public List<Movie> Movies { get; set; } = new List<Movie>();
    public string FilePath { get; set; }


    public MovieRepo()
    {
        FilePath = Path.Combine(PathHelper.GetSolutionDirectory(), "TheMovies.csv");
    }


    public void Add<T>(T entity)
    {
        if (entity is Movie movie)
            Movies.Add(movie);
        else
            throw new InvalidOperationException("Entity must be of type Movie.");
    }

    public IEnumerable<T> GetAll<T>()
    {
        if (typeof(T) == typeof(Movie))
            return (IEnumerable<T>)Movies;
        else
            throw new InvalidOperationException("Type must be of Movie.");
    }

    public void SaveToFile<T>()
    {
        using (StreamWriter sw = new StreamWriter(FilePath))
        {
            //headers
            sw.WriteLine("Title,Duration,Genre");

            foreach (Movie movie in Movies)
            {
                sw.WriteLine($"{movie.Title},{movie.Duration},{movie.Genre}");
            }
        }

    }

    public void LoadFromFile<T>()
    {
        Movies.Clear();

        if (File.Exists(FilePath))
        {
            using (StreamReader sr = new StreamReader(FilePath))
            {
                //Skip headerLine.
                string headerLine = sr.ReadLine();

                string line;
                while ((line = sr.ReadLine()) != null)
                { 
                    //Split into array and make movie objects
                    string[] values = line.Split(',');
                    var Movie = new Movie()
                    {
                        Title = values[0],
                        Duration = int.Parse(values[1]),
                        Genre = values[2]
                    };
                    Movies.Add(Movie);
                }
       
            }
        }
    }
}
