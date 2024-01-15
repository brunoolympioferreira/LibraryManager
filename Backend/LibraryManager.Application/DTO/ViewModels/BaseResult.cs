namespace LibraryManager.Application.DTO.ViewModels;
public class BaseResult
{
    public BaseResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
}

public class BaseResult<T> : BaseResult
{
    public BaseResult(T data, bool success = true, string message = "") : base(success, message)
    {
        Data = data;
    }

    public T Data { get; set; }
}
