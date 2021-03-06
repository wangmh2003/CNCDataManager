﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.APIs.Tests
{
    [TestClass()]
    public class CablesControllerTests
    {
        [TestMethod()]
        public void GetCablesTest()
        {
            var con = new CablesController();
            int expected = 4;

            var result = con.GetCables();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetCablesTest1()
        {
            var con = new CablesController();

            var result = con.GetCables("HCB-0021-1000-XXX-CD").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<Cables>;

            Assert.IsNotNull(result);
        }
    }
}