﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataApi.Models;
using System.Web.Http.Results;

namespace CNCDataApi.Controllers.Tests
{
    [TestClass()]
    public class FlexiblePinCoupsControllerTests
    {
        [TestMethod()]
        public void GetFlexiblePinCouplingsTest()
        {
            var con = new FlexiblePinCoupsController();
            int expected = 5;

            var result = con.GetFlexiblePinCouplings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetFlexiblePinCoupTest()
        {
            var con = new FlexiblePinCoupsController();

            var result = con.GetFlexiblePinCoup("HL1").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<FlexiblePinCoup>;

            Assert.IsNotNull(result);
        }
    }
}