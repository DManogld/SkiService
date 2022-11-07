using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiService.DTO;
using SkiService.Models;
using SkiService.RegistrationDTO;
using System.Data;
using System.Numerics;
using System.Xml.Linq;

namespace SkiService.Services
{
    public class RegistrationDbServices : IRegistrationServices
    {
        private readonly RegistrationContext _dbcontext;

        public RegistrationDbServices(RegistrationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            List<Client> client = new List<Client>();
            List<ClientDTO> result = new List<ClientDTO>();
           client =  _dbcontext.Clients.Include("Facility").Include("Priority").Include("Status").ToList();

           client.ForEach(e => result.Add(new ClientDTO()
            {
                ClientID = e.ClientID,
                Name = e.Name,
                EMail = e.EMail,
                Phone = e.Phone,
                CreateDate = e.CreateDate,
                PickupDate = e.PickupDate,
                FacilityName = e.Facility.FacilityName,
                PriorityName = e.Priority.PriorityName,
                StatusName = e.Status.StatusName,
            }));
            
            return result;
        }

        public ClientDTO? Get(int id)
        {
            Client c;
            c = _dbcontext.Clients.Include("Facility").Include("Priority").Include("Status").FirstOrDefault(p => p.ClientID == id);
            if(c == null)
                return null;

                return new ClientDTO
                {
                    ClientID = c.ClientID,
                    Name = c.Name,
                    EMail = c.EMail,
                    Phone = c.Phone,
                    CreateDate = c.CreateDate,
                    PickupDate = c.PickupDate,
                    FacilityName = c.Facility.FacilityName,
                    PriorityName = c.Priority.PriorityName,
                    StatusName = c.Status.StatusName,
                };           
        }

        public void Add(ClientDTO registration)
        {
            Client c = new Client()
            {
                ClientID = registration.ClientID,
                Name = registration.Name,
                EMail = registration.EMail,
                Phone = registration.Phone,
                Priority = _dbcontext.Priorities.FirstOrDefault(e => e.PriorityName == registration.PriorityName),
                Facility = _dbcontext.Facilities.FirstOrDefault(e => e.FacilityName == registration.FacilityName),
                Status = _dbcontext.Status.FirstOrDefault(e => e.StatusName == registration.StatusName),
            };

          _dbcontext.Add(c);
          _dbcontext.SaveChanges();
        }


        public void Update(ClientDTO registration)
        {
            var cli = _dbcontext.Clients.Where(e => e.ClientID == registration.ClientID).FirstOrDefault();


            if (cli != null)
            {
                cli.ClientID = registration.ClientID;
                cli.Name = registration.Name;
                cli.EMail = registration.EMail;
                cli.Phone = registration.Phone;
                cli.Priority = _dbcontext.Priorities.FirstOrDefault(e => e.PriorityName == registration.PriorityName);
                cli.Facility = _dbcontext.Facilities.FirstOrDefault(e => e.FacilityName == registration.FacilityName);
                cli.Status = _dbcontext.Status.FirstOrDefault(e => e.StatusName == registration.StatusName);
            }
            _dbcontext.Entry(cli).State = EntityState.Modified;
            _dbcontext.SaveChanges();
        }


        public void Delete(int id)
        {
            var client = _dbcontext.Clients.Find(id);
            if (client != null)
            {
                _dbcontext.Clients.Remove(client);
                _dbcontext.SaveChanges();
            }
        } 
    }
}
