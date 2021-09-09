using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {

            List<JogoDomain> ListarTodos();

            JogoDomain BuscarPorId(int idJogo);

            void Cadastrar(JogoDomain novoJogo);

            void AtualizarIdCorpo(JogoDomain jogoAtualizado);

            void Deletar(int idjogo);

       
    }
}
