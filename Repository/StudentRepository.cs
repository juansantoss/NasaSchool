using NasaSchool.Data;
using NasaSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NasaSchool.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly BancoContext _bancoContext;

        public StudentRepository(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        public StudentModel ListById(int id)
        {
            return _bancoContext.Students.FirstOrDefault(x => x.Id == id);
        }
        public List<StudentModel> SearchAll()
        {
            return _bancoContext.Students.ToList();
                
        }
        public StudentModel Add(StudentModel student)
        {
            _bancoContext.Students.Add(student);
            _bancoContext.SaveChanges();
            return student;
        }

        public StudentModel Atualizar(StudentModel student)
        {
            StudentModel studentDB = ListById(student.Id);

            if (studentDB == null) throw new System.Exception("There was an error updating the student");

            studentDB.FullName = student.FullName;
            studentDB.Ssn = student.Ssn;
            studentDB.Year = student.Year;

            _bancoContext.Students.Update(studentDB);
            _bancoContext.SaveChanges();

            return studentDB;
        }
        public bool Delete(int id)
        {
            StudentModel studentDB = ListById(id);

            if (studentDB == null) throw new System.Exception("There was an error delete the student");

            _bancoContext.Students.Remove(studentDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
