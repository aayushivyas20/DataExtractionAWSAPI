using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractionDomain.Entities
{
    public class tblConfigParams
    {
        [Key]
        public int idConfigParam { get; set; }
        public int? configParamValType { get; set; }
        public DateTime? createdOn { get; set; }
        public string? configParamName { get; set; }
        public string configParamVal { get; set; }
        public int? isActive { get; set; }
        public string? configParamDisplayVal { get; set; }
        public int? moduleId { get; set; }
        public string? configDevDesc { get; set; }
    }
}
