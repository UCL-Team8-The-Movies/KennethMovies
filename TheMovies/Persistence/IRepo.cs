namespace TheMovies.Persistence;

internal interface IRepo
{
    public void Add<T>(T entity);
    public IEnumerable<T> GetAll<T>();
    public void SaveToFile<T>();
    public void LoadFromFile<T>();
}
