
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.DBContexts;


namespace BackendBolsaDeTrabajoUTN.Data.Repository
{
   public class CompanyRepository : ICompanyRepository
   {
        private readonly TPContext _context;
        public CompanyRepository(TPContext context)
        {
            _context = context;
        }


        public void CreateCompany(Company newCompany)
        {
            try
            {
                _context.Companies.Add(newCompany);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {


                throw new Exception("el error es" + ex);
            }
        }

        public void RemoveCompany(int id)
        {
            try
            {
                var company = _context.Companies.FirstOrDefault(s => s.UserId == id);
                company.UserIsActive = false;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Empresa no encontrada");
            }
        }

        public void CreateOffer(Offer newOffer)
        {
            try
            {
                _context.Offers.Add(newOffer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {


                throw new Exception("el error es" + ex);
            }
        }
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public List<Company> GetCompanies()
        {
            return _context.Companies.ToList();
        }

        public List<Student> GetStudentsInOffer(int offerId)
        {
            try
            {
                var studentsInOffer = _context.Offers.FirstOrDefault(o => o.OfferId == offerId && o.OfferIsActive == true).Students.ToList();
                List<Student> studentsToReturn = new List<Student>();
                foreach (var student in studentsInOffer)
                {
                    var studentOffer = _context.StudentOffers.First(so => so.StudentId == student.UserId && so.OfferId == offerId);
                    if (studentOffer != null)
                    {
                        studentsToReturn.Add(student);
                    }
                }
                return studentsToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CVFile GetStudentCv(int studentId)
        {
            CVFile cVFile = _context.CVFiles.FirstOrDefault(c => c.StudentId == studentId);
            return cVFile;
        }
    }
}