using System;
using System.Windows.Forms;

namespace ParkingControll.App
{
    public partial class PlateForm : Form
    {
        public PlateForm()
        {
            InitializeComponent();
        }


        public string GetPlate()
        {
            return txtPlate.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (string.IsNullOrEmpty(txtPlate.Text))
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Digite a placa do veiculo");
            }

        }
    }
}
