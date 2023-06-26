using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Implementations
{
    public class StudentKnowledgeRepository : IStudentKnowledgeRepository
    {
        private readonly TPContext _context;
        public StudentKnowledgeRepository(TPContext context)
        {
            _context = context;
        }

        public void AddStudentKnowledge (int knowledgeId, int studentId)
        {
            try
            {
                var knowledge = _context.Knowledges.FirstOrDefault(k => k.KnowledgeId == knowledgeId);
                var student = _context.Users.FirstOrDefault(s => s.UserId == studentId);
                if (knowledge == null || student == null)
                {
                    throw new Exception("No existe el conocimiento o el estudiante");
                }

                var isAssociated = _context.StudentKnowledge.Any(sk => sk.UserId == studentId && sk.KnowledgeId == knowledgeId && sk.StudentKnowledgeIsActive == true);
                if (isAssociated)
                {
                    throw new Exception("El estudiante ya está asociado a este conocimiento");
                }
                var studentKnowledgeExists = _context.StudentKnowledge.FirstOrDefault(sk => sk.UserId == studentId && sk.KnowledgeId == knowledgeId);
                try
                {
                    if (studentKnowledgeExists == null)
                    {
                        var studentKnowledge = new StudentKnowledge
                        {
                            KnowledgeId = knowledgeId,
                            UserId = studentId,
                            StudentKnowledgeIsActive = true
                        };
                        _context.StudentKnowledge.Add(studentKnowledge);
                    }
                    else
                    {
                        _context.StudentKnowledge.First(sk => sk.UserId == studentId && sk.KnowledgeId == knowledgeId).StudentKnowledgeIsActive = true;
                    }
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        throw new Exception(ex.InnerException.Message);
                    }
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteStudentKnowledg(int knowledgeId,  int studentId)
        {
            _context.StudentKnowledge.First(sk => sk.UserId == studentId && sk.KnowledgeId == knowledgeId).StudentKnowledgeIsActive = false;
            _context.SaveChanges();
        }

        public List<Knowledge> GetAllKnowledgeToStudent(int studentId)
        {
            try
            {
                return _context.StudentKnowledge
                    .Where(sk => sk.UserId == studentId  && sk.StudentKnowledgeIsActive == true)
                    .Select(sk => sk.Knowledge)
                    .ToList();
            }
            catch
            {
                throw new Exception("No se encontraron conocimientos");
            }
        }


    }
}