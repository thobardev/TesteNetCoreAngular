namespace WebAPI.Models
{
    public class ErrorModel
    {
        public int CodeError { get; set; }
        public string MessageError { get; set; }
        public bool HasError { get; set; }
    }
}
