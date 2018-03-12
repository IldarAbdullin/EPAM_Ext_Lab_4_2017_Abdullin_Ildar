using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HWT_11;
using System.Collections.Generic;

namespace HWT_11.Tests
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void ViewCustOrderHistTest()
        {
            DAL dal = new DAL();
            List<CustOrderHist> custOrderHist = dal.ViewCustOrderHist("TORTU");
            Assert.IsTrue(custOrderHist.Count > 0);
            //Assert.AreEqual(custOrderHist.Count, 24);
        }

        [TestMethod]
        public void ViewCustOrdersDetailTest()
        {
            DAL dal = new DAL();
            List<CustOrdersDetail> custOrdersDetail = dal.ViewCustOrdersDetail(11070);
            Assert.IsTrue(custOrdersDetail.Count > 0);
        }
    }
}
