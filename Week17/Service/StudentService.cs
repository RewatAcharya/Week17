
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Week17.Service
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDBContext _dbContext;

        public StudentService(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            var results = await _dbContext.Students.ToListAsync();
            return results;
        }

        public async Task<Student> GetStudentById(string id)
        {
            var result = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            return result;
        }

        public async Task<Student> AddStudent(Student student)
        {
            //student.Id = Guid.NewGuid();
            var result = await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _dbContext.Entry(student).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return student;
        }

        public async Task DeleteStudent(string id)
        {
            var result = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            if (result != null)
            {
                _dbContext.Students.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
