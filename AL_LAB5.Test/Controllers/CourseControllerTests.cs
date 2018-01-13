using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AL_LAB3.Models.Fakes;
using AL_LAB3.Controllers;
using System.Web.Mvc;

namespace AL_LAB5.Test.Controllers
{
    [TestClass]
    public class CourseControllerTests
    {

        [TestMethod]
        public void IndexAction_Stub_ValidCourse()
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
