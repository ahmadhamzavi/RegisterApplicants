using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationProcess.Domain.Models
{
    public class BaseEntity<TPrimary>
    {
        public TPrimary Id { get; set; }
    }
}
