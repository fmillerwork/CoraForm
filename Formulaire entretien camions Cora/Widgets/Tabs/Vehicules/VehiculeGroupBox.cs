using Formulaire_entretien_camions_Cora.Objects;
using iTextSharp.text;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Tabs.Vehicules
{
    public class VehiculeGroupBox : GroupBox
    {
        static private int _vehiculeCount = 0;
        public ImmatriculationTextBox ImmatriculationTextBox { get; set; }
        public TypeRadioButton[] TypeRBCollection { get; set; }

        public VehiculeGroupBox()
        {
            InitVGB();
            BackColor = System.Drawing.SystemColors.InactiveCaption;

            Controls.AddRange(TypeRBCollection);

            ImmatriculationTextBox = new ImmatriculationTextBox();
            Controls.Add(ImmatriculationTextBox);
        }

        public VehiculeGroupBox(string immatriculation, string type)
        {
            InitVGB();

            foreach(var typeRB in TypeRBCollection)
            {
                if(typeRB.Text == type) // on coche le TypeRadioButton correspondant au paramètre type
                {
                    BackColor = System.Drawing.SystemColors.ActiveCaption;
                    typeRB.Checked = true;
                    break;
                }
            }
            Controls.AddRange(TypeRBCollection);

            ImmatriculationTextBox = new ImmatriculationTextBox(immatriculation);
            Controls.Add(ImmatriculationTextBox);
        }

        private void InitVGB()
        {
            Location = new System.Drawing.Point(3, 3);
            Size = new System.Drawing.Size(250, 80);
            _vehiculeCount++;
            Text = "Véhicule " + _vehiculeCount;
            Name = "vehiculeGroupBox" + _vehiculeCount;

            var rb6m3 = new TypeRadioButton("6m3", 3, 57);
            var rb11m3 = new TypeRadioButton("11m3", 54, 57);
            var rb17m3 = new TypeRadioButton("17m3", 111, 57);
            var rb20m3 = new TypeRadioButton("20m3", 168, 57);
            var rbRemorque = new TypeRadioButton("Remorque frigo", 111, 34);
            var rbFrigo = new TypeRadioButton("Camion frigo", 111, 11);

            TypeRBCollection = new TypeRadioButton[] { rb6m3, rb11m3, rb17m3, rb20m3, rbRemorque, rbFrigo };
        }

        /// <summary>
        /// Remet le compte de véhicules à 0.
        /// </summary>
        public static void ResetVCount()
        {
            _vehiculeCount = 0;
        }
    }
}
