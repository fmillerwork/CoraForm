using Formulaire_entretien_camions_Cora.Widgets.Tabs.Vehicules;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Tabs.Vehicules
{
    /// <summary>
    /// Onglet de gestion des véhicules
    /// </summary>
    public class VehiculesTabPage : TabPage
    {
        private const string NAME = "vehiculesTabPage";
        private const string TEXT = "Véhicules";
        public VehiculesFlowLayoutPanel VehiculesFlowLayoutPanel { get; set; }
        public VehiculesTabPage()
        {
            Name = NAME;
            Text = TEXT;
            VehiculesFlowLayoutPanel = new VehiculesFlowLayoutPanel();
            Controls.Add(VehiculesFlowLayoutPanel);
            Controls.Add(new VehiculesValiderButton());
        }
    }
}
