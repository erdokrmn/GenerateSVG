using GenerateSVG.Data;
using GenerateSVG.Models;
using GenerateSVG.Services.IServices;
using GenerateSVG.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ShapeController : Controller
{
    private readonly ISvgBuilderService _svgService;
    private readonly ApplicationDbContext _context;

    public ShapeController(ISvgBuilderService svgService, ApplicationDbContext context)
    {
        _svgService = svgService;
        _context = context;
    }
    [HttpGet]
    public IActionResult List(int matrixSize = 2)
    {
        var shapes = _context.Shapes.AsNoTracking().ToList();

        var viewModel = new ShapeMatrixViewModel
        {
            MatrixSize = matrixSize,
            Shapes = shapes
        };

        return View(viewModel);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ShapeModel model)
    {
        ModelState.Remove("SvgPath");

        if (!ModelState.IsValid)
            return View(model);

        // SVG oluştur
        var svgPath = _svgService.GenerateSvg(model.ShapeType, model.Color, model.IsFilled, model.Rotation);
        model.SvgPath = svgPath;

        // SVG zaten varsa tekrar ekleme
        if (_context.Shapes.Any(s => s.SvgPath == model.SvgPath))
        {
            return RedirectToAction("List");
        }

        // Yeni şekli ekle
        await _context.Shapes.AddAsync(model);
        await _context.SaveChangesAsync();

        return RedirectToAction("Create");


    }

    public IActionResult List()
    {
        var shapes = _context.Shapes.ToList();
        return View(shapes);
    }
}

