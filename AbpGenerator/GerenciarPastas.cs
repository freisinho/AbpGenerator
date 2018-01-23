using System.Collections.Generic;
using System.IO;

namespace AbpGenerator
{
    public static class GerenciarPastas
    {
        public static void CriaEntidade(string projectNome, string nomeSolucao, string nome, string nomePlural,
            string sigla, string gravacaoBanco, string tipoDaChave, string interfacesComplementares, string tenant,
            List<CampoEntidade> listaDeCampos)
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

            var nameSpace = ModeloEntidade.Namespace(projectNome, nomeSolucao, nomePlural);

            var entidadebase = ModeloEntidade.Entidade(nameSpace, nome, tipoDaChave, sigla, gravacaoBanco,
                interfacesComplementares, tenant, listaDeCampos);

            if (!File.Exists(caminhoEntidades))
                using (var file = File.Create(caminhoEntidades))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoEntidades, entidadebase);
        }

        public static void CriaBuilder(string projectNome, string nomeSolucao, string nome, string nomePlural,
            string sigla, string gravacaoBanco, string tipoDaChave, string interfacesComplementares, string tenant,
            List<CampoEntidade> listaDeCampos)
        {
            nome = char.ToUpper(nome[0]) + nome.Substring(1);

            nomePlural = char.ToUpper(nomePlural[0]) + nomePlural.Substring(1);

            sigla = char.ToUpper(sigla[0]) + sigla.Substring(1);

            nomeSolucao = char.ToUpper(nomeSolucao[0]) + nomeSolucao.Substring(1);

            var pastaRaiz = Utils.PastaRaizArquivos;

            var entityFolder = ModeloBuilder.NomePastaBuilder;

            var caminho = pastaRaiz + entityFolder;

            var caminhoBuilders = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoBuilders);

            var nomeDaBuilder = nome + "Builder.cs";

            caminhoBuilders = Path.Combine(caminhoBuilders, nomeDaBuilder);

            var nameSpace = ModeloBuilder.Namespace(projectNome, nomeSolucao, nomePlural);

            var builderbase = ModeloBuilder.Builder(nameSpace, nome, tipoDaChave, sigla, gravacaoBanco,
                interfacesComplementares, tenant, listaDeCampos);

            if (!File.Exists(caminhoBuilders))
                using (var file = File.Create(caminhoBuilders))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoBuilders, builderbase);
        }

        private static void CriaManager(string projectNome, string nomeSolucao, string nome, string nomePlural,
            string tipoDaChave)
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

            var nameSpace = ModeloManager.Namespace(projectNome, nomeSolucao, nomePlural);

            var managerbase = ModeloManager.Manager(nameSpace, nome, tipoDaChave);

            if (!File.Exists(caminhoManagers))
                using (var file = File.Create(caminhoManagers))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoManagers, managerbase);
        }

        private static void CriaInterfaceManager(string projectNome, string nomeSolucao, string nome, string nomePlural,
            string tipoDaChave)
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

            var nameSpace = ModeloManager.Namespace(projectNome, nomeSolucao, nomePlural);

            var managerbase = ModeloManager.IManager(nameSpace, nome, tipoDaChave);

            if (!File.Exists(caminhoManagers))
                using (var file = File.Create(caminhoManagers))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoManagers, managerbase);
        }

        private static void CriaService(string projectNome, string nomeSolucao, string nome, string nomePlural,
            string tenant)
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

            var nameSpace = ModeloService.Namespace(projectNome, nomeSolucao, nomePlural);

            var servicebase = ModeloService.Service(nameSpace, nome, nomePlural, tenant);

            if (!File.Exists(caminhoServices))
                using (var file = File.Create(caminhoServices))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoServices, servicebase);
        }

        private static void CriaInterfaceService(string projectNome, string nomeSolucao, string nome, string nomePlural)
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

            var nameSpace = ModeloService.Namespace(projectNome, nomeSolucao, nomePlural);

            var servicebase = ModeloService.IService(nameSpace, nome);

            if (!File.Exists(caminhoServices))
                using (var file = File.Create(caminhoServices))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoServices, servicebase);
        }

        public static void CriaInterfaceImplementacaoManager(string projectNome, string nomeSolucao, string nome,
            string nomePlural, string tipoDaChave)
        {
            CriaInterfaceManager(projectNome, nomeSolucao, nome, nomePlural, tipoDaChave);
            CriaManager(projectNome, nomeSolucao, nome, nomePlural, tipoDaChave);
        }

        public static void CriaDtos(string projectNome, string nomeSolucao, string nomePlural, string nome,
            string tipoDaChave, List<CampoEntidade> listaDeCampos)
        {
            nomePlural = char.ToUpper(nomePlural[0]) + nomePlural.Substring(1);

            nome = char.ToUpper(nome[0]) + nome.Substring(1);

            nomeSolucao = char.ToUpper(nomeSolucao[0]) + nomeSolucao.Substring(1);

            var pastaRaiz = Utils.PastaRaizArquivos;

            var entityFolder = ModeloDtos.NomePastaDto;

            var caminho = pastaRaiz + entityFolder;

            var caminhoDtos = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoDtos);

            CriarInputDto(projectNome, nomeSolucao, nomePlural, listaDeCampos, caminhoDtos);

            CriarOutputDto(projectNome, nomeSolucao, nomePlural, caminhoDtos, tipoDaChave);

            ObterTodosOutputDto(projectNome, nomeSolucao, nomePlural, caminhoDtos);

            CriarItemOutputDto(projectNome, nomeSolucao, nomePlural, nome, tipoDaChave, listaDeCampos, caminhoDtos);

            CriarAtualizarInputDto(projectNome, nomeSolucao, nomePlural, listaDeCampos, caminhoDtos);

            CriarAtualizarOutputDto(projectNome, nomeSolucao, nomePlural, tipoDaChave, listaDeCampos, caminhoDtos);

            CriarObterPorIdOutputDto(projectNome, nomeSolucao, nomePlural, tipoDaChave, listaDeCampos, caminhoDtos);

            CriarObterPorIdInputDto(projectNome, nomeSolucao, nomePlural, tipoDaChave, caminhoDtos);

            CriarDeletarInputDto(projectNome, nomeSolucao, nomePlural, tipoDaChave, caminhoDtos);

            CriarDeletarOutputDto(projectNome, nomeSolucao, nomePlural, caminhoDtos);
        }

        private static void CriarAtualizarInputDto(string projectNome, string nomeSolucao, string nomePlural,
            IEnumerable<CampoEntidade> listaDeCampos, string caminhoDtos)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloDtos.AtualizarPastaNome;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloDtos.AtualizarInputNome + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectNome, nomeSolucao, nomePlural, ModeloDtos.AtualizarPastaNome);

            var dtobase = ModeloDtos.AtualizarInput(nameSpace, listaDeCampos);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);
        }

        private static void CriarAtualizarOutputDto(string projectNome, string nomeSolucao, string nomePlural,
            string tipoChave, IEnumerable<CampoEntidade> listaDeCampos, string caminhoDtos)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloDtos.AtualizarPastaNome;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloDtos.AtualizarOutputNome + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectNome, nomeSolucao, nomePlural, ModeloDtos.AtualizarPastaNome);

            var dtobase = ModeloDtos.AtualizarOutput(nameSpace, listaDeCampos, tipoChave);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);
        }

        private static void CriarItemOutputDto(string projectNome, string nomeSolucao, string nomePlural, string nome,
            string tipoChave, IEnumerable<CampoEntidade> listaDeCampos, string caminhoDtos)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloEntidade.NomePastaEntidade;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloDtos.ItemOutputNome + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectNome, nomeSolucao, nomePlural, ModeloEntidade.NomePastaEntidade);

            var dtobase = ModeloDtos.ItemOutput(nameSpace, listaDeCampos, nome, tipoChave);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);
        }

        private static void CriarInputDto(string projectNome, string nomeSolucao, string nomePlural,
            IEnumerable<CampoEntidade> listaDeCampos, string caminhoDtos)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloDtos.CriarPastaNome;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloDtos.CriarInputNome + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectNome, nomeSolucao, nomePlural, ModeloDtos.CriarPastaNome);

            var dtobase = ModeloDtos.CriarInput(nameSpace, listaDeCampos);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);
        }

        private static void CriarOutputDto(string projectNome, string nomeSolucao, string nomePlural, string caminhoDtos,
            string tipoChave)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloDtos.CriarPastaNome;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloDtos.CriarOutputNome + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectNome, nomeSolucao, nomePlural, ModeloDtos.CriarPastaNome);

            var dtobase = ModeloDtos.CriarOutput(nameSpace, tipoChave);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);
        }

        private static void ObterTodosOutputDto(string projectNome, string nomeSolucao, string nomePlural,
            string caminhoDtos)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloDtos.ObterPastaNome;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloDtos.ObterTodosOutputNome + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectNome, nomeSolucao, nomePlural, ModeloDtos.ObterPastaNome);

            var dtobase = ModeloDtos.ObterTodosOutput(nameSpace, nomePlural);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);
        }

        public static void CriaInterfaceImplementacaoService(string projectNome, string nomeSolucao, string nome,
            string nomePlural, string tenant)
        {
            CriaInterfaceService(projectNome, nomeSolucao, nome, nomePlural);
            CriaService(projectNome, nomeSolucao, nome, nomePlural, tenant);
        }

        private static void CriarObterPorIdOutputDto(string projectNome, string nomeSolucao, string nomePlural,
            string tipoChave, IEnumerable<CampoEntidade> listaDeCampos, string caminhoDtos)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloDtos.ObterPastaNome;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloDtos.ObterPorIdOutputNome + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectNome, nomeSolucao, nomePlural, ModeloDtos.ObterPastaNome);

            var dtobase = ModeloDtos.ObterPorIdOutput(nameSpace, listaDeCampos, tipoChave);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);
        }

        private static void CriarObterPorIdInputDto(string projectNome, string nomeSolucao, string nomePlural,
            string tipoChave, string caminhoDtos)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloDtos.ObterPastaNome;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloDtos.ObterPorIdInputNome + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectNome, nomeSolucao, nomePlural, ModeloDtos.ObterPastaNome);

            var dtobase = ModeloDtos.ObterPorIdInput(nameSpace, tipoChave);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);
        }

        private static void CriarDeletarInputDto(string projectNome, string nomeSolucao, string nomePlural,
            string tipoChave, string caminhoDtos)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloDtos.DeletarPastaNome;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloDtos.DeletarInputNome + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectNome, nomeSolucao, nomePlural, ModeloDtos.DeletarPastaNome);

            var dtobase = ModeloDtos.DeletarInput(nameSpace, tipoChave);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);
        }

        private static void CriarDeletarOutputDto(string projectNome, string nomeSolucao, string nomePlural,
            string caminhoDtos)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloDtos.DeletarPastaNome;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloDtos.DeletarOutputNome + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectNome, nomeSolucao, nomePlural, ModeloDtos.DeletarPastaNome);

            var dtobase = ModeloDtos.DeletarOutput(nameSpace);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);
        }

        public static void CriaTestes(string projectNome, string nomeSolucao, string nome, string nomePlural)
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

            var nameSpace = ModeloService.Namespace(projectNome, nomeSolucao, nomePlural);

            var servicebase = ModeloService.IService(nameSpace, nome);

            if (!File.Exists(caminhoServices))
                using (var file = File.Create(caminhoServices))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoServices, servicebase);
        }


    }
}