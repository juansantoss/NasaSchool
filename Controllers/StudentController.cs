using Microsoft.AspNetCore.Mvc;
using NasaSchool.Models;
using NasaSchool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NasaSchool.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            List<StudentModel> student = _studentRepository.SearchAll();
            return View(student);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            StudentModel student = _studentRepository.ListById(id);
            return View(student);
        }
        public IActionResult DeleteConfirm(int id)
        {
            StudentModel student = _studentRepository.ListById(id);
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _studentRepository.Delete(id);

                if (deleted)
                {
                    TempData["SucessMessage"] = "student deleted successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = $"Unable to delete student, please try again";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["ErrorMessage"] = $"Unable to delete student, please try again, error message: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Add(StudentModel student)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    _studentRepository.Add(student);
                    TempData["SucessMessage"] = "successfully registered student";
                    return RedirectToAction("Index");
                }

                return View(student);
            }
            catch (System.Exception erro)
            {
                TempData["ErrorMessage"] = $"it was not possible to register the student try againt, error message: {erro.Message}" ;
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Alterar(StudentModel student)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _studentRepository.Atualizar(student);
                    TempData["SucessMessage"] = "success in updating student";
                    return RedirectToAction("Index");
                }

                return View("Editar", student);
            }

            catch (System.Exception erro)
            {
                TempData["ErrorMessage"] = $"unable to update student please try again, error message: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
