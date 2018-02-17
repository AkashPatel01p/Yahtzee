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
    public class IntEqualityTests
    {
        [TestMethod()]
        public void Equals_SameValueMustReturnTrue_Test()
        {
            //Arrange
            var equality = IntEqualityByLiteral.Build(); 
            //Act
            bool actual = equality.Equals(4, 4); 
            //Assert
            Assert.IsTrue(actual); 
        }

        [TestMethod()]
        public void Equals_DiffrentValuesMustReturnFalse_Test()
        {
            //Arrange
            var equality = IntEqualityByLiteral.Build();
            //Act
            bool actual = equality.Equals(3, 4);
            //Assert
            Assert.IsFalse(actual); 
        }

        [TestMethod()]
        public void Equals_NumberIsEqualToItself_Test()
        {
            //Arrange
            var equality = IntEqualityByLiteral.Build(); 
            Random random = new Random();
            int numberEqualToItself = random.Next(int.MinValue, int.MaxValue);
            //Act
            bool actual = equality.Equals(numberEqualToItself, numberEqualToItself);
            //Assert
            Assert.IsTrue(actual); 
        }

        

        [TestMethod]
        public void Equals_ZeroIsNotNegative_Test()
        {
            //Arrange
            var equality = IntEqualityByLiteral.Build(); 
            Random random = new Random();
            int firstNumber = 0;
            
            int secondNumber = random.Next(int.MinValue , - 1);
            //Act
            bool actual = equality.Equals(firstNumber, secondNumber);
            //Assert
            Assert.IsFalse(actual); 
        }

        [TestMethod]
        public void Equals_PostiveIsNotZero_Test()
        {
            //Arrange
            var equality =  IntEqualityByLiteral.Build();
            Random random = new Random();
            int firstNumber = 0;
            int secondNumber = random.Next(firstNumber, 100000);

            //Act
            bool actual = equality.Equals(firstNumber, secondNumber);

            //Assert
            Assert.IsFalse(actual); 
        }

       
    }
}