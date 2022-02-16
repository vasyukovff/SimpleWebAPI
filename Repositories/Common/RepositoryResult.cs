namespace SimpleWebAPI.Repositories.Common
{
    public class RepositoryResult <T>
    {
        public RepositoryResult(bool isSuccess, string msg = "", IEnumerable<T>? results = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = msg;
            Results = results;
        }

        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<T>? Results { get; set; }
    }
}
