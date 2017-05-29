﻿using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD_Day1
{
    [TestClass]
    public class UnitTest_GroupSum
    {
        List<Product> Products;
        [TestInitialize]
        public void Init()
        {
            Products = new List<Product>()
            {
                new Product() { Id=1 ,Cost=1 ,Revenue=11,SellPrice=21 },
                new Product() { Id=2 ,Cost=2 ,Revenue=12,SellPrice=22 },
                new Product() { Id=3 ,Cost=3 ,Revenue=13,SellPrice=23 },
                new Product() { Id=4 ,Cost=4 ,Revenue=14,SellPrice=24 },
                new Product() { Id=5 ,Cost=5 ,Revenue=15,SellPrice=25 },
                new Product() { Id=6 ,Cost=6 ,Revenue=16,SellPrice=26 },
                new Product() { Id=7 ,Cost=7 ,Revenue=17,SellPrice=27 },
                new Product() { Id=8 ,Cost=8 ,Revenue=18,SellPrice=28 },
                new Product() { Id=9 ,Cost=9 ,Revenue=19,SellPrice=29 },
                new Product() { Id=10,Cost=10,Revenue=20,SellPrice=30 },
                new Product() { Id=11,Cost=11,Revenue=21,SellPrice=31 }
            };
        }

        [TestMethod]
        public void 三筆一組取cost總合_realclass()
        {
            //arrange
            var target = new GroupSum<Product>(Products);
            var expected = new List<int>() { 6, 15, 24, 21 };

            //act
            var actual = target.Sum(3, a => a.Cost).ToList();

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }


        [TestMethod]
        public void 四筆一組取revenue總合_realclass()
        {
            //arrange
            var target = new GroupSum<Product>(Products);
            var expected = new List<int>() { 50, 66, 60 };

            //act
            var actual = target.Sum(4, a => a.Revenue).ToList();

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void ThrowNullReferenceException_realclass()
        {

            //arrange
            var target = new GroupSum<Product>(null);

            //act
            Action action = () => target.Sum(4, a => a.Revenue).ToList();


            //assert
            action.ShouldThrow<NullReferenceException>();
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ThrowNullReferenceException_realclass_MSTest()
        {

            //arrange
            var target = new GroupSum<Product>(null);

            //act
            var actual = target.Sum(4, a => a.Revenue).ToList();


            //assert - Expects exception
        }

    }
}
