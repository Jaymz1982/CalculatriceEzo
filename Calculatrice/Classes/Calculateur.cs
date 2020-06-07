using Calculatrice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Classes
{
    /// <summary>
    /// Classe des méthodes de calcul
    /// </summary>
    public class Calculateur : ICalculateur
    {

        /// <summary>
        /// constructeur par defaut
        /// </summary>
        public Calculateur()
        {

        }
        /// <summary>
        /// Additionner deux nombres
        /// </summary>
        /// <param name="nombre1">premier nombre à additionner</param>
        /// <param name="nombre2">deuxième nombre à additionner</param>
        /// <returns>Résultat de l'addition</returns>
        public double Additionner(List<double> nombres)
        {
            var resultat = 0d;

            foreach (var nombre in nombres)
            {
                resultat += nombre;
            }
            return resultat;
        }

        /// <summary>
        /// Diviser deux nombres
        /// </summary>
        /// <param name="nombre1">premier nombre à diviser</param>
        /// <param name="nombre2">deuxième nombre à diviser</param>
        /// <returns>Résultat de la division</returns>
        public double Diviser(double nombre1, double nombre2)
        {
            return nombre1 / nombre2;
        }

        /// <summary>
        /// Multiplie des nombres
        /// </summary>
        /// <param name="nombres">Liste de nombres à multiplier</param>
        /// <returns>Résultat de la multiplication</returns>
        public double Multiplier(List<double> nombres)
        {
            var resultat = 1d;
            if (nombres.Count > 0)
            {
                foreach (var nombre in nombres)
                {
                    resultat = resultat * nombre;
                }
            }
            return resultat;
        }

        /// <summary>
        /// Soustraire des nombres
        /// </summary>
        /// <param name="nombre1">nombres à soustraire</param>
        /// <returns>Résultat de la soustraction</returns>
        public double Soustraire(List<double> nombres)
        {
            var resultat = 0d;
            if (nombres.Count > 0)
            {
                resultat = nombres[0];
                nombres.RemoveAt(0);

                foreach (var nombre in nombres)
                {
                    resultat -= nombre;
                }
            }
            return resultat;
        }

        /// <summary>
        /// Calculer puissance d'un nombre par un autre
        /// </summary>
        /// <param name="nombre1">chiffre dont on veut connaitre le resultat de puissance</param>
        /// <param name="nombre2">nombre par lequel on fait la puissance</param>
        /// <returns>Résultat de la soustraction</returns>
        public double Puissance(double nombre1, double nombre2)
        {
            return Math.Pow(nombre1, nombre2);
        }
    }
}
