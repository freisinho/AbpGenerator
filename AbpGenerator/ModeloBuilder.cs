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
            var campoEntidades = listaDeCampos as CampoEntidade[] ?? listaDeCampos.ToArray();
            var builderBase = @"
        using System;
        using System.Threading.Tasks;
        using Abp.AutoMapper;
        using Abp.Domain.Repositories;
        using " + nameSpace.Replace(NomePastaBuilder, "Dtos.Entidade") + @";
        using " + nameSpace.Replace(NomePastaBuilder, "Entidade") + @";

        namespace " + nameSpace + @"
        {
            public partial class " + nome + NomePastaBuilder + @"
            {
                public " + nome + NomePastaBuilder + @"()
                {
                     " + nome + @"Dto = new  " + nome + @"Dto();
                }

                public " + nome + @"Dto " + nome + @"Dto { get; set; };

                public class " + nome + NomePastaBuilder + @" DataBuilder(
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
                    var " + nome.ToLower() + @" = ObjectMapper.Map<" + nome + @">(" + nome.ToLower() + @"Dto);
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
        public static const NumeroDe" + char.ToUpper(nome[0]) + nome.Substring(1) + @" = 1;
        " + MontaCamposConstants(campoEntidades).TrimEnd() + @"

        " + MontaCamposConstantsUpdate(campoEntidades).TrimEnd() + @"
    }
    }";

            return builderBase.Replace(",)", ")");
        }
        public static string Namespace(string projectNome, string nomeSolucao, string nomePlural)
        {
            var name = projectNome + "." + nomeSolucao + "." + nomePlural + "." + NomePastaBuilder;
            return name;
        }

        private static string MontaDtoBuilder(IEnumerable<CampoEntidade> listaDeCampos, string nome)
        {
            var campos = listaDeCampos.Aggregate("",
                (current, campo) => current + RetornaAtribuicaoDto(campo, nome) + "\n                    ");

            return campos;
        }

        private static string RetornaAtribuicaoDto(CampoEntidade campo, string nome)
        {
            return nome + "Dto." + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = " +
                   char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + ";";
        }

        private static string MontaCamposDaBuilder(IEnumerable<CampoEntidade> listaDeCampos, string nome)
        {
            var campos = listaDeCampos.Aggregate("",
                (current, campo) => current + RetornaDeclaracaoDoTipo(campo, nome) + "\n                ");

            return campos;
        }

        private static string RetornaDeclaracaoDoTipo(CampoEntidade campo, string nome)
        {
            switch (campo.Tipo)
            {
                case "string":
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = " + nome + @"Constants." + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + " ,";
                case "int":
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = " + nome + @"Constants." + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + " ,";
                case "long":
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = " + nome + @"Constants." + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + " ,";
                case "decimal":
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = " + nome + @"Constants." + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + " ,";
                case "DateTime":
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = " + nome + @"Constants." + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + " ,";

                default:
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = 1 ,";
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
                    return "public static const " + campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = ""Str"";";

                case "int":
                    return "public static const " + campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 1;";

                case "long":
                    return "public static const " + campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 1,0;";

                case "decimal":
                    return "public static const " + campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 1,0;";

                case "DateTime":
                    return "public static const " + campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = DateTime.Now;";

                default:
                    return "public static const " + campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 1;";
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
                    return "public static const " + campo.Tipo + " Novo" + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = ""NovaStr"";";

                case "int":
                    return "public static const " + campo.Tipo + " Novo" + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 2;";

                case "long":
                    return "public static const " + campo.Tipo + " Novo" + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 2,0;";

                case "decimal":
                    return "public static const " + campo.Tipo + " Novo" + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 2,0;";

                case "DateTime":
                    return "public static const " + campo.Tipo + " Novo" + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = DateTime.Now.AddDays(1);";

                default:
                    return "public static const " + campo.Tipo + " Novo" + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1) + @" = 2;";
            }
        }

    }
}