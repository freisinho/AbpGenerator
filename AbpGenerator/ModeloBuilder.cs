using System.Collections.Generic;
using System.Linq;

namespace AbpGenerator
{
    public abstract class ModeloBuilder
    {
        public static string NomePastaBuilder { get; } = @"Builder";

        public static string Builder(string nameSpace, string nome, string tipoChave, string sigla, string gravacaoBanco,
            string interfacesComplementares, string filtroTenant, IEnumerable<CampoEntidade> listaDeCampos)
        {
            var namespaceEntidadeDto = @"using " + nameSpace.Replace(NomePastaBuilder, "Dtos.Entidade");
            namespaceEntidadeDto = namespaceEntidadeDto.Replace("Tests.", "");

            var namespaceEntidade = @"using " + nameSpace.Replace(NomePastaBuilder, "Entidade");
            namespaceEntidade = namespaceEntidade.Replace("Tests.", "");

            var campoEntidades = listaDeCampos as CampoEntidade[] ?? listaDeCampos.ToArray();
            var builderBase = @"
using System;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
" + namespaceEntidadeDto + @";
" + namespaceEntidade + @";

namespace " + nameSpace + @"
{
    public class " + nome + NomePastaBuilder + @"
    {
        public " + nome + NomePastaBuilder + @"()
        {
             " + nome + @"Dto = new  " + nome + @"Dto();
        }

        public " + nome + @"Dto " + nome + @"Dto { get; set; }

        public " + nome + NomePastaBuilder + @" DataBuilder(
        " + MontaCamposDaBuilder(campoEntidades, nome).TrimEnd() + @")
        {
            " + MontaDtoBuilder(campoEntidades, nome) + @"
            return this;
        }

        public " + nome + @"Dto Build()
        {
            return " + nome + @"Dto;
        }
    }

    public static class " + nome + @"Persist
    {
        public static async Task<" + tipoChave + @"> Persist (this " + nome + @"Dto " + nome.ToLower() +
                      @"Dto, IRepository< " + nome + @"," + tipoChave + @"> repository)
        {
            var " + nome.ToLower() + " = " + nome.ToLower() + @"Dto.MapTo<" + nome + @">();
            var " + nome.ToLower() + @"Id = await repository.InsertAndGetIdAsync(" + nome.ToLower() + @");

            return " + nome.ToLower() + @"Id;
        }
    }
}";

            return builderBase.Replace(",)", ")");
        }


        public static string BuilderConst(string nameSpace, string nome, string tipoChave, string sigla, string gravacaoBanco,
           string interfacesComplementares, string filtroTenant, IEnumerable<CampoEntidade> listaDeCampos)
        {
            var campoEntidades = listaDeCampos as CampoEntidade[] ?? listaDeCampos.ToArray();
            var builderBase = @"
using System;

namespace " + nameSpace + @"
{
    public class " + nome + @"Constants
    {
        public static int NumeroDe" + char.ToUpper(nome[0]) + nome.Substring(1) + @" = 1;
        " + MontaCamposConstants(campoEntidades).TrimEnd() + @"

        " + MontaCamposConstantsUpdate(campoEntidades).TrimEnd() + @"
    }
}";

            return builderBase.Replace(",)", ")");
        }
        public static string Namespace(string projectNome, string nomeSolucao, string nomePlural)
        {
            var name = projectNome + "." + nomeSolucao + ".Tests." + nomePlural + "." + NomePastaBuilder;
            return name;
        }

        private static string MontaDtoBuilder(IEnumerable<CampoEntidade> listaDeCampos, string nome)
        {
            var campos = listaDeCampos.Aggregate("",
                (current, campo) => current + RetornaAtribuicaoDto(campo, nome) + "\n            ");

            return campos;
        }

        private static string RetornaAtribuicaoDto(CampoEntidade campo, string nome)
        {
            return nome + "Dto." + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " ?? " + char.ToUpper(nome[0]) + nome.Substring(1) + "Constants." +
                   char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + ";";
        }

        private static string MontaCamposDaBuilder(IEnumerable<CampoEntidade> listaDeCampos, string nome)
        {
            var campos = listaDeCampos.Aggregate("",
                (current, campo) => current + RetornaDeclaracaoDoTipo(campo, nome) + "\n            ");

            return campos;
        }

        private static string RetornaDeclaracaoDoTipo(CampoEntidade campo, string nome)
        {
            switch (campo.Tipo)
            {
                case "string":
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = null,";
                case "int":
                    return campo.Tipo + "? " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = null,";
                case "long":
                    return campo.Tipo + "? " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = null,";
                case "decimal":
                    return campo.Tipo + "? " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = null,";
                case "DateTime":
                    return campo.Tipo + "? " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = null,";

                default:
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = null,";

            }
        }

        private static string MontaCamposConstants(IEnumerable<CampoEntidade> listaDeCampos)
        {
            var campos = listaDeCampos.Aggregate("",
                (current, campo) => current + RetornaConstantsCampoEntidade(campo) + "\n        ");

            return campos;
        }

        private static string RetornaConstantsCampoEntidade(CampoEntidade campo)
        {

            switch (campo.Tipo)
            {
                case "string":
                    return "public static " + campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = ""Str"";";

                case "int":
                    return "public static " + campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 1;";

                case "long":
                    return "public static " + campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 4294967296L;";

                case "decimal":
                    return "public static " + campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 1.5m;";

                case "DateTime":
                    return "public static " + campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = DateTime.Now;";

                default:
                    return "public static " + campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 1;";
            }
        }

        private static string MontaCamposConstantsUpdate(IEnumerable<CampoEntidade> listaDeCampos)
        {
            var campos = listaDeCampos.Aggregate("",
                (current, campo) => current + RetornaConstantsCampoEntidadeUpdate(campo) + "\n        ");

            return campos;
        }

        private static string RetornaConstantsCampoEntidadeUpdate(CampoEntidade campo)
        {

            switch (campo.Tipo)
            {
                case "string":
                    return "public static " + campo.Tipo + " Novo" + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = ""StrNovo"";";

                case "int":
                    return "public static " + campo.Tipo + " Novo" + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 2;";

                case "long":
                    return "public static " + campo.Tipo + " Novo" + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 4294967297L;";

                case "decimal":
                    return "public static " + campo.Tipo + " Novo" + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 2.5m;";

                case "DateTime":
                    return "public static " + campo.Tipo + " Novo" + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = DateTime.Now.AddDays(1);";

                default:
                    return "public static " + campo.Tipo + " Novo" + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 2;";
            }
        }

    }
}