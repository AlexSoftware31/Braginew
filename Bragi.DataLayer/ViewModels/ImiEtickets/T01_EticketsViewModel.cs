using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.ViewModels.Core;

namespace Bragi.DataLayer.ViewModels.ImiEtickets
{
    public class T01_EticketsViewModel : BaseViewModel
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

    }
}
