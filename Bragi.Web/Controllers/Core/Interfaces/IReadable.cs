using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bragi.Web.Controllers.Core.Interfaces
{
    public interface IReadable
    {
        Task<IActionResult> GetList();
        Task<IActionResult> GetById(int id);
    }
}