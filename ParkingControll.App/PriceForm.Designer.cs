namespace ParkingControll.App
{
    partial class PriceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudHourInitial = new System.Windows.Forms.NumericUpDown();
            this.nudAdditional = new System.Windows.Forms.NumericUpDown();
            this.nudTolerance = new System.Windows.Forms.NumericUpDown();
            this.dtpInitial = new System.Windows.Forms.DateTimePicker();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudHourInitial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdditional)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTolerance)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor Hora Inicial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor Adicional:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tolerancia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 122);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data inicial:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 152);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Data final:";
            // 
            // nudHourInitial
            // 
            this.nudHourInitial.DecimalPlaces = 2;
            this.nudHourInitial.Location = new System.Drawing.Point(182, 24);
            this.nudHourInitial.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHourInitial.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHourInitial.Name = "nudHourInitial";
            this.nudHourInitial.Size = new System.Drawing.Size(120, 24);
            this.nudHourInitial.TabIndex = 5;
            this.nudHourInitial.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudAdditional
            // 
            this.nudAdditional.DecimalPlaces = 2;
            this.nudAdditional.Location = new System.Drawing.Point(182, 55);
            this.nudAdditional.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudAdditional.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAdditional.Name = "nudAdditional";
            this.nudAdditional.Size = new System.Drawing.Size(120, 24);
            this.nudAdditional.TabIndex = 6;
            this.nudAdditional.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudTolerance
            // 
            this.nudTolerance.Location = new System.Drawing.Point(182, 85);
            this.nudTolerance.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTolerance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTolerance.Name = "nudTolerance";
            this.nudTolerance.Size = new System.Drawing.Size(120, 24);
            this.nudTolerance.TabIndex = 7;
            this.nudTolerance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpInitial
            // 
            this.dtpInitial.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtpInitial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInitial.Location = new System.Drawing.Point(182, 116);
            this.dtpInitial.Name = "dtpInitial";
            this.dtpInitial.Size = new System.Drawing.Size(184, 24);
            this.dtpInitial.TabIndex = 8;
            // 
            // dtpFinal
            // 
            this.dtpFinal.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinal.Location = new System.Drawing.Point(182, 146);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(184, 24);
            this.dtpFinal.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(291, 176);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 223);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpFinal);
            this.Controls.Add(this.dtpInitial);
            this.Controls.Add(this.nudTolerance);
            this.Controls.Add(this.nudAdditional);
            this.Controls.Add(this.nudHourInitial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PriceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar periodo de preço";
            ((System.ComponentModel.ISupportInitialize)(this.nudHourInitial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdditional)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTolerance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudHourInitial;
        private System.Windows.Forms.NumericUpDown nudAdditional;
        private System.Windows.Forms.NumericUpDown nudTolerance;
        private System.Windows.Forms.DateTimePicker dtpInitial;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Button btnSave;
    }
}