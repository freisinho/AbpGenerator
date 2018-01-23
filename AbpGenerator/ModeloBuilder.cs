﻿using System.Collections.Generic;
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
            public class " + nome + NomePastaBuilder + @"
            {
                public " + nome + NomePastaBuilder + @"()
                {
                     " + nome + @"Dto = new  " + nome + @"Dto();
                }

                public " + nome + @"Dto " + nome + @"Dto { get; set; };

                public class " + nome + NomePastaBuilder + @" DataBuilder(
                " + MontaCamposDaBuilder(campoEntidades).TrimEnd() + @")
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

        private static string MontaCamposDaBuilder(IEnumerable<CampoEntidade> listaDeCampos)
        {
            var campos = listaDeCampos.Aggregate("",
                (current, campo) => current + RetornaDeclaracaoDoTipo(campo) + "\n                ");

            return campos;
        }

        private static string RetornaDeclaracaoDoTipo(CampoEntidade campo)
        {
            switch (campo.Tipo)
            {
                case "string":
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + @" = ""St"" ,";
                case "int":
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = 1 ,";
                case "long":
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = 1 ,";
                case "decimal":
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = 1 ,";
                case "DateTime":
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) +
                           " = DateTime.Now ,";
                default:
                    return campo.Tipo + " " + char.ToLower(campo.Nome[0]) + campo.Nome.Substring(1) + " = 1 ,";
            }
        }
    }
}