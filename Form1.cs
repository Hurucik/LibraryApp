using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Net;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace LibraryApp
{
    public partial class Form1 : Form
    {
        public string conStr;
        public SqlConnection conn;

        public string strBooks, strGenre, strAuthors, strBasket, strLibUser, strHistory, strTicket;
        public SqlCommand cmdBooks, cmdGenre, cmdAuthors, cmdBasket, cmdLibUser, cmdHistory, cmdTicket;
        public SqlDataAdapter adapBooks, adapGenre, adapAuthors, adapBasket, adapLibUser, adapHistory, adapTicket;



        public DataTable Books, Genre, Authors, Basket, LibUser, History, Ticket;

       

        public BindingSource bsBooks, bsBasket, bsHistory, bsLibUser, bsTicket, bsAuthors;

        public int index1, index2, index3;
        public string GenreId, AuthorId, LibUserId, TicketId;
        public string TicketIdStr, GenreIdStr;

        public DataRow[] selRows, selRowsAuthor, selRowsUser;

        public int userAmountOfBooks = 0;

        public int Option;


        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rukubik\Desktop\ЛАБЫ4СЕМА\LibraryApp\Library.mdf;Integrated Security=True;Connect Timeout=30";

            conn = new SqlConnection(conStr);
            conn.Open();

            //Таблица Books

            strBooks = "SELECT * FROM Books";

            cmdBooks = new SqlCommand(strBooks, conn);

            adapBooks = new SqlDataAdapter(cmdBooks);

            Books = new DataTable();
            adapBooks.Fill(Books);

            bsBooks = new BindingSource();
            bsBooks.DataSource = Books;
            dataGridView1.DataSource = bsBooks;

            //Таблица Genre

            strGenre = "SELECT * FROM Genre";
            cmdGenre = new SqlCommand(strGenre, conn);
            adapGenre = new SqlDataAdapter(cmdGenre);

            Genre = new DataTable();
            adapGenre.Fill(Genre);

            comboBox1.Items.Add("Все жанры");
            comboBox1.Text = "Все жанры";
            foreach (DataRow genre in Genre.Rows)
            {
                comboBox1.Items.Add(genre["Genre"]);
                               
            }
            comboBox1.SelectedIndex = 0;


            //Таблица Authors

            strAuthors = "SELECT * FROM Authors";
            cmdAuthors = new SqlCommand(strAuthors, conn);
            adapAuthors = new SqlDataAdapter(cmdAuthors);

            Authors = new DataTable();
            adapAuthors.Fill(Authors);

            comboBox2.Items.Add("Все авторы");
            comboBox2.Text = "Все авторы";
            foreach (DataRow author in Authors.Rows)
            {
                comboBox2.Items.Add(author["LastName"]);
            }
            comboBox2.SelectedIndex = 0;
            

            //Таблица Basket

            strBasket = "SELECT * FROM Basket";
            
            cmdBasket = new SqlCommand(strBasket, conn);

            adapBasket = new SqlDataAdapter(cmdBasket);
            Basket = new DataTable();

            adapBasket.Fill(Basket);
            
            bsBasket = new BindingSource();
            bsBasket.DataSource = Basket;
            dataGridView2.DataSource = bsBasket;

            
            
            Basket.Clear();

            //Таблица History

            strHistory = "SELECT * FROM History";
            cmdHistory = new SqlCommand(strHistory, conn);

            adapHistory = new SqlDataAdapter(cmdHistory);
            History = new DataTable();
            adapHistory.Fill(History);

            bsHistory = new BindingSource();
            bsHistory.DataSource = History;
            

            //Таблица Ticket
            strTicket = "SELECT * FROM Ticket";
            cmdTicket = new SqlCommand(strTicket,conn);
            

            adapTicket = new SqlDataAdapter(cmdTicket);
            Ticket = new DataTable();
            adapTicket.Fill(Ticket);    
            

            bsTicket = new BindingSource();
            bsTicket.DataSource = Ticket;
            

            // ТАБЛИЦА   User
            strLibUser = "SELECT * FROM  LibUser";
            cmdLibUser = new SqlCommand(strLibUser, conn);
            adapLibUser = new SqlDataAdapter(cmdLibUser);

            LibUser = new DataTable();
            adapLibUser.Fill(LibUser);

            Console.WriteLine(Authors.Select());


            textBox3.Text = DateTime.Now.ToString("MM.dd.yyyy");


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            while (true)
            {
                

                if (dataGridView2.Rows.Count > 1)
                {
                    DataGridViewRow curRow = dataGridView2.CurrentRow;
                    DataGridViewRow curRowView1 = dataGridView1.CurrentRow;

                    string id = curRow.Cells["BookId"].Value.ToString();
                    string amount = curRow.Cells["Amount"].Value.ToString();
                    string AmountOfBooks = "";

                    MessageBox.Show($"ID КНИГИ {id}");

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["BookId"].Value.ToString() == id)
                        {
                            AmountOfBooks = row.Cells["Amount"].Value.ToString();
                            MessageBox.Show($"В УСЛОВИИ {AmountOfBooks}");
                            break;
                        }
                    }

                    curRowView1.Cells["Amount"].Value = AmountOfBooks;

                    string sum = (int.Parse(amount) + int.Parse(AmountOfBooks)).ToString();
                    MessageBox.Show($"ТЕКУЩАЯ СТРОКА У Books {curRowView1}");
                    MessageBox.Show($"ОБЩЕЕ КОЛ-ВО КНИГ {AmountOfBooks}");
                    MessageBox.Show($"КОЛ-ВО КНИГ ВЗЯТЫХ {amount}");
                    MessageBox.Show($"СУММА КНИГ {sum}");


                    string deleteStr = "DELETE FROM Basket WHERE BookId =" + id;
                    string updateStr = "UPDATE Books SET Amount = " + sum + " WHERE BookId =" + id;

                    MessageBox.Show(updateStr);

                    SqlCommand deleteCmd = new SqlCommand(deleteStr, conn);
                    deleteCmd.ExecuteNonQuery();

                    SqlCommand updateCmd = new SqlCommand(updateStr, conn);
                    updateCmd.ExecuteNonQuery();

                    Basket.Clear();
                    adapBasket.Fill(Basket);
                    Books.Clear();
                    adapBooks.Fill(Books);

                    textBox2.Text = SumBooks().ToString();
                }
                else
                {
                    break;
                }

                
            }
            
            string truncateStr = "TRUNCATE TABLE Basket";
            
            SqlCommand trucnateCmd = new SqlCommand(truncateStr, conn);
            trucnateCmd.ExecuteNonQuery();

            string fillBooks = "UPDATE Books SET Amount = 50";

            SqlCommand fillCmd = new SqlCommand(fillBooks, conn);
            fillCmd.ExecuteNonQuery();

            MessageBox.Show("Корзина очищена.");
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            strBooks = "SELECT * FROM Books";
            strAuthors = "SELECT * FROM Authors";
            index1 = comboBox1.SelectedIndex;

            if (index1 > 0)
            {
                selRows = Genre.Select($"Genre= '{comboBox1.Text}'");
                GenreId = selRows[0]["GenreId"].ToString();

                strBooks = strBooks + $" WHERE GenreId= {GenreId}";
                strAuthors = strAuthors + $" WHERE GenreId = {GenreId}";

                cmdAuthors.CommandText = strAuthors;
                Authors.Clear();
                adapAuthors.Fill(Authors);

                comboBox2.Items.Clear();

                comboBox2.Items.Add("Все авторы");
                
                comboBox2.Text = "Все авторы";

                foreach (DataRow author in Authors.Rows)
                {
                    comboBox2.Items.Add(author["LastName"]);
                }

                comboBox2.SelectedIndex = 0;
            }
            cmdBooks.CommandText = strBooks;
            Books.Clear();
            adapBooks.Fill(Books);
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            if (index2 >0 )
            {
                strAuthors = "SELECT * FROM Authors";

                cmdAuthors.CommandText = strAuthors;
                Authors.Clear();
                adapAuthors.Fill(Authors);

                comboBox2.Items.Clear();

                comboBox2.Items.Add("Все авторы");

                comboBox2.Text = "Все авторы";

                foreach (DataRow author in Authors.Rows)
                {
                    comboBox2.Items.Add(author["LastName"]);
                }
            }
            else
            {
                return;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            index1 = comboBox1.SelectedIndex;
            index2 = comboBox2.SelectedIndex;

            strBooks = "SELECT * FROM Books";
            strAuthors = "SELECT * FROm Authors";

            if (index1 > 0)
            {
                strBooks = strBooks + $" WHERE (GenreId = {GenreId})";
            }
            if (index2 > 0 & index1 > 0)
            {
                selRows = Authors.Select($"LastName = '{comboBox2.Text}'");
                AuthorId = selRows[0]["AuthorId"].ToString();

                strBooks = strBooks + $" AND (AuthorId = {AuthorId})";
            }
            else if (index2 > 0)
            {
                selRows = Authors.Select($"LastName = '{comboBox2.Text}'");
                AuthorId = selRows[0]["AuthorId"].ToString();

                strBooks = strBooks + $" WHERE AuthorId = {AuthorId}";

                
            }
            
            MessageBox.Show(strBooks);
            
            cmdBooks.CommandText = strBooks;
            Books.Clear();
            adapBooks.Fill(Books);
        }



        /*private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            index3 = comboBox3.SelectedIndex;

            if (index3 > 0)
            {
                selRowsUser = LibUser.Select("UserName = '" + comboBox3.Text + "'");
                LibUserId = selRowsUser[0]["UserId"].ToString();

                TicketIdStr = " SELECT TicketId FROM LibUser WHERE UserName = @UserName";
                SqlCommand TicketCmd = new SqlCommand(TicketIdStr, conn);

                TicketCmd.Parameters.AddWithValue("@UserName", comboBox3.Text);
                SqlDataReader TicketReader = TicketCmd.ExecuteReader();
                if (TicketReader.Read())
                {
                    TicketId = TicketReader["TicketId"].ToString();
                    TicketReader.Close();
                }
                

                //MessageBox.Show(TicketReader.ToString());

                //MessageBox.Show(TicketId);

                bsHistory.Filter = "UserId = " + LibUserId;
                
                //MessageBox.Show(index3.ToString());

                MessageBox.Show($"ID ЧИТАТЕЛЬСКОГО БИЛЕТА {TicketId}");
            }
            else bsHistory.Filter = "";
        }*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btn_choose_client_Click(object sender, EventArgs e)
        {
            // Код кнопки ВЫбрать пользователя  
            Option = 1;
            OrderForm order = new OrderForm();
            order.form1 = this;

            order.Show();

        }
        /*private void button3_Click(object sender, EventArgs e)
        {
            //Делаем оформление заказа для одного пользователя 
            // Вписываем в таблицу Ticket Столбцы: Суммма заказа, количество взятых книг по читательскому билету,  
            
            DataGridViewRow curRow = dataGridView2.CurrentRow;

            string summ = textBox2.Text;

            MessageBox.Show(summ);

            string amount = userAmountOfBooks.ToString();

            string ticketId = curRow.Cells["TicketId"].Value.ToString();

            string insertStr = $"UPDATE Ticket SET Amount = {amount}, Summ = {summ} WHERE TicketId = {ticketId}";

            MessageBox.Show(insertStr);
            
            SqlCommand insertCmd = new SqlCommand(insertStr, conn);
            insertCmd.ExecuteNonQuery();

            Ticket.Clear();
            adapTicket.Fill(Ticket);

            textBox1.Text = "";

            string deleteStr = $"DELETE FROM Basket WHERE TicketId = {ticketId}";

            SqlCommand deleteCmd = new SqlCommand(deleteStr, conn);
            deleteCmd.ExecuteNonQuery();

            Basket.Clear();
            adapBasket.Fill(Basket);

        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow curRow = dataGridView2.CurrentRow;
            DataGridViewRow curRowView1 = dataGridView1.CurrentRow;

           

            string id = curRow.Cells["BookId"].Value.ToString();
            string amount = curRow.Cells["Amount"].Value.ToString();
            string AmountOfBooks = "";
            
            MessageBox.Show($"ID КНИГИ {id}");

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["BookId"].Value.ToString() == id)
                {
                    AmountOfBooks = row.Cells["Amount"].Value.ToString();
                    MessageBox.Show($"В УСЛОВИИ {AmountOfBooks}");
                    break;
                }
            }

            curRowView1.Cells["Amount"].Value = AmountOfBooks;
            
            string sum = (int.Parse(amount) + int.Parse(AmountOfBooks)).ToString();
            MessageBox.Show($"ТЕКУЩАЯ СТРОКА У Books {curRowView1}");
            MessageBox.Show($"ОБЩЕЕ КОЛ-ВО КНИГ {AmountOfBooks}");
            MessageBox.Show($"КОЛ-ВО КНИГ ВЗЯТЫХ {amount}");
            MessageBox.Show($"СУММА КНИГ {sum}");


            string deleteStr = "DELETE FROM Basket WHERE BookId =" + id;
            string updateStr = "UPDATE Books SET Amount = " + sum + " WHERE BookId =" + id;

            MessageBox.Show(updateStr);

            SqlCommand deleteCmd = new SqlCommand(deleteStr, conn);
            deleteCmd.ExecuteNonQuery();

            SqlCommand updateCmd = new SqlCommand(updateStr, conn);
            updateCmd.ExecuteNonQuery();

            Basket.Clear();
            adapBasket.Fill(Basket);
            Books.Clear();
            adapBooks.Fill(Books);

            textBox2.Text = SumBooks().ToString();

        }

        // TODO: Сделать проверку на null кол-во книг в таблице Books
        private void button1_Click(object sender, EventArgs e)
        {

            DataGridViewRow curRow = dataGridView1.CurrentRow;
            

            string bookId = curRow.Cells["BookId"].Value.ToString();
            string title = curRow.Cells["Title"].Value.ToString();
            string price = curRow.Cells["Price"].Value.ToString();
            string amount = textBox1.Text;
            string amountofBooks = curRow.Cells["Amount"].Value.ToString();
            string isData = textBox3.Text.ToString();
            string reData = textBox4.Text.ToString();
            string userId = index3.ToString();
            string ticketId = TicketId;

            DateTime timeIsDate, timeReDate;


            if (Int32.Parse(amountofBooks)<=0)
            {
                MessageBox.Show("Книг нет в наличии");
            }


            //MessageBox.Show(amount);
            if (DateTime.TryParseExact(isData, "MM.dd.yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out timeIsDate) && DateTime.TryParseExact(reData, "MM.dd.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeReDate))
            {   
                if (timeIsDate > timeReDate)
                {
                    MessageBox.Show("Дата возрвата не может быть позже даты выдачи...");
                }
                else
                {
                    int diff = int.Parse(amountofBooks) - int.Parse(amount);

                    userAmountOfBooks = userAmountOfBooks + Int32.Parse(amount);


                    string insertHistoryStr = $"INSERT INTO History  (BookId, Title, Price, Amount, IssueData, ReturnData)  " +
                        $"VALUES ({bookId}, N'{title}', {price}, {amount}, '{isData}', '{reData}');";

                    MessageBox.Show(insertHistoryStr);

                    SqlCommand insertHistoryCmd = new SqlCommand(insertHistoryStr, conn);
                    insertHistoryCmd.ExecuteNonQuery();

                    string insertStr = $"INSERT INTO Basket  (BookId, Title, Price, Amount, IssueData, ReturnData)  " +
                        $"VALUES ({bookId}, N'{title}', {price}, {amount}, '{isData}', '{reData}');";
                    SqlCommand insertCmd = new SqlCommand(insertStr, conn);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show(insertStr);

                    string updateStr = "UPDATE Books SET Amount= " + diff.ToString() + " WHERE BookId =" + bookId;
                    SqlCommand updateCmd = new SqlCommand(updateStr, conn);
                    updateCmd.ExecuteNonQuery();

                    Basket.Clear();
                    adapBasket.Fill(Basket);
                    History.Clear();
                    adapHistory.Fill(History);
                    Books.Clear();
                    adapBooks.Fill(Books);
                    textBox2.Text = SumBooks().ToString();

                    
                }
            }
            else if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                
                    MessageBox.Show(" Не Введена дата выдачи/возврата или не указано количество книг...");
                    MessageBox.Show(index3.ToString());
                
            }
            else
            {
                MessageBox.Show("Формат даты должен быть: \"mm.dd.yyyy\"");
            }
                
        }

        private decimal SumBooks()
        {
            decimal price, sum = 0;

            int amount;

            foreach (DataRow row in Basket.Rows)
            {
                price = Convert.ToDecimal(row["Price"]);
                amount = Convert.ToInt32(row["Amount"]);
                sum = sum + price * amount;
            }

            return sum;
        }


        
    }
}