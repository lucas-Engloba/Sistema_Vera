namespace Mercado_Vera.View.GerCliente
{
    partial class FmrCliPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmrCliPagamento));
            this.button1 = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblCli = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.cbxPag = new System.Windows.Forms.ComboBox();
            this.cbxBand = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(152, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(22, 53);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(109, 23);
            this.txtValor.TabIndex = 2;
            this.txtValor.Text = "0,00";
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Location = new System.Drawing.Point(54, 141);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(77, 23);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblCli
            // 
            this.lblCli.AutoSize = true;
            this.lblCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCli.Location = new System.Drawing.Point(29, 9);
            this.lblCli.Name = "lblCli";
            this.lblCli.Size = new System.Drawing.Size(72, 17);
            this.lblCli.TabIndex = 1;
            this.lblCli.Text = "CLIENTE";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(6, 9);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(17, 17);
            this.lblId.TabIndex = 4;
            this.lblId.Text = "1";
            // 
            // cbxPag
            // 
            this.cbxPag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPag.FormattingEnabled = true;
            this.cbxPag.Items.AddRange(new object[] {
            "Débito",
            "Crédito",
            "Dinheiro"});
            this.cbxPag.Location = new System.Drawing.Point(137, 52);
            this.cbxPag.Name = "cbxPag";
            this.cbxPag.Size = new System.Drawing.Size(92, 24);
            this.cbxPag.TabIndex = 5;
            this.cbxPag.SelectedIndexChanged += new System.EventHandler(this.cbxPag_SelectedIndexChanged);
            // 
            // cbxBand
            // 
            this.cbxBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBand.FormattingEnabled = true;
            this.cbxBand.Items.AddRange(new object[] {
            "Visa",
            "Mastercard",
            "American Express",
            "Elo",
            "Caixa"});
            this.cbxBand.Location = new System.Drawing.Point(22, 97);
            this.cbxBand.Name = "cbxBand";
            this.cbxBand.Size = new System.Drawing.Size(207, 24);
            this.cbxBand.TabIndex = 13;
            // 
            // FmrCliPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(249, 176);
            this.Controls.Add(this.cbxBand);
            this.Controls.Add(this.cbxPag);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblCli);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmrCliPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamento";
            this.Load += new System.EventHandler(this.FmrCliPagamento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblCli;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.ComboBox cbxPag;
        private System.Windows.Forms.ComboBox cbxBand;
    }
}