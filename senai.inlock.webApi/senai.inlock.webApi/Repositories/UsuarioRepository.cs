﻿using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-LEARTL9\\SQLExpress; initial catalog=Inlock_Games_Tarde; user Id=sa; pwd=senai@132";
        public UsuarioDomain BuscarPorId(int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = @"SELECT Email, Senha, tipoUsuario FROM Usuario
                                        INNER JOIN TipoUsuario 
                                        ON TipoUsuario.idTipoUsuario = Usuario.idTipoUSuario
                                        WHERE idUsuario = @idUsuario";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("idUsuario", idUsuario);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioEncontrado = new UsuarioDomain
                        {
                            Email = (rdr[0]).ToString(),
                            Senha = (rdr[1]).ToString(),
                            tipoUsuario = new TipoUsuarioDomain
                            {
                                titulo = (rdr[2]).ToString()
                            }

                        };
                        return usuarioEncontrado;

                    }
                }
                return null;
            }
        }
        public List<UsuarioDomain> ListarTodos()
        {
            List<UsuarioDomain> listaUsuario = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT Email, Senha, tipoUsuario FROM Usuario
                                        INNER JOIN TipoUsuario 
                                        ON TipoUsuario.idTipoUsuario = Usuario.idTipoUSuario";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            Email = (rdr[0]).ToString(),
                            Senha = (rdr[1]).ToString(),

                            tipoUsuario = new TipoUsuarioDomain
                            {
                                titulo = (rdr[2]).ToString()
                            }
                        };
                        listaUsuario.Add(usuario);
                    }
                }

            }
            return listaUsuario;
        }
    }
}
