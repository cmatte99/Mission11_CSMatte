using Microsoft.AspNetCore.Mvc;
using Mission11_CMatte.Models;
using Mission11_CMatte.Models.ViewModels;

using System.Diagnostics;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IBooks _repo;

    public HomeController(ILogger<HomeController> logger, IBooks temp)
    {
        _logger = logger;
        _repo = temp;
    }

    public IActionResult Index(int pageNum)
    {
        int pageSize = 10;
        var blah = new ProjectsListViewModel
        {
            Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
            PaginationInfo = new PaginationInfo
            {
                CurrentPage = pageNum,
                ItemsPerPage = pageSize,
                TotalItems = _repo.Books.Count()
            }
        };
        return View(blah);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
