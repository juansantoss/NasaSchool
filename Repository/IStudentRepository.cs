using NasaSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NasaSchool.Repository
{
    public interface IStudentRepository
    {
        StudentModel ListById(int id);
        List<StudentModel> SearchAll();
        StudentModel Add(StudentModel student);
        StudentModel Atualizar(StudentModel student);
        bool Delete(int id);
    }
}
