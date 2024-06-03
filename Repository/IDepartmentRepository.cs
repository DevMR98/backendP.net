namespace backendP.Repository
{
    public interface IDepartmentRepository<T>
    {
        Task<IEnumerable<T>> Get();
    }
}
