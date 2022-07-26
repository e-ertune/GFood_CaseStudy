namespace GFood_CaseStudy.Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(bool isSuccess, string message, T data) : base(isSuccess, message)
        {
            Data = data;
        }

        public DataResult(bool isSuccess, T data) : base(isSuccess)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
