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



        [Fact]
        public void TestAddUnit_AjouteBienLUnite()
        {
            Logic.Notebook notebook = new Logic.Notebook();
            Logic.Unit unite = new Logic.Unit();
            unite.Name = "Mathématiques";
            unite.Coef = 2.5f;

            notebook.AddUnit(unite);

            var liste = notebook.ListUnits();

            Assert.Single(liste);
            Assert.Equal(unite, liste[0]);
        }

        [Fact]
        public void TestRemoveUnit_SupprimeBienLUnite()
        {
            Logic.Notebook notebook = new Logic.Notebook();
            Logic.Unit unite = new Logic.Unit();
            unite.Name = "Physique";
            unite.Coef = 2.0f;
            notebook.AddUnit(unite);

            notebook.RemoveUnit(unite);
            var liste = notebook.ListUnits();
            Assert.Empty(liste);
        }

        [Fact]
        public void TestModuleComputeAverage()
        {
            Logic.Module mod = new Logic.Module { Name = "Maths", Coef = 2 };
            Exam e1 = new Exam { Module = mod, Note = 10, Coef = 1, IsAbsent = false };
            Exam e2 = new Exam { Module = mod, Note = 15, Coef = 1, IsAbsent = false };

            Exam[] exams = { e1, e2 };
            AvgScore avg = mod.ComputeAverage(exams);

            Assert.NotNull(avg);
            Assert.Equal(12.5f, avg.Average);
        }
    }
}