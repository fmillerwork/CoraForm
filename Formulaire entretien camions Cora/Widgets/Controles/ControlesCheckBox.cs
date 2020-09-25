﻿using Formulaire_entretien_camions_Cora.Tabs.Apercu;
using Formulaire_entretien_camions_Cora.Widgets.Tabs.Apercu;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Controles
{
    /// <summary>
    /// CheckBox contenant une tâche à effectuer (contrôle)
    /// </summary>
    class ControlesCheckBox : CheckBox
    {
        private static int _pos = 0;
        public ControlesCheckBox(string label)
        {
            Text = label;
            Dock = DockStyle.Top;

            AutoSize = true;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular);
            Location = new System.Drawing.Point(23, 37);
            Size = new System.Drawing.Size(80, 24);

            this.CheckedChanged += (s, e) =>
            {
                bool cbNonChecked = false;
                ApercuDataGridView gridView = new ApercuDataGridView(); // création nouveau ApercuDataGridView
                foreach (ControlesCheckBox control in ControlesGroupBox.ControlCollection)  // pour chaque CheckBox dans ControlesGroupBox.ControlCollection
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
                    MainForm.AllControlesRadioButton.Checked = true;    // coche AllControlesRadioButton
                else
                    MainForm.AllControlesRadioButton.Checked = false; // décoche AllControlesRadioButton

                ApercuTabPage.ApercuDataGridView = gridView;
                MainForm.MainTabControl.ApercuTabPage.Controls.Clear(); //vider l'onglet ApercuTabPage
                MainForm.MainTabControl.ApercuTabPage.Controls.Add(gridView); // ajout de ApercuDataGridView dans ApercuTabPage
            };
        }
    }
}