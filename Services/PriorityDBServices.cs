using Microsoft.EntityFrameworkCore;
using SkiService.DTO;
using SkiService.Migrations;
using SkiService.Models;
using SkiService.RegistrationDTO;

namespace SkiService.Services
{
    public class PriorityDBServices : IPriorityServices
    {
        private readonly RegistrationContext _dbcontext;
        public List<Priority> Prio = new List<Priority>();

        public PriorityDBServices(RegistrationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


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
