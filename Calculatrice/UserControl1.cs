using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using constantes = Calculatrice.Constantes.Constantes;
using util = Calculatrice.Utilitaires.Utilitaires;
using Autofac;
using Calculatrice.Classes;
using Calculatrice.Interfaces;
using Calculatrice.Utilitaires;
using System.Xml.XPath;
using System.Text.RegularExpressions;

namespace Calculatrice
{
    /// <summary>
    /// classe du programme
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        string texteSaisi = string.Empty;
        private static Autofac.IContainer container { get; set; }
        private Utilitaires.Utilitaires _utilitaires { get; set; }
        private Calculateur _calculateur { get; set; }

        /// <summary>
        /// constructeur par defaut
        /// </summary>
        public UserControl1()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
            _utilitaires = new util();
            _calculateur = new Calculateur();

        }
        

        private void btnCalcul_Click(object sender, EventArgs e)
        {
            string texteSaisi = tbxSaisie.Text;
            texteSaisi = _utilitaires.ArrangerTextSaisi(texteSaisi);
            ReponseCalcul retourCalcul;

            try
            {
                retourCalcul = GererCalcul(texteSaisi);
            }
            catch (Exception)
            {
                retourCalcul = new ReponseCalcul();
                retourCalcul.TraitementCorrect = false;
            }

            if (retourCalcul.TraitementCorrect)
            {
                tbxSaisie.Text = retourCalcul.Resultat.ToString();
            }
            else
            {
                tbxSaisie.Text = constantes.TEXTE_ERREUR_CALCUL;
            }
        }

        private ReponseCalcul GererCalcul(string texteSaisi)
        {
            var reponseCalcul = new ReponseCalcul();

            if (texteSaisi.Contains(constantes.OPERATEUR_PARENTHESES_OUVRANTE) && !texteSaisi.Contains(constantes.OPERATEUR_RACINE_CARREE))
            {
                var indexParentheseOuvrante = texteSaisi.IndexOf(constantes.OPERATEUR_PARENTHESES_OUVRANTE);
                var indexParentheseFermante = texteSaisi.IndexOf(constantes.OPERATEUR_PARENTHESES_FERMANTE);
                var operation = texteSaisi.Substring(indexParentheseOuvrante + 1, indexParentheseFermante - 1);

                var retourCalculParenthese = GererCalcul(operation);
                texteSaisi = texteSaisi.Replace(string.Concat(constantes.OPERATEUR_PARENTHESES_OUVRANTE, operation, constantes.OPERATEUR_PARENTHESES_FERMANTE), retourCalculParenthese.Resultat.ToString());

                reponseCalcul = GererCalcul(texteSaisi);
            }
            if (texteSaisi.Contains(constantes.OPERATEUR_PUISSANCE))
            {
                var retourSplit = _utilitaires.SpliterTexte(texteSaisi, constantes.OPERATEUR_PUISSANCE);
                double premierChiffre;
                double deuxiemeChiffre;

                if (double.TryParse(retourSplit[0], out premierChiffre) &
                    double.TryParse(retourSplit[1], out deuxiemeChiffre))
                {
                    reponseCalcul.Resultat = _calculateur.Puissance(double.Parse(retourSplit[0]), double.Parse(retourSplit[1]));
                }
                else
                {
                    _utilitaires.RecupererChiffreEntourantSigneOperation(texteSaisi, constantes.OPERATEUR_PUISSANCE.ToString(), out premierChiffre, out deuxiemeChiffre);

                    var resultatPuissance = _calculateur.Puissance(premierChiffre, deuxiemeChiffre);

                    texteSaisi = texteSaisi.Replace(string.Concat(premierChiffre, constantes.OPERATEUR_PUISSANCE, deuxiemeChiffre), resultatPuissance.ToString());

                    reponseCalcul = GererCalcul(texteSaisi);
                }
            }
            if (texteSaisi.Contains(constantes.OPERATEUR_MULTIPLIER))
            {
                var retourSplit = _utilitaires.SpliterTexte(texteSaisi, constantes.OPERATEUR_MULTIPLIER);
                double premierChiffre;
                double deuxiemeChiffre;

                bool tousSplitsSontNb = true;

                foreach (var split in retourSplit)
                {
                    double nb;

                    if (!double.TryParse(split, out nb))
                    {
                        tousSplitsSontNb = false;
                        break;
                    }
                }

                if (tousSplitsSontNb)
                {
                    List<double> nombres = _utilitaires.PreparerListeNombres(retourSplit);

                    reponseCalcul.Resultat = _calculateur.Multiplier(nombres);
                    texteSaisi = reponseCalcul.Resultat.ToString();
                }
                else
                {
                    var reg = new System.Text.RegularExpressions.Regex(@"\d+[*/]\d+");
                    var resultat = reg.Match(texteSaisi).ToString();

                    _utilitaires.RecupererChiffreEntourantSigneOperation(resultat, constantes.OPERATEUR_MULTIPLIER.ToString(), out premierChiffre, out deuxiemeChiffre);

                    List<double> nombres = _utilitaires.PreparerListeNombres(new string[] { premierChiffre.ToString(), deuxiemeChiffre.ToString() });
                    var resultatMulti = _calculateur.Multiplier(nombres);
                    texteSaisi = texteSaisi.Replace(string.Concat(premierChiffre, constantes.OPERATEUR_MULTIPLIER, deuxiemeChiffre), resultatMulti.ToString());

                    reponseCalcul = GererCalcul(texteSaisi);
                }
            }
            else if (texteSaisi.Contains(constantes.OPERATEUR_DIVISER))
            {
                var retourSplit = _utilitaires.SpliterTexte(texteSaisi, constantes.OPERATEUR_DIVISER);
                if (retourSplit[1].Equals("0"))
                {
                    reponseCalcul.TraitementCorrect = false;
                }
                else
                {
                    reponseCalcul.Resultat = _calculateur.Diviser(double.Parse(retourSplit[0]), double.Parse(retourSplit[1]));
                }
            }
            else if (texteSaisi.Contains(constantes.OPERATEUR_PLUS))
            {
                var retourSplit = _utilitaires.SpliterTexte(texteSaisi, constantes.OPERATEUR_PLUS);

                List<double> nombres = _utilitaires.PreparerListeNombres(retourSplit);

                reponseCalcul.Resultat = _calculateur.Additionner(nombres);
            }
            else if (texteSaisi.Contains(constantes.OPERATEUR_MOINS))
            {
                var retourSplit = _utilitaires.SpliterTexte(texteSaisi, constantes.OPERATEUR_MOINS);
                List<double> nombres = _utilitaires.PreparerListeNombres(retourSplit);

                reponseCalcul.Resultat = _calculateur.Soustraire(nombres);
            }
            else if (texteSaisi.Contains(constantes.OPERATEUR_RACINE_CARREE))
            {
                string nombre = texteSaisi.Replace("sqrt", "").Replace("(", "").Replace(")", "");
                reponseCalcul.Resultat = Math.Sqrt(double.Parse(nombre));
            }

            return reponseCalcul;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button boutonClic = sender as Button;

            if (boutonClic.Name.Equals(nameof(btnRacine)))
            {
                tbxSaisie.Text = string.Concat(tbxSaisie.Text, constantes.OPERATEUR_RACINE_CARREE);
            }
            else
            {
                tbxSaisie.Text = string.Concat(tbxSaisie.Text, boutonClic.Text);
            }
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            tbxSaisie.Text = string.Empty;
            tbxSaisie.Text = string.Empty;
        }
    }
}
