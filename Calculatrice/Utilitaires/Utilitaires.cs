using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using constantes = Calculatrice.Constantes.Constantes;

namespace Calculatrice.Utilitaires
{
    /// <summary>
    /// Classe de méthodes utilitaires
    /// </summary>
    public class Utilitaires
    {
        /// <summary>
        /// split le text en fonction d'un séparateur
        /// </summary>
        /// <param name="texte">texte à spliter</param>
        /// <param name="separateur">séparateur de split</param>
        /// <returns>tableau de string</returns>
        public string[] SpliterTexte(string texte, char separateur)
        {
            int nbSeparateur = texte.Count(s => s == separateur);

            return texte.Split(new Char[] { separateur }, nbSeparateur + 1);
        }

        /// <summary>
        /// Remplacer les caractères g^nants par d'autres
        /// </summary>
        /// <param name="texteSaisi">Texte à arranger</param>
        /// <returns>texte modifié</returns>
        public string ArrangerTextSaisi(string texteSaisi)
        {
            texteSaisi = texteSaisi.Replace("- -", "+");
            texteSaisi = texteSaisi.Replace("--", "+");
            texteSaisi = texteSaisi.Replace(".", ",");
            return texteSaisi;
        }

        /// <summary>
        /// Créer une liste de chiffres à soustraire ou a addiitonner
        /// </summary>
        /// <param name="retourSplit">resultat de split d'une chaine de string</param>
        /// <returns>List<double></returns>
        public List<double> PreparerListeNombres(string[] retourSplit)
        {
            List<double> nombres = new List<double>();
            for (int i = 0; i < retourSplit.Length; i++)
            {
                nombres.Add(double.Parse(retourSplit[i].ToString()));
            }

            return nombres;
        }

        /// <summary>
        /// Récupérer les nombres entourant un symbole d'opération
        /// </summary>
        /// <param name="texteSaisi">texte à étudier</param>
        /// <param name="signeOperation">signe de l'opération</param>
        /// <param name="premierNombre">valeur du premier nombre</param>
        /// <param name="deuxiemeNombre">valeur du deuxieme nombre</param>
        public void RecupererChiffreEntourantSigneOperation(string texteSaisi, string signeOperation, out double premierNombre, out double deuxiemeNombre)
        {
            var indexSigne = texteSaisi.IndexOf(signeOperation);
            premierNombre = double.Parse(texteSaisi.Substring(0, indexSigne));
            deuxiemeNombre = double.Parse(texteSaisi.Substring(indexSigne + 1));
        }
    }
}
