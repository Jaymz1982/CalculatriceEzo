using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculatrice.Tests
{
    [TestClass]
    public class UtilitairesTest
    {
        private Utilitaires.Utilitaires _utilitaires;

        public UtilitairesTest()
        {
            _utilitaires = new Utilitaires.Utilitaires();
        }

        [TestMethod]
        public void SpliterTexte_ChaineAvecMultiplicateur_RetourneDeuxNombres()
        {
            string chaineASpliter = "2*3";

            var result = _utilitaires.SpliterTexte(chaineASpliter, '*');

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual("2", result[0]);
            Assert.AreEqual("3", result[1]);
        }

        [TestMethod]
        public void ArrangerTexteSaisis_ChaineAvecDeuxMoins_RetourneChaineAvecPlus()
        {
            string chaineAArranger = "1--1";

            var result = _utilitaires.ArrangerTextSaisi(chaineAArranger);

            Assert.AreEqual("1+1", result);
        }

        [TestMethod]
        public void ArrangerTexteSaisis_ChaineAvecNombreAPoint_RetourneChaineAvecNombreAVirgule()
        {
            string chaineAArranger = "29.8";

            var result = _utilitaires.ArrangerTextSaisi(chaineAArranger);

            Assert.AreEqual("29,8", result);
        }


        [TestMethod]
        public void PreparerListeNombres_TableauStringAvecTroisEntrees_RetourneListDOubleADeuxValeurs()
        {
            string[] tableauEntree = new string[3] { "12", "34", "98" };

            var result = _utilitaires.PreparerListeNombres(tableauEntree);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(12, result[0]);
            Assert.AreEqual(34, result[1]);
            Assert.AreEqual(98, result[2]);
        }

        [TestMethod]
        public void RecupererChiffreEntourantSigneOperation_ChaineAvecMultiplication_RetourneDeuxNombresDeLOperation()
        {
            double premierNombre = 0d;
            double deuxiemeNombre = 0d;
            var operation = "321 * 666";

            _utilitaires.RecupererChiffreEntourantSigneOperation(operation, "*", out premierNombre, out deuxiemeNombre);

            Assert.AreEqual(321, premierNombre);
            Assert.AreEqual(666, deuxiemeNombre);
        }
    }
}
