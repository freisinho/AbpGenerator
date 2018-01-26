namespace AbpGenerator
{
    public abstract class ModeloManager
    {
        public static string NomePastaManager { get; } = @"Manager";

        public static string IManager(string nameSpace, string nomeEntidade, string tipoChave, string nomeAplicacao)
        {
            var nameSpaceEntidade = nameSpace.Replace("Manager", "Entidade");


            var iManager =
@"using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;
using " + nameSpaceEntidade + @";

namespace " + nameSpace + @"
{
    public interface I" + nomeEntidade + NomePastaManager + @" : IDomainService
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

        public static string Manager(string nameSpace, string nomeEntidade, string tipoChave, string nomeAplicacao, bool isCore)
        {
            var nameSpaceEntidade = nameSpace.Replace("Manager", "Entidade");
            var manager =
@"using System.Collections.Generic;
"+ (!isCore ? @"using System.Data.Entity;" : "using Microsoft.EntityFrameworkCore;") + @"
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using " + nameSpaceEntidade + @";

namespace " + nameSpace + @"
{
    public class " + nomeEntidade + NomePastaManager + @" : I" + nomeEntidade + NomePastaManager + @"
    {
        private readonly IRepository<" + nomeEntidade + ", " + tipoChave + @"> _repositorio" + nomeEntidade +
                          @";
       
        public " + nomeEntidade + NomePastaManager + @"(
        IRepository<" + nomeEntidade + ", " + tipoChave + @"> repositorio" + nomeEntidade + @")
        {
            _repositorio" + nomeEntidade + @" = repositorio" + nomeEntidade + @";
        }

        public async Task <" + tipoChave + ">" + @" Criar(" + nomeEntidade + " " + nomeEntidade.ToLower() + @")
        {
            return await _repositorio" + nomeEntidade + @".InsertAndGetIdAsync(" + nomeEntidade.ToLower() + @");
        }

        public async Task<" + nomeEntidade + ">" + @" Atualizar(" + nomeEntidade + " " + nomeEntidade.ToLower() +
                          @")
        {
            var creationTime = await _repositorio" + nomeEntidade + @"
                .GetAll().Where(" + nomeEntidade.ToLower() + @"Item => " + nomeEntidade.ToLower() + @"Item.Id == " + nomeEntidade.ToLower() + @".Id)
                .AsNoTracking()
                .Select(entidade => entidade.CreationTime)
                .SingleAsync();

            " + nomeEntidade.ToLower() + @".CreationTime = creationTime;

            return await _repositorio" + nomeEntidade + @".UpdateAsync(" + nomeEntidade.ToLower() + @");
        }

        public async Task<" + nomeEntidade + ">" + @" ObterPorId(" + tipoChave + @" id )
        {
            return await _repositorio" + nomeEntidade + @".FirstOrDefaultAsync(id);
        }

        public async Task Deletar(" + tipoChave + @" id )
        {
            await _repositorio" + nomeEntidade + @".DeleteAsync(id);
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