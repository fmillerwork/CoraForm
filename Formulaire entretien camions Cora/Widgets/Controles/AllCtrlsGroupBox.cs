﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Controles
{
    public class AllCtrlsGroupBox : GroupBox
    {
        private const string NAME = "allControlesGroupBox";
        private const string TEXT = "";
        public AllCtrlsRadioBtn AllCtrlsRadioBtn { get; set; }
        public AllCtrlsGroupBox()
        {
            AutoSize = true;
            Location = new System.Drawing.Point(30, 200);
            Name = NAME;
            Text = TEXT;
            Size = new System.Drawing.Size(150, 50);
            AllCtrlsRadioBtn = new AllCtrlsRadioBtn();
            Controls.Add(AllCtrlsRadioBtn);
        }
    }
}
