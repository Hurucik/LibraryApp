using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryApp
{
    public partial class OrderForm : Form
    {
        public Form1 form1;


        int cb_index;

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            
            // Таблица Basket
            dgw_basket.DataSource = form1.bsBasket;

            // ТАБЛИЦА   History
            dgw_history.DataSource = form1.bsHistory;

            // ТАБЛИЦА   Ticket
            dgw_Ticket.DataSource = form1.bsTicket;

            
            // ТАБЛИЦА   User
            cb_users.Items.Add("All users");
            cb_users.Text = "All users";
            foreach (DataRow user in form1.LibUser.Rows)
            {
                cb_users.Items.Add(user["UserName"]);
            }
            cb_users.SelectedIndex = 0;

           form1.bsLibUser = new BindingSource();
           form1.bsLibUser.DataSource = form1.LibUser;
           dgw_clients.DataSource = form1.LibUser;

            tb_Summ.Text = SumBooks().ToString();
            tb_amount.Text = form1.userAmountOfBooks.ToString();

            bt_order.Visible = false;
            dgw_Ticket.Visible = false;
            label4.Visible = false;

        }
        

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string ticketId = form1.TicketId;
            string userId = cb_index.ToString();

            MessageBox.Show(ticketId);
            MessageBox.Show(userId);
;
            if (cb_index > 0)
            {
                string insertBasketStr = $"UPDATE Basket SET UserId = {userId}, TicketId = {ticketId} WHERE UserId IS NULL AND TicketId IS NULL;";
                string insertHistoryStr = $"UPDATE History SET UserId = {userId} WHERE UserId IS NULL;";



                SqlCommand basketCmd = new SqlCommand(insertBasketStr, form1.conn);
                basketCmd.ExecuteNonQuery();
                SqlCommand historyCmd = new SqlCommand(insertHistoryStr, form1.conn);
                historyCmd.ExecuteNonQuery();

                form1.Basket.Clear();
                form1.adapBasket.Fill(form1.Basket);
                form1.History.Clear();
                form1.adapHistory.Fill(form1.History);

                bt_order.Visible = true;
                btn_ok.Visible = false;
                dgw_Ticket.Visible = true;
                label4.Visible = true;

            }
            else
            {
                MessageBox.Show("Выберите пользователя...");
            }
        }

        private void cb_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_index = cb_users.SelectedIndex;

            if (cb_index > 0)
            {
                form1.selRowsUser = form1.LibUser.Select("UserName = '" + cb_users.Text + "'");
                form1.LibUserId = form1.selRowsUser[0]["UserId"].ToString();

                form1.TicketIdStr = " SELECT TicketId FROM LibUser WHERE UserName = @UserName";
                SqlCommand TicketCmd = new SqlCommand(form1.TicketIdStr, form1.conn);

                TicketCmd.Parameters.AddWithValue("@UserName", cb_users.Text);
                SqlDataReader TicketReader = TicketCmd.ExecuteReader();
                if (TicketReader.Read())
                {
                    form1.TicketId = TicketReader["TicketId"].ToString();
                    TicketReader.Close();
                }


                //MessageBox.Show(TicketReader.ToString());

                //MessageBox.Show(TicketId);

                form1.bsHistory.Filter = "UserId = " + form1.LibUserId;
                form1.bsTicket.Filter = "TicketId = " + form1.TicketId;

                //MessageBox.Show(index3.ToString());

                MessageBox.Show($"ID ЧИТАТЕЛЬСКОГО БИЛЕТА {form1.TicketId}");
            }
            else 
            {
                form1.bsHistory.Filter = "";
                form1.bsTicket.Filter = "";
            }
           
        }

        private decimal SumBooks()
        {
            decimal price, sum = 0;

            int amount;

            foreach (DataRow row in form1.Basket.Rows)
            {
                price = Convert.ToDecimal(row["Price"]);
                amount = Convert.ToInt32(row["Amount"]);
                sum = sum + price * amount;
            }

            return sum;
        }

        private void bt_order_Click(object sender, EventArgs e)
        {
            //Делаем оформление заказа для одного пользователя 
            // Вписываем в таблицу Ticket Столбцы: Суммма заказа, количество взятых книг по читательскому билету,  

            DataGridViewRow curRow = dgw_basket.CurrentRow;

            string summ = tb_Summ.Text;

            MessageBox.Show(summ);

            string amount = tb_amount.Text;

            string ticketId = curRow.Cells["TicketId"].Value.ToString();

            string insertStr = $"UPDATE Ticket SET Amount = {amount}, Summ = {summ} WHERE TicketId = {ticketId}";

            MessageBox.Show(insertStr);

            SqlCommand insertCmd = new SqlCommand(insertStr, form1.conn);
            insertCmd.ExecuteNonQuery();

            form1.Ticket.Clear();
            form1.adapTicket.Fill(form1.Ticket);
            form1.Basket.Clear();
            form1.adapBasket.Fill(form1.Basket);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tb_Summ_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
