using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundacionDonandoParaAyudar.Web.Helpers
{
    public interface ISelectedHelper
    {
        Task<string> ResultUserName(string userName);
        Task<string> ResultFirstName(string firstName);
        Task<string> ResultLastName(string lastName);

    }
}
