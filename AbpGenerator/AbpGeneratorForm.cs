using System;
using System.Windows.Forms;

namespace AbpGenerator
{
    public partial class AbpBackEndGeneratorForm : Form
    {
        public AbpBackEndGeneratorForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var siglaGravacao = SiglaBancoGravacao();

            var tenant = FiltroTenant();

            GerenciarPastas.CriaEntidade(NomeProjeto.Text, NomeSolucao.Text, NomeEntidade.Text, NomeClassePlural.Text, SiglaAplicacao.Text, siglaGravacao, TipoChavePrimaria.Text, InterfacesComplementares.Text, tenant);
        }

        private string SiglaBancoGravacao()
        {
            return LeituraEscritaCheck.Checked ? Modelos.ApenasLeitura : Modelos.LeituraEscrita;
        }

        private string FiltroTenant()
        {
            if (TenantFacultativa.Checked)
                return Modelos.TenantFacultativa;

            return TenantObrigatoria.Checked ? Modelos.TenantObrigatoria : "";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void NomeClassePlural_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ApenasLeituraCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ApenasLeituraCheck.Checked)
                LeituraEscritaCheck.Checked = false;

        }

        private void LeituraEscritaCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (LeituraEscritaCheck.Checked)
                ApenasLeituraCheck.Checked = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void TenantObrigatoria_CheckedChanged(object sender, EventArgs e)
        {
            if (!TenantObrigatoria.Checked) return;

            TenantFacultativa.Checked = false;

            SemTenant.Checked = false;
        }

        private void TenantFacultativa_CheckedChanged(object sender, EventArgs e)
        {
            if (!TenantFacultativa.Checked) return;

            TenantObrigatoria.Checked = false;

            SemTenant.Checked = false;
        }

        private void SemTenant_CheckedChanged(object sender, EventArgs e)
        {
            if (!SemTenant.Checked) return;

            TenantObrigatoria.Checked = false;

            TenantFacultativa.Checked = false;
        }
    }
}
