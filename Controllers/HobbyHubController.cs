using System.Collections.Generic;
using System.Linq;
using HobbyHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HobbyHub.Controllers
{
    public class HobbyHubController : Controller
    {
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }



        private HobbyHubContext db;
        public HobbyHubController(HobbyHubContext context)
        {
            db = context;
        }



        // initial route pages



        [HttpGet("/Hobby")]
        public IActionResult Hub()
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Hobby> allHobbies = db.Hobbies
                .Include(hobby => hobby.UserHobbies)
                .ToList();


            return View("Hub", allHobbies);
        }



        [HttpGet("/Hobby/New")]
        public IActionResult NewHobby()
        {

            return View();
        }



        [HttpGet("/Hobby/{hobbyId}")]
        public IActionResult HobbyDetails(int hobbyId)
        {
            Hobby selectedHobby = db.Hobbies
                .Include(hobby => hobby.UserHobbies)
                .ThenInclude(userHobby => userHobby.User)
                .FirstOrDefault(hobby => hobby.HobbyId == hobbyId);

            ViewBag.HobbyId = hobbyId;
            return View(selectedHobby);
        }



        [HttpGet("/Hobby/Edit/{hobbyId}")]
        // any parameters in the url need to be parameters for the method (action)
        public IActionResult EditHobby(int hobbyId)
        {
            if (uid == null)
            {
                return RedirectToAction("Hub", "HobbyHub");
            }

            Hobby selectedHobby = db.Hobbies.FirstOrDefault(hobby => hobby.HobbyId == hobbyId);

            if (selectedHobby == null || selectedHobby.UserId != uid)
            {
                return RedirectToAction("Hub");
            }

            return View("EditHobby", selectedHobby);
        }



        // action routes



        [HttpPost("/Hobby/Create")]
        public IActionResult Create(Hobby newHobby)
        {
            if (uid == null)
            {
                return RedirectToAction("Hub", "HobbyHub");
            }

            if (ModelState.IsValid)
            {
                newHobby.UserId = (int)uid;
                db.Add(newHobby);
                db.SaveChanges();
                return RedirectToAction("Hub");

            }
            return View("NewHobby");

        }



        [HttpPost("/Update/{hobbyId}")]
        public IActionResult Update(Hobby editedHobby, int hobbyId)
        {

            if (ModelState.IsValid == false)
            {
                return View("Edit", editedHobby);
            }

            Hobby dbHobby = db.Hobbies.FirstOrDefault(truck => truck.HobbyId == editedHobby.HobbyId);

            if (editedHobby.Name != dbHobby.Name)
            {
                bool isNameTaken = db.Hobbies.Any(hobby => hobby.Name == editedHobby.Name);

                if (isNameTaken)
                {
                    ModelState.AddModelError("Name", "is taken");
                    return View("Edit", editedHobby);
                }
            }

            dbHobby.UpdatedAt = System.DateTime.Now;
            dbHobby.Name = editedHobby.Name;
            dbHobby.Description = editedHobby.Description;

            db.Update(dbHobby);
            db.SaveChanges();
            return RedirectToAction("Hub");
        }





        [HttpPost("/Hobby/AddToHobbies/{hobbyId}")]
        public IActionResult AddToHobbies(UserHobby newUserHobby, int hobbyId)
        {

            UserHobby hobbyToAdd = new UserHobby()
            {
                HobbyId = hobbyId,
                UserId = (int)uid,
            };





            // UserHobby userAddedToEnthusiast = db.UserHobbies.FirstOrDefault(userHobby => userHobby.UserId == uid && userHobby.HobbyId == newUserHobby.HobbyId);

            // if (userAddedToEnthusiast != null)
            // {
            //     ModelState.AddModelError("Body", "Already Reviewed");
            //     return View("HobbyDetails", hobbyToAdd);
            // }





            db.UserHobbies.Add(hobbyToAdd);
            db.SaveChanges();

            return RedirectToAction("HobbyDetails", "HobbyHub", new { hobbyId = hobbyId });
        }





    }
}