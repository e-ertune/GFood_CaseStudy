namespace GFood_CaseStudy.Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(string message, T data) : base(isSuccess: false, message: message, data: data)
        {
        }

        public ErrorDataResult(T data) : base(isSuccess: false, data: data)
        {
        }

        public ErrorDataResult(string message) : base(data: default, isSuccess: false, message: message)
        {
        }

        public ErrorDataResult() : base(data: default, isSuccess: true)
        {
        }
    }
}
