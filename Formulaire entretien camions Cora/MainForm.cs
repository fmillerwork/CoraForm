using Formulaire_entretien_camions_Cora.Controls;
using Formulaire_entretien_camions_Cora.Objects;
using Formulaire_entretien_camions_Cora.Widgets.Controles;
using Formulaire_entretien_camions_Cora.Widgets.Tabs;
using Formulaire_entretien_camions_Cora.Widgets.Tabs.Vehicules;
using Formulaire_entretien_camions_Cora.Widgets.Vehicules;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora
{
    public partial class MainForm : Form
    {
        public static MainTabControl MainTabControl { get; set; }
        public static ControlesGroupBox ControlesGroupBox { get; set; }
        public static VehiculesGroupBox VehiculesGroupBox { get; set; }
        public static AllControlesRadioButton AllControlesRadioButton { get; set; }
        public static AllVehiculesRadioButton AllVehiculesRadioButton { get; set; }
        public static Session Session { get; set; }

        //public static Session Session;

        private PDFButton _pdfButton = new PDFButton();
        public MainForm()
        {
            InitializeComponent();

            #region [ Ajout des composants ]

            ControlesGroupBox = new ControlesGroupBox();
            Controls.Add(ControlesGroupBox);

            MainTabControl = new MainTabControl();
            Controls.Add(MainTabControl);

            AllControlesRadioButton = new AllControlesRadioButton();
            Controls.Add(AllControlesRadioButton);

            Controls.Add(_pdfButton);

            VehiculesGroupBox = new VehiculesGroupBox();
            Controls.Add(VehiculesGroupBox);

            AllVehiculesRadioButton = new AllVehiculesRadioButton();
            Controls.Add(AllVehiculesRadioButton);

            #endregion

            InitializeForm();
        }

        private void InitializeForm()
        {
            Session = Session.Load();

            if(Session.Camions.Count != 0)
            {
                #region [ Création du nouveau VehiculesFlowLayoutPanel dans MainTabControl.VehiculesTabPage]

                MainTabControl.VehiculesTabPage.VehiculesFlowLayoutPanel = new VehiculesFlowLayoutPanel(Session.Camions);
                MainTabControl.VehiculesTabPage.Controls.RemoveAt(0);
                MainTabControl.VehiculesTabPage.Controls.Add(MainTabControl.VehiculesTabPage.VehiculesFlowLayoutPanel);

                #endregion

                #region [ Création des VehiculesCheckBox]

                VehiculesGroupBox.Controls.Clear(); // clear du VehiculesGroupBox

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
                AllVehiculesRadioButton.Checked = false;

                #endregion
            }
        }

    }
}
