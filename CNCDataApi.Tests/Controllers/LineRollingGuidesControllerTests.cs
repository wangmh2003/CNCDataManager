﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNCDataApi.Models;
using System.Web.Http.Results;
using System.Linq;

namespace CNCDataApi.Controllers.Tests
{
    [TestClass()]
    public class LineRollingGuidesControllerTests
    {
        [TestMethod()]
        public void GetLineRollingGuidesTest()
        {
            var con = new LineRollingGuidesController();
            int expected = 13;

            var result = con.GetLineRollingGuides();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetLineRollingGuideTest()
        {
            var con = new LineRollingGuidesController();

            var result = con.GetLineRollingGuide("HGW15CA").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<LineRollingGuide>;

            Assert.IsNotNull(result);
        }
    }
}