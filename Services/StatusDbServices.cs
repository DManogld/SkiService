using Microsoft.EntityFrameworkCore;
using SkiService.DTO;
using SkiService.Models;
using SkiService.RegistrationDTO;

namespace SkiService.Services
{
    public class StatusDbServices : IStatusServices
    {
        private readonly RegistrationContext _dbcontext;
        public List<Status> Status = new List<Status>();

        public StatusDbServices(RegistrationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


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
