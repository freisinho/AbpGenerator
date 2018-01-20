namespace AbpGenerator
{
    public abstract class Utils
    {
        public static string PastaRaizArquivos { get; } = @"C:\Arquivos Gerados\";

        public static string ApenasLeitura { get; } = @"Tr";

        public static string LeituraEscrita { get; } = @"Tw";

        public static string TenantFacultativa { get; } = @"IMayHaveTenant";

        public static string TenantObrigatoria { get; } = @"IMustHaveTenant";

        public static string DeclaracaoCampo { get; } = @"public insereAqui { get; set; }";


    }
}
