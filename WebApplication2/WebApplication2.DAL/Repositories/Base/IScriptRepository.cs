using System;
using System.Collections.Generic;
using WebApplication2.Domain.Entities;

namespace WebApplication2.DAL.Repositories.Base
{
    public interface IScriptRepository
    {
        IEnumerable<Script> GetScripts();

        IEnumerable<Script> GetScripts(Func<Script, bool> func);

        Script GetScript(int id);

        Script GetScript(string script);

        bool AddScript(Script script);

        bool EditScript(Script script);

        bool DeleteScript(int id);

        bool RestoreScript(int id);
    }
}
