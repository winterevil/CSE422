
using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    public IActionResult User()
    {
        var users = InMemoryDatabase.Users;
        return View(users);
    }

    public IActionResult AddEdit(int? id)
    {
        var user = id.HasValue
        ? InMemoryDatabase.Users.FirstOrDefault(u => u.UserId == id.Value)
        : new User();

        return View(user);
    }

    [HttpPost]
    public IActionResult AddEdit(User user)
    {
        if (ModelState.IsValid)
        {
            if (user.UserId == 0)
            {
                user.UserId = InMemoryDatabase.GetNextId("User");
                InMemoryDatabase.Users.Add(user);
            }
            else
            {
                var existingUser = InMemoryDatabase.Users.FirstOrDefault(u => u.UserId == user.UserId);
                if (existingUser != null)
                {
                    existingUser.UserName = user.UserName;
                    existingUser.UserEmail = user.UserEmail;
                    existingUser.UserPhone = user.UserPhone;
                }
            }

            return RedirectToAction("User", "User");
        }

        return View(user);
    }

    public IActionResult Delete(int id)
    {
        var user = InMemoryDatabase.Users.FirstOrDefault(u => u.UserId == id);
        if (user != null)
        {
            InMemoryDatabase.Users.Remove(user);
        }

        return RedirectToAction("User", "User");
    }
}