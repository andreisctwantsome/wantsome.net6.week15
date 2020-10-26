using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Students.Data
{
    public class StudentManager
    {
        static List<Student> studentList = new List<Student>
        {
            new Student() { Id = 1, Name = "John", Age = 18 } ,
            new Student() { Id = 2, Name = "Steve",  Age = 21 } ,
            new Student() { Id = 3, Name = "Bill",  Age = 25 } ,
            new Student() { Id = 4, Name = "Ram" , Age = 20 } ,
            new Student() { Id = 5, Name = "Ron" , Age = 31 } ,
            new Student() { Id = 6, Name = "Chris" , Age = 17 } ,
            new Student() { Id = 7, Name = "Rob" , Age = 19 }
        };

        public List<Student> GetAll()
        {
            return studentList;
        }

        public Student GetById(int id)
        {
            return studentList.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var student = studentList.FirstOrDefault(x => x.Id == id);
            studentList.Remove(student);
        }

        public void Update(int id, Student updated)
        {
            var student = studentList.FirstOrDefault(x => x.Id == id);

            student.Age = updated.Age;
            student.Name = updated.Name;

            // todo - save student in db
        }

        public void Add(Student student)
        {
            student.Id = GetMaxId();

            studentList.Add(student);

            // todo - save student in db
        }

        private int GetMaxId()
        {
            return studentList.Count + 1;
        }
    }
}
