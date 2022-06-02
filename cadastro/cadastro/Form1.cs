using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cadastro
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEstoque_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (con.State == ConnectionState.Open)
            {
                SqlCommand cm;
                string sql = "";
                sql = "insert into cadastro_matheus (produto,estoque,vlr_unit) values (@PRODUTO,@ESTOQUE,@VLR_UNIT)";
                cm = new SqlCommand(sql, con);

                cm.Parameters.Add("@PRODUTO", SqlDbType.VarChar).Value = txtProduto.Text;
                cm.Parameters.Add("@ESTOQUE", SqlDbType.VarChar).Value = txtEstoque.Text;
                cm.Parameters.Add("@VLR_UNIT", SqlDbType.Decimal).Value = txtValor.Text;

                int ret = cm.ExecuteNonQuery();
                if (ret > 0)
                {
                    MessageBox.Show("O Produto foi inserido com sucesso!");

                }
            }
            mostrar();

        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            if (con.State == ConnectionState.Open)
            {
                if (ccbEntrada.Checked == true)
                {

                    SqlCommand cm;
                    string sql = "";
                    string estoque = "";
                    estoque = " update cadastro_matheus set ESTOQUE = ESTOQUE + @QUANTIDADE where id =@ID";
                    sql = "update cadastro_matheus set VLR_UNIT=@VLR_UNIT, DATA_ALT=@DATA_ALT, TIPO= @ENTRADA where id=@ID";
                    cm = new SqlCommand(sql + estoque, con);

                    cm.Parameters.Add("@QUANTIDADE", SqlDbType.Int).Value = txtEntrada.Text;
                    cm.Parameters.Add("@VLR_UNIT", SqlDbType.Decimal).Value = txtValor2.Text;
                    cm.Parameters.Add("@DATA_ALT", SqlDbType.Date).Value = mtbData.Text;
                    cm.Parameters.Add("@ID", SqlDbType.BigInt).Value = lblId.Text;
                    cm.Parameters.Add("@ENTRADA", SqlDbType.VarChar).Value = "Entrada";

                    int ret = cm.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        MessageBox.Show("O Produto foi alterado com sucesso!");
                    }
                }
                else if (ccbSaida.Checked == true)
                {

                    SqlCommand cm;
                    string sql = "";
                    string estoque = "";
                    estoque = " update cadastro_matheus set ESTOQUE = ESTOQUE - @QUANTIDADE where id =@ID";
                    sql = "update cadastro_matheus set VLR_UNIT=@VLR_UNIT, DATA_ALT=@DATA_ALT, TIPO= @SAIDA where id=@ID";
                    cm = new SqlCommand(sql + estoque, con);

                    cm.Parameters.Add("@QUANTIDADE", SqlDbType.Int).Value = txtEntrada.Text;
                    cm.Parameters.Add("@VLR_UNIT", SqlDbType.Decimal).Value = txtValor2.Text;
                    cm.Parameters.Add("@DATA_ALT", SqlDbType.Date).Value = mtbData.Text;
                    cm.Parameters.Add("@ID", SqlDbType.BigInt).Value = lblId.Text;
                    cm.Parameters.Add("@SAIDA", SqlDbType.VarChar).Value = "Saida";

                    int ret = cm.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        MessageBox.Show("O Produto foi alterado com sucesso!");
                    }
                }

                mostrar();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str = "";
            str = "Data source = 10.64.45.32, 1433; Initial Catalog = TI41; User Id = aluno; Password = 123456";
            con = new SqlConnection(str);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        private void mostrar()
        {
            SqlCommand cm;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tb = new DataTable();
            string sql = "select * from cadastro_matheus";
            cm = new SqlCommand(sql, con);
            da.SelectCommand = cm;
            da.Fill(tb);
            dtgBusca.DataSource = null;
            dtgBusca.DataSource = tb;

        }

        private void dtgBusca_Click(object sender, EventArgs e)
        {
            if (dtgBusca.Rows.Count > 0)
            {
                lblId.Text = dtgBusca.CurrentRow.Cells[0].Value.ToString();
                txtValor2.Text = dtgBusca.CurrentRow.Cells[3].Value.ToString();
                mtbData.Text = dtgBusca.CurrentRow.Cells[4].Value.ToString();
            }

        }
    }
}
