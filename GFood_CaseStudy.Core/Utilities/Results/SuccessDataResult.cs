namespace GFood_CaseStudy.Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(string message, T data) : base(isSuccess: true, message: message, data: data)
        {
        }

        public SuccessDataResult(T data) : base(isSuccess: true, data: data)
        {
        }

        public SuccessDataResult(string message) : base(data: default, isSuccess: true, message: message)
        {
        }

        public SuccessDataResult() : base(data: default, isSuccess: true)
        {
        }
    }
}
