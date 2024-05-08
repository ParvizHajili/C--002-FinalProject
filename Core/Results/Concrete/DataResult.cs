using Core.Results.Abstract;

namespace Core.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool IsSucces) : base(IsSucces)
        {
            Data = data;
        }

        public DataResult(T data,string message, bool IsSuccess) : base(message, IsSuccess)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
