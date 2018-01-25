using System.Collections.Generic;
using System.Linq;

namespace AbpGenerator
{
    public abstract class ModeloEntidade
    {
        public static string NomePastaEntidade { get; } = @"Entidade";

        public static string Entidade(string nameSpace, string nomeEntidade, string tipoChave, string sigla,
            string gravacaoBanco, string interfacesComplementares, string filtroTenant,
            IEnumerable<CampoEntidade> listaDeCampos)
        {
            var entidadeBase =
@"using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace " + nameSpace + @"
{
    [Table(""" + MontaNomeTabelaBanco(sigla, gravacaoBanco, nomeEntidade) + @""")]
    public class " + nomeEntidade + @" : FullAuditedEntity<" + tipoChave + @">" +
                       MontaInterfaces(interfacesComplementares) + MontaTenant(filtroTenant) + @"
    {" +
                       MontaCamposDaEntidade(listaDeCampos, filtroTenant).TrimEnd() + @"
    }
}";

            return entidadeBase;
        }

        public static string Namespace(string projectNome, string nomeSolucao, string nomePlural)
        {
            var name = projectNome + "." + nomeSolucao + "." + nomePlural + "." + NomePastaEntidade;
            return name;
        }

        private static string MontaInterfaces(string interfacesComplementares)
        {
            if (interfacesComplementares != "")
                return "," + interfacesComplementares;

            return interfacesComplementares;
        }

        private static string MontaTenant(string tenant)
        {
            if (tenant != "")
                return "," + tenant;

            return tenant;
        }

        private static string MontaNomeTabelaBanco(string sigla, string gravacaoBanco, string nome)
        {
            var nomeTabela = sigla + gravacaoBanco + nome;

            return nomeTabela;
        }

        private static string MontaCamposDaEntidade(IEnumerable<CampoEntidade> listaDeCampos, string tenant)
        {
            var campos = listaDeCampos.Aggregate("\n        ",
                (current, campo) => current + RetornaDeclaracaoDoTipo(campo) + "\n        ");

            if (tenant == "IMustHaveTenant")
                campos = campos + Utils.DeclaracaoCampo.Replace("insereAqui", "int TenantId") + "\n        ";

            if (tenant == "IMayHaveTenant")
                campos = campos + Utils.DeclaracaoCampo.Replace("insereAqui", "int? TenantId") + "\n        ";

            return campos;
        }

        private static string RetornaDeclaracaoDoTipo(CampoEntidade campo)
        {
            var nomeTipo = campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1);

            return Utils.DeclaracaoCampo.Replace("insereAqui", nomeTipo);
        }
    }
}