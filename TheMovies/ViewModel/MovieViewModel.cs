using TheMovies.Model;
using TheMovies.MVVM;

namespace TheMovies.ViewModel;

internal class MovieViewModel : ViewModelBase
{


    public string Title { get; set; }
    public int Duration { get; set; }
    public string Genre { get; set; }

    public MovieViewModel(Movie movie)
    {
        this.Title = movie.Title;
        this.Duration = movie.Duration;
        this.Genre = movie.Genre;
    }

    public override string ToString()
    {
        return $"{Title},{Duration},{Genre}";
    }

}
