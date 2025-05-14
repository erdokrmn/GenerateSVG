using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GenerateSVG.Models
{
    public class ShapeModel
    {
        public int Id { get; set; }
        public string ShapeType { get; set; }     // triangle, circle, etc.
        public bool IsFilled { get; set; }        // true = dolu, false = boş
        public string Color { get; set; }         // red, black, green, etc.
        public int Rotation { get; set; }

        [ValidateNever]
        public string SvgPath { get; set; }      // /svgs/triangle_red_90.svg
    }
}
