using Student.Business.interfaces;
using Student.Entities.Dto;
using Student.Entities.Entities;
using Student.Repository.interfaces;
using System.Collections.Generic;

namespace Student.Business.services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public GenericResponse<bool> Delete(int id)
        {
            return new GenericResponse<bool>
            {
                Result = studentRepository.Delete(id),
                Message = "Student was deleted successfully"
            };
        }

        public GenericResponse<List<StudentDto>> Get(StudentDto student)
        {
            return new GenericResponse<List<StudentDto>>
            {
                Result = studentRepository.Get(student)
            };
        }

        public GenericResponse<List<StudentDto>> GetAll()
        {
            return new GenericResponse<List<StudentDto>>
            {
                Result = studentRepository.GetAll()
            };
        }

        public GenericResponse<int> Save(StudentDto student)
        {
            return new GenericResponse<int>
            {
                Result = studentRepository.Save(student),
                Message = "Student added successfully"
            };
        }

        public GenericResponse<bool> Update(StudentDto student)
        {
            return new GenericResponse<bool>
            {
                Result = studentRepository.Update(student),
                Message = "Student updated successfully"
            };
        }
    }
}
