using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Vehicules
{
    public class AllVehiculesGroupBox : GroupBox
    {
        private const string NAME = "allControlesGroupBox";
        private const string TEXT = "";
        public AllVehiculesRadioBtn AllVehiculesRadioBtn { get; set; }
        public AllVehiculesGroupBox()
        {
            AutoSize = true;
            Location = new System.Drawing.Point(200, 480);
            Name = NAME;
            Text = TEXT;
            Size = new System.Drawing.Size(160, 50);
            AllVehiculesRadioBtn = new AllVehiculesRadioBtn();
            Controls.Add(AllVehiculesRadioBtn);
        }
    }
}
