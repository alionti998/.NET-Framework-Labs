using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AL_LAB3.Controllers;
using AL_LAB2Model;
using System.Web.Http.Results;

namespace AL_LAB5.Test.Controllers
{
    [TestClass]
    public class StudentControllerTests
    {
        private static int _sID { get; set; }

        [TestMethod]
        public void Add_Test()
        {

            StudentsAPIController sc = new StudentsAPIController();
            Student s = new Student()
            {
                FirstName = "Anthony",
                LastName = "Lionti",
                Student_Number = "abc123"
            };

            var result = sc.PostStudent(s) as CreatedAtRouteNegotiatedContentResult<Student>;

            Assert.AreEqual("Anthony", result.Content.FirstName);
            _sID = result.Content.Id;
        }

        [TestMethod]
        public void Get_Test()
        {
            StudentsAPIController sc = new StudentsAPIController();
            var result = sc.GetStudent(_sID) as OkNegotiatedContentResult<Student>;
            Assert.AreEqual("Anthony", result.Content.FirstName);

        }

        [TestMethod]
        public void Delete_Test()
        {
            StudentsAPIController sc = new StudentsAPIController();
            var result = sc.DeleteStudent(_sID) as OkNegotiatedContentResult<Student>;
            Assert.AreEqual("Anthony", result.Content.FirstName);
        }
    }
}
