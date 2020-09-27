using Formulaire_entretien_camions_Cora.Objects;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Tabs.Vehicules
{
    public class VehiculesFlowLayoutPanel : FlowLayoutPanel
    {
        public static ControlCollection VehiculesCollection { get; set; }
        public VehiculesFlowLayoutPanel()
        {
            VehiculesCollection = Controls;
            AutoScroll = true;
            Dock = DockStyle.Top;
            Location = new System.Drawing.Point(3, 3);
            Size = new System.Drawing.Size(714, 420);

            for (int i = 0; i < 27; i++)
                Controls.Add(new VehiculeGroupBox());
            
        }

        public VehiculesFlowLayoutPanel(List<Camion> liste)
        {
            VehiculeGroupBox.ResetVCount(); // on reset le nombre de véhicules car on re remplit le VehiculesFlowLayoutPanel

            VehiculesCollection = Controls;
            AutoScroll = true;
            Dock = DockStyle.Top;
            Location = new System.Drawing.Point(3, 3);
            Size = new System.Drawing.Size(714, 420);

            for (int i = 0; i < 27; i++)
            {
                if (i < liste.Count)
                    Controls.Add(new VehiculeGroupBox(liste[i].Immatriculation, liste[i].Type)); // création des VehiculeGroupBox plein
                else
                    Controls.Add(new VehiculeGroupBox()); // création des VehiculeGroupBox vierges
            }
        }
    }
}
