namespace GrpcService.Data.Service
{
    public interface IService <T, TDto> where T : class
    {
        public T Create(T t);
        public List<T> Get();
        public bool Delete(Guid id);
        public bool Update(Guid id, TDto t);
    }
}
