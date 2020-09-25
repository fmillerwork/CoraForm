using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Tabs.Camion
{
    /// <summary>
    /// Onglet Camions;
    /// </summary>
    public class CamionsTabPage : TabPage
    {
        private const string NAME = "camionTabPage";
        private const string TEXT = "Camions";
        public CamionsTabPage()
        {
            Name = NAME;
            Text = TEXT;
            int l = 120;
            int h = 100;

            #region [ Création et ajout des CamionTextBox ]

            // décalage de 40 pour les hauteur et de 140 en largeur
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    Controls.Add(new CamionTextBox(new System.Drawing.Point(l, h)));
                    h += 40;
                }
                l += 140;
                h = 100;
            }
            #endregion

            Controls.Add(new ImmatriculationLabel());
            Controls.Add(new CamionValiderButton());
        }

    }
}
