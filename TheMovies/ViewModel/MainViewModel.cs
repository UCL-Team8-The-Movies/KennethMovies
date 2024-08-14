using System.Collections.ObjectModel;
using TheMovies.MVVM;
using TheMovies.Persistence;
using TheMovies.Model;

namespace TheMovies.ViewModel;

internal class MainViewModel : ViewModelBase
{

    private IRepo movieRepo;
    public ObservableCollection<MovieViewModel> MovieViewModels { get; set; }


    //Commands.
    public RelayCommand AddCommand => new RelayCommand(execute => AddMovie(), canExecute => { return true; });
    //public RelayCommand RemoveCommand => new RelayCommand(execute => RemoveMovie(), canExecute => { return true; });
    public RelayCommand SaveToFileCommand => new RelayCommand(execute => SaveToFile(), canExecute => { return true; });
    public RelayCommand LoadFromFileCommand => new RelayCommand(execute => LoadFromFile(), canExecute => { return true; });


    //Constructor.
    public MainViewModel()
    {
        this.MovieViewModels = new ObservableCollection<MovieViewModel>();
        this.movieRepo = new MovieRepo();
    }


    //Properties.
    private string title;

    public string Title
    {
        get { return title; }
        set
        {
            title = value;
            OnPropertyChanged();
        }
    }
    private int duration;

    public int Duration
    {
        get { return duration; }
        set 
        { 
            duration = value; 
            OnPropertyChanged();
        }
    }
    private string genre;

    public string Genre
    {
        get { return genre; }
        set 
        { 
            genre = value; 
            OnPropertyChanged();
        }
    }


    /// <summary>
    /// Add a Movie to the list in movieRepo and MovieViewModel to ObservableCollection in MainViewModel and show it in the datagrid.
    /// </summary>
    private void AddMovie()
    {
        Movie movie = new Movie
        {
            Title = Title,
            Genre = Genre,
            Duration = Duration
        };

        movieRepo.Add(movie);
        MovieViewModel movieViewModel = new MovieViewModel(movie);
        this.MovieViewModels.Add(movieViewModel);
    }


    private void SaveToFile()
    {
        movieRepo.SaveToFile<Movie>();
    }

    private void LoadFromFile()
    {
        movieRepo.LoadFromFile<Movie>();
        MovieViewModels.Clear();
        foreach (Movie movie in movieRepo.GetAll<Movie>())
        {
            this.MovieViewModels.Add(new MovieViewModel(movie));
        }
    }


}
