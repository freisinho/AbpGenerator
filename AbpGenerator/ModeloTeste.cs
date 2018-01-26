using System.Collections.Generic;
using System.Linq;

namespace AbpGenerator
{
    public abstract class ModeloTeste
    {
        public static string NomePastaTeste { get; } = @"Teste";
        public static string NomeTeste { get; } = @"AppServiceTests";

        public static string Teste(string nameSpace, string nome, string nomePlural, IEnumerable<CampoEntidade> listaDeCampos, string nomeSolucao, bool isCore)
        {
            var testBase = !isCore ? "Solution" : nomeSolucao;

            var namespaceDtos = nameSpace.Replace(".Tests", "");
            namespaceDtos = namespaceDtos.Replace(NomePastaTeste, "Dtos");


            var campoEntidades = listaDeCampos as CampoEntidade[] ?? listaDeCampos.ToArray();
            var service =
(!isCore ? @"using System.Data.Entity; " : "using Microsoft.EntityFrameworkCore; ") + @"
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Shouldly;
using Xunit;
using " + namespaceDtos.Replace(".Dtos", "") + @".Application;
using " + namespaceDtos + @".Criar;
using " + namespaceDtos + @".Atualizar;
using " + namespaceDtos + @".Deletar;
using " + namespaceDtos + @".Obter;
using " + namespaceDtos.Replace(".Dtos", "") + @".Entidade;
using " + nameSpace.Replace(NomePastaTeste, "Builder") + @";
using " + nameSpace.Replace(NomePastaTeste, "Utils") + @";
using " + nomeSolucao + @".Tests;

namespace " + nameSpace + @"
{
    public class " + nome + @"AppServiceTests : " + testBase + @"TestBase
    {
        private readonly I" + nome + @"AppService _servico" + nome + @";

        private readonly IRepository<" + nome + @", long> _repositorio" + nome + @";

        public " + nome + @"AppServiceTests()
        {
            _servico" + nome + @" = Resolve<I" + nome + @"AppService>();
            _repositorio" + nome + @" = Resolve<IRepository<" + nome + @", long>>();

        }

        [Fact]
        public async Task Deve_Criar_Uma_" + nome + @"()
        {
            var " + nome.ToLower() + @"Dto = new " + nome + @"Builder()
                                        .DataBuilder()
                                        .Build();

            var " + nome.ToLower() + @"Input = " + nome.ToLower() + @"Dto.MapTo<CriarInput>();

            await _servico" + nome + @".Criar(" + nome.ToLower() + @"Input);

            UsingDbContext(context =>
            {
                var " + nomePlural.ToLower() + @" = context." + nomePlural + @";
                var " + nome.ToLower() + " = " + nomePlural.ToLower() + @".FirstOrDefaultAsync().Result;

                " + nomePlural.ToLower() + @".Count().ShouldBe(" + nome + "Constants.NumeroDe" + nome + @");
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
            var " + nome.ToLower() + @"Input = " + nome.ToLower() + @"Dto.MapTo<AtualizarInput>();

            await _servico" + nome + @".Atualizar(" + nome.ToLower() + @"Input);

            UsingDbContext(context =>
            {
                var " + nomePlural.ToLower() + @" = context." + nomePlural + @";
                var " + nome.ToLower() + " = " + nomePlural.ToLower() + @".FirstOrDefaultAsync().Result;

                " + nomePlural.ToLower() + @".Count().ShouldBe(" + nome + "Constants.NumeroDe" + nome + @");
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
            " + nomePlural.ToLower() + @".Count.ShouldBe(2);
            " + nomePlural.ToLower() + @"[0].Id.ShouldBe(idUm);
            " + nomePlural.ToLower() + @"[1].Id.ShouldBe(idDois);

            " + MontaCamposTeste(campoEntidades, nomePlural.ToLower(), "[0]", nome + "Constants.").TrimEnd() + @"
            " + MontaCamposTeste(campoEntidades, nomePlural.ToLower(), "[1]", nome + "Constants.").TrimEnd() + @"
        }
    }
}";

            return service;
        }

        private static string MontaCamposTeste(IEnumerable<CampoEntidade> listaDeCampos, string nome, string precedente, string finalNomeDoCampo)
        {
            var campos = listaDeCampos.Aggregate("\n                ",
                (current, campo) => current + RetornaDeclaracaoDoTipo(campo, nome, precedente, finalNomeDoCampo) + "\n                ");

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
            var campos = listaDeCampos.Aggregate("\n                ",
                (current, campo) => current + RetornaAtualizacao(campo, nome, precedente) + "\n                ");

            return campos;
        }

        private static string RetornaAtualizacao(CampoEntidade campo, string nome, string precedent)
        {
            return nome.ToLower() + precedent + @"." + campo.Nome + " = " + nome + "Constants." + "Novo" + campo.Nome + @";";
        }

        public static string Namespace(string projectNome, string nomeSolucao, string nomePlural)
        {
            var name = projectNome + "." + nomeSolucao + ".Tests." + nomePlural + "." + NomePastaTeste;
            return name;
        }
    }
}