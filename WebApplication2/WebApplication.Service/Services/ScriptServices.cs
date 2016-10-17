using System.Collections.Generic;
using WebApplication2.DAL.Repositories.Base;
using WebApplication2.Domain.Entities;

namespace WebApplication.Service.Services
{
    public class ScriptServices : Base.IScriptServices
    {
        IEasyWorkRepository _easyWorkRepository = null;

        public IEnumerable<Script> GetScripts() =>
            _easyWorkRepository.GetScripts();

        public bool DeleteScript(int id) =>
            _easyWorkRepository.DeleteScript(id);


        public bool RestoreScript(int id) =>
            _easyWorkRepository.RestoreScript(id);


        public bool AddScript(Script script) =>
            _easyWorkRepository.AddScript(script);


        public bool EditScript(Script script) =>
            _easyWorkRepository.EditScript(script);

    }
}
