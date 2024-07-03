using cpsc_2650_tech_eval.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cpsc_2650_tech_eval.Controllers;

public class AppController : Controller
{
    private readonly TodoContext _context;

    public AppController(TodoContext context)
    {
        _context = context;
    }

	[HttpGet]
    public async Task<IActionResult> Index()
    {
		var todoItems = await _context.TodoItems.ToListAsync();
		return View(todoItems);
    }

    [HttpPost]
    public async Task<IActionResult> Index(TodoItem todoItem)
    {
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();
		return RedirectToAction("Index");
    }

	[HttpGet]
    public async Task<ActionResult> Edit(long id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return View(todoItem);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TodoItem todoItem)
    {
        _context.Entry(todoItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(long id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        _context.TodoItems.Remove(todoItem);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
