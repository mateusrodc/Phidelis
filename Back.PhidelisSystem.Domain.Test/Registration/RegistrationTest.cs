using Back.PhidelisSystem.Domain.Models;
using ExpectedObjects;
using Xunit;

namespace Back.PhidelisSystem.Domain.Test.Registrations
{
    public class RegistrationTest
    {
        [Fact(DisplayName = "CreateRegistration")]
        public void CreateSuccessRegistration()
        {
            var registrationGood = new
            {
                studentid = 4,
                grade = "9° ano",
                lesson = "A"
            };
            

            var registration = new Registration(registrationGood.studentid, registrationGood.grade, registrationGood.lesson);

            registrationGood.ToExpectedObject().ShouldMatch(registration);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void NotCreateStudentInvalidStudentId(int invalidStudent)
        {
            var registrationGood = new
            {
                studentid = 4,
                grade = "9° ano",
                lesson = "A"
            };

            var registration = new Registration(invalidStudent, registrationGood.grade, registrationGood.lesson);
            registrationGood.ToExpectedObject().DoesNotMatch(registration);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateStudentInvalidGrade(string invalidGrade)
        {
            var registrationGood = new
            {
                studentid = 4,
                grade = "9° ano",
                lesson = "A"
            };

            var registration = new Registration(registrationGood.studentid, invalidGrade, registrationGood.lesson);
            registrationGood.ToExpectedObject().DoesNotMatch(registration);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateStudentInvalidLesson(string invalidLesson)
        {
            var registrationGood = new
            {
                studentid = 4,
                grade = "9° ano",
                lesson = "A"
            };

            var registration = new Registration(registrationGood.studentid, registrationGood.grade, invalidLesson);
            registrationGood.ToExpectedObject().DoesNotMatch(registration);
        }
    }
}