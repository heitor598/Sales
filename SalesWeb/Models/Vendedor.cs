﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWeb.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<RegistroVenda> RegistrosVendas { get; set; } = new List<RegistroVenda>();

        public Vendedor()
        {
        }       
        public Vendedor(int id, string nome, string email, DateTime dataNascimento, string salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }
        public void AddRegistroVenda(RegistroVenda rv)
        {
            RegistrosVendas.Add(rv);
        }
        public void RemoveRegistroVenda(RegistroVenda rv)
        {
            RegistrosVendas.Remove(rv);
        }
        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return RegistrosVendas.Where(rv => rv.Data >= inicial && rv.Data <= final).Sum(rv => rv.Quantidade);
        }
    }
}
