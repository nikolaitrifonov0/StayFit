﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayFit.Services.BodyParts;
using StayFit.Services.Equipments;
using StayFit.Services.Exercises;
using StayFit.Web.Models.Exercises;

using static StayFit.Web.Areas.Admin.AdminConstants;

namespace StayFit.Web.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly IExerciseServices exercises;
        private readonly IEquipmentServices equipments;
        private readonly IBodyPartServices bodyParts;

        public ExercisesController(IExerciseServices exercises,
            IEquipmentServices equipments, IBodyPartServices bodyParts)
        {
            this.exercises = exercises;
            this.equipments = equipments;
            this.bodyParts = bodyParts;
        }

        [Authorize]
        public IActionResult Add() => View(new AddExerciseFormModel
        {
            Equipments = this.equipments.All(),
            BodyPartsDisplay = this.bodyParts.All()
        });

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddExerciseFormModel exercise)
        {
            if (!this.equipments.DoesEquipmentExist(exercise.Equipment))
            {
                this.ModelState.AddModelError(nameof(exercise.Equipment), "Equipment does not exist.");
            }

            if (exercise.BodyParts != null)
            {
                foreach (var bodyPart in exercise.BodyParts)
                {
                    if (!this.bodyParts.DoesBodyPartExist(bodyPart))
                    {
                        this.ModelState.AddModelError(nameof(exercise.BodyParts), "Muscle group does not exist.");
                    }
                }
            }

            if (!this.ModelState.IsValid)
            {
                exercise.Equipments = this.equipments.All();
                exercise.BodyPartsDisplay = this.bodyParts.All();

                return View(exercise);
            }

            exercises.Add(exercise.Name, exercise.Description, exercise.ImageUrl, exercise.VideoUrl,
                exercise.Equipment, exercise.Color, exercise.BodyParts);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Find(string keyword)
            => Ok(this.exercises.Find(keyword));

        public IActionResult LoadExercises()
            => Ok(this.exercises.All(false));

        public IActionResult Details(string id)
        {
            var exercise = this.exercises.Details(id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        public IActionResult All() => View(this.exercises.All());

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Edit(string id) 
        {
            var exercise = this.exercises.EditDetails(id);

            exercise.BodyPartsDisplay = this.bodyParts.All();
            exercise.Equipments = this.equipments.All();

            return View(exercise); 
        }

        [Authorize(Roles = AdministratorRoleName)]
        [HttpPost]
        public IActionResult Edit(string id, ExerciseEditServiceModel exercise)
        {
            if (!this.equipments.DoesEquipmentExist(exercise.Equipment))
            {
                this.ModelState.AddModelError(nameof(exercise.Equipment), "Equipment does not exist.");
            }

            if (exercise.BodyParts != null)
            {
                foreach (var bodyPart in exercise.BodyParts)
                {
                    if (!this.bodyParts.DoesBodyPartExist(bodyPart))
                    {
                        this.ModelState.AddModelError(nameof(exercise.BodyParts), "Muscle group does not exist.");
                    }
                }
            }

            if (!this.ModelState.IsValid)
            {
                exercise.Equipments = this.equipments.All();
                exercise.BodyPartsDisplay = this.bodyParts.All();

                return View(exercise);
            }

            exercises.Edit(id, exercise.Name, exercise.Description,
                exercise.ImageUrl, exercise.VideoUrl, exercise.Equipment, exercise.Color, exercise.BodyParts);

            return Redirect($"/Exercises/{nameof(this.Details)}/{id}");
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Delete(string id)
        {
            exercises.Delete(id);

            return RedirectToAction("Index", "Home");
        }
    }
}
