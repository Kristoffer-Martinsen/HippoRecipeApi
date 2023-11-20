namespace HippoRecipeApi.Models;

public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public Boolean Success { get; set; }
    public string Message { get; set; }
}