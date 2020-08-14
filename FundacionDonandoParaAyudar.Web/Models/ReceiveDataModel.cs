using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundacionDonandoParaAyudar.Web.Models
{
    public class ReceiveDataModel
    {

        public ReceiveDataModel(string UserName,
            string FirstName,
            string LastName)
        {
            this.UserName = UserName;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
