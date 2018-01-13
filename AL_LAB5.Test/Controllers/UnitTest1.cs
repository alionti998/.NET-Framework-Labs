using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AL_LAB3.Controllers;
using System.Web.Http.Results;
using AL_LAB2Model;
using System.Web.Mvc;
using AL_LAB3.Models.Fakes;
using AL_LAB3.Models;

namespace AL_LAB5.Test.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AvailableCourses()
        {
            CoursesController cc = new CoursesController();

            ViewResult actualResult = cc.Index() as ViewResult;
            string actualViewName = actualResult.ViewName;

            //Assert
            string expectViewName = "Index";
            Assert.AreEqual(expectViewName, actualViewName);
        }

        [TestMethod]
        public void FakeRepositoryAvailableCourses()
        {
            CourseRepository r = new CourseRepository();
            CoursesController cc = new CoursesController(r);

            ViewResult actualResult = cc.Index() as ViewResult;
            string actualViewName = actualResult.ViewName;

            //Assert
            string expectViewName = "Index";
            Assert.AreEqual(expectViewName, actualViewName);
        }

        [TestMethod]
        public void FakeStubAvailableCourses()
        {
            StubCourseRepository r = new StubCourseRepository();
            CoursesController cc = new CoursesController(r);

            ViewResult actualResult = cc.Index() as ViewResult;
            string actualViewName = actualResult.ViewName;

            //Assert
            string expectViewName = "Index";
            Assert.AreEqual(expectViewName, actualViewName);
        }
    }
}
