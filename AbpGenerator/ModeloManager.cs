using System.Collections.Generic;

namespace AbpGenerator
{
    public abstract class ModeloManager
    {
        public static string NomePastaManager { get; } = @"Manager";

        public static string IManager(string nameSpace, string nomeEntidade, string tipoChave)
        {
            var iManager = @"
        using System;
        using System.Collections.Generic;
        using System.Threading.Tasks;
        using Abp.Domain.Services;

        namespace " + nameSpace + @"
        {
            public class I" + nomeEntidade + NomePastaManager + @" : IDomainService
            { 
                Task<" + tipoChave + ">" + @" Criar(" + nomeEntidade + " " + nomeEntidade.ToLower() + @");

                Task<" + nomeEntidade + ">" + @" Atualizar(" + nomeEntidade + " " + nomeEntidade.ToLower() + @");

                Task<" + nomeEntidade + ">" + @" ObterPorId(" + tipoChave + @" id );

                Task Deletar(" + tipoChave + @" id );

                Task<List<" + nomeEntidade + ">>" + @" ObterTodos();          
            }
        }";

            return iManager;
        }

        public static string Manager(string nameSpace, string nomeEntidade, string tipoChave)
        {
            var manager = @"
        using System;
        using System.Collections.Generic;
        using System.Data.Entity;
        using System.Threading.Tasks;
        using Abp.Domain.Repositories;
        using System.Linq;
        using " + nameSpace.Replace("Manager", "Entidade") + @";

        namespace " + nameSpace + @"
        {
            public class " + nomeEntidade + NomePastaManager + @" : I" + nomeEntidade + NomePastaManager + @"
            { 
                private readonly IRepository<" + nomeEntidade + ", " + tipoChave + @"> _repositorio" + nomeEntidade + @";
               
                public " + nomeEntidade + NomePastaManager + @"(
                IRepository<" + nomeEntidade + ", " + tipoChave + @"> repositorio" + nomeEntidade + @")
                {
                    _repositorio" + nomeEntidade + @" = repositorio" + nomeEntidade + @";
                }

                public async Task <" + tipoChave + ">" + @" Criar(" + nomeEntidade + " " + nomeEntidade.ToLower() + @")
                {
                    return await _repositorio" + nomeEntidade + @".InsertAndGetIdAsync(" + nomeEntidade.ToLower() + @");
                }

                public async Task<" + nomeEntidade + ">" + @" Atualizar(" + nomeEntidade + " " + nomeEntidade.ToLower() + @")
                {
                    " + nomeEntidade.ToLower() + @".CreationTime = (await _repositorio" + nomeEntidade + @".FirstOrDefaultAsync(" + nomeEntidade.ToLower() + @".Id)).CreationTime;
                    return await _repositorio" + nomeEntidade + @".UpdateAsync(" + nomeEntidade.ToLower() + @");
                }

                public async Task<" + nomeEntidade + ">" + @" ObterPorId(" + tipoChave + @" id )
                {
                    return await _repositorio" + nomeEntidade + @".FirstOrDefaultAsync(id);
                }

                public async Task Deletar(" + tipoChave + @" id )
                {
                    return await _repositorio" + nomeEntidade + @".DeleteAsync(id);
                }

                public async Task<List<" + nomeEntidade + ">>" + @" ObterTodos()
                {
                    return await _repositorio" + nomeEntidade + @".GetAllListAsync();
                }          
            }
        }";

            return manager;
        }

        public static string Namespace(string projectNome, string nomeSolucao, string nomePlural)
        {
            var name = projectNome + "." + nomeSolucao + "." + nomePlural + "." + NomePastaManager;
            return name;
        }
    }
}
