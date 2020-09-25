using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Tabs.Apercu
{
    public class ApercuDataGridView : DataGridView
    {

        public ApercuDataGridView()
        {
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dock = DockStyle.Fill;

            RowHeadersVisible = false;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
            AllowUserToOrderColumns = false;
            ReadOnly = true;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = ColumnHeadersHeight * 2;

            DefaultCellStyle.SelectionBackColor = DefaultCellStyle.BackColor;
            DefaultCellStyle.SelectionForeColor = DefaultCellStyle.ForeColor;

            Columns.Add(new ControlDataGridViewColumn("Camion"));
            Columns.Add(new ControlDataGridViewColumn("Date"));
        }

    }
}
