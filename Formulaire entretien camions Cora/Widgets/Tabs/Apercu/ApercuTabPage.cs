using Formulaire_entretien_camions_Cora.Widgets.Tabs.Apercu;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Tabs.Apercu
{
    /// <summary>
    /// Onglet Aperçu.
    /// </summary>
    public class ApercuTabPage : TabPage
    {
        private const string NAME = "apercuTabPage";
        private const string TEXT = "Aperçu PDF";

        /// <summary>
        /// DataGridView gérant l'aperçu du tableau
        /// </summary>
        public static ApercuDataGridView ApercuDataGridView { get; set; }
        public ApercuTabPage()
        {
            Name = NAME;
            Text = TEXT;
            ApercuDataGridView = new ApercuDataGridView();
            Controls.Add(ApercuDataGridView);

        }

    }
}
