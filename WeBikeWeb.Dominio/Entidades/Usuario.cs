﻿using System;
using System.Collections.Generic;

namespace WeBikeWeb.Dominio.Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Cidade { get; set; }

        public virtual string Email { get; set; }

        public virtual bool EmailConfirmed { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string SecurityStamp { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual bool PhoneNumberConfirmed { get; set; }

        public virtual bool TwoFactorEnabled { get; set; }

        public virtual DateTime? LockoutEndDateUtc { get; set; }

        public virtual bool LockoutEnabled { get; set; }

        public virtual int AccessFailedCount { get; set; }

        public virtual string UserName { get; set; }

        public virtual ICollection<Bicicleta> Bicicletas { get; set; }
    }
}
