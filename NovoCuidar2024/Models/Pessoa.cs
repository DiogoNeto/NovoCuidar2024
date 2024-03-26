﻿using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Nif { get; set; }
        [Required]
        public int CC { get; set; }
        [Required]
        public int SNS { get; set; }
        [Required]
        public required string NomePrincipal { get; set; }
        [Required]
        public required string NomeApelido { get; set; }
        [Required]
        public DateOnly DataNascimento { get; set; }
        [Required]
        public required string Nacionalidade { get; set; }
        [Required]
        public char Genero { get; set; }
        [Required]
        public required string Telefone { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Morada1 { get; set; }
        [Required]
        public required string CodPostal1 { get; set; }
        [Required]
        public required string Localidade1 { get; set; }
        [Required]
        public required string Concelho1 { get; set; }
        public required string Morada2 { get; set; }
        public required string Concelho2 { get; set; }
        public required string Localidade2 { get; set; }
        public required string CodPostal2 { get; set; }
        [Required]
        public required string EstadoCivil { get; set; }
    }
}
