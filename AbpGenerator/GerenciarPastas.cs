using System.IO;
using System.Collections.Generic;

namespace AbpGenerator
{
    public static class GerenciarPastas
    {
        public static void CriaEntidade(string projectName, string nomeSolucao, string nome, string nomePlural, string sigla, string gravacaoBanco, string tipoDaChave, string interfacesComplementares, string tenant, List<CampoEntidade> listaDeCampos)
        {
            nome = char.ToUpper(nome[0]) + nome.Substring(1);

            nomePlural = char.ToUpper(nomePlural[0]) + nomePlural.Substring(1);

            sigla = char.ToUpper(sigla[0]) + sigla.Substring(1);

            nomeSolucao = char.ToUpper(nomeSolucao[0]) + nomeSolucao.Substring(1);

            var pastaRaiz = Utils.PastaRaizArquivos;

            var entityFolder = ModeloEntidade.NomePastaEntidade;

            var caminho = pastaRaiz + entityFolder;

            var caminhoEntidades = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoEntidades);

            var nomeDaEntidade = nome + ".cs";

            caminhoEntidades = Path.Combine(caminhoEntidades, nomeDaEntidade);

            var nameSpace = ModeloEntidade.Namespace(projectName, nomeSolucao, nomePlural);

            var entidadebase = ModeloEntidade.Entidade(nameSpace, nome, tipoDaChave, sigla, gravacaoBanco, interfacesComplementares, tenant, listaDeCampos);

            if (!File.Exists(caminhoEntidades))
                using (var file = File.Create(caminhoEntidades))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoEntidades, entidadebase);

        }

        private static void CriaManager(string projectName, string nomeSolucao, string nome, string nomePlural, string tipoDaChave)
        {
            nome = char.ToUpper(nome[0]) + nome.Substring(1);

            nomePlural = char.ToUpper(nomePlural[0]) + nomePlural.Substring(1);

            nomeSolucao = char.ToUpper(nomeSolucao[0]) + nomeSolucao.Substring(1);

            var pastaRaiz = Utils.PastaRaizArquivos;

            var entityFolder = ModeloManager.NomePastaManager;

            var caminho = pastaRaiz + entityFolder;

            var caminhoManagers = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoManagers);

            var nomeDaInterfaceManager = nome + ModeloManager.NomePastaManager + ".cs";

            caminhoManagers = Path.Combine(caminhoManagers, nomeDaInterfaceManager);

            var nameSpace = ModeloManager.Namespace(projectName, nomeSolucao, nomePlural);

            var managerbase = ModeloManager.Manager(nameSpace, nome, tipoDaChave);

            if (!File.Exists(caminhoManagers))
                using (var file = File.Create(caminhoManagers))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoManagers, managerbase);

        }

        private static void CriaInterfaceManager(string projectName, string nomeSolucao, string nome, string nomePlural, string tipoDaChave)
        {
            nome = char.ToUpper(nome[0]) + nome.Substring(1);

            nomePlural = char.ToUpper(nomePlural[0]) + nomePlural.Substring(1);

            nomeSolucao = char.ToUpper(nomeSolucao[0]) + nomeSolucao.Substring(1);

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

        private static void CriaService(string projectName, string nomeSolucao, string nome, string nomePlural, string tenant)
        {
            nome = char.ToUpper(nome[0]) + nome.Substring(1);

            nomePlural = char.ToUpper(nomePlural[0]) + nomePlural.Substring(1);

            nomeSolucao = char.ToUpper(nomeSolucao[0]) + nomeSolucao.Substring(1);

            var pastaRaiz = Utils.PastaRaizArquivos;

            var entityFolder = ModeloService.NomePastaService;

            var caminho = pastaRaiz + entityFolder;

            var caminhoServices = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoServices);

            var nomeDaInterfaceService = nome + ModeloService.NomeService + ".cs";

            caminhoServices = Path.Combine(caminhoServices, nomeDaInterfaceService);

            var nameSpace = ModeloService.Namespace(projectName, nomeSolucao, nomePlural);

            var servicebase = ModeloService.Service(nameSpace, nome, nomePlural, tenant);

            if (!File.Exists(caminhoServices))
                using (var file = File.Create(caminhoServices))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoServices, servicebase);

        }

        private static void CriaInterfaceService(string projectName, string nomeSolucao, string nome, string nomePlural)
        {
            nome = char.ToUpper(nome[0]) + nome.Substring(1);

            nomePlural = char.ToUpper(nomePlural[0]) + nomePlural.Substring(1);

            nomeSolucao = char.ToUpper(nomeSolucao[0]) + nomeSolucao.Substring(1);

            var pastaRaiz = Utils.PastaRaizArquivos;

            var entityFolder = ModeloService.NomePastaService;

            var caminho = pastaRaiz + entityFolder;

            var caminhoServices = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoServices);

            var nomeDaInterfaceService = "I" + nome + ModeloService.NomeService + ".cs";

            caminhoServices = Path.Combine(caminhoServices, nomeDaInterfaceService);

            var nameSpace = ModeloService.Namespace(projectName, nomeSolucao, nomePlural);

            var servicebase = ModeloService.IService(nameSpace, nome);

            if (!File.Exists(caminhoServices))
                using (var file = File.Create(caminhoServices))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoServices, servicebase);
        }

        public static void CriaInterfaceImplementacaoManager(string projectName, string nomeSolucao, string nome, string nomePlural, string tipoDaChave)
        {
            CriaInterfaceManager(projectName, nomeSolucao, nome, nomePlural, tipoDaChave);
            CriaManager(projectName, nomeSolucao, nome, nomePlural, tipoDaChave);

        }

        public static void CriaDtos(string projectName, string nomeSolucao, string nomePlural, string nome, string tipoDaChave, List<CampoEntidade> listaDeCampos)
        {
            nomePlural = char.ToUpper(nomePlural[0]) + nomePlural.Substring(1);

            nome = char.ToUpper(nome[0]) + nome.Substring(1);

            nomeSolucao = char.ToUpper(nomeSolucao[0]) + nomeSolucao.Substring(1);

            var pastaRaiz = Utils.PastaRaizArquivos;

            var entityFolder = ModeloDtos.NomePastaDto;

            var caminho = pastaRaiz + entityFolder;

            var caminhoDtos = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoDtos);

            CriarInputDto(projectName, nomeSolucao, nomePlural, listaDeCampos, caminhoDtos);
            CriarOutputDto(projectName, nomeSolucao, nomePlural, caminhoDtos, tipoDaChave);

            CriarEntidadeDto(projectName, nomeSolucao, nomePlural, nome, tipoDaChave, listaDeCampos, caminhoDtos);
        }

        private static void CriarEntidadeDto(string projectName, string nomeSolucao, string nomePlural, string nome, string tipoChave, IEnumerable<CampoEntidade> listaDeCampos, string caminhoDtos)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloEntidade.NomePastaEntidade;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = nome + "Dto.cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectName, nomeSolucao, nomePlural, ModeloEntidade.NomePastaEntidade);

            var dtobase = ModeloDtos.EntidadeDto(nameSpace, listaDeCampos, nome, tipoChave);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);

        }

        private static void CriarInputDto(string projectName, string nomeSolucao, string nomePlural, IEnumerable<CampoEntidade> listaDeCampos, string caminhoDtos)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloDtos.CriarPastaName;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloDtos.CriarInputName + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectName, nomeSolucao, nomePlural, ModeloDtos.CriarPastaName);

            var dtobase = ModeloDtos.CriarInput(nameSpace, listaDeCampos);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);

        }

        private static void CriarOutputDto(string projectName, string nomeSolucao, string nomePlural, string caminhoDtos, string tipoChave)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloDtos.CriarPastaName;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloDtos.CriarOutputName + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectName, nomeSolucao, nomePlural, ModeloDtos.CriarPastaName);

            var dtobase = ModeloDtos.CriarOutput(nameSpace, tipoChave);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);
        }

        public static void CriaInterfaceImplementacaoService(string projectName, string nomeSolucao, string nome, string nomePlural, string tipoDaChave, string tenant)
        {
            CriaInterfaceService(projectName, nomeSolucao, nome, nomePlural);
            CriaService(projectName, nomeSolucao, nome, nomePlural, tenant);
        }
    }
}
