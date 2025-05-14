namespace GenerateSVG.Services.IServices
{
    public interface ISvgBuilderService
    {
        string GenerateSvg(string shapeType, string color, bool isFilled, int rotation);
    }
}
