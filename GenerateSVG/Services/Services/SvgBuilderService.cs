using GenerateSVG.Services.IServices;

namespace GenerateSVG.Services.Services
{
    public class SvgBuilderService :ISvgBuilderService
    {
        private readonly IWebHostEnvironment _env;

        public SvgBuilderService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string GenerateSvg(string shapeType, string color, bool isFilled, int rotation)
        {
            string svgBody = shapeType switch
            {
                "triangle" => GetTriangle(color, isFilled),
                "circle" => GetCircle(color, isFilled),
                "square" => GetSquare(color, isFilled),
                _ => GetSquare(color, isFilled)
            };

            string svg = $"""
<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100">
  <g transform="rotate({rotation}, 50, 50)">
    {svgBody}
  </g>
</svg>
""";

            string fileName = $"{shapeType}_{color}_{(isFilled ? "filled" : "outline")}_{rotation}.svg";
            string folderPath = Path.Combine(_env.WebRootPath, "svgs");
            Directory.CreateDirectory(folderPath);

            string fullPath = Path.Combine(folderPath, fileName);
            if (!System.IO.File.Exists(fullPath))
            {
                File.WriteAllText(fullPath, svg);
            }

            return $"/svgs/{fileName}";
        }

        private string GetTriangle(string color, bool filled)
        {
            if (filled)
                return $"<polygon points='50,0 0,100 100,100' fill='{color}' />";
            else
                return $"<polygon points='50,0 0,100 100,100' fill='none' stroke='{color}' stroke-width='5'/>";
        }

        private string GetCircle(string color, bool filled)
        {
            if (filled)
                return $"<circle cx='50' cy='50' r='40' fill='{color}' />";
            else
                return $"<circle cx='50' cy='50' r='40' fill='none' stroke='{color}' stroke-width='5'/>";
        }

        private string GetSquare(string color, bool filled)
        {
            if (filled)
                return $"<rect x='10' y='10' width='80' height='80' fill='{color}' />";
            else
                return $"<rect x='10' y='10' width='80' height='80' fill='none' stroke='{color}' stroke-width='5'/>";
        }
    }
}
