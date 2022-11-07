using SkiService.Models;
using SkiService.RegistrationDTO;

namespace SkiService.Services
{
    /// <summary>
    /// Wird verwendet um DI zu erstellen.
    /// </summary>
    public interface IRegistrationServices
    {
        IEnumerable<ClientDTO> GetAll();
        ClientDTO? Get(int id);
        void Add(ClientDTO registration);
        public void Delete(int id);
        public void Update(ClientDTO registration);
        //void Add(ClientDTO newCLient);
    }
}
