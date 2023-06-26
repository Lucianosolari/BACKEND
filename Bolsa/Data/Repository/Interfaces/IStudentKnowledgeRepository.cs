using BackendBolsaDeTrabajoUTN.Entities;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces
{
    public interface IStudentKnowledgeRepository
    {
        public void AddStudentKnowledge(int knowledgeId, int studentId);
        public void DeleteStudentKnowledg(int knowledgeId, int studentId);
        public List<Knowledge> GetAllKnowledgeToStudent(int studentId);
    }
}
