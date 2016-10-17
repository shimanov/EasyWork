using System.Collections.Generic;
using WebApplication2.Domain.Entities;

namespace WebApplication.Service.Services.Base
{
    public interface IScriptServices
    {
        IEnumerable<Script> GetScripts();

        bool DeleteScript(int id);

        bool RestoreScript(int id);

        bool AddScript(Script script);

        bool EditScript(Script script);
    }
}
