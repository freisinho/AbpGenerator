using System.IO;
using System.Windows.Forms;
using AbpGenerator.Properties;
using System.Collections.Generic;

namespace AbpGenerator
{
    public class GerenciarPastas
    {
        public static void CriaEntidade(string projectName, string nomeSolucao, string nome, string nomePlural, string sigla, string gravacaoBanco, string tipoDaChave, string interfacesComplementares, string tenant, List<CampoEntidade> listaDeCampos)
        {
            var pastaRaiz = Utils.PastaRaizArquivos;

            var entityFolder = ModeloEntidade.NomePastaEntidade;

            var caminho = pastaRaiz + entityFolder;

            var caminhoEntidades = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoEntidades);

            var nomeDaEntidade = nome + ".cs";

            caminhoEntidades = Path.Combine(caminhoEntidades, nomeDaEntidade);

            var nameSpace = ModeloEntidade.Namespace(projectName, nomeSolucao, nomePlural);

            var entidadebase = ModeloEntidade.Entidade(nameSpace, nome, tipoDaChave, sigla, gravacaoBanco, interfacesComplementares, tenant,listaDeCampos);

            if (!File.Exists(caminhoEntidades))
                using (var file = File.Create(caminhoEntidades))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoEntidades, entidadebase);

            MessageBox.Show(Resources.ArquivoCriadoComSucesso_);
        }

        public static void CriaManager(string projectName, string nomeSolucao, string nome, string nomePlural, string tipoDaChave)
        {
            nome = char.ToUpper(nome[0]) + nome.Substring(1);

            var pastaRaiz = Utils.PastaRaizArquivos;

            var entityFolder = ModeloManager.NomePastaManager;

            var caminho = pastaRaiz + entityFolder;

            var caminhoManagers = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoManagers);

            var nomeDaInterfaceManager = nome + ModeloManager.NomePastaManager+ ".cs";

            caminhoManagers = Path.Combine(caminhoManagers, nomeDaInterfaceManager);

            var nameSpace = ModeloManager.Namespace(projectName, nomeSolucao, nomePlural);

            var managerbase = ModeloManager.Manager(nameSpace, nome, tipoDaChave);

            if (!File.Exists(caminhoManagers))
                using (var file = File.Create(caminhoManagers))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoManagers, managerbase);

            MessageBox.Show(Resources.ArquivoCriadoComSucesso_);
        }
        public static void CriaInterfaceManager(string projectName, string nomeSolucao, string nome, string nomePlural, string tipoDaChave)
        {
            nome = char.ToUpper(nome[0]) + nome.Substring(1);

            var pastaRaiz = Utils.PastaRaizArquivos;

            var entityFolder = ModeloManager.NomePastaManager;

            var caminho = pastaRaiz + entityFolder;

            var caminhoManagers = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoManagers);

            var nomeDaInterfaceManager = "I" + nome + ModeloManager.NomePastaManager + ".cs";

            caminhoManagers = Path.Combine(caminhoManagers, nomeDaInterfaceManager);

            var nameSpace = ModeloManager.Namespace(projectName, nomeSolucao, nomePlural);

            var managerbase = ModeloManager.IManager(nameSpace, nome, tipoDaChave);

            if (!File.Exists(caminhoManagers))
                using (var file = File.Create(caminhoManagers))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoManagers, managerbase);
        }


        public static void CriaInterfaceImplementacaoManager(string projectName, string nomeSolucao, string nome, string nomePlural, string tipoDaChave)
        {
            CriaInterfaceManager(projectName, nomeSolucao, nome, nomePlural, tipoDaChave);
            CriaManager(projectName, nomeSolucao, nome, nomePlural, tipoDaChave);

            MessageBox.Show(Resources.ArquivoCriadoComSucesso_);
        }


    }
}
