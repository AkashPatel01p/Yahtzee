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
    public class ListBackedAmountOfItemsTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
    "A null list was inappropriately allowed.")]
        public void Build_NullListMustThrow_Test()
        {
            //Arrange
            List<bool> nullList = null;
            //Act
            ListBackedAmountOfItems<bool>.Build(nullList); 
            //Assert execption thrown 
        }

        [TestMethod()]
        public void Build_NonNullListMustNotReturnNull_Test()
        {
            //Arrange
            List<string> list = new List<string> { "Apple", "Orange" };
            AmountOfItems<string> amountOfItems;
            //Act
            amountOfItems = ListBackedAmountOfItems<string>.Build(list);
            //Assert
            Assert.IsNotNull(amountOfItems); 
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
    "A null value was inappropriately allowed.")]
        public void AddOne_NullValueMustThrow_Test()
        {
            //Arrange
            List<string> list = new List<string> { "Apple", "Orange" };
            AmountOfItems<string> amountOfItems = ListBackedAmountOfItems<string>.Build(list);
            //Act
            amountOfItems.AddOne(null); 
            //Asssert execption thrown 
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
    "A null value was inappropriately allowed.")]
        public void AddMany_NullValueMustThrow_Test()
        {
            //Arrange
            List<string> list = new List<string> { "Apple", "Orange" };
            AmountOfItems<string> amountOfItems = ListBackedAmountOfItems<string>.Build(list);
            //Act
            amountOfItems.AddMany(null, 0); 
            //Assert execption thrown 
        }
        
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
    "A negative amount was inappropriately allowed.")]
        public void AddMany_NegativeAmountMustThrow_Test()
        {
            //Arrange
            List<string> list = new List<string> { "Apple", "Orange" };
            AmountOfItems<string> amountOfItems = ListBackedAmountOfItems<string>.Build(list);
            //Act
            amountOfItems.AddMany("", -1); 
            //Assert execption thrown 
        }

        [TestMethod()]
        public void AddMany_ZeroAmountMustNotThrow_Test()
        {
            //Arrange
            List<int> list = new List<int>(); 
            AmountOfItems<int> amountOfItems = ListBackedAmountOfItems<int>.Build(list);
            //Act
            amountOfItems.AddMany(int.MaxValue, 0); 
            //Assert
        }

        [TestMethod()]
        public void AmountOf_BeforeAddReturns0_Test()
        {
            //Arrange
            List<int> list = new List<int>();
            AmountOfItems<int> amountOfItems = ListBackedAmountOfItems<int>.Build(list);
            var equalityOperation = IntEqualityByLiteral.Build(); 
            int expected = 0;
            //Act
            int actual = amountOfItems.AmountOf(4, equalityOperation);
            //Assert
            Assert.AreEqual(expected, actual); 
        }

       
        [TestMethod()]
        public void AmountOf_IncreasesByOneWhenAddingOne_Test()
        {
            //Arrange
            int literalToAdd = 0; 
            List<int> list = new List<int>();
            AmountOfItems<int> amountOfItems = ListBackedAmountOfItems<int>.Build(list);
            var equalityOperation = IntEqualityByLiteral.Build(); 
            int expected = 1;
            amountOfItems.AddOne(literalToAdd);
            //Act
            int after = amountOfItems.AmountOf(literalToAdd, equalityOperation);
            //Assert
            Assert.AreEqual(expected, after); 
        }

        [TestMethod()]
        public void AmountOf_IncreasesByAmountWhenAddingMany_Test()
        {
            //Arrange
            int literalToAdd = 9;
            int amount = 10;
            List<int> list = new List<int>();
            var amountOfItems = ListBackedAmountOfItems<int>.Build(list);
            var equalityOperation = IntEqualityByLiteral.Build();
            int expected = amount;
            amountOfItems.AddMany(literalToAdd, amount);
            int actual = 0;
            //Act
             actual = amountOfItems.AmountOf(9, equalityOperation); 
            //Assert 
            Assert.AreEqual(expected, actual); 
        }
        


      
     
    }
}