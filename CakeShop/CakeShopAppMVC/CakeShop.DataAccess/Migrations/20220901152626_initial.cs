using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeShop.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cake",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cake", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CakeOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CakeId = table.Column<int>(type: "int", nullable: false),
                    Selected = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CakeOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CakeOrder_Cake_CakeId",
                        column: x => x.CakeId,
                        principalTable: "Cake",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CakeOrder_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cake",
                columns: new[] { "Id", "Description", "Image", "Ingredients", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Cheesecake is a sweet dessert consisting of one or more layers. The main, and thickest, layer consists of a mixture of a soft, fresh cheese, eggs, and sugar. If there is a bottom layer, it most often consists of a crust or base made from crushed cookies, graham crackers, pastry, or sometimes sponge cake.", "https://www.thespruceeats.com/thmb/r8TCBwuaBBV5oBKc5vXzP7JvllU=/940x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/gluten-free-new-york-cheesecake-1450985-hero-01-dc54f9daf38044238b495c7cefc191fa.jpg", "Cream cheese, soure cream, eggs,biscuits, sugar, cheery", "cheesecake", 650m },
                    { 2, "Chocolate cake or chocolate gâteau is a cake flavored with melted chocolate, cocoa powder, or both.Chocolate cake is made with chocolate.It can also include other ingredients.These include fudge, vanilla creme, and other sweeteners.", "https://th.bing.com/th/id/OIP.L8n28h8SNmk_9C8OQxXMqAHaJR?pid=ImgDet&rs=1", "Flour,sugar, Chocolate, eggs, milk,vanilla", "Chocolate Cake", 700m },
                    { 3, "This mousse cake is our homage to the Canadian favourite, just in time for the holidays. It starts with a bottom layer of cake, and includes cream, in lieu of egg whites, to give the mousse better consistency. ", "https://img.taste.com.au/thf4ZgLa/taste/2016/11/top-50-cakes-image-30-66357-1.jpg", "Chocolate biscuits,Butter,Dark Chocolate,Cream,Coffee", "chocolate mousse cake", 350m },
                    { 4, "A moist and fluffy strawberry cake filled with strawberry and lemon buttercream and crowned with strawberries and buttercream roses", "https://img.taste.com.au/GIR51Wnj/taste/2016/11/top-50-cakes-image-31-66359-1.jpg", "coconut,Lemon Juice,Frozen strawberries,flour,Eggs,Sugar,Milk", "strawberry Cake", 450m },
                    { 5, "A veggie burger is a hamburger patty that does not contain meat. It may be made from ingredients like beans, A moist and fluffy raspberry cake filled with raspberry and lemon buttercream and crowned with raspberry and buttercream roses", "https://img.taste.com.au/-dGYc9Ej/taste/2016/11/top-50-cakes-image-49-66387-1.jpg", "frozen raspberries,Eggs,Sugar,Almonds", " Raspberry cake", 250m }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Address", "CloseAt", "Image", "Name", "OpenAt" },
                values: new object[,]
                {
                    { 1, "Kaspos", new DateTime(2022, 1, 1, 23, 0, 0, 0, DateTimeKind.Unspecified), "https://images.creativemarket.com/0.1.0/ps/797108/2000/1500/m1/fpnw/wm0/cake-shop-logo-mock-up-1-.jpg?1448176497&s=57e541bc392c59d6b6c6097b57105505", "Cake House", new DateTime(2022, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Centar", new DateTime(2022, 1, 1, 23, 0, 0, 0, DateTimeKind.Unspecified), "https://images.creativemarket.com/0.1.0/ps/797108/2000/1500/m1/fpnw/wm0/cake-shop-logo-mock-up-1-.jpg?1448176497&s=57e541bc392c59d6b6c6097b57105505", "Cake House", new DateTime(2022, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Aerodrom", new DateTime(2022, 1, 1, 23, 0, 0, 0, DateTimeKind.Unspecified), "https://images.creativemarket.com/0.1.0/ps/797108/2000/1500/m1/fpnw/wm0/cake-shop-logo-mock-up-1-.jpg?1448176497&s=57e541bc392c59d6b6c6097b57105505", "Cake House", new DateTime(2022, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Novo Lisice", new DateTime(2022, 1, 1, 23, 0, 0, 0, DateTimeKind.Unspecified), "https://images.creativemarket.com/0.1.0/ps/797108/2000/1500/m1/fpnw/wm0/cake-shop-logo-mock-up-1-.jpg?1448176497&s=57e541bc392c59d6b6c6097b57105505", "Cake House", new DateTime(2022, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Avtokomanda", new DateTime(2022, 1, 1, 23, 0, 0, 0, DateTimeKind.Unspecified), "https://images.creativemarket.com/0.1.0/ps/797108/2000/1500/m1/fpnw/wm0/cake-shop-logo-mock-up-1-.jpg?1448176497&s=57e541bc392c59d6b6c6097b57105505", "Cake House", new DateTime(2022, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Description", "Price" },
                values: new object[,]
                {
                    { 1, "Quarter", 300m },
                    { 2, "Half", 600m },
                    { 3, "Full", 900m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CakeOrder_CakeId",
                table: "CakeOrder",
                column: "CakeId");

            migrationBuilder.CreateIndex(
                name: "IX_CakeOrder_CartId",
                table: "CakeOrder",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CartId",
                table: "Order",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_LocationId",
                table: "Order",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CakeOrder");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Cake");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
