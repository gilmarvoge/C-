using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; 
using System.Data.SqlClient;
//acima tem que chamar duas ultima bibliotecas para trabalhar com banco de dados

namespace CamadaDados
{
    public class DCategoria
    {
        private int _IdCategoria;
        private string _Nome;
        private string _Descricao;
        private string _TextoBuscar;

        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //construtor com parametros
        public DCategoria(int idcategoria, string nome, string descricao, string textoBuscar)
        {
            this.IdCategoria = idcategoria;
            this.Nome = nome;
            this.Descricao = descricao;
            this.TextoBuscar = textoBuscar;

        }

        public DCategoria()
        {
        }

        //Metodo inserir
        public string Inserir(DCategoria Categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //código da inserção
                SqlCon.ConnectionString = conexao.Conexao;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "varNome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Categoria.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "varDescricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 50;
                ParDescricao.Value = Categoria.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

                //executar comando                       if e else da pra fazer assim:
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "Registro não foi inserido";//pra saber se deu certo ou nao, se recebeu 1 então deu certo

            }
            catch (Exception ex)
            {
                resp = ex.Message;
                //resp = "Deu erro ao salvar!";
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return resp;


        }
        //Metodo Editar
        public string Editar(DCategoria Categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //código da inserção
                SqlCon.ConnectionString = conexao.Conexao;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.IdCategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "varNome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Categoria.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "varDescricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 50;
                ParDescricao.Value = Categoria.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

                //executar comando                       if e else da pra fazer assim:
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "A edição não foi realizada";//pra saber se deu certo ou nao, se recebeu 1 então deu certo

            }
            catch (Exception ex)
            {
                resp = ex.Message;
                //resp = "Deu erro ao salvar!";
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return resp;



        }
        //Metodo Excluir
        public string Excluir(DCategoria Categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //código da inserção
                SqlCon.ConnectionString = conexao.Conexao;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdeletar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.IdCategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

                

                //executar comando                       if e else da pra fazer assim:
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "A exclusão não foi realizada";//pra saber se deu certo ou nao, se recebeu 1 então deu certo

            }
            catch (Exception ex)
            {
                resp = ex.Message;
                //resp = "Deu erro ao salvar!";
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return resp;


        }
        //Metodo inserir
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexao.Conexao;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);
            }
            catch
            {
                DtResultado = null;
            }
            return DtResultado;

        }
        //Metodo Buscar
        public DataTable BuscarNome(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexao.Conexao;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_noome";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
                SqlCmd.Parameters.Add(TextoBuscar);
            }
            catch
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    }
    
     
}

