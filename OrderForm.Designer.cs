namespace LibraryApp
{
    partial class OrderForm
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
            this.dgw_clients = new System.Windows.Forms.DataGridView();
            this.dgw_basket = new System.Windows.Forms.DataGridView();
            this.dgw_history = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_users = new System.Windows.Forms.ComboBox();
            this.Basket = new System.Windows.Forms.Label();
            this.Clients = new System.Windows.Forms.Label();
            this.History = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.tb_Summ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_order = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_amount = new System.Windows.Forms.TextBox();
            this.dgw_Ticket = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_clients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_basket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_history)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_Ticket)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw_clients
            // 
            this.dgw_clients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_clients.Location = new System.Drawing.Point(28, 317);
            this.dgw_clients.Name = "dgw_clients";
            this.dgw_clients.Size = new System.Drawing.Size(286, 184);
            this.dgw_clients.TabIndex = 2;
            // 
            // dgw_basket
            // 
            this.dgw_basket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_basket.Location = new System.Drawing.Point(28, 38);
            this.dgw_basket.Name = "dgw_basket";
            this.dgw_basket.Size = new System.Drawing.Size(1036, 184);
            this.dgw_basket.TabIndex = 3;
            // 
            // dgw_history
            // 
            this.dgw_history.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_history.Location = new System.Drawing.Point(336, 317);
            this.dgw_history.Name = "dgw_history";
            this.dgw_history.Size = new System.Drawing.Size(728, 184);
            this.dgw_history.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Имя клиента";
            // 
            // cb_users
            // 
            this.cb_users.FormattingEnabled = true;
            this.cb_users.Location = new System.Drawing.Point(635, 290);
            this.cb_users.Name = "cb_users";
            this.cb_users.Size = new System.Drawing.Size(72, 21);
            this.cb_users.TabIndex = 12;
            this.cb_users.SelectedIndexChanged += new System.EventHandler(this.cb_users_SelectedIndexChanged);
            // 
            // Basket
            // 
            this.Basket.AutoSize = true;
            this.Basket.Location = new System.Drawing.Point(25, 22);
            this.Basket.Name = "Basket";
            this.Basket.Size = new System.Drawing.Size(50, 13);
            this.Basket.TabIndex = 14;
            this.Basket.Text = "Корзина";
            // 
            // Clients
            // 
            this.Clients.AutoSize = true;
            this.Clients.Location = new System.Drawing.Point(25, 301);
            this.Clients.Name = "Clients";
            this.Clients.Size = new System.Drawing.Size(51, 13);
            this.Clients.TabIndex = 15;
            this.Clients.Text = "Клиенты";
            // 
            // History
            // 
            this.History.AutoSize = true;
            this.History.Location = new System.Drawing.Point(333, 298);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(95, 13);
            this.History.TabIndex = 16;
            this.History.Text = "История заказов";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(856, 256);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(101, 48);
            this.btn_ok.TabIndex = 20;
            this.btn_ok.Text = "Ок";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // tb_Summ
            // 
            this.tb_Summ.Location = new System.Drawing.Point(750, 290);
            this.tb_Summ.Name = "tb_Summ";
            this.tb_Summ.Size = new System.Drawing.Size(100, 20);
            this.tb_Summ.TabIndex = 21;
            this.tb_Summ.TextChanged += new System.EventHandler(this.tb_Summ_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(747, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Сумма заказа";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // bt_order
            // 
            this.bt_order.Location = new System.Drawing.Point(808, 540);
            this.bt_order.Name = "bt_order";
            this.bt_order.Size = new System.Drawing.Size(101, 48);
            this.bt_order.TabIndex = 23;
            this.bt_order.Text = "Оформить заказ";
            this.bt_order.UseVisualStyleBackColor = true;
            this.bt_order.Click += new System.EventHandler(this.bt_order_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(747, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Кол-во книг";
            // 
            // tb_amount
            // 
            this.tb_amount.Location = new System.Drawing.Point(750, 251);
            this.tb_amount.Name = "tb_amount";
            this.tb_amount.Size = new System.Drawing.Size(100, 20);
            this.tb_amount.TabIndex = 24;
            // 
            // dgw_Ticket
            // 
            this.dgw_Ticket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_Ticket.Location = new System.Drawing.Point(454, 540);
            this.dgw_Ticket.Name = "dgw_Ticket";
            this.dgw_Ticket.Size = new System.Drawing.Size(334, 184);
            this.dgw_Ticket.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 524);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Читательский билет";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 794);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgw_Ticket);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_amount);
            this.Controls.Add(this.bt_order);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Summ);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.History);
            this.Controls.Add(this.Clients);
            this.Controls.Add(this.Basket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_users);
            this.Controls.Add(this.dgw_history);
            this.Controls.Add(this.dgw_basket);
            this.Controls.Add(this.dgw_clients);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_clients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_basket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_history)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_Ticket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgw_clients;
        public System.Windows.Forms.DataGridView dgw_basket;
        public System.Windows.Forms.DataGridView dgw_history;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cb_users;
        public System.Windows.Forms.Label Basket;
        public System.Windows.Forms.Label Clients;
        public System.Windows.Forms.Label History;
        public System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox tb_Summ;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button bt_order;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_amount;
        public System.Windows.Forms.DataGridView dgw_Ticket;
        public System.Windows.Forms.Label label4;
    }
}