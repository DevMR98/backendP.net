using backendP.DTOs;

namespace backendP.Services
{
    public interface ICommonService<T,TI,TU>
    {
        //
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int ItemID);
        Task<T> Add(TI itemInsertDto);
        Task<T> Update(int ItemID,TU itemUpdatetDto);
        Task<T> Delete(int ItemID);
    }
}
