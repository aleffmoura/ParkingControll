using ParkingControll.App.ViewModels;
using System;
using System.Windows.Forms;

namespace ParkingControll.App
{
    public partial class PriceForm : Form
    {
        private PriceDataObject _price;

        public PriceForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _price = new PriceDataObject
            {
                Additional = nudAdditional.Value,
                Tolerance = decimal.ToInt32(nudTolerance.Value),
                Value = nudHourInitial.Value,
                Final = dtpFinal.Value,
                Initial = dtpInitial.Value
            };
        }

        public PriceDataObject GetPrice() => _price ?? new PriceDataObject();
    }
}
