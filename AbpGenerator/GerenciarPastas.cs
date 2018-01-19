using System.IO;
using System.Windows.Forms;
using AbpGenerator.Properties;

namespace AbpGenerator
{
    public class GerenciarPastas
    {
        public static void CriaEntidade(string projectName, string nomeSolucao, string nome, string nomePlural, string sigla, string gravacaoBanco, string tipoDaChave, string interfacesComplementares, string tenant)
        {
            var pastaRaiz = Modelos.PastaRaizArquivos;

            var entityFolder = Modelos.NomePastaEntidade;

            var caminho = pastaRaiz + entityFolder;

            var caminhoEntidades = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoEntidades);

            var nomeDaEntidade = nome + ".cs";

            caminhoEntidades = Path.Combine(caminhoEntidades, nomeDaEntidade);

            var nameSpace = Modelos.Namespace(projectName, nomeSolucao, nomePlural);

            var entidadebase = Modelos.Entidade(nameSpace, nome, tipoDaChave, sigla, gravacaoBanco, interfacesComplementares, tenant);

            if (!File.Exists(caminhoEntidades))
                using (var file = File.Create(caminhoEntidades))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoEntidades, entidadebase);

            MessageBox.Show(Resources.ArquivoCriadoComSucesso_);
        }
    }
}
