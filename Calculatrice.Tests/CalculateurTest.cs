using System;
using System.Collections.Generic;
using Calculatrice.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculatrice.Tests
{
    [TestClass]
    public class CalculateurTest
    {
        private Calculateur _calculateur;

        public CalculateurTest()
        {
            _calculateur = new Calculateur();
        }

        [TestMethod]
        public void Additionner_TroisNombres_RetourneBonResultat()
        {
            List<double> nombresAddition = new List<double>();
            nombresAddition.Add(2);
            nombresAddition.Add(2);
            nombresAddition.Add(2);

            var result = _calculateur.Additionner(nombresAddition);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Soustraire_TroisNombres_RetourneBonResultat()
        {
            List<double> nombresAddition = new List<double>();
            nombresAddition.Add(10);
            nombresAddition.Add(2);
            nombresAddition.Add(2);

            var result = _calculateur.Soustraire(nombresAddition);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Multiplier_TroisNombres_RetourneBonResultat()
        {
            List<double> nombresAddition = new List<double>();
            nombresAddition.Add(2);
            nombresAddition.Add(2);
            nombresAddition.Add(2);

            var result = _calculateur.Multiplier(nombresAddition);

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Diviser_DeuxNombres_RetourneBonResultat()
        {
            var result = _calculateur.Diviser(10, 5);

            Assert.AreEqual(2, result);
        }
    }
}
