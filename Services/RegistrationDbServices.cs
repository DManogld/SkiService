using Microsoft.EntityFrameworkCore;
using SkiService.DTO;
using SkiService.Migrations;
using SkiService.Models;
using SkiService.RegistrationDTO;
using System.Data;

namespace SkiService.Services
{
    /// <summary>
    /// Registration Service für RegisrationController
    /// </summary>
    public class RegistrationDbServices : IRegistrationServices
    {
        private readonly RegistrationContext _dbcontext;

        /// <summary>
        /// Kontruktor für instanziierung von DB verbindung
        /// </summary>
        /// <param name="dbcontext"></param>
        public RegistrationDbServices(RegistrationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        /// <summary>
        ///GetAll Methode welche alle Registrationen zurückgibt
        /// </summary>
        /// <returns>Liste von ClientDTO</returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<ClientDTO> GetAll()
        {
            List<Client> client = new List<Client>();
            List<ClientDTO> result = new List<ClientDTO>();
           client =  _dbcontext.Clients.Include("Facility").Include("Priority").Include("Status").ToList();
            try
            {
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
                    Kommentar = e.Kommentar
                }));

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// GetById Methode welche Registration nach bestimmter id zurückgibt
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientDTO</returns>
        /// <exception cref="Exception"></exception>
        public ClientDTO? Get(int id)
        {
            Client c;
            c = _dbcontext.Clients.Include("Facility").Include("Priority").Include("Status").FirstOrDefault(p => p.ClientID == id);

            try
            {
                if (c == null)
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
                    Kommentar = c.Kommentar
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }


        /// <summary>
        /// Add Methode für hinzufügen von Eintrag in Registration
        /// </summary>
        /// <param name="registration"></param>
        /// <exception cref="Exception"></exception>
        public void Add(ClientDTO registration)
        {
            try
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
                    Kommentar = registration.Kommentar
                };

                _dbcontext.Add(c);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Update Methode für modifizieren von Eintrag in Registrationen
        /// </summary>
        /// <param name="registration"></param>
        /// <exception cref="Exception"></exception>
        public void Update(ClientDTO registration)
        {
            var cli = _dbcontext.Clients.Where(e => e.ClientID == registration.ClientID).FirstOrDefault();
            try
            {
                if (cli != null)
                {
                    cli.ClientID = registration.ClientID;
                    cli.Name = registration.Name;
                    cli.EMail = registration.EMail;
                    cli.Phone = registration.Phone;
                    cli.Priority = _dbcontext.Priorities.FirstOrDefault(e => e.PriorityName == registration.PriorityName);
                    cli.Facility = _dbcontext.Facilities.FirstOrDefault(e => e.FacilityName == registration.FacilityName);
                    cli.Status = _dbcontext.Status.FirstOrDefault(e => e.StatusName == registration.StatusName);
                    cli.Kommentar = registration.Kommentar;
                }
                _dbcontext.Entry(cli).State = EntityState.Modified;
                _dbcontext.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Delete Methode für löschen von Eintrag in Registration
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Exception"></exception>
        public void Delete(int id)
        {
            var client = _dbcontext.Clients.Find(id);
            try
            {
                if (client != null)
                {
                    _dbcontext.Clients.Remove(client);
                    _dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
