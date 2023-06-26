using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Entities;
using System.Linq;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly TPContext _context;
        public AdminRepository(TPContext context)
        {
            _context = context;
        }

        public void CreateCareer(Career newCareer)
        {
            try
            {
                _context.Careers.Add(newCareer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {


                throw new Exception("el error es" + ex);
            }
        }

        public List<Career> GetCareers()
        {
            return _context.Careers.ToList();
        }

        public void CreateKnowledge(Knowledge newKnowledge, Knowledge newKnowledge1, Knowledge newKnowledge2)
        {
            try
            {
                _context.Knowledges.Add(newKnowledge);
                _context.Knowledges.Add(newKnowledge1);
                _context.Knowledges.Add(newKnowledge2);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {


                throw new Exception("el error es" + ex);
            }
        }

        public void DeleteCareer(int id)
        {
            try
            {
                var career = _context.Careers.FirstOrDefault(x => x.CareerId == id);
                career.CareerIsActive = false;
                _context.SaveChanges();
              
            }
            catch
            {
                throw new Exception("Carrera no encontrada");
            }
        }
        public void DeleteKnowledge(int id)
        {
            try
            {
                var knowledge =_context.Knowledges.FirstOrDefault(x => x.KnowledgeId == id);
                knowledge.KnowledgeIsActive = false;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Conocimiento no encontrado");
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.UserId == id);

                if (user != null)
                {
                    user.UserIsActive = false;
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Usuario no encontrado");
                }
            }
            catch
            {
                throw new Exception("Error al eliminar el usuario");
            }
        }


        public void DeleteOffer(int id)
        {
            try
            {
                var offer = _context.Offers.FirstOrDefault(x => x.OfferId == id);
                var studentOffers = _context.StudentOffers.Where(x => x.OfferId == id).ToList();
                foreach (var studentOffer in studentOffers)
                {
                    studentOffer.StudentOfferIsActive = false;
                }
                offer.OfferIsActive = false;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Oferta no encontrado");
            }
        }

        public List<Company> CompanyPending()
        {
            return _context.Companies
                .Where(u => u.UserType == "Company" && u.CompanyPendingConfirmation == true)
                .ToList();
        }

        public void UpdateCompanyPending(int companyId)
        {
            Company company = _context.Companies.FirstOrDefault(c => c.UserId == companyId);
            if (company != null)
            {
                company.CompanyPendingConfirmation = false;
                _context.Update(company);
                _context.SaveChanges();
            }
        }

    }
}
