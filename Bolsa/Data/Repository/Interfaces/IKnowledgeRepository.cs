using BackendBolsaDeTrabajoUTN.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces
{
    public interface IKnowledgeRepository
    {
        public List<Knowledge> GetAllKnowledge();
        public void DeleteKnowledge(int knowledgeId);
    }
}
