using dotNetCoreRestApi.Models;

namespace dotNetCoreRestApi.StudentData
{
    public class MockStudentData : IStudentData
    {
        private List<Student> _students = new List<Student>() { 
            new Student() { Id=Guid.NewGuid(),Name="Mehmet",Surname="Deniz"}, 
            new Student() { Id = Guid.NewGuid(), Name = "Ali", Surname = "Kaya" } 
        };

        public Student AddStudent(Student student)
        {
          student.Id = Guid.NewGuid();
            _students.Add(student);
            return student;
        }

        public void DeleteStudent(Student student)
        {
             _students.Remove(student);
        }

        public Student EditStudent(Student student)
        {
            var existStudent = GetStudentById(student.Id);
            existStudent.Name = student.Name;
            existStudent.Surname = student.Surname;
            return existStudent;
        }

        public Student GetStudentById(Guid id)
        {
            return _students.SingleOrDefault(x => x.Id == id);
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }
    }
}
