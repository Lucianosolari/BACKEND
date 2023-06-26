using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.DBContexts;
using Microsoft.AspNetCore.Mvc;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Implementations
{
    public class KnowledgeRepository : IKnowledgeRepository
    {
        private readonly TPContext _context;
        public KnowledgeRepository(TPContext context)
        {
            _context = context;
        }

        public List<Knowledge> GetAllKnowledge()
        {
            try
            {
                return _context.Knowledges.Where(k => k.KnowledgeIsActive == true).ToList();
            }
            catch
            {
                throw new Exception("No se encontraron conocimientos");
            }
        }

        public void DeleteKnowledge(int knowledgeId)
        {
            try
            {
                var knowledge = _context.Knowledges.FirstOrDefault(k => k.KnowledgeId == knowledgeId);
                if (knowledge == null)
                {
                    throw new Exception("No existe el conocimiento");
                }
                knowledge.KnowledgeIsActive=false;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Error, no se pudo borrar el conocimiento" + ": " + ex.Message);
            }
        }
    }
}
