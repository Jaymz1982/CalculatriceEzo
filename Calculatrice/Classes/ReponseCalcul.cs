using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Classes
{
    public class ReponseCalcul
    {
        /// <summary>
        /// resultat de l'opération mathématique
        /// </summary>
        public double Resultat { get; set; } = 0;

        /// <summary>
        /// Indicateur de succès de l'opération mathiématique
        /// </summary>
        public bool TraitementCorrect { get; set; } = true;
    }
}
