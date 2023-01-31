using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Misyon.Core.Common.Entities.Misyon;

namespace Misyon.Core.Common.Entities.Boa
{
    [Table("Parameter", Schema = "Cor")]
    public class Parameter:EntityBase 
    {

        public string ParamType { get; set; }

        public string ParamCode { get; set; }

        public string? ParamValue { get; set; }

        public string? ParamValue2 { get; set; }

        public string? ParamValue3 { get; set; }

        public string? ParamValue4 { get; set; }

        public string? ParamValue5 { get; set; }

        public string? ParamValue6 { get; set; }

        public string? ParamValue7 { get; set; }

        public string? ParamValue8 { get; set; }

        public string? ParamDescription { get; set; }
    }
}
