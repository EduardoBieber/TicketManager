using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager;
using MySqlConnector;
using Interface.Cadastros;
using System.Data;
using Xamarin.Forms;
using System.Windows.Forms;
using System.Runtime.CompilerServices;


namespace Interface
{
    public class Funcionario
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Situacao { get; set; }

        public Funcionario(string id, string nome, string cpf, string situacao)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Situacao = situacao;
        }
    }

    public class Tickets
    {
        public string Id { get; set; }
        public string Funcionario { get; set; }
        public string Data { get; set; }
        public string QntEntregue { get; set; }
        public string Situacao { get; set; }
       

        public Tickets(string id, string funcionario, string data, string qntEntregue, string situacao)
        {
            Id = id;
            Funcionario = funcionario;
            Data = data;
            QntEntregue = qntEntregue;
            Situacao = situacao;
        }
    }



    public class Validacoes
    {
        public static bool VerificarExistencia(string cpf)
        {
            Conexao conexao = new Conexao();
            try
            {
                conexao.Conectar();
                string query = "SELECT COUNT(*) FROM funcionarios WHERE cpf = @cpf";
                MySqlCommand cmd = new MySqlCommand(query, conexao.con);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                bool exists = Convert.ToBoolean(cmd.ExecuteScalar());
                return exists;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao verificar existência: " + ex.Message);
                return false;
            }
            finally
            {
                conexao.Desconectar();
            }
        }
    }


    public class Cadastro
        {
            public static void Cadastrar(string nome, string cpf)
            {
                if (Validacoes.VerificarExistencia(cpf))
                {
                    MessageBox.Show("Já existe um funcionário com esse CPF!");
                    return;
                }

                Conexao conexao = new Conexao();
                try
                {
                    conexao.Conectar();
                    string query = "INSERT INTO funcionarios (nome, cpf, situacao) VALUES (@nome, @cpf, 'A')";
                    MySqlCommand cmd = new MySqlCommand(query, conexao.con);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Funcionário cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao cadastrar funcionário: " + ex.Message);
                }
                finally
                {
                    conexao.Desconectar();
                }
            }
        }
          
    public class Edicao
    {
        private DataGridView grid;
        public string Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Situacao { get; set; }


        public Edicao(DataGridView grid)
        {
            this.grid = grid;
        }

        private void FormatarDG()
        {      
                grid.Columns[0].HeaderText = "ID";
                grid.Columns[1].HeaderText = "NOME";
                grid.Columns[2].HeaderText = "CPF";
                grid.Columns[3].HeaderText = "SITUACAO";
                grid.Columns[4].HeaderText = "ULT.ALTERACAO";

                grid.Columns[5].Visible = false;
                grid.Columns[6].Visible = false;
                grid.Columns[7].Visible = false;

                grid.Columns[0].Width = 20;
                grid.Columns[1].Width = 100;
                grid.Columns[2].Width = 100;
                grid.Columns[3].Width = 80;
                grid.Columns[4].Width = 200;

            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }

        public void Listar()
        {
            Conexao conexao = new Conexao();
            string sql = "SELECT * FROM funcionarios ORDER BY nome ASC";

            try
            {
                
                conexao.Conectar();
                MySqlCommand cmd = new MySqlCommand(sql, conexao.con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.grid.DataSource = dt;
                FormatarDG();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar funcionários: " + ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void BuscarNome(string nome)
        {
            Conexao conexao = new Conexao();
            string sql = "SELECT * FROM funcionarios WHERE nome LIKE @nome ORDER BY nome ASC";

            try
            {
                conexao.Conectar();
                MySqlCommand cmd = new MySqlCommand(sql, conexao.con);
                cmd.Parameters.AddWithValue("@nome", "%" + nome + "%"); 
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.grid.DataSource = dt;
                FormatarDG();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar funcionários por nome: " + ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }


        public string RecuperarSituacao()
        {
            string situacao = grid.CurrentRow.Cells[3].Value.ToString();
            return situacao;
        }

        public Funcionario RecuperarID()
        {
            string id = grid.CurrentRow.Cells[0].Value.ToString();
            string nome = grid.CurrentRow.Cells[1].Value.ToString();
            string cpf = grid.CurrentRow.Cells[2].Value.ToString();
            string situacao = grid.CurrentRow.Cells[3].Value.ToString();

            return new Funcionario(id, nome, cpf, situacao);
        }

        public class ConsultaCpf
        {
            public static string CpfOriginal(string id)
            {
                Conexao conexao = new Conexao();
                string cpf = "";

                try
                {
                    conexao.Conectar();
                    string query = "SELECT cpf FROM funcionarios WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexao.con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cpf = cmd.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao obter CPF por ID: + ex.Message");
                }
                finally
                {
                    conexao.Desconectar();
                }
                return cpf;
            }
        }



        public static void SalvarEdicao(string nome, string cpf, string id, string situacao)
        {
            string cpfOriginal = ConsultaCpf.CpfOriginal(id);


            if (cpf != cpfOriginal)
            {
                if (Validacoes.VerificarExistencia(cpf))
                {
                    MessageBox.Show("Já existe um funcionário com esse CPF!");
                    return;
                }
            }

            Conexao conexao = new Conexao();
            try
            {
                conexao.Conectar();
                string query = "UPDATE funcionarios SET nome = @nome, cpf = @cpf, situacao = @situacao, data_ult_alteracao = NOW() WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conexao.con);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Situacao", situacao);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Funcionário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar funcionário: " + ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
    }

    public class GerenciarTickets
    {

  
        private DataGridView grid;
        public string Id { get; set; }
        public string Funcionario { get; set; }
        public string Situacao { get; set; }
        public string DataEntrega { get; set; }
        public DateTime dataInicial { get; set; }
        public DateTime dataFinal { get; set; }
        public string nomeFuncionario { get; set; }


        public GerenciarTickets(DataGridView grid)
        {
            this.grid = grid;
        }

        public static void LancarTickets(string nomeFuncionario, int quantidadeTickets)
        {
            Conexao conexao = new Conexao();
            try
            {
                conexao.Conectar();
                string queryTickets = "INSERT INTO tickets (funcionario_destino, qnt_entregue, situacao, data_entrega) VALUES (@funcionario, @quantidade, 'A', NOW())";
                MySqlCommand cmdTickets = new MySqlCommand(queryTickets, conexao.con);
                cmdTickets.Parameters.AddWithValue("@funcionario", nomeFuncionario);
                cmdTickets.Parameters.AddWithValue("@quantidade", quantidadeTickets);
                cmdTickets.ExecuteNonQuery();

                string queryFuncionario = "UPDATE funcionarios SET data_ult_lancamento = NOW(), ultimo_lancamento = @quantidade, total_tickets_emitidos = total_tickets_emitidos + @quantidade WHERE nome = @funcionario";
                MySqlCommand cmdFuncionario = new MySqlCommand(queryFuncionario, conexao.con);
                cmdFuncionario.Parameters.AddWithValue("@quantidade", quantidadeTickets);
                cmdFuncionario.Parameters.AddWithValue("@funcionario", nomeFuncionario);
                cmdFuncionario.ExecuteNonQuery();

                Console.WriteLine("Tickets lançados com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao lançar tickets: " + ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }


        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "NOME";
            grid.Columns[2].HeaderText = "CPF";
            grid.Columns[3].HeaderText = "SITUACAO";
            grid.Columns[4].HeaderText = "ULT.ALTERACAO";

            grid.Columns[0].Width = 30;
            grid.Columns[1].Width = 150;
            grid.Columns[2].Width = 150;
            grid.Columns[3].Width = 100;
            grid.Columns[4].Width = 200;

            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }

        public void ListarTickets()
        {
            Conexao conexao = new Conexao();
            string sql = "SELECT * FROM tickets ORDER BY id ASC";

            try
            {

                conexao.Conectar();
                MySqlCommand cmd = new MySqlCommand(sql, conexao.con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.grid.DataSource = dt;
                FormatarDG();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar tickets: " + ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void BuscarTicketPorNome(string nome)
        {
            Conexao conexao = new Conexao();
            string sql = "SELECT * FROM tickets WHERE funcionario_destino LIKE @nome ORDER BY data_entrega ASC";

            try
            {
                conexao.Conectar();
                MySqlCommand cmd = new MySqlCommand(sql, conexao.con);
                cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.grid.DataSource = dt;
                FormatarDG();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar tickets por nome: " + ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }


        public Tickets RecuperarID()
        {
            if (grid.CurrentRow == null)
            {
                return null;
            }

            string id = grid.CurrentRow.Cells[0].Value.ToString();
            string funcionario = grid.CurrentRow.Cells[1].Value.ToString();
            string data = grid.CurrentRow.Cells[2].Value.ToString();
            string qntEntregue = grid.CurrentRow.Cells[3].Value.ToString();
            string situacao = grid.CurrentRow.Cells[4].Value.ToString();

            return new Tickets(id, funcionario, data, qntEntregue, situacao);
        }

        public static void SalvarEdicaoTicket(string id, string funcionario, int qntEntregue, string situacao)
        {
            Conexao conexao = new Conexao();
            try
            {
                conexao.Conectar();
                string query = "UPDATE tickets SET funcionario_destino = @funcionario, qnt_entregue = @qntEntregue, situacao = @situacao, data_entrega = NOW() WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conexao.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@funcionario", funcionario);
                cmd.Parameters.AddWithValue("@qntEntregue", qntEntregue);
                cmd.Parameters.AddWithValue("@situacao", situacao);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Ticket atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar ticket: " + ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

 


        public void FiltrarRelatorio(string nomeFuncionario, DateTime dataInicial, DateTime dataFinal)
        {
            Conexao conexao = new Conexao();
            string sql = "SELECT funcionario_destino, id, cpf, data_entrega, qnt_entregue FROM tickets WHERE funcionario_destino = @nome AND data_entrega BETWEEN @dataInicial AND @dataFinal";
            try
            {
                conexao.Conectar();
                MySqlCommand cmd = new MySqlCommand(sql, conexao.con);
                cmd.Parameters.AddWithValue("@nome", nomeFuncionario);
                cmd.Parameters.AddWithValue("@dataInicial", dataInicial);
                cmd.Parameters.AddWithValue("@dataFinal", dataFinal);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                int totalTickets = dt.AsEnumerable().Sum(row => row.Field<int>("qnt_entregue"));
                dt.Rows.Add("Total", "", "", "", totalTickets);

                grid.DataSource = dt;
                FormatarDG();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar relatório: " + ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
    }
}
