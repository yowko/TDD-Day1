using System;
using System.Collections.Generic;
using ExpectedObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace TDD_Day1
{
    [TestClass]
    public class UnitTest_GroupSum
    {
        static List<Product> Products;
        //[TestInitialize]
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Products = new List<Product>();
            for (int i = 1; i < 12; i++)
            {
                Products.Add(new Product() { Id = i, Cost = i, Revenue = 10 + i, SellPrice = 20 + i });
            }
        }

        [TestMethod]
        public void 三筆一組取cost總合_nsub_stub()
        {
            //arrange
            var target = Substitute.For<IGroupSum>();
            var expected = new List<int>() { 6, 15, 24, 21 };
            target.SumData(3, nameof(Product.Cost)).Returns(new List<int>() { 6, 15, 24, 21 });

            //act
            var actual = target.SumData(3, nameof(Product.Cost));

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
            //CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void 三筆一組取cost總合_realclass()
        {
            //arrange
            var target = new GroupSum(Products);
            var expected = new List<int>() { 6, 15, 24, 21 };

            //act
            var actual = target.SumData(3, nameof(Product.Cost));

            //assert
            //expected.ToExpectedObject().ShouldEqual(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 四筆一組取revenue總合_nsub_stub()
        {
            //arrange
            var target = Substitute.For<IGroupSum>();
            var expected = new List<int>() { 50, 66, 60 };
            target.SumData(4, nameof(Product.Revenue)).Returns(new List<int>() { 50, 66, 60 });

            //act
            var actual = target.SumData(4, nameof(Product.Revenue));

            //assert
            //expected.ToExpectedObject().ShouldEqual(actual);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void 四筆一組取revenue總合_realclass()
        {
            //arrange
            var target = new GroupSum(Products);
            var expected = new List<int>() { 50, 66, 60 };

            //act
            var actual = target.SumData(4, nameof(Product.Revenue));

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
            //CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ThrowNullReferenceException_nsub_stub()
        {

            //arrange
            var target = Substitute.For<IGroupSum>();
            target.SumData(4, nameof(Product.Revenue)).ReturnsForAnyArgs(a => throw new NullReferenceException());

            //act
            Action action = () => target.SumData(4, nameof(Product.Revenue));


            //assert
            //target.Invoking(a => a.SumData(4, nameof(Product.Revenue))).ShouldThrow<NullReferenceException>();
            action.ShouldThrow<NullReferenceException>();

        }
        [TestMethod]
        public void ThrowNullReferenceException_realclass()
        {

            //arrange
            var target = new GroupSum(null);

            //act
            //Action action = () => target.SumData(4, nameof(Product.Revenue));


            //assert
            //action.ShouldThrow<NullReferenceException>();
            target.Invoking(a => a.SumData(4, nameof(Product.Revenue))).ShouldThrow<NullReferenceException>();


        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ThrowNullReferenceException_realclass_MSTest()
        {

            //arrange
            var target = new GroupSum(null);

            //act
            var actual = target.SumData(4, nameof(Product.Revenue));


            //assert - Expects exception
        }

    }
}
