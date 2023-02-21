using System.Text;

namespace Project3.Web.Entry
{
    /// <summary>
    /// Json Result Model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class ResultViewModel<T>
    {
        public ResultViewModel(string code, string message, T data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }

        public string Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    [Serializable]
    public class ResultViewModel : ResultViewModel<string>
    {
        public ResultViewModel(string code, string message) : base(code, message, string.Empty)
        {

        }
    }
}