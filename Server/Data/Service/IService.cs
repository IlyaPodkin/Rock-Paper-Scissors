namespace GrpcService.Data.Service
{
    public interface IService <T, TDto> where T : class
    {
        public Task<T> Create(T t);
        public Task<List<T>> Get();
        public Task<T> GetElement(Guid id);
        public Task<bool> Delete(Guid id);
        public Task<bool> Update(Guid id, TDto t);
    }
}
