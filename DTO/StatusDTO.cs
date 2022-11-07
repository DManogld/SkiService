﻿using SkiService.Models;
using SkiService.RegistrationDTO;
using System.ComponentModel.DataAnnotations;

namespace SkiService.DTO
{
    public class StatusDTO
    {
        [Key]
        public int StatusID { get; set; }
        public string? StatusName { get; set; }
        public List<ClientDTO> client { get; set; } = new List<ClientDTO>();
    }
}
