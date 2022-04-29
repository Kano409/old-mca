using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;
using WebApi.Interface;

namespace WebApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApiDbContext _Context;
        public StudentRepository(ApiDbContext context)
        {
            _Context = context;
        }
        public async Task<Student> AddStudent(Student student)
        {
            var result = await _Context.Students.AddAsync(student);
            await _Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Student> DeleteStudent(int Id)
        {
            var result = await _Context.Students.Where(a => a.Id  == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                _Context.Students.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Student> GetStudent(int Id)
        {
            return await _Context.Students.Where(a => a.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _Context.Students.ToListAsync();
        }

        public async Task<IEnumerable<Student>> Search(string FirstName)
        {
            IQueryable<Student> query = _Context.Students;
            if (query != null)
            {
                query = query.Where(a => a.FirstName.Contains(FirstName));
            }
            return await query.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var result = await _Context.Students.Where(a => a.Id == student.Id).FirstOrDefaultAsync();
            if (result != null)
            {
               
                result.FirstName = student.FirstName;
                result.LastName = student.LastName;
                result.Age = student.Age;
                result.MobileNo = student.MobileNo;
                result.Email = student.Email;
                result.Password = student.Password;
                _Context.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
