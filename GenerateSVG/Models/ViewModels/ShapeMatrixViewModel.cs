using GenerateSVG.Models;
using System.Collections.Generic;

namespace GenerateSVG.ViewModels
{
    public class ShapeMatrixViewModel
    {
        // Mevcut SVG’ler
        public List<ShapeModel> Shapes { get; set; }

        // Seçilen matris boyutu (2 veya 3)
        public int MatrixSize { get; set; } = 2;

        // Hücrelere atanmış SVG yolları (isteğe bağlı)
        public string[,] SvgAssignments { get; set; }
    }
}
