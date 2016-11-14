using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DAL.Context;
using WebApplication2.Domain.Entities;

namespace WebApplication2.DAL.Repositories
{
    public class ScriptRepository : Base.IScriptRepository
    {
        private EasyWorkDBContext _context = null;

        public IEnumerable<Script> GetScripts()
        {
            return _context.Scripts.ToArray();
        }

        public IEnumerable<Script> GetScripts(Func<Script, bool> func)
        {
            return _context.Scripts.Where(func).ToArray();
        }

        public Script GetScript(int id)
        {
            return _context.Scripts.FirstOrDefault(x => x.Id == id);
        }

        public Script GetScript(string script)
        {
            return _context.Scripts
                .FirstOrDefault(x =>
                    x.Scripts.Trim().ToLower() == script.ToLower().Trim());
        }

        public bool AddScript(Script script)
        {
            try
            {
                _context.Scripts.Add(script);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool EditScript(Script script)
        {
            try
            {
                var old = GetScript(script.Id);
                if (old == null)
                    return false;
                old.IsDeleted = false;
                old.Scripts = script.Scripts;
                old.Description = script.Description;

                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteScript(int id)
        {
            try
            {
                var script = GetScript(id);
                if (script == null)
                    return false;

                script.IsDeleted = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RestoreScript(int id)
        {
            try
            {
                var script = GetScript(id);
                if (script == null)
                    return false;

                script.IsDeleted = false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
