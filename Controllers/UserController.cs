using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Implement the Index method here

            return View(userlist);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Find the user with the provided id in the userlist
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // Check if the user exists
            if (user == null)
            {
                // If the user does not exist, return a HttpNotFoundResult
                return HttpNotFound();
            }

            // Pass the user details to the Details view
            return View(user);
        }

        // GET: User/Create

        public ActionResult Create()
        {
            // Implement the Create method here

            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Handle the form submission to create a new user
            // Add the user to the userlist
            userlist.Add(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // Pass the user details to the Edit view
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            User existingUser = userlist.FirstOrDefault(u => u.Id == id);

            // Check if the user exists
            if (existingUser == null)
            {
                // If the user does not exist, return a HttpNotFoundResult
                return HttpNotFound();
            }

            // Update the user's information
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            // Find the user with the provided id in the userlist
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // Check if the user exists
            if (user == null)
            {
                // If the user does not exist, return a HttpNotFoundResult
                return HttpNotFound();
            }

            // Pass the user details to the Delete view
            return View(user);

        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Find the user with the provided id in the userlist
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // Check if the user exists
            if (user == null)
            {
                // If the user does not exist, return a HttpNotFoundResult
                return HttpNotFound();
            }

            // Remove the user from the userlist
            userlist.Remove(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
    }
}
