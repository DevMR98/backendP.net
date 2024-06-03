namespace backendP.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> Get();
    }
}
