namespace AbpGenerator
{
    public abstract class ModeloTeste
    {
        public static string NomePastaTeste { get; } = @"Teste";
        public static string NomeTeste { get; } = @"AppServiceTests";

        public static string Teste(string nameSpace, string nomeEntidade, string nomePlural)
        {
            var stringTenant = "";

            var service = @"
        using System.Data.Entity;
        using System.Linq.Dynamic.Core;
        using System.Threading.Tasks;
        using Abp.AutoMapper;
        using Abp.Domain.Repositories;
        using Shouldly;
        using Xunit;
        using " + nameSpace.Replace(NomePastaTeste, "Dtos") + @".Criar;
        using " + nameSpace.Replace(NomePastaTeste, "Dtos") + @".Deletar;
        using " + nameSpace.Replace(NomePastaTeste, "Dtos") + @".Entidade;
        using " + nameSpace.Replace(NomePastaTeste, "Dtos") + @".Obter;
        using " + nameSpace.Replace(NomePastaTeste, "Dtos") + @".Atualizar;

        namespace " + nameSpace + @"
        {
            public class " + nomeEntidade + NomeTeste + @" : SolutionTestBase                            
            {
                private readonly I" + nomeEntidade + "Manager _" + nomeEntidade.ToLower() + @"Manager;

                public " + nomeEntidade + NomeTeste + @"(
                I" + nomeEntidade + "Manager " + nomeEntidade.ToLower() + @"Manager)
                {
                   _" + nomeEntidade.ToLower() + @"Manager = " + nomeEntidade.ToLower() + @"Manager;
                }

                /// <summary>
                /// Cria uma " + nomeEntidade.ToLower() + @"
                /// </summary>
                /// <param name=""input""> Dados para a criação da " + nomeEntidade.ToLower() + @" </param>
                /// <returns>
                /// Id da " + nomeEntidade.ToLower() + @" criada
                /// </returns>
                public async Task<CriarOutput> Criar(CriarInput input)
                {
                    var " + nomeEntidade.ToLower() + @" = input.MapTo<" + nomeEntidade + @">();
                    " + stringTenant + @"
                    var id = await _" + nomeEntidade.ToLower() + @"Manager.Criar(" + nomeEntidade.ToLower() + @");
                    return new CriarInput { Id = id };
                }

                /// <summary>
                /// Atualiza uma " + nomeEntidade.ToLower() + @"
                /// </summary>
                /// <param name=""input""> Dados para a atualizar da " + nomeEntidade.ToLower() + @" </param>
                /// <returns>
                /// " + nomeEntidade + @" atualizada
                /// </returns>
                public async Task<AtualizarOutput>" + @" Atualizar(AtualizarInput input)
                {
                    var " + nomeEntidade.ToLower() + @" = input.MapTo<" + nomeEntidade + @">();
                    " + stringTenant + @"
                    var " + nomeEntidade.ToLower() + @"Retornada = await _" + nomeEntidade.ToLower() +
                              @"Manager.Atualizar(" + nomeEntidade.ToLower() + @");

                    return " + nomeEntidade.ToLower() + @"Retornada.MapTo<AtualizarOutput>();
                }

                /// <summary>
                /// Obtem a " + nomeEntidade.ToLower() + @" pelo id
                /// </summary>
                /// <param name=""input""> Id da " + nomeEntidade.ToLower() + @" </param>
                /// <returns>
                /// Dados da " + nomeEntidade.ToLower() + @"
                /// </returns>
                public async Task<ObterPorIdOutput> ObterPorId(ObterPorIdInput input)
                {
                    var " + nomeEntidade.ToLower() + @" = await _" + nomeEntidade.ToLower() +
                              @"Manager.ObterPorId(input.Id);
                    return " + nomeEntidade.ToLower() + @".MapTo<ObterPorIdOutput>();
                }

                /// <summary>
                /// Deleta uma " + nomeEntidade.ToLower() + @"
                /// </summary>
                /// <param name=""input""> Id da " + nomeEntidade.ToLower() + @" </param>
                /// <returns>
                /// Dto vazio
                /// </returns>
                public async Task Deletar(DeletarInput input)
                {
                    await _" + nomeEntidade.ToLower() + @"Manager.Deletar(input.Id);
                    return new DeletarOutput();
                }

                /// <summary>
                /// Obter todos as " + nomeEntidade.ToLower() + @"s
                /// </summary>
                /// <returns>
                /// Lista de " + nomeEntidade.ToLower() + @"s
                /// </returns>
                public async Task<ObterTodosOutput> ObterTodos()
                {
                    var " + nomePlural.ToLower() + @" = await _" + nomeEntidade.ToLower() + @"Manager.ObterTodos();

                    return new ObterTodosOutput
                    {
                        " + nomePlural + @" = " + nomeEntidade.ToLower() + @".MapTo<List<ItemOutput>>()
                    };
                }
            }
        }";

            return service;
        }

        public static string Namespace(string projectNome, string nomeSolucao, string nomePlural)
        {
            var name = projectNome + "." + nomeSolucao + "." + nomePlural + "." + NomePastaTeste;
            return name;
        }
    }
}