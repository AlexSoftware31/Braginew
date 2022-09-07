using Bragi.DataLayer.Models.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bragi.DataLayer.Models.ImiEtickets
{
    [Table("T01_Etickets", Schema = "dbo")]
    public class T01_Etickets: BaseModel
    {

        public int ApplicationId { get; set; }

        public string Names { get; set; }

        public string LastNames { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }

        public string PassportNumber { get; set; }

        public bool IsUsed { get; set; }

        public string EntradaSalida { get; set; }

        public DateTime EmissionDate { get; set; }

        public T01_Etickets()
        {
            CreationDate = DateTime.Now;
        }

    }
}
