using BalticMarinasClient.Utilities.Validation.UserValidation;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace BalticMarinaClient.Tests
{
    public class MethodsTests
    {
        [Test]
        public void IsLengthValid50_True()
        {
            ValidationContext validationContext = null;

            Assert.AreEqual(true, UserUtilities.IsLengthValid50("UserName", validationContext), "User Name length should be less than 50 characters");
        }

        [Test]
        public void IsLengthValid50_False()
        {
            ValidationContext validationContext = null;

            Assert.AreEqual(false, UserUtilities.IsLengthValid50("UserNameUserNameUserNameUserNameUserNameUserNameUserName", validationContext), "User Name length should be more than 50 characters");
        }

        [Test]
        public void IsLengthValid100_True()
        {
            ValidationContext validationContext = null;

            Assert.AreEqual(true, UserUtilities.IsLengthValid100("UserNameUserNameUserNameUserNameUserNameUserNameUserName", validationContext), "User Name length should be less than 100 characters");
        }

        [Test]
        public void IsLengthValid100_False ()
        {
            ValidationContext validationContext = null;

            Assert.AreEqual(false, UserUtilities.IsLengthValid100("UserNameUserNameUserNameUserNameUserNameUserNameUserNameUserNameUserNameUserNameUserNameUserNameUserNameUserName", validationContext), "User Name length should be more than 100 characters");
        }

        [Test]
        public void ContainsNumbers_True()
        {
            ValidationContext validationContext = null;

            Assert.AreEqual(true, UserUtilities.ContainsNumbers("UserPassword5", validationContext), "User Password should contain numeric values");
        }

        [Test]
        public void ContainsNumbers_False()
        {
            ValidationContext validationContext = null;

            Assert.AreEqual(false, UserUtilities.ContainsNumbers("UserPassword", validationContext), "User Password should not contain numeric values");
        }

        [Test]
        public void IsEmail_True()
        {
            ValidationContext validationContext = null;

            Assert.AreEqual(true, UserUtilities.IsEmail("user@gmail.com", validationContext), "User Email should be valid email");
        }

        [Test]
        public void IsEmail_False()
        {
            ValidationContext validationContext = null;

            Assert.AreEqual(false, UserUtilities.IsEmail("usergmail.com", validationContext), "User Email should not be valid email");
        }

    }
}
