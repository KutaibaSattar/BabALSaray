using Microsoft.EntityFrameworkCore.Migrations;

namespace BabALSaray.data.migrations
{
    public partial class ProductTableSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.Sql("Insert Into ProductTypes (Name) values ('Swing')");
             migrationBuilder.Sql("Insert Into ProductTypes (Name) values ('Sliding')");
             migrationBuilder.Sql("Insert Into ProductTypes (Name) values ('OverHead')");
           
             migrationBuilder.Sql("Insert Into ProductBrands (Name) values ('Serai')");
             migrationBuilder.Sql("Insert Into ProductBrands (Name) values ('BFT')");
             migrationBuilder.Sql("Insert Into ProductBrands (Name) values ('Somfy')");

             migrationBuilder.Sql(
                 "INSERT INTO Products(Name, Description, price, PictureUrl, ProductTypeId, ProdcuctBrandId) VALUES ('Swing 2 m','Swing 2 m',3000,null,1,1)");
               
              migrationBuilder.Sql(
                 "INSERT INTO Products(Name, Description, price, PictureUrl, ProductTypeId, ProdcuctBrandId) VALUES ('Sliding 800KG','Sliding 800KG',2000,null,2,2)");

                   migrationBuilder.Sql(
                 "INSERT INTO Products(Name, Description, price, PictureUrl, ProductTypeId, ProdcuctBrandId) VALUES ('Wood','Wood',8000,null,3,3)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
