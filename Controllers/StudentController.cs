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
            _studentRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
            
        }

        [HttpPost]
        public IActionResult Alterar(StudentModel student)
        {
            _studentRepository.Atualizar(student);
            return RedirectToAction("Index");
        }
    }
}
