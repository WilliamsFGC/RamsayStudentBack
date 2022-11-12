using Student.Entities.Dto;
using Student.Entities.Entities;
using System.Collections.Generic;

namespace Student.Business.interfaces
{
    public interface IStudentService
    {
        public GenericResponse<int> Save(StudentDto student);
        public GenericResponse<bool> Update(StudentDto student);
        public GenericResponse<List<StudentDto>> GetAll();
        public GenericResponse<List<StudentDto>> Get(StudentDto student);
        public GenericResponse<bool> Delete(int id);
    }
}
