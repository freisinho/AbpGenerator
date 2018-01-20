using System.Collections.Generic;

namespace AbpGenerator
{
    public abstract class ModeloManager
    {
        public static string NomePastaManager { get; } = @"Manager";

        public static string IManager(string nameSpace, string nomeEntidade, string tipoChave)
        {
            var iManager = @"
        using System;
        using System.Collections.Generic;
        using System.Threading.Tasks;
        using Abp.Domain.Services;

        namespace " + nameSpace + @"
        {
            public class I" + nomeEntidade + NomePastaManager + @" : IDomainService
            { 
                Task<" + tipoChave + ">" + @" Criar("+ nomeEntidade + " "+ nomeEntidade.ToLower()+ @");

                Task<" + nomeEntidade + ">" + @" Atualizar(" + nomeEntidade + " " + nomeEntidade.ToLower() + @");

                Task<" + nomeEntidade + ">" + @" ObterPorId(" + tipoChave + @" id );

                Task Deletar(" + tipoChave + @" id );

                Task<List<" +nomeEntidade + ">>" + @" ObterTodos();          
            }
        }";

            return iManager;
        }

        public static string Namespace(string projectName, string nomeSolucao, string nomePlural)
        {
            var name = projectName + "." + nomeSolucao + "." + nomePlural + "." + NomePastaManager;
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
