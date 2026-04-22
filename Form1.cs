using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SistemaLanche
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=banco.db;Version=3;";
        private DataGridView dgvEstoque;
        private TextBox txtQuantidade, txtTemperatura;
        private DateTimePicker dtpValidade;
        private ComboBox cbProdutos;
        private Label lblStatus;
        private Button btnAdicionar, btnExcluir, btnVender, btnSincronizar, btnLogs;

        public Form1()
        {
            InitializeComponent();
            CriarBanco();
            CarregarProdutos();
            CarregarEstoque();
        }

        private void InitializeComponent()
        {
            this.Text = "Sistema Lanche";
            this.Size = new Size(900, 600);

            cbProdutos = new ComboBox() { Location = new Point(20, 20), Width = 200 };
            txtQuantidade = new TextBox() { Location = new Point(240, 20), Width = 100 };
            txtTemperatura = new TextBox() { Location = new Point(360, 20), Width = 100 };
            dtpValidade = new DateTimePicker() { Location = new Point(480, 20), Width = 150 };

            btnAdicionar = new Button() { Text = "Adicionar", Location = new Point(20, 60) };
            btnExcluir = new Button() { Text = "Excluir", Location = new Point(120, 60) };
            btnVender = new Button() { Text = "Vender", Location = new Point(220, 60) };
            btnSincronizar = new Button() { Text = "Sincronizar", Location = new Point(320, 60) };
            btnLogs = new Button() { Text = "Logs", Location = new Point(440, 60) };

            btnAdicionar.Click += (s, e) => Adicionar();
            btnExcluir.Click += (s, e) => Excluir();
            btnVender.Click += (s, e) => Vender();
            btnSincronizar.Click += (s, e) => Sincronizar();
            btnLogs.Click += (s, e) => VerLogs();

            dgvEstoque = new DataGridView()
            {
                Location = new Point(20, 120),
                Size = new Size(830, 350)
            };

            lblStatus = new Label()
            {
                Location = new Point(20, 500),
                Width = 800,
                Text = "Sistema pronto"
            };

            Controls.Add(cbProdutos);
            Controls.Add(txtQuantidade);
            Controls.Add(txtTemperatura);
            Controls.Add(dtpValidade);
            Controls.Add(btnAdicionar);
            Controls.Add(btnExcluir);
            Controls.Add(btnVender);
            Controls.Add(btnSincronizar);
            Controls.Add(btnLogs);
            Controls.Add(dgvEstoque);
            Controls.Add(lblStatus);
        }

        private void CriarBanco()
        {
            if (!File.Exists("banco.db"))
                SQLiteConnection.CreateFile("banco.db");

            using var conn = new SQLiteConnection(connectionString);
            conn.Open();

            string sql1 = "CREATE TABLE IF NOT EXISTS produtos (id INTEGER PRIMARY KEY, nome TEXT)";
            string sql2 = "CREATE TABLE IF NOT EXISTS estoque (id INTEGER PRIMARY KEY, produto TEXT, quantidade INT, validade TEXT, temperatura REAL)";
            string sql3 = "CREATE TABLE IF NOT EXISTS logs (id INTEGER PRIMARY KEY, acao TEXT, data TEXT)";

            new SQLiteCommand(sql1, conn).ExecuteNonQuery();
            new SQLiteCommand(sql2, conn).ExecuteNonQuery();
            new SQLiteCommand(sql3, conn).ExecuteNonQuery();

            new SQLiteCommand("INSERT OR IGNORE INTO produtos (id, nome) VALUES (1,'Hamburguer'),(2,'Leite'),(3,'Queijo')", conn)
                .ExecuteNonQuery();
        }

        private void CarregarProdutos()
        {
            cbProdutos.Items.Clear();
            cbProdutos.Items.Add("Hamburguer");
            cbProdutos.Items.Add("Leite");
            cbProdutos.Items.Add("Queijo");
            cbProdutos.SelectedIndex = 0;
        }

        private void CarregarEstoque()
        {
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();

            var da = new SQLiteDataAdapter("SELECT * FROM estoque", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvEstoque.DataSource = dt;
        }

        private void Adicionar()
        {
            double temp = double.Parse(txtTemperatura.Text);

            if (temp < 2 || temp > 8)
            {
                MessageBox.Show("Temperatura inválida!");
                return;
            }

            using var conn = new SQLiteConnection(connectionString);
            conn.Open();

            string sql = "INSERT INTO estoque (produto, quantidade, validade, temperatura) VALUES (@p,@q,@v,@t)";
            var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@p", cbProdutos.Text);
            cmd.Parameters.AddWithValue("@q", txtQuantidade.Text);
            cmd.Parameters.AddWithValue("@v", dtpValidade.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@t", temp);
            cmd.ExecuteNonQuery();

            CarregarEstoque();
        }

        private void Excluir()
        {
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();
            new SQLiteCommand("DELETE FROM estoque WHERE id=(SELECT MIN(id) FROM estoque)", conn).ExecuteNonQuery();
            CarregarEstoque();
        }

        private void Vender()
        {
            MessageBox.Show("Venda registrada!");
        }

        private void Sincronizar()
        {
            MessageBox.Show("Sincronizado!");
        }

        private void VerLogs()
        {
            MessageBox.Show("Logs aqui");
        }
    }
}
