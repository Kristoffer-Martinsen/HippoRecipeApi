using System.Text.Json.Serialization;

namespace HippoRecipeApi.Models;

public class Recipe
{
    public int Id { get; set; }
    
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public required string Name { get; set; }
    
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public required string Description { get; set; }
    
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public required string Ingredients { get; set; }
    
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public required string Instructions { get; set; }
    
    // ReSharper disable once CollectionNeverUpdated.Global
    // public List<Tag>? Tags { get; set; } = [];
}