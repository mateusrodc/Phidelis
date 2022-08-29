using Back.PhidelisSystem.Domain.Models;
using ExpectedObjects;
using System;
using Xunit;

namespace Back.PhidelisSystem.Domain.Test.Students
{
    public class StudentTest
    {
        [Fact(DisplayName = "CreateStudent")]
        public void CreateSuccessStudent()
        {
            var studentGood = new
            {
                name = "Rodrigo Duarte",
                mother = "Regina Duarte",
                birthdate = "05/10/2007",
                registered = false,
                registrationdate = DateTime.UtcNow,
            };

            var student = new Student(studentGood.name, studentGood.mother, studentGood.birthdate, studentGood.registered, studentGood.registrationdate);

            studentGood.ToExpectedObject().ShouldMatch(student);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateStudentInvalidName(string invalidName)
        {
            var studentGood = new
            {
                name = "Rodrigo Duarte",
                mother = "Regina Duarte",
                birthdate = "05/10/2007",
                registered = false,
                registrationdate = DateTime.UtcNow,
            };

            var student = new Student(invalidName, studentGood.mother, studentGood.birthdate, studentGood.registered, studentGood.registrationdate);
            studentGood.ToExpectedObject().DoesNotMatch(student);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateStudentInvalidMother(string invalidMother)
        {
            var studentGood = new
            {
                name = "Rodrigo Duarte",
                mother = "Regina Duarte",
                birthdate = "05/10/2007",
                registered = false,
                registrationdate = DateTime.UtcNow,
            };

            var student = new Student(studentGood.name, invalidMother, studentGood.birthdate, studentGood.registered, studentGood.registrationdate);
            studentGood.ToExpectedObject().DoesNotMatch(student);
        }
    }
}