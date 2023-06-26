using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Entities;

namespace BackendBolsaDeTrabajoUTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeController : ControllerBase
    {
        private readonly IKnowledgeRepository _knowledgeRepository;

        public KnowledgeController(IKnowledgeRepository knowledgeRepository)
        {
            _knowledgeRepository = knowledgeRepository;
        }

        [Authorize]
        [HttpGet("knowledge/GetAllKnowledge")]
        public List<Knowledge> GetAllKnowledge()
        {
            var knowledge = _knowledgeRepository.GetAllKnowledge();

            return knowledge;
        }

        [Authorize]
        [HttpDelete("knowledge/deleteKnowledge/{knowldgeId}")]
        public IActionResult DeleteKnowledge(int knowledgeId)
        {
            try
            {
                _knowledgeRepository.DeleteKnowledge(knowledgeId);
                return Ok("Conocimiento borrado");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
