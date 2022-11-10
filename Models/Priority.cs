﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SkiService.Models
{
    public class Priority
    {
        [Key]      
        public int PriorityID { get; set; }    
        public string? PriorityName { get; set; }
        public List<Client> client { get; set; } = new List<Client>();
    }
}
