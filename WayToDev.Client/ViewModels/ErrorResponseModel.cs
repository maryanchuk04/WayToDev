namespace WayToDev.Client.ViewModels;

public class ErrorResponseModel
{
    public string Error { get; set; }

    public ErrorResponseModel(string error)
    {
        Error = error;
    }
}