using System.Diagnostics;
using DAL;
using Microsoft.AspNetCore.Mvc;
using FullStackTechTest.Models.Specialities;
using FullStackTechTest.Models.Shared;

namespace FullStackTechTest.Controllers;

public class SpecialitiesController : Controller
{
    private readonly ILogger<SpecialitiesController> _logger;
    private readonly ISpecialityRepository _specialityRepository;

    public SpecialitiesController(ILogger<SpecialitiesController> logger, ISpecialityRepository specialityRepository)
    {
        _logger = logger;
        _specialityRepository = specialityRepository;
    }

    public async Task<IActionResult> Index()
    {
        var model = await IndexViewModel.CreateAsync(_specialityRepository);
        return View(model);
    }

    public async Task<IActionResult> Details(int id)
    {
        var model = await DetailsViewModel.CreateAsync(id, false, _specialityRepository);
        return View(model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var model = await DetailsViewModel.CreateAsync(id, true, _specialityRepository);
        return View("Details", model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [FromForm] DetailsViewModel model)
    {
        await _specialityRepository.SaveAsync(model.Speciality);
        return RedirectToAction("Details", new { id = model.Speciality.Id });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete (int id, [FromForm] DetailsViewModel model)
    {
        await _specialityRepository.DeleteAsync(model.Speciality);
        return RedirectToAction("Index");
    }
}