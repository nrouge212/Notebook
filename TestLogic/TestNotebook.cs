using Logic;
using System;
using Xunit;

namespace TestLogic
{
    public class TestMetier
    {
        [Fact]
        public void TestCoef_ExceptionSiNegatifOuNul()
        {
            Unit element = new Unit();
            Assert.Throws<Exception>(() =>
            {
                element.Coef = 0;
            });

            Assert.Throws<Exception>(() =>
            {
                element.Coef = -2.5f;
            });
        }

        [Fact]
        public void TestName_ExceptionSiVide()
        {
            Unit element = new Unit();
            Assert.Throws<Exception>(() =>
            {
                element.Name = "";
            });
        }

        [Fact]
        public void TestListUnits_EstVideALaCreation()
        {
            Logic.Notebook notebook = new Logic.Notebook();

            var liste = notebook.ListUnits();

            Assert.NotNull(liste);
            Assert.Empty(liste);
        }
    }
}