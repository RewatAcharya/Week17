namespace Week17.Service
{
    public interface IStudentService
    {
        Task<Student> GetStudentById(string id);
        Task<IEnumerable<Student>> GetAllStudent();
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task DeleteStudent(string id);
    }
}
