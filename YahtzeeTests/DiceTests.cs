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
    public class DiceTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
    "A negative id was inappropriately allowed.")]
        public void Build_NullIdMustThrow_Test()
        {
            //Arrange
            //Act
            Dice<string>.Build(null, 10, 0, false);
            //Assert
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
"A negative id was inappropriately allowed.")]
        public void Build_NegativeMaxInclusiveMustThrow_Test()
        {
            //Arrange
            //Act
            Dice<char>.Build('a', -1, 0, false);
            //Assert
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
"A negative id was inappropriately allowed.")]
        public void Build_FaceGreaterThanMaxInclusiveMustThrow_Test()
        {
            //Arrange
            //Act
            Dice<string>.Build(null, 10, 11, false);
            //Assert
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
"A negative id was inappropriately allowed.")]
        public void SameDice_NulCompareMustThrow_Test()
        {
            //Arrange
            var d = Dice<double>.Build(5.4, 10, 3, false);
            //Act
            bool actual = d.SameDice(5.4, null);
            //Assert
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
"A negative id was inappropriately allowed.")]
        public void SameDice_NullIdMustThrow_Test()
        {
            //Arrange
            var d = Dice<string>.Build("non_null", 10, 3, false);
            //Act
            bool actual = d.SameDice(null, null);
            //Assert
        }

        [TestMethod()]
        public void SameDice_DiffrentIdMustReturnFalse_Test()
        {
            //Arrange
            var someDice = Dice<int>.Build(0, 6, 6, false);
            var expected = false;
            //Act
            bool actual = someDice.SameDice(1, new IntEquality());
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SameDice_SameIdMustReturnTrue_Test()
        {
            //Arrange
            var someDice = Dice<int>.Build(0, 6, 6, false);
            var expected = true;
            //Act
            bool actual = someDice.SameDice(0, new IntEquality());
            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void MoveToCupTest()
        {
            //Arrange
            //Act
            //Assert
        }

        [TestMethod()]
        public void RollTest()
        {
            //Arrange
            //Act
            //Assert
        }

        [TestMethod()]
        public void TopTest()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}