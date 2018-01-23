using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AbpGenerator.Properties;

namespace AbpGenerator
{
    public partial class AbpBackEndGeneratorForm : Form
    {
        public AbpBackEndGeneratorForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var siglaGravacao = SiglaBancoGravacao();

            var tenant = FiltroTenant();
            var lista = ConverteTabelaDeCamposParaLista();

            GerenciarPastas.CriaEntidade(
                NomeProjeto.Text,
                NomeSolucao.Text,
                NomeEntidade.Text,
                NomeClassePlural.Text,
                SiglaAplicacao.Text,
                siglaGravacao,
                TipoChavePrimaria.Text,
                InterfacesComplementares.Text,
                tenant,
                lista
                );

            GerenciarPastas.CriaBuilder(
               NomeProjeto.Text,
               NomeSolucao.Text,
               NomeEntidade.Text,
               NomeClassePlural.Text,
               SiglaAplicacao.Text,
               siglaGravacao,
               TipoChavePrimaria.Text,
               InterfacesComplementares.Text,
               tenant,
               lista
               );

            GerenciarPastas.CriaDtos(
                NomeProjeto.Text,
                NomeSolucao.Text,
                NomeClassePlural.Text,
                NomeEntidade.Text,
                TipoChavePrimaria.Text,
                lista
            );

            GerenciarPastas.CriaInterfaceImplementacaoManager(
                NomeProjeto.Text,
                NomeSolucao.Text,
                NomeEntidade.Text,
                NomeClassePlural.Text,
                TipoChavePrimaria.Text);

            GerenciarPastas.CriaInterfaceImplementacaoService(
                NomeProjeto.Text,
                NomeSolucao.Text,
                NomeEntidade.Text,
                NomeClassePlural.Text,
                tenant);

            GerenciarPastas.CriaTestes(
              NomeProjeto.Text,
              NomeSolucao.Text,
              NomeEntidade.Text,
              NomeClassePlural.Text
              );

            MessageBox.Show(Resources.ArquivoCriadoComSucesso_);
        }

        private string SiglaBancoGravacao()
        {
            return LeituraEscritaCheck.Checked ? Utils.ApenasLeitura : Utils.LeituraEscrita;
        }

        private string FiltroTenant()
        {
            if (TenantFacultativa.Checked)
                return Utils.TenantFacultativa;

            return TenantObrigatoria.Checked ? Utils.TenantObrigatoria : "";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private List<CampoEntidade> ConverteTabelaDeCamposParaLista()
        {
            var linhasTabela = TabelaNomes.Rows;

            var lista = new List<CampoEntidade>();

            for (var count = 0; count < linhasTabela.Count - 1; count++)
            {
                var campoTemp = new CampoEntidade
                {
                    Nome = linhasTabela[count].Cells[0].Value.ToString(),
                    Tipo = linhasTabela[count].Cells[1].Value.ToString()
                };

                lista.Add(campoTemp);
            }
            return lista;
        }
    }
}
