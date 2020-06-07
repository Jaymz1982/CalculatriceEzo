using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Interfaces
{
    /// <summary>
    /// interface des méthodes de calcul
    /// </summary>
    interface ICalculateur
    {
        /// <summary>
        /// Multiplie des nombres
        /// </summary>
        /// <param name="nombres">Liste de nombres à multiplier</param>
        /// <returns>Résultat de la multiplication</returns>
        double Multiplier(List<double> nombres);

        /// <summary>
        /// Additionner des nombres
        /// </summary>
        /// <param name="nombres">liste de nombres à addicitonner</param>
        /// <returns>Résultat de l'addition</returns>
        double Additionner(List<double> nombres);

        /// <summary>
        /// Soustraire des nombres
        /// </summary>
        /// <param name="nombres">liste de nombres à addicitonner</param>
        /// <returns>Résultat de la soustraction</returns>
        double Soustraire(List<double> nombres);

        /// <summary>
        /// Diviser deux nombres
        /// </summary>
        /// <param name="nombre1">premier nombre à diviser</param>
        /// <param name="nombre2">deuxième nombre à diviser</param>
        /// <returns>Résultat de la division</returns>
        double Diviser(double nombre1, double nombre2);
    }
}
