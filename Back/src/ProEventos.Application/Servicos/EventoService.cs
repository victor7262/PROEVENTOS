using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contrato;

namespace ProEventos.Application.Servicos
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IEventoPersistence _eventoPersistence;
        
        public EventoService(IGeralPersistence _geralPersistence, IEventoPersistence eventoPersistence)
        {
            this._geralPersistence = _geralPersistence;            
            this._eventoPersistence = eventoPersistence;
        }

        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _geralPersistence.Add<Evento>(model);

                if (await _geralPersistence.SaveChangesAsync())
                    return await _eventoPersistence.GetEventoByIdAsync(model.Id, false);
                
                return null;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, false);

                if (evento == null) return null;

                model.Id = evento.Id;

                _geralPersistence.Update<Evento>(model);
                if (await _geralPersistence.SaveChangesAsync())
                    return await _eventoPersistence.GetEventoByIdAsync(model.Id, false);
                
                return null; 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, false);

                if (evento == null) throw new Exception("Evento para delete não foi encontrado.");

                _geralPersistence.Delete<Evento>(evento);
                
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                return await _eventoPersistence.GetAllEventosAsync(includePalestrantes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                return await _eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                return await _eventoPersistence.GetEventoByIdAsync(eventoId, includePalestrantes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}