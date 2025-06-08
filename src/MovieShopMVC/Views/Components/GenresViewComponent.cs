using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApplicationCore.Entities;
using Infrastructure.Data;

public class GenresViewComponent : ViewComponent
{
    private readonly MovieShopDbContext _context;

    public GenresViewComponent(MovieShopDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<Genre> genres = await _context.Genres.ToListAsync();
        return View(genres);
    }
}