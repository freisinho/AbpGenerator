using System.Collections.Generic;

namespace AbpGenerator
{
    public abstract class ModeloEntidade
    {
        public static string NomePastaEntidade { get; } = @"Entidade";

        public static string Entidade(string nameSpace, string nomeEntidade, string tipoChave, string sigla, string gravacaoBanco, string interfacesComplementares, string filtroTenant, List<CampoEntidade> listaDeCampos)
        {
            var entidadeBase = @"
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
        using Abp.Domain.Entities;
        using Abp.Domain.Entities.Auditing;

        namespace " + nameSpace + @"
        {
            [Table(""" + MontaNomeTabelaBanco(sigla, gravacaoBanco, nomeEntidade) + @""")]
            public class " + nomeEntidade + @" : FullAuditedEntity<" + tipoChave + @">" + MontaInterfaces(interfacesComplementares) + MontaTenant(filtroTenant) + @"
            {" +
            MontaCamposDaEntidade(listaDeCampos).TrimEnd()+@"
            }
        }";

            return entidadeBase;
        }

        public static string Namespace(string projectName, string nomeSolucao, string nomePlural)
        {
            var name = projectName + "." + nomeSolucao + "." + nomePlural + "." + NomePastaEntidade;
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

        private static string MontaCamposDaEntidade(List<CampoEntidade> listaDeCampos)
        {
            var campos = "\n              ";

            foreach (var campo in listaDeCampos)
            {

                campos = campos + RetornaDeclaracaoDoTipo(campo) + "\n              ";
            }

            return campos;
        }
        private static string RetornaDeclaracaoDoTipo(CampoEntidade campo)
        {

            var nomeTipo = campo.Tipo + " " + campo.Nome;

            return Utils.DeclaracaoCampo.Replace("insereAqui", nomeTipo);

        }


    }
}
