using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDemo3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;
using DBModel;
using System.Net;
using MVCDemo3.Repos;


namespace MVCDemo3.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        [TestMethod()]
        public void IndexAction_Returns_IndexView()
        {
            //Arrange
            ProductsController pc = new ProductsController();
            string ExpectedView = "Index";

            //Act
            ViewResult r = pc.Index() as ViewResult;
            string ActualView = r.ViewName;

            //Assert
            Assert.AreEqual(ExpectedView, ActualView);
        }

        [TestMethod()]
        public void DetailAction_Returns_ProductModel()
        {
            //Arrange
            //ProductsController pc = new ProductsController();

            ProductsController pc = new ProductsController(new ProductArrayRepository());

            Type ExpectedModelType = typeof(DBModel.Product);


            //Act
            ViewResult r = pc.Details(3) as ViewResult;
            Type ActualModelType = r.Model.GetType();

            //Assert
            Assert.AreEqual(ExpectedModelType, ActualModelType);

        }

        [TestMethod]
        public void DetailAction_NullID_BadHTTPStatus()
        {
            //Arrange
            ProductsController pc = new ProductsController();
            int ExpectedHttpStatusCode = new HttpStatusCodeResult(HttpStatusCode.BadRequest).StatusCode;

            //Act
            HttpStatusCodeResult r = pc.Details(null) as HttpStatusCodeResult;
            int ActualHttpStatusCode = r.StatusCode;

            //Assert
            Assert.AreEqual(ExpectedHttpStatusCode, ActualHttpStatusCode);

        }

        [TestMethod]
        public void DetailAction_InvalidID_NotFoundStatus()
        {
            //Arrange
            ProductsController pc = new ProductsController();
            int ExpectedStatusCode = new HttpStatusCodeResult(HttpStatusCode.NotFound).StatusCode;

            //Act
            HttpStatusCodeResult r = pc.Details(-1) as HttpStatusCodeResult;
            int ActualStatusCode = r.StatusCode;

            //Assert
            Assert.AreEqual(ExpectedStatusCode, ActualStatusCode);

        }






        
    }
}