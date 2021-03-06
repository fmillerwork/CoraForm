﻿using Formulaire_entretien_camions_Cora.Widgets.Tabs.Apercu;
using Formulaire_entretien_camions_Cora.Widgets.Vehicules;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Controles
{
    /// <summary>
    /// CheckBox contenant une tâche à effectuer (contrôle)
    /// </summary>
    public class CtrlCheckBox : CheckBox
    {
        public CtrlCheckBox(string label)
        {
            Text = label;
            Dock = DockStyle.Top;

            AutoSize = true;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular);
            Location = new System.Drawing.Point(5, 5);
            Size = new System.Drawing.Size(80, 24);

            this.CheckedChanged += (s, e) =>
            {
                ApercuDataGridView gridView = new ApercuDataGridView(); // création nouveau ApercuDataGridView
                VehiculeCheckBox.AddVehiculesRows(gridView); // ajout des lignes
                AddControlesColumns(gridView); // ajout des colonnes

                MainForm.MainTabControl.ApercuTabPage.ApercuDataGridView = gridView; // Remplacement de MainForm.MainTabControl.ApercuTabPage.ApercuDataGridView par gridView  
                MainForm.MainTabControl.ApercuTabPage.Controls.Clear(); //vider l'onglet ApercuTabPage
                MainForm.MainTabControl.ApercuTabPage.Controls.Add(gridView); // ajout de ApercuDataGridView dans ApercuTabPage
            };
        }

        /// <summary>
        /// Ajoute les colonnes correspondantes aux ControlesCheckBox cochées issues de CtrlsGroupBox.ControlCollection
        /// Les ajoute dans la ApercuDataGridView passée en paramètre.
        /// </summary>
        /// <param name="gridView">ApercuDataGridView accueillant les colonnes</param>
        public static void AddControlesColumns(ApercuDataGridView gridView)
        {
            bool cbNonChecked = false;
            foreach (CtrlCheckBox control in CtrlsGroupBox.ControlCollection)  // pour chaque CheckBox dans CtrlsGroupBox.ControlCollection
            {
                if (control.Checked) // si CheckBox Checked
                {
                    var column = new ControlDataGridViewColumn(control.Text);   // création nouvelle colonne avec HeaderText valant le Text de la CheckBox
                    gridView.Columns.Add(column);   // ajout de la colonne dans le ApercuDataGridView
                }
                else   // si CheckBox non Checked
                {
                    cbNonChecked = true;
                }
            }
            if (!cbNonChecked)   // si tous les CheckBox sont Checked
                MainForm.AllCtrlsGroupBox.AllCtrlsRadioBtn.Checked = true;  // coche AllCtrlsRadioBtn
            else
                MainForm.AllCtrlsGroupBox.AllCtrlsRadioBtn.Checked = false; // décoche AllCtrlsRadioBtn
        }
    }
}
