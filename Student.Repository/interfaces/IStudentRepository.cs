using Student.Entities.Dto;
using System.Collections.Generic;

namespace Student.Repository.interfaces
{
    public interface IStudentRepository
    {
        public int Save(StudentDto student);
        public bool Update(StudentDto student);
        public List<StudentDto> GetAll();
        public List<StudentDto> Get(StudentDto student);
        public bool Delete(int id);
    }
}
