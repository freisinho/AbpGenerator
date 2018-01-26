using System.Collections.Generic;
using System.Linq;

namespace AbpGenerator
{
    public abstract class ModeloDtos
    {
        public static string NomePastaDto { get; } = @"Dtos";
        public static string CriarInputNome { get; } = @"CriarInput";
        public static string CriarOutputNome { get; } = @"CriarOutput";
        public static string ObterPorIdInputNome { get; } = @"ObterPorIdInput";
        public static string ObterPorIdOutputNome { get; } = @"ObterPorIdOutput";

        public static string DeletarInputNome { get; } = @"DeletarInput";
        public static string DeletarOutputNome { get; } = @"DeletarOutput";

        public static string ObterTodosOutputNome { get; } = @"ObterTodosOutput";
        public static string AtualizarInputNome { get; } = @"AtualizarInput";
        public static string AtualizarOutputNome { get; } = @"AtualizarOutput";

        public static string CriarPastaNome { get; } = @"Criar";
        public static string AtualizarPastaNome { get; } = @"Atualizar";

        public static string ObterPastaNome { get; } = @"Obter";
        public static string DeletarPastaNome { get; } = @"Deletar";

        public static string ItemOutputNome { get; } = @"ItemOutput";

        public static string Namespace(string projectNome, string nomeSolucao, string nomePlural, string nomePasta)
        {
            var name = projectNome + "." + nomeSolucao + "." + nomePlural + "." + NomePastaDto + "." + nomePasta;
            return name;
        }

        private static string MontaCamposDto(IEnumerable<CampoEntidade> listaDeCampos)
        {
            return listaDeCampos.Aggregate("\n        ",
                (current, campo) => current + RetornaDeclaracaoDoTipo(campo) + "\n        ");
        }

        private static string RetornaDeclaracaoDoTipo(CampoEntidade campo)
        {
            var nomeTipo = campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1);

            return Utils.DeclaracaoCampo.Replace("insereAqui", nomeTipo);
        }

        public static string CriarInput(string nameSpace, IEnumerable<CampoEntidade> listaDeCampos, string nome)
        {
            var dtoBase =
@"using System;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using " + nameSpace.Replace("Dtos.Criar", "Entidade") + @";

namespace " + nameSpace + @"
{
    [AutoMapTo(typeof(" + nome + @"))]
    public class CriarInput : ICustomValidate
    {" +
                  MontaCamposDto(listaDeCampos).TrimEnd() + @"
 
        public void AddValidationErrors(CustomValidationContext context)
        {
        }
    }
}";
            return dtoBase;
        }

        public static string AtualizarInput(string nameSpace, IEnumerable<CampoEntidade> listaDeCampos, string tipoChave, string nome)
        {
            var dtoBase =
@"using System;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Application.Services.Dto;
using " + nameSpace.Replace("Dtos.Atualizar", "Entidade") + @";

namespace " + nameSpace + @"
{
    [AutoMapTo(typeof(" + nome + @"))]
    public class AtualizarInput : EntityDto<" + tipoChave + @">,ICustomValidate
    {" +
                  MontaCamposDto(listaDeCampos).TrimEnd() + @"
        public void AddValidationErrors(CustomValidationContext context)
        {
        }
    }
}";
            return dtoBase;
        }

        public static string AtualizarOutput(string nameSpace, IEnumerable<CampoEntidade> listaDeCampos,
            string tipoChave, string nome)
        {
            var dtoBase =
@"using System;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Application.Services.Dto;
using " + nameSpace.Replace("Dtos.Atualizar", "Entidade") + @";

namespace " + nameSpace + @"
{
    [AutoMapTo(typeof(" + nome + @"))]
    public class AtualizarOutput : EntityDto<" + tipoChave + @">
    {" +
                  MontaCamposDto(listaDeCampos).TrimEnd() + @"
    }
}";
            return dtoBase;
        }

        public static string ItemOutput(string nameSpace, IEnumerable<CampoEntidade> listaDeCampos, string nome,
            string tipoChave)
        {
            var dtoBase =
@"using System;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Application.Services.Dto;
using " + nameSpace.Replace("Dtos.Entidade", "Entidade") + @";

namespace " + nameSpace + @"
{
    [AutoMapTo(typeof(" + nome + @"))]
    public class ItemOutput : EntityDto<" + tipoChave + @">
    {" +
                  MontaCamposDto(listaDeCampos).TrimEnd() + @"
    }
}";
            return dtoBase;
        }

        public static string CriarOutput(string nameSpace, string tipoChave)
        {
            var dtoBase =
@"namespace " + nameSpace + @"
{
    public class CriarOutput
    {
        public " + tipoChave + @" Id { get; set; }
    }
}";
            return dtoBase;
        }

        public static string ObterTodosOutput(string nameSpace, string nomePlural)
        {
            var dtoBase =
@"using System.Collections.Generic;
using " + nameSpace.Replace(ObterPastaNome, ModeloEntidade.NomePastaEntidade) + @";

namespace " + nameSpace + @"
{
    public class ObterTodosOutput
    {
        public IList<ItemOutput> " + nomePlural + @" { get; set; }
    }
}";
            return dtoBase;
        }

        public static string ObterPorIdOutput(string nameSpace, IEnumerable<CampoEntidade> listaDeCampos,
            string tipoChave)
        {
            var dtoBase =
@"using System;
using Abp.Application.Services.Dto;

namespace " + nameSpace + @"
{
    public class ObterPorIdOutput : EntityDto<" + tipoChave + @">
    {" +
                  MontaCamposDto(listaDeCampos).TrimEnd() + @"
    }
}";
            return dtoBase;
        }

        public static string ObterPorIdInput(string nameSpace, string tipoChave, string nome)
        {
            var dtoBase =
@"using System;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Application.Services.Dto;
using " + nameSpace.Replace("Dtos.Obter", "Entidade") + @";

namespace " + nameSpace + @"
{
    [AutoMapTo(typeof(" + nome + @"))]
    public class ObterPorIdInput
    {
        public " + tipoChave + @" Id { get; set; }
    }
}";
            return dtoBase;
        }

        public static string DeletarInput(string nameSpace, string tipoChave)
        {
            var dtoBase =
@"namespace " + nameSpace + @"
{
    public class DeletarInput
    {
        public " + tipoChave + @" Id { get; set; }
    }
}";
            return dtoBase;
        }

        public static string DeletarOutput(string nameSpace)
        {
            var dtoBase =
@"namespace " + nameSpace + @"
{
    public class DeletarOutput
    {
    }
}";
            return dtoBase;
        }

        public static string Entidade(string nameSpace, IEnumerable<CampoEntidade> listaDeCampos, string nome,
           string tipoChave)
        {
            var dtoBase =
@"using System;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Application.Services.Dto;
using " + nameSpace.Replace(".Dtos", "") + @";

namespace " + nameSpace + @"
{
    [AutoMapTo(typeof(" + nome + @"))]
    public class " + nome + @"Dto : EntityDto<" + tipoChave + @">
    {" +
                  MontaCamposDto(listaDeCampos).TrimEnd() + @"
    }
}";
            return dtoBase;
        }

    }
}