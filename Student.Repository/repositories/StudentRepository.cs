using Student.Entities.Dto;
using Student.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Student.Repository.repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConnection connection;
        public StudentRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public bool Delete(int id)
        {
            string delete = "DELETE FROM Student WHERE Id = @Id;";
            connection.Execute(delete, new Dictionary<string, object>
            {
                { "@Id", id }
            });
            return true;
        }

        public List<StudentDto> Map(DataTable data)
        {
            List<StudentDto> students = data.Rows.OfType<DataRow>().Select(s => new StudentDto
            {
                Age = Convert.ToInt32(s["Age"]),
                Career = Convert.ToString(s["Career"]),
                FirstName = Convert.ToString(s["FirstName"]),
                LastName = Convert.ToString(s["LastName"]),
                UserName = Convert.ToString(s["UserName"]),
                Id = Convert.ToInt32(s["Id"])
            }).ToList();
            return students;
        }

        public List<StudentDto> Get(StudentDto student)
        {
            string where = "(UPPER(UserName) LIKE '%' || UPPER(@UserName) || '%' OR @UserName = '') " +
                "AND (UPPER(FirstName) LIKE '%' || UPPER(@FirstName) || '%' OR @FirstName = '') " +
                "AND (UPPER(LastName) LIKE '%' || UPPER(@LastName) || '%' OR @LastName = '')";
            DataTable data = connection.Execute($"SELECT * FROM Student WHERE {where}", new Dictionary<string, object>
            {
                { "@UserName", student.UserName ?? "" },
                { "@FirstName", student.FirstName ?? "" },
                { "@LastName", student.LastName ?? "" }
            });
            return Map(data);
        }

        public List<StudentDto> GetAll()
        {
            DataTable data = connection.Execute("SELECT * FROM Student;");
            return Map(data);
        }

        public int Save(StudentDto student)
        {
            string lastId = "SELECT last_insert_rowid();";
            string values = "@UserName, @FirstName, @LastName, @Age, @Career";
            string insert = $"INSERT INTO Student(UserName, FirstName, LastName, Age, Career) VALUES({values}); {lastId}";
            DataTable data = connection.Execute(insert, new Dictionary<string, object>
            {
                { "@UserName", student.UserName },
                { "@FirstName", student.FirstName },
                { "@LastName", student.LastName },
                { "@Age", student.Age },
                { "@Career", student.Career }
            });
            return Convert.ToInt32(data.Rows[0][0]);
        }

        public bool Update(StudentDto student)
        {
            string update = "UPDATE Student SET UserName = @UserName, FirstName = @FirstName, LastName = @LastName, " +
                "Age = @Age, Career = @Career WHERE Id = @Id";
            connection.Execute(update, new Dictionary<string, object>
            {
                { "@Id", student.Id },
                { "@UserName", student.UserName },
                { "@FirstName", student.FirstName },
                { "@LastName", student.LastName },
                { "@Age", student.Age },
                { "@Career", student.Career }
            });
            return true;
        }
    }
}
