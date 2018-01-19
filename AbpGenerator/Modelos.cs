namespace WindowsFormsApplication1
{
    public abstract class Modelos
    {
        public static string NomePastaEntidade { get; } = @"Entidade";

        public static string PastaRaizArquivos { get; } = @"C:\Arquivos Gerados\";

        public static string ApenasLeitura { get; } = @"Tr";

        public static string LeituraEscrita { get; } = @"Tw";

        public static string TenantFacultativa { get; } = @"IMayHaveTenant";

        public static string TenantObrigatoria { get; } = @"IMustHaveTenant";

        public static string Entidade(string nameSpace, string nomeEntidade, string tipoChave, string sigla, string gravacaoBanco, string interfacesComplementares, string filtroTenant)
        {
            var entidadebase = @"
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
        using Abp.Domain.Entities;
        using Abp.Domain.Entities.Auditing;

        namespace " + nameSpace + @"
        {
            [Table(""" + MontaNomeTabelaBanco(sigla, gravacaoBanco, nomeEntidade) + @""")]
            public class " + nomeEntidade + @" : FullAuditedEntity<" + tipoChave + @">" + MontaInterfaces(interfacesComplementares) + MontaTenant(filtroTenant) + @"
            {
            }
        }";

            return entidadebase;
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

    }
}
