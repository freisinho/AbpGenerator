using System.Collections.Generic;
using System.Linq;

namespace AbpGenerator
{
    public abstract class ModeloDtos
    {
        public static string NomePastaDto { get; } = @"Dtos";
        public static string CriarInputName { get; } = @"CriarInput";
        public static string CriarOutputName { get; } = @"CriarOutput";
        public static string ObterPorIdInputName { get; } = @"ObterPorIdInput";
        public static string DeletarInputName { get; } = @"DeletarInput";
        public static string ObterTodosInputName { get; } = @"ObterTodosInput";
        public static string AtualizarInputName { get; } = @"AtualizarInput";
        public static string CriarPastaName { get; } = @"Criar";
        public static string AtualizarPastaName { get; } = @"Atualizar";
        public static string ObterPastaName { get; } = @"Obter";
        public static string DeletarPastaName { get; } = @"Deletar";

        public static string Namespace(string projectName, string nomeSolucao, string nomePlural, string nomePasta)
        {
            var name = projectName + "." + nomeSolucao + "." + nomePlural + "." + NomePastaDto + "." + nomePasta;
            return name;
        }

        private static string MontaCamposDto(IEnumerable<CampoEntidade> listaDeCampos)
        {
            return listaDeCampos.Aggregate("\n              ", (current, campo) => current + RetornaDeclaracaoDoTipo(campo) + "\n              ");
        }

        private static string RetornaDeclaracaoDoTipo(CampoEntidade campo)
        {

            var nomeTipo = campo.Tipo + " " + char.ToUpper(campo.Nome[0]) + campo.Nome.Substring(1);

            return Utils.DeclaracaoCampo.Replace("insereAqui", nomeTipo);

        }

        public static string CriarInput(string nameSpace, IEnumerable<CampoEntidade> listaDeCampos)
        {
            var dtoBase = @"
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.ComponentModel.DataAnnotations;
        using System.Text.RegularExpressions;
        using Abp.Runtime.Validation;
        using Abp.UI;

        namespace " + nameSpace + @"
        {
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

        public static string EntidadeDto(string nameSpace, IEnumerable<CampoEntidade> listaDeCampos, string nome, string tipoChave)
        {
            var dtoBase = @"
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.ComponentModel.DataAnnotations;
        using System.Text.RegularExpressions;
        using Abp.Runtime.Validation;
        using Abp.UI;

        namespace " + nameSpace + @"
        {
            public class " + nome + @"Dto : EntityDto<" + tipoChave + @">, ICustomValidate
            {" +
            MontaCamposDto(listaDeCampos).TrimEnd() + @"
         
              public void AddValidationErrors(CustomValidationContext context)
              {
              }
            }
        }";
            return dtoBase;
        }

        public static string CriarOutput(string nameSpace, string tipoChave)
        {
            var dtoBase = @"
        namespace " + nameSpace + @"
        {
            public class CriarOutput
            {
              public " + tipoChave + @" Id { get; set; }
            }
        }";
            return dtoBase;
        }

    }
}
