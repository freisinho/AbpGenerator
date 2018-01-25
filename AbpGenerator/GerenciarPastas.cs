using System.Collections.Generic;
using System.IO;

namespace AbpGenerator
{
    public static class GerenciarPastas
    {
        public static void AbpGenerator(string projectNome, string nomeSolucao, string nome, string nomePlural,
     string sigla, string gravacaoBanco, string tipoDaChave, string interfacesComplementares, string tenant,
     List<CampoEntidade> listaDeCampos)
        {
            nome = char.ToUpper(nome[0]) + nome.Substring(1);

            nomePlural = char.ToUpper(nomePlural[0]) + nomePlural.Substring(1);

            sigla = char.ToUpper(sigla[0]) + sigla.Substring(1);

            nomeSolucao = char.ToUpper(nomeSolucao[0]) + nomeSolucao.Substring(1);

            var pastaRaiz = Utils.PastaRaizArquivos;

            var pastaCamada = pastaRaiz + nomePlural;

            var caminho = Path.Combine(pastaRaiz, pastaCamada);

            Directory.CreateDirectory(caminho);

            CriaCamadaManager(projectNome, nomeSolucao, nome, nomePlural, sigla, gravacaoBanco, tipoDaChave, interfacesComplementares, tenant, listaDeCampos, caminho);

            CriaCamadaApplication(projectNome, nomeSolucao, nome, nomePlural, tenant, caminho, tipoDaChave, listaDeCampos);

            CriaTeste(projectNome, nomeSolucao, nome, nomePlural, sigla, gravacaoBanco, tipoDaChave, interfacesComplementares, tenant, listaDeCampos, caminho);
        }

        private static void CriaCamadaManager(string projectNome, string nomeSolucao, string nome, string nomePlural,
          string sigla, string gravacaoBanco, string tipoDaChave, string interfacesComplementares, string tenant,
          List<CampoEntidade> listaDeCampos, string pastaRaiz)
        {

            var pasta = pastaRaiz + @"\" + ModeloManager.NomePastaManager;

            var caminho = Path.Combine(pastaRaiz, pasta);

            Directory.CreateDirectory(caminho);


            CriaEntidade(projectNome, nomeSolucao, nome, nomePlural, sigla, gravacaoBanco, tipoDaChave, interfacesComplementares, tenant, listaDeCampos, caminho);
            CriaManager(projectNome, nomeSolucao, nome, nomePlural, tipoDaChave, caminho);
            CriaInterfaceManager(projectNome, nomeSolucao, nome, nomePlural, tipoDaChave, caminho);
        }

        private static void CriaCamadaApplication(string projectNome, string nomeSolucao, string nome, string nomePlural, string tenant, string pastaRaiz, string tipoDaChave, List<CampoEntidade> listaDeCampos)
        {
            var pasta = pastaRaiz + @"\" + ModeloService.NomePastaService;

            var caminho = Path.Combine(pastaRaiz, pasta);

            Directory.CreateDirectory(caminho);

            CriaService(projectNome, nomeSolucao, nome, nomePlural, tenant, nomeSolucao, caminho);
            CriaInterfaceService(projectNome, nomeSolucao, nome, nomePlural, caminho);
            CriaDtos(projectNome, nomeSolucao, nomePlural, nome, tipoDaChave, listaDeCampos, caminho);
        }

        private static void CriaTeste(string projectNome, string nomeSolucao, string nome, string nomePlural,
          string sigla, string gravacaoBanco, string tipoDaChave, string interfacesComplementares, string tenant,
          List<CampoEntidade> listaDeCampos, string pastaRaiz)
        {
            var pasta = pastaRaiz + @"\" + ModeloTeste.NomePastaTeste;

            var caminho = Path.Combine(pastaRaiz, pasta);

            Directory.CreateDirectory(caminho);

            CriaTestes(projectNome, nomeSolucao, nome, nomePlural, listaDeCampos, caminho);
            ConstroiBuilder(projectNome, nomeSolucao, nome, nomePlural, sigla, gravacaoBanco, tipoDaChave, interfacesComplementares, tenant, listaDeCampos, caminho);
            CriaUtils(projectNome, nomeSolucao, nome, nomePlural, listaDeCampos, caminho);

        }

        private static void CriaEntidade(string projectNome, string nomeSolucao, string nome, string nomePlural,
            string sigla, string gravacaoBanco, string tipoDaChave, string interfacesComplementares, string tenant,
            List<CampoEntidade> listaDeCampos, string caminho)
        {
            var caminhoEntidades = caminho + @"\" + nomePlural;

            caminhoEntidades = Path.Combine(caminho, caminhoEntidades);

            Directory.CreateDirectory(caminhoEntidades);

            var caminhoEntidade = caminhoEntidades + @"\" + ModeloEntidade.NomePastaEntidade;

            caminhoEntidade = Path.Combine(caminhoEntidades, caminhoEntidade);

            Directory.CreateDirectory(caminhoEntidade);

            var nomeDaEntidade = nome + ".cs";

            caminhoEntidade = Path.Combine(caminhoEntidade, nomeDaEntidade);

            var nameSpace = ModeloEntidade.Namespace(projectNome, nomeSolucao, nomePlural);

            var entidadebase = ModeloEntidade.Entidade(nameSpace, nome, tipoDaChave, sigla, gravacaoBanco,
                interfacesComplementares, tenant, listaDeCampos);

            if (!File.Exists(caminhoEntidade))
                using (var file = File.Create(caminhoEntidade))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoEntidade, entidadebase);
        }

        private static void CriaManager(string projectNome, string nomeSolucao, string nome, string nomePlural,
          string tipoDaChave, string caminho)
        {
            var caminhoEntidades = caminho + @"\" + nomePlural;

            caminhoEntidades = Path.Combine(caminho, caminhoEntidades);

            var caminhoArquivo = caminhoEntidades + @"\" + ModeloManager.NomePastaManager;

            caminhoArquivo = Path.Combine(caminhoEntidades, caminhoArquivo);

            Directory.CreateDirectory(caminhoArquivo);

            var nomeArquivo = nome + ModeloManager.NomePastaManager + ".cs";

            caminhoArquivo = Path.Combine(caminhoArquivo, nomeArquivo);

            var nameSpace = ModeloManager.Namespace(projectNome, nomeSolucao, nomePlural);

            var managerbase = ModeloManager.Manager(nameSpace, nome, tipoDaChave, nomeSolucao);

            if (!File.Exists(caminhoArquivo))
                using (var file = File.Create(caminhoArquivo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoArquivo, managerbase);
        }

        private static void CriaInterfaceManager(string projectNome, string nomeSolucao, string nome, string nomePlural,
            string tipoDaChave, string caminho)
        {
            var caminhoEntidades = caminho + @"\" + nomePlural;

            caminhoEntidades = Path.Combine(caminho, caminhoEntidades);

            var caminhoArquivo = caminhoEntidades + @"\" + ModeloManager.NomePastaManager;

            caminhoArquivo = Path.Combine(caminhoEntidades, caminhoArquivo);

            Directory.CreateDirectory(caminhoArquivo);

            var nomeDaInterfaceManager = "I" + nome + ModeloManager.NomePastaManager + ".cs";

            caminhoArquivo = Path.Combine(caminhoArquivo, nomeDaInterfaceManager);

            var nameSpace = ModeloManager.Namespace(projectNome, nomeSolucao, nomePlural);

            var managerbase = ModeloManager.IManager(nameSpace, nome, tipoDaChave, nomeSolucao);

            if (!File.Exists(caminhoArquivo))
                using (var file = File.Create(caminhoArquivo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoArquivo, managerbase);
        }

        private static void ConstroiBuilder(string projectNome, string nomeSolucao, string nome, string nomePlural,
             string sigla, string gravacaoBanco, string tipoDaChave, string interfacesComplementares, string tenant,
             IEnumerable<CampoEntidade> listaDeCampos, string caminho)
        {
            var caminhoEntidades = caminho + @"\" + nomePlural;

            caminhoEntidades = Path.Combine(caminho, caminhoEntidades);

            var caminhoArquivo = caminhoEntidades + @"\" + ModeloBuilder.NomePastaBuilder;

            caminhoArquivo = Path.Combine(caminhoEntidades, caminhoArquivo);

            Directory.CreateDirectory(caminhoArquivo);

            var nomeArquivo = nome + ModeloBuilder.NomePastaBuilder + ".cs";

            caminhoArquivo = Path.Combine(caminhoArquivo, nomeArquivo);

            var nameSpace = ModeloBuilder.Namespace(projectNome, nomeSolucao, nomePlural);

            var builderbase = ModeloBuilder.Builder(nameSpace, nome, tipoDaChave, sigla, gravacaoBanco,
                interfacesComplementares, tenant, listaDeCampos);

            if (!File.Exists(caminhoArquivo))
                using (var file = File.Create(caminhoArquivo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoArquivo, builderbase);
        }

        private static void CriaUtils(string projectNome, string nomeSolucao, string nome, string nomePlural,
          IEnumerable<CampoEntidade> listaDeCampos, string caminho)
        {
            var caminhoEntidades = caminho + @"\" + nomePlural;

            caminhoEntidades = Path.Combine(caminho, caminhoEntidades);

            Directory.CreateDirectory(caminhoEntidades);

            var caminhoArquivo = caminhoEntidades + @"\" + "Utils";

            caminhoArquivo = Path.Combine(caminhoEntidades, caminhoArquivo);

            Directory.CreateDirectory(caminhoArquivo);

            var nomeDaBuilder = nome + "Constants.cs";

            caminhoArquivo = Path.Combine(caminhoArquivo, nomeDaBuilder);

            var nameSpace = ModeloBuilder.Namespace(projectNome, nomeSolucao, nomePlural);

            var builderbase = ModeloBuilder.BuilderConst(nameSpace, nome, listaDeCampos);

            if (!File.Exists(caminhoArquivo))
                using (var file = File.Create(caminhoArquivo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoArquivo, builderbase);
        }


        private static void CriaService(string projectNome, string nomeSolucao, string nome, string nomePlural,
            string tenant, string nomeAplicacao, string caminho)
        {
            var caminhoEntidades = caminho + @"\" + nomePlural;

            caminhoEntidades = Path.Combine(caminho, caminhoEntidades);

            var caminhoArquivo = caminhoEntidades + @"\" + ModeloService.NomePastaService;

            caminhoArquivo = Path.Combine(caminhoEntidades, caminhoArquivo);

            Directory.CreateDirectory(caminhoArquivo);

            var nomeDaInterfaceService = nome + ModeloService.NomeService + ".cs";

            caminhoArquivo = Path.Combine(caminhoArquivo, nomeDaInterfaceService);

            var nameSpace = ModeloService.Namespace(projectNome, nomeSolucao, nomePlural);

            var servicebase = ModeloService.Service(nameSpace, nome, nomePlural, tenant, nomeAplicacao);

            if (!File.Exists(caminhoArquivo))
                using (var file = File.Create(caminhoArquivo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoArquivo, servicebase);
        }

        private static void CriaInterfaceService(string projectNome, string nomeSolucao, string nome, string nomePlural, string caminho)
        {
            var caminhoEntidades = caminho + @"\" + nomePlural;

            caminhoEntidades = Path.Combine(caminho, caminhoEntidades);

            var caminhoArquivo = caminhoEntidades + @"\" + ModeloService.NomePastaService;

            caminhoArquivo = Path.Combine(caminhoEntidades, caminhoArquivo);

            Directory.CreateDirectory(caminhoArquivo);
            var nomeDaInterfaceService = "I" + nome + ModeloService.NomeService + ".cs";

            caminhoArquivo = Path.Combine(caminhoArquivo, nomeDaInterfaceService);

            var nameSpace = ModeloService.Namespace(projectNome, nomeSolucao, nomePlural);

            var servicebase = ModeloService.IService(nameSpace, nome);

            if (!File.Exists(caminhoArquivo))
                using (var file = File.Create(caminhoArquivo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoArquivo, servicebase);
        }


        private static void CriaDtos(string projectNome, string nomeSolucao, string nomePlural, string nome,
            string tipoDaChave, List<CampoEntidade> listaDeCampos, string caminho)
        {
            var caminhoEntidades = caminho + @"\" + nomePlural;

            caminhoEntidades = Path.Combine(caminho, caminhoEntidades);

            var caminhoArquivo = caminhoEntidades + @"\" + ModeloDtos.NomePastaDto;

            caminhoArquivo = Path.Combine(caminhoEntidades, caminhoArquivo);

            Directory.CreateDirectory(caminhoArquivo);

            CriarInputDto(projectNome, nomeSolucao, nomePlural, listaDeCampos, caminhoArquivo);

            CriarOutputDto(projectNome, nomeSolucao, nomePlural, caminhoArquivo, tipoDaChave);

            ObterTodosOutputDto(projectNome, nomeSolucao, nomePlural, caminhoArquivo);

            CriarItemOutputDto(projectNome, nomeSolucao, nomePlural, nome, tipoDaChave, listaDeCampos, caminhoArquivo);

            CriarAtualizarInputDto(projectNome, nomeSolucao, nomePlural, listaDeCampos, caminhoArquivo, tipoDaChave);

            CriarAtualizarOutputDto(projectNome, nomeSolucao, nomePlural, tipoDaChave, listaDeCampos, caminhoArquivo);

            CriarObterPorIdOutputDto(projectNome, nomeSolucao, nomePlural, tipoDaChave, listaDeCampos, caminhoArquivo);

            CriarObterPorIdInputDto(projectNome, nomeSolucao, nomePlural, tipoDaChave, caminhoArquivo);

            CriarDeletarInputDto(projectNome, nomeSolucao, nomePlural, tipoDaChave, caminhoArquivo);

            CriarDeletarOutputDto(projectNome, nomeSolucao, nomePlural, caminhoArquivo);

            CriarEntidadeDto(projectNome, nomeSolucao, nomePlural, nome, tipoDaChave, listaDeCampos, caminhoArquivo);

        }

        private static void CriarAtualizarInputDto(string projectNome, string nomeSolucao, string nomePlural,
            IEnumerable<CampoEntidade> listaDeCampos, string caminhoDtos, string tipoChave)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloDtos.AtualizarPastaNome;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloDtos.AtualizarInputNome + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectNome, nomeSolucao, nomePlural, ModeloDtos.AtualizarPastaNome);

            var dtobase = ModeloDtos.AtualizarInput(nameSpace, listaDeCampos, tipoChave);

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

        private static void CriaTestes(string projectNome, string nomeSolucao, string nome, string nomePlural, IEnumerable<CampoEntidade> listaDeCampos, string caminho)
        {
            var caminhoEntidades = caminho + @"\" + nomePlural;

            caminhoEntidades = Path.Combine(caminho, caminhoEntidades);

            var caminhoArquivo = caminhoEntidades + @"\" + ModeloTeste.NomePastaTeste;

            caminhoArquivo = Path.Combine(caminhoEntidades, caminhoArquivo);

            Directory.CreateDirectory(caminhoArquivo);

            var nomeDaInterfaceTeste = nome + ModeloTeste.NomeTeste + ".cs";

            caminhoArquivo = Path.Combine(caminhoArquivo, nomeDaInterfaceTeste);

            var nameSpace = ModeloTeste.Namespace(projectNome, nomeSolucao, nomePlural);

            var testebase = ModeloTeste.Teste(nameSpace, nome, nomePlural, listaDeCampos);

            if (!File.Exists(caminhoArquivo))
                using (var file = File.Create(caminhoArquivo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoArquivo, testebase);
        }

        private static void CriarEntidadeDto(string projectNome, string nomeSolucao, string nomePlural, string nome,
          string tipoChave, IEnumerable<CampoEntidade> listaDeCampos, string caminhoDtos)
        {
            var pastaRaiz = caminhoDtos + "\\";

            var entityFolder = ModeloEntidade.NomePastaEntidade;

            var caminho = pastaRaiz + entityFolder;

            var caminhoNovo = Path.Combine(pastaRaiz, caminho);

            Directory.CreateDirectory(caminhoNovo);

            var nomeDaDto = ModeloEntidade.NomePastaEntidade + "Dto" + ".cs";

            caminhoNovo = Path.Combine(caminhoNovo, nomeDaDto);

            var nameSpace = ModeloDtos.Namespace(projectNome, nomeSolucao, nomePlural, ModeloEntidade.NomePastaEntidade);

            var dtobase = ModeloDtos.Entidade(nameSpace, listaDeCampos, nome, tipoChave);

            if (!File.Exists(caminhoNovo))
                using (var file = File.Create(caminhoNovo))
                {
                    file.Close();
                }

            File.WriteAllText(caminhoNovo, dtobase);
        }

    }
}