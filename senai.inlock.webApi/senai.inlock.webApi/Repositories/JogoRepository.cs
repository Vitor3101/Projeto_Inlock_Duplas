using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=DESKTOP-LEARTL9\\SQLExpress; initial catalog=Inlock_Games_Tarde; user Id=sa; pwd=senai@132";


        public void AtualizarIdCorpo(JogoDomain jogoAtualizado)
        {
            if (jogoAtualizado.nomeJogo != null || jogoAtualizado.Valor >= 0 || jogoAtualizado.descricao != null || jogoAtualizado.idJogo > 0)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE JOGO SET  nomeJogo = @nomeJogo, Valor = @Valor, Descricao = @Descricao, dataLancamento = @dataLancamento WHERE idJogo = @idJogo";
                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@nomeJogo", jogoAtualizado.nomeJogo);
                        cmd.Parameters.AddWithValue("@Valor", jogoAtualizado.Valor);
                        cmd.Parameters.AddWithValue("@Descricao", jogoAtualizado.descricao);
                        cmd.Parameters.AddWithValue("@dataLancamento", jogoAtualizado.dataLancamento);
                        cmd.Parameters.AddWithValue("@idJogo", jogoAtualizado.idJogo);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public JogoDomain BuscarPorId(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT nomeJogo, Valor, Descricao, dataLancamento FROM JOGO WHERE idJogo = @idJogo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("idJogo", idJogo);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain jogoEncontrado = new JogoDomain
                        {
                            nomeJogo = (rdr[0]).ToString(),
                            Valor = Convert.ToInt32(rdr[1]),
                            descricao = (rdr[2]).ToString(),
                            dataLancamento = Convert.ToDateTime(rdr[3]),
                        };
                        return jogoEncontrado;

                    }
                }
                return null;
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO JOGO (nomeJogo, Valor, Descricao, dataLancamento) VALUES (@nomeJogo, @Valor, @Descricao, @dataLancamaneto)";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idjogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE * FROM JOGO WHERE idJogo = @idJogo";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idjogo);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT nomeJogo, Valor, Descricao, dataLancamento FROM JOGO";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain
                        {
                            nomeJogo = (rdr[0]).ToString(),
                            Valor = Convert.ToInt32(rdr[1]),
                            descricao = (rdr[2]).ToString(),
                            dataLancamento = Convert.ToDateTime(rdr[3]),
                        };
                        listaJogo.Add(jogo);
                    }
                }
                
            }
            return listaJogo;
        }
    }
}
