using System.Collections.Generic;
using System.Linq;

namespace AbpGenerator
{
    public abstract class ModeloTeste
    {
        public static string NomePastaTeste { get; } = @"Teste";
        public static string NomeTeste { get; } = @"AppServiceTests";

        public static string Teste(string nameSpace, string nome, string nomePlural, IEnumerable<CampoEntidade> listaDeCampos)
        {
            var campoEntidades = listaDeCampos as CampoEntidade[] ?? listaDeCampos.ToArray();
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
    public class " + nome + @"AppServiceTests : SolutionTestBase
    {
        private readonly I" + nome + @"AppService _servico" + nome + @";

        private readonly IRepository<" + nome + @", long> _repositorio" + nome + @";

        public " + nome + @"AppServiceTests()
        {
            _servico" + nome + @" = Resolve<I" + nome + @"AppService>();
        }

        [Fact]
        public async Task Deve_Criar_Uma_" + nome + @"()
        {
            var " + nome.ToLower() + @"Dto = new " + nome + @"Builder()
                                        .DataBuilder()
                                        .Build();

            var " + nome.ToLower() + @"Input = ObjectMapper.Map<CreateInput>(" + nome.ToLower() + @"Dto);

            await _servico" + nome + @".Criar(" + nome.ToLower() + @"Input);

            UsingDbContext(context =>
            {
            var " + nomePlural + @" = context." + nomePlural + @";
            var " + nome.ToLower() + " = " + nomePlural + @".FirstOrDefaultAsync().Result;

            " + nome.ToLower() + @"s.Count().ShouldBe(NumeroDe" + nome + @");
            " + nome.ToLower() + @".ShouldNotBeNull();" +
            MontaCamposTeste(campoEntidades, nome, "", nome + "Constants.") + @"
            });
        }

        [Fact]
        public async Task Deve_Obter_" + nome + @"_Por_Id()
        {
            var " + nome.ToLower() + @"Id = await new " + nome + @"Builder()
                                        .DataBuilder()
                                        .Build()
                                        .Persist(_repositorio" + nome + @");

            var " + nome.ToLower() + @"Output = await _servico" + nome + @"
                                        .ObterPorId(new ObterPorIdInput { Id = " + nome.ToLower() + @"Id });


            " + nome.ToLower() + @"Output.ShouldNotBeNull();" +
            MontaCamposTeste(campoEntidades, nome, "Output", nome + "Constants.").TrimEnd() + @"
        }

        [Fact]
        public async Task Deve_Remover_" + nome + @"()
        {
            var " + nome.ToLower() + @"Id = await new " + nome + @"Builder()
                                        .DataBuilder()
                                        .Build()
                                        .Persist(_repositorio" + nome + @");

            await _servico" + nome + @".Deletar(new DeletarInput { Id = " + nome.ToLower() + @"Id });

            UsingDbContext(context =>
           {
           var " + nome.ToLower() + @"Output = context." + nomePlural + @".FirstOrDefaultAsync(" + nome.ToLower() + @" => " + nome.ToLower() + @".Id == " + nome.ToLower() + @"Id && " + nome.ToLower() + @".IsDeleted).Result;

            " + nome.ToLower() + @"Output.ShouldNotBeNull();" +
            MontaCamposTeste(campoEntidades, nome, "Output", nome + "Constants.") + @"
           });
        }

        [Fact]
        public async Task Deve_Atualizar_" + nome + @"()
        {
            var " + nome.ToLower() + @"Id = await new " + nome + @"Builder()
                                        .DataBuilder()
                                        .Build()
                                        .Persist(_repositorio" + nome + @");

            var " + nome.ToLower() + @"Dto = new " + nome + @"Builder()
                                        .DataBuilder()
                                        .Build();

            " + nome.ToLower() + @"Dto.Id = " + nome.ToLower() + @"Id;

            " + MontaNomeAtualizacao(campoEntidades, nome, "Dto") + @"

            var " + nome.ToLower() + @"Input = ObjectMapper.Map<AtualizarInput>(" + nome.ToLower() + @"Dto);

            await _servico" + nome + @".Atualizar(" + nome.ToLower() + @"Input);

            UsingDbContext(context =>
            {
            var " + nomePlural + @" = context." + nomePlural + @";
            var " + nome.ToLower() + " = " + nomePlural + @".FirstOrDefaultAsync().Result;

            " + nome.ToLower() + @"s.Count().ShouldBe(NumeroDe" + nome + @");
            " + nome.ToLower() + @".ShouldNotBeNull();" +
            MontaCamposTeste(campoEntidades, nome, "", nome + "Constants." + "Novo") + @"
            });
        }

        [Fact]
        public async Task Deve_Obter_" + nomePlural + @"()
        {

            var idUm = await new " + nome + @"Builder()
                                         .DataBuilder()
                                         .Build()
                                         .Persist(_repositorio" + nome + @");

            var idDois = await new " + nome + @"Builder()
                                         .DataBuilder()
                                         .Build()
                                         .Persist(_repositorio" + nome + @");

            var " + nomePlural.ToLower() + @" = (await _servico" + nome + @".ObterTodos())." + nomePlural + @";

            " + nomePlural.ToLower() + @".ShouldNotBeNull();
            " + nomePlural.ToLower() + @".Count().ShouldBe(2);
            " + nomePlural.ToLower() + @"[0].Id.ShouldBe(1);
            " + nomePlural.ToLower() + @"[1].Id.ShouldBe(2);

            " + MontaCamposTeste(campoEntidades, nomePlural.ToLower(), "[0]", nome + "Constants.").TrimEnd() + @"
            " + MontaCamposTeste(campoEntidades, nomePlural.ToLower(), "[1]", nome + "Constants.").TrimEnd() + @"
        }
    }
}";

            return service;
        }

        private static string MontaCamposTeste(IEnumerable<CampoEntidade> listaDeCampos, string nome, string precedente, string finalNomeDoCampo)
        {
            var campos = listaDeCampos.Aggregate("\n            ",
                (current, campo) => current + RetornaDeclaracaoDoTipo(campo, nome, precedente, finalNomeDoCampo) + "\n            ");

            return campos;
        }

        private static string RetornaDeclaracaoDoTipo(CampoEntidade campo, string nome, string precedent, string finalNomeDoCampo)
        {

            switch (campo.Tipo)
            {
                case "string":
                    return nome.ToLower() + precedent + @"." + campo.Nome + @".ShouldBe(" + finalNomeDoCampo + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + ");";

                case "int":
                    return nome.ToLower() + precedent + @"." + campo.Nome + @".ShouldBe(" + finalNomeDoCampo + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + ");";

                case "long":
                    return nome.ToLower() + precedent + @"." + campo.Nome + @".ShouldBe(" + finalNomeDoCampo + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + ");";

                case "decimal":
                    return nome.ToLower() + precedent + @"." + campo.Nome + @".ShouldBe(" + finalNomeDoCampo + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + ");";

                case "DateTime":
                    return nome.ToLower() + precedent + @"." + campo.Nome + @".ShouldBe(" + finalNomeDoCampo + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + ");";

                default:
                    return nome.ToLower() + precedent + @"." + campo.Nome + @".ShouldBe(" + finalNomeDoCampo + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + ");";

            }
        }



        private static string MontaNomeAtualizacao(IEnumerable<CampoEntidade> listaDeCampos, string nome, string precedente)
        {
            var campos = listaDeCampos.Aggregate("\n            ",
                (current, campo) => current + RetornaAtualizacao(campo, nome, precedente) + "\n            ");

            return campos;
        }

        private static string RetornaAtualizacao(CampoEntidade campo, string nome, string precedent)
        {
            return nome.ToLower() + precedent + @"." + campo.Nome + " = " + nome + "Constants." + "Novo" + campo.Nome + @";";
        }

        public static string Namespace(string projectNome, string nomeSolucao, string nomePlural)
        {
            var name = projectNome + "." + nomeSolucao + "." + nomePlural + "." + NomePastaTeste;
            return name;
        }
    }
}