using Microsoft.EntityFrameworkCore;
using SkiService.DTO;
using SkiService.Models;
using SkiService.RegistrationDTO;

namespace SkiService.Services
{
    /// <summary>
    /// Status Service für abrufen von Registrationen nach Status
    /// </summary>
    public class StatusDbServices : IStatusServices
    {
        private readonly RegistrationContext _dbcontext;
        public List<Status> Status = new List<Status>();

        /// <summary>
        /// Konstruktor für instanziierung von DB verbindung
        /// </summary>
        /// <param name="dbcontext"></param>
        public StatusDbServices(RegistrationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        /// <summary>
        /// GetAll Methode welche Registrationen, gruppiert nach Status zurückgibt
        /// </summary>
        /// <returns>Liste von StatusDTO</returns>
        /// <exception cref="Exception"></exception>
        public List<StatusDTO> GetAll()
        { 
            Status = _dbcontext.Status.Include("client").Include("client.Priority").Include("client.Facility").ToList();
            List<StatusDTO> result = new List<StatusDTO>();

            try
            {
                foreach (var s in Status)
                {
                    var status = new StatusDTO();
                    status.StatusID = s.StatusID;
                    status.StatusName = s.StatusName;

                    foreach (var r in s.client)
                    {
                        ClientDTO cdto = new ClientDTO();
                        cdto.ClientID = r.ClientID;
                        cdto.Name = r.Name;
                        cdto.EMail = r.EMail;
                        cdto.Phone = r.Phone;
                        cdto.CreateDate = r.CreateDate;
                        cdto.PickupDate = r.PickupDate;

                        cdto.PriorityName = r.Priority.PriorityName;
                        cdto.FacilityName = r.Facility.FacilityName;
                        cdto.StatusName = r.Status.StatusName;

                        status.client.Add(cdto);
                    }
                    result.Add(status);
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
        /// <param name="status"></param>
        /// <returns>StatusDTO</returns>
        /// <exception cref="Exception"></exception>
        public StatusDTO GetStatus(string status)
        {
            try
            {
                List<StatusDTO> t = GetAll();
                StatusDTO result = t.Find(p => p.StatusName == status);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
