using Nyous_NoSQL.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous_NoSQL.Interfaces
{
    public interface IEventosRepositories
    {
        List<EventoDomain> Listar();
        EventoDomain BuscarPorId(string id);
        void Adcionar(EventoDomain evento);
        void Atualizar(string id, EventoDomain evento);
        void Remover(string id);
    }
}
