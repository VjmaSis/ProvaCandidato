﻿using ProvaCandidato.Data.Entidade;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaCandidato.Data
{
  public class ContextoPrincipal : DbContext
  {
    private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["provacandidato"].ConnectionString;
    public ContextoPrincipal() : base(CONNECTION_STRING) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
  }
}
