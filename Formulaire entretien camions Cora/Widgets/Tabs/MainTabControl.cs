using Formulaire_entretien_camions_Cora.Tabs.Apercu;
using Formulaire_entretien_camions_Cora.Tabs.Vehicules;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Tabs
{
    /// <summary>
    /// TabControl regroupant les onglets Camions et Aperçu
    /// </summary>
    public class MainTabControl : TabControl
    {
        private const string NAME = "MainTabControl";

        public VehiculesTabPage VehiculesTabPage { get; set; }
        public ApercuTabPage ApercuTabPage { get; set; }

        public MainTabControl()
        {
            Name = NAME;
            Location = new System.Drawing.Point(411, 23);
            Size = new System.Drawing.Size(725, 500);

            VehiculesTabPage = new VehiculesTabPage();
            ApercuTabPage = new ApercuTabPage();

            Controls.AddRange(new TabPage[] { ApercuTabPage, VehiculesTabPage });
        }
    }
}
