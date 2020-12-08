using MongoDB.Driver;
using Nyous_NoSQL.Context;
using Nyous_NoSQL.Domains;
using Nyous_NoSQL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous_NoSQL.Repositories
{
    public class EventosRepositories : IEventosRepositories
    {
        private readonly IMongoCollection<EventoDomain> _eventos;
        public EventosRepositories(INyousDataBaseSettigs settings)
        {

            var client = new MongoClient(settings.ConnectionString);

            var database = client.GetDatabase(settings.DatabaseName);

            _eventos = database.GetCollection<EventoDomain>(settings.EventosCollectionName);
        }

        public void Adcionar(EventoDomain evento)
        {
            try 
            {
                _eventos.InsertOne(evento);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(string id, EventoDomain evento)
        {
            try
            {
               
                _eventos.ReplaceOne(c => c.Id == id, evento); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EventoDomain BuscarPorId(string id)
        {
            try
            {

                return _eventos.Find<EventoDomain>(c => c.Id == id).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EventoDomain> Listar()
        {
          
            try
            {
                return _eventos.AsQueryable<EventoDomain>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(string id)
        {
            try
            {
                 _eventos.Find<EventoDomain>(c => c.Id == id).First();
                _eventos.DeleteOne(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
