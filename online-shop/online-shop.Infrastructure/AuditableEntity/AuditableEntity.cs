﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Infrastructure.AuditableEntity
{
    public class AuditableEntity
    {
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
