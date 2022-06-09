using Day58Demo.Models;
using Day58Demo.Models.Services;
using Day58Demo.Models.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Day58Demo.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> IndexAsync()
    {
        //var userService = new UserService();
        var users = await _userService.GetAllAsync();

        return View(users);
    }

    public async Task<IActionResult> DetailsAsync(int id)
    {
        //var userService = new UserService();
        var user = await _userService.GetByIdAsync(id);

        return View(user);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var user = Utility.GenerateFakeData();

        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        //var userService = new UserService();
        await _userService.CreateAsync(user);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(int id)
    {
        //var userService = new UserService();
        var user = await _userService.GetByIdAsync(id);

        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Update(User user)
    {
        //var userService = new UserService();
        await _userService.UpdateAsync(user);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        //var userService = new UserService();
        var user = await _userService.GetByIdAsync(id);

        return View(user);
    }

    public async Task<IActionResult> DeleteUser(int id)
    {
        //var userService = new UserService();
        await _userService.DeleteAsync(id);

        return RedirectToAction("Index");
    }
}

