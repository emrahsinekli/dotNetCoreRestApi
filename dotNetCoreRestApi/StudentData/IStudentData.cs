using dotNetCoreRestApi.Models;

namespace dotNetCoreRestApi.StudentData
{
    public interface IStudentData
    {
        List<Student> GetAllStudents();
        Student GetStudentById(Guid id);
        Student AddStudent(Student student);
        void DeleteStudent(Student student);
        Student EditStudent(Student student);

    }
}
