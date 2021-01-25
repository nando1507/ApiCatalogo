using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalogo5._0.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert Into Categoria(Nome, ImagemUrl) values ('Bebidas','http://www.macoratti.net/Imagens/1.jpg')");
            mb.Sql("Insert Into Categoria(Nome, ImagemUrl) values ('Lanches','http://www.macoratti.net/Imagens/2.jpg')");
            mb.Sql("Insert Into Categoria(Nome, ImagemUrl) values ('Sobremesas','http://www.macoratti.net/Imagens/3.jpg')");
            mb.Sql("Insert Into Produto (Nome, Descricao, Preco, ImagemURL, Estoque, DataCadastro, CategoriaID) Values ('Coca-cola Zero', 'Refrigerante de Cola',5.45, 'http://www.macoratti.net/Imagens/coca.jpg',50,now(),(Select CategoriaId from Categoria where nome = 'Bebidas'))");
            mb.Sql("Insert Into Produto (Nome, Descricao, Preco, ImagemURL, Estoque, DataCadastro, CategoriaID) Values ('Lanche de Atum', 'Lanche de atum com Maionese',8.50, 'http://www.macoratti.net/Imagens/atum.jpg',50,now(),(Select CategoriaId from Categoria where nome = 'Lanches'))");
            mb.Sql("Insert Into Produto (Nome, Descricao, Preco, ImagemURL, Estoque, DataCadastro, CategoriaID) Values ('Pudim 100G', 'Pudim de leite Condensado',6.75, 'http://www.macoratti.net/Imagens/pudim.jpg',50,now(),(Select CategoriaId from Categoria where nome = 'Sobremesas'))");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categoria  ");
            mb.Sql("Delete from Produto ");
        }
    }
}
