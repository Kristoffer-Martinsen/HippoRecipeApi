using HippoRecipeApi.Models;

namespace HippoRecipeApi.Dtos.Steps;

public class GetStepDto
{
    public int Id { get; set; }
    public string Instruction { get; set; }
}