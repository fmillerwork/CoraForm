using Formulaire_entretien_camions_Cora.Objects;
using Formulaire_entretien_camions_Cora.Widgets.Vehicules;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Tabs.Vehicules
{
    class VehiculesValiderButton : Button
    {
        private const string TEXT = "Enregistrer";

        private Session _session;
        public VehiculesValiderButton()
        {
            Dock = DockStyle.Bottom;
            Location = new System.Drawing.Point(3, 465);
            Size = new System.Drawing.Size(714, 43);
            Text = TEXT;

            this.Click += (s, e) =>
            {
                #region [ Création des VehiculesCheckBox et enregistrement session]
                _session = new Session();
                MainForm.VehiculesGroupBox.Controls.Clear(); // clear du VehiculesGroupBox

                foreach (VehiculeGroupBox vehiculeGb in VehiculesFlowLayoutPanel.VehiculesCollection)
                {
                    if (vehiculeGb.ImmatriculationTextBox.Text != "")
                    {
                        bool typeUnchosen = false;
                        int cpt = 0;
                        foreach (TypeRadioButton typeRB in vehiculeGb.TypeRBCollection)
                        {
                            cpt++;
                            if (typeRB.Checked) // si un TypeRadioButton coché
                            {
                                MainForm.VehiculesGroupBox.Controls.Add(new VehiculeCheckBox(vehiculeGb.ImmatriculationTextBox.Text + " :  " + typeRB.Text)); // ajt dans VehiculesGroupBox
                                vehiculeGb.BackColor = System.Drawing.SystemColors.ActiveCaption; // changement de couleur du VehiculeGroupBox
                                var camion = new Camion(vehiculeGb.ImmatriculationTextBox.Text, typeRB.Text);
                                _session.Camions.Add(camion); // création et ajout du camion dans la Session
                                break;
                            }
                            else if (cpt == vehiculeGb.TypeRBCollection.Length) // si dernier élement de TypeControlsCollection sans avoir de typeRB coché
                            {
                                typeUnchosen = true;
                            }
                        }
                        if (typeUnchosen) // si un véhicule n'a pas de type coché
                        {
                            vehiculeGb.BackColor = System.Drawing.Color.Red; // changement de couleur du VehiculeGroupBox si une type n'est pas coché
                            MessageBox.Show("Veuillez choisir une catégorie pour chaque véhicule !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                }

                _session.Save();

                MainForm.AllVehiculesRadioButton.Checked = false;
                #endregion


            };
        }
    }
}
