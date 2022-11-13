using Microsoft.EntityFrameworkCore;
using SkiService.DTO;
using SkiService.Migrations;
using SkiService.Models;
using SkiService.RegistrationDTO;

namespace SkiService.Services
{
    /// <summary>
    /// Priority Service für abrufen von Registrationen nach Priority
    /// </summary>
    public class PriorityDBServices : IPriorityServices
    {
        private readonly RegistrationContext _dbcontext;
        public List<Priority> Prio = new List<Priority>();

        /// <summary>
        /// Konstruktor für instanziierung von DBverbindung
        /// </summary>
        /// <param name="dbcontext"></param>
        public PriorityDBServices(RegistrationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        /// <summary>
        /// GetAll Methode welche Registrationen, gruppiert nach Priority zurückgibt
        /// </summary>
        /// <returns>Liste von PriorityDTO</returns>
        /// <exception cref="Exception"></exception>
        public List<PriotityDTO> GetAll()
        {
            Prio = _dbcontext.Priorities.Include("client").Include("client.Status").Include("client.Facility").ToList();
            List<PriotityDTO> result = new List<PriotityDTO>();

            try
            {
                foreach (var s in Prio)
                {
                    var prio = new PriotityDTO();
                    prio.PriorityID = s.PriorityID;
                    prio.PriorityName = s.PriorityName;

                    foreach (var r in s.client)
                    {
                        ClientDTO pdto = new ClientDTO();
                        pdto.ClientID = r.ClientID;
                        pdto.Name = r.Name;
                        pdto.EMail = r.EMail;
                        pdto.Phone = r.Phone;
                        pdto.CreateDate = r.CreateDate;
                        pdto.PickupDate = r.PickupDate;

                        pdto.PriorityName = r.Priority.PriorityName;
                        pdto.FacilityName = r.Facility.FacilityName;
                        pdto.StatusName = r.Status.StatusName;

                        prio.client.Add(pdto);
                    }
                    result.Add(prio);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// GetStatus Methode welche Registrationen, nach spezifischem Status ausgibt
        /// </summary>
        /// <param name="priority"></param>
        /// <returns>PriorityDTO</returns>
        /// <exception cref="Exception"></exception>
        public PriotityDTO GetPriority(string priority)
        {
            try
            {
                List<PriotityDTO> t = GetAll();
                PriotityDTO result = t.Find(p => p.PriorityName == priority);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
