using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GerenciamentoProdutosPorCategoria {
    public partial class CategoriaForm : Form {
        private List<Categoria> categorias = new List<Categoria>();
        private List<Produto> produtos = new List<Produto>();

        public CategoriaForm() {
            InitializeComponent();
        }

        private void CategoriaForm_Load(object sender, EventArgs e) {
         
            foreach (var categoria in categorias) {
                categoriaComboBox.Items.Add(categoria.Nome);
            }
        }

        private void categoriaComboBox_SelectedIndexChanged(object sender, EventArgs e) {

            string categoriaSelecionada = categoriaComboBox.SelectedItem.ToString();
            var produtosDaCategoria = produtos.FindAll(p => p.Categoria.Nome == categoriaSelecionada);
            
        }

        private void registrarProdutoButton_Click(object sender, EventArgs e) {
            
        }

        private void excluirProdutoButton_Click(object sender, EventArgs e) {
            
        }
    }

    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CategoriaForm categoriaForm = new CategoriaForm();
            Application.Run(categoriaForm);
        }
    }
}
