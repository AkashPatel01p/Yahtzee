using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee.Tests
{
    [TestClass()]
    public class AcesTests
    {
        [TestMethod()]
        public void Build_MustNotReturnNull_Test()
        {
            //Arrange

            //Act
            var ace = Aces.Build();
            //Assert
            Assert.IsNotNull(ace); 
        }
        

        [TestMethod()]
        public void PointsFor_MustReturnSumOfAmountOfOnes_Test()
        {
            //Arrange
            var ace = Aces.Build();
            var list = new List<int> { 1, 2, 3, 4, 5, 6 };
            var dice = ListBackedAmountOfItems<int>.Build(list); 
            //Act
            //Assert
        }

        [TestMethod()]
        public void PointsFor_MustNotReturnNegative_Test()
        {
            //Arrange
            var ace = Aces.Build(); 
            var list = new List<int> { 2, 2, 2, 2, 2, 2, 2};
            var dice = ListBackedAmountOfItems<int>.Build(list);
            //Act
            int actual = ace.PointsFor(dice);
            //Assert
            Assert.IsTrue(actual >= 0); 
        }
    }
}