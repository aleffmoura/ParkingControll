namespace ParkingControll.App
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridView = new System.Windows.Forms.DataGridView();
            this.btnCameIn = new System.Windows.Forms.Button();
            this.btnExited = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrice = new System.Windows.Forms.Button();
            this.plate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cameIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exited = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalTimeInParking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalTimePaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            this.gridView.BackgroundColor = System.Drawing.Color.White;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.plate,
            this.cameIn,
            this.exited,
            this.totalTimeInParking,
            this.totalTimePaid,
            this.price,
            this.amountPaid});
            this.gridView.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.gridView.Location = new System.Drawing.Point(12, 79);
            this.gridView.MultiSelect = false;
            this.gridView.Name = "gridView";
            this.gridView.ReadOnly = true;
            this.gridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.Size = new System.Drawing.Size(868, 359);
            this.gridView.TabIndex = 0;
            // 
            // btnCameIn
            // 
            this.btnCameIn.Location = new System.Drawing.Point(606, 51);
            this.btnCameIn.Name = "btnCameIn";
            this.btnCameIn.Size = new System.Drawing.Size(145, 22);
            this.btnCameIn.TabIndex = 1;
            this.btnCameIn.Text = "Marcar Entrada";
            this.btnCameIn.UseVisualStyleBackColor = true;
            this.btnCameIn.Click += new System.EventHandler(this.btnCameIn_Click);
            // 
            // btnExited
            // 
            this.btnExited.Location = new System.Drawing.Point(757, 51);
            this.btnExited.Name = "btnExited";
            this.btnExited.Size = new System.Drawing.Size(123, 22);
            this.btnExited.TabIndex = 2;
            this.btnExited.Text = "Marcar Saida";
            this.btnExited.UseVisualStyleBackColor = true;
            this.btnExited.Click += new System.EventHandler(this.btnExited_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 51);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(145, 22);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Recarregar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrice
            // 
            this.btnPrice.Location = new System.Drawing.Point(12, 12);
            this.btnPrice.Name = "btnPrice";
            this.btnPrice.Size = new System.Drawing.Size(145, 22);
            this.btnPrice.TabIndex = 4;
            this.btnPrice.Text = "Preços";
            this.btnPrice.UseVisualStyleBackColor = true;
            this.btnPrice.Click += new System.EventHandler(this.btnPrice_Click);
            // 
            // plate
            // 
            this.plate.DataPropertyName = "plate";
            this.plate.HeaderText = "Placa";
            this.plate.Name = "plate";
            this.plate.ReadOnly = true;
            this.plate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cameIn
            // 
            this.cameIn.DataPropertyName = "cameIn";
            this.cameIn.HeaderText = "Horário de Chegada";
            this.cameIn.Name = "cameIn";
            this.cameIn.ReadOnly = true;
            this.cameIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cameIn.Width = 140;
            // 
            // exited
            // 
            this.exited.DataPropertyName = "exited";
            this.exited.HeaderText = "Horário de Saida";
            this.exited.Name = "exited";
            this.exited.ReadOnly = true;
            this.exited.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.exited.Width = 140;
            // 
            // totalTimeInParking
            // 
            this.totalTimeInParking.DataPropertyName = "totalTimeInParking";
            this.totalTimeInParking.HeaderText = "Duração";
            this.totalTimeInParking.Name = "totalTimeInParking";
            this.totalTimeInParking.ReadOnly = true;
            this.totalTimeInParking.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // totalTimePaid
            // 
            this.totalTimePaid.DataPropertyName = "totalTimePaid";
            this.totalTimePaid.HeaderText = "Tempo Cobrado (hora)";
            this.totalTimePaid.Name = "totalTimePaid";
            this.totalTimePaid.ReadOnly = true;
            this.totalTimePaid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.totalTimePaid.Width = 140;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "Preço";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // amountPaid
            // 
            this.amountPaid.DataPropertyName = "amountPaid";
            this.amountPaid.HeaderText = "Valor a Pagar";
            this.amountPaid.Name = "amountPaid";
            this.amountPaid.ReadOnly = true;
            this.amountPaid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 450);
            this.Controls.Add(this.btnPrice);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnExited);
            this.Controls.Add(this.btnCameIn);
            this.Controls.Add(this.gridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estacionamento";
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.Button btnCameIn;
        private System.Windows.Forms.Button btnExited;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn plate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cameIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exited;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalTimeInParking;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalTimePaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountPaid;
    }
}

