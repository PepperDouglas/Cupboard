namespace Cupboard.Models.DTO
{
    public record RecipeAvgDTO(
        string Title,
        string Description,
        string IngredientsData,
        string Category,
        double ReviewAverage
    );
}
