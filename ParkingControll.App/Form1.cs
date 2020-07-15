using Newtonsoft.Json;
using ParkingControll.App.ViewModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace ParkingControll.App
{
    public partial class Form1 : Form
    {
        string url = "https://localhost:5001";
        public Form1()
        {
            InitializeComponent();
            try
            {
                LoadItems();
            }
            catch { }
        }
        public void LoadItems()
            => Command(HttpMethod.Get, $"{url}/vehicles/with-values");

        public void Command(HttpMethod httpMethod, string urlFull, object postBody = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(httpMethod, urlFull);

            if (postBody != null)
            {
                var json = JsonConvert.SerializeObject(postBody, Formatting.Indented, new JsonSerializerSettings());
                request.Content = new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json");
            }

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Host = url.Replace("https://", "");

            using (var httpClient = new HttpClient())
            using (request)
            using (var response = httpClient.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult())
            {
                var resultString = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Erro na comunicação com a API.\nError: {resultString} status de erro: {response.StatusCode}", new Exception(resultString));

                if (postBody == null)
                {
                    var content = JsonConvert.DeserializeObject<PageResult<VehicleViewModel>>(resultString);

                    gridView.DataSource = content.Items;
                }
            }
        }
        public void ExecutePlateForm(HttpMethod httpMethod, string urlFull)
        {
            PlateForm plateForm = new PlateForm();

            if (plateForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Command(httpMethod, urlFull, new VehicleDataObject { Plate = plateForm.GetPlate() });
                    LoadItems();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCameIn_Click(object sender, EventArgs e)
            => ExecutePlateForm(HttpMethod.Post, $"{url}/vehicles");

        private void btnExited_Click(object sender, EventArgs e)
            => ExecutePlateForm(new HttpMethod("PATCH"), $"{url}/vehicles/exit");

        private void btnRefresh_Click(object sender, EventArgs e)
           => LoadItems();

        private void btnPrice_Click(object sender, EventArgs e)
        {
            PriceForm priceForm = new PriceForm();

            if(priceForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Command(HttpMethod.Post, $"{url}/prices", priceForm.GetPrice());
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
