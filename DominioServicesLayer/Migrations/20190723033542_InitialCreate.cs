using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DominioServicesLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    EmpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Empnombre = table.Column<string>(maxLength: 20, nullable: false),
                    EmpLogo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empresa__AF2DBB99A0F137AB", x => x.EmpId);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstDescipcion = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Estado__665CAD5ECE111DCC", x => x.EstId);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProdId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProdNombre = table.Column<string>(maxLength: 20, nullable: false),
                    ProdUM = table.Column<string>(maxLength: 20, nullable: false),
                    ProdCategoria = table.Column<string>(maxLength: 50, nullable: false),
                    ProdPrecioCompra = table.Column<decimal>(type: "decimal(25, 4)", nullable: true),
                    ProdPrecioVenta = table.Column<decimal>(type: "decimal(25, 4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__042785E54ADCD50E", x => x.ProdId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuUsuario = table.Column<string>(maxLength: 20, nullable: false),
                    UsuClave = table.Column<string>(maxLength: 20, nullable: false),
                    UsuActivo = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    UsuIntentos = table.Column<int>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__685263833772D33D", x => x.UsuId);
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    EnId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnProveedor = table.Column<string>(maxLength: 50, nullable: true),
                    EnFecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    EnEstado = table.Column<int>(nullable: true, defaultValueSql: "((1))"),
                    EnUsuarioCrea = table.Column<int>(nullable: true),
                    EnFechaRegitro = table.Column<DateTime>(type: "datetime", nullable: true),
                    EnUsuarioModifica = table.Column<int>(nullable: true),
                    EnFechaModifica = table.Column<DateTime>(type: "datetime", nullable: true),
                    EnObservacion = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Entrada__E3E8BE946EF52EB5", x => x.EnId);
                    table.ForeignKey(
                        name: "FK__Entrada__EnVrTot__628FA481",
                        column: x => x.EnUsuarioCrea,
                        principalTable: "Usuario",
                        principalColumn: "UsuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Entrada__EnUsuar__6383C8BA",
                        column: x => x.EnUsuarioModifica,
                        principalTable: "Usuario",
                        principalColumn: "UsuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEmpresa",
                columns: table => new
                {
                    UsuEmpid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuEmpUsuario = table.Column<int>(nullable: false),
                    UsuEmpEmpresa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UsuarioE__0CDFECFF6718754D", x => x.UsuEmpid);
                    table.ForeignKey(
                        name: "FK__UsuarioEm__UsuEm__5CD6CB2B",
                        column: x => x.UsuEmpEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__UsuarioEm__UsuEm__5BE2A6F2",
                        column: x => x.UsuEmpUsuario,
                        principalTable: "Usuario",
                        principalColumn: "UsuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntradaDetalle",
                columns: table => new
                {
                    EnDetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndDetEntradaId = table.Column<int>(nullable: false),
                    EnDetProuctoId = table.Column<int>(nullable: false),
                    EnDetCantidad = table.Column<decimal>(type: "decimal(25, 5)", nullable: false),
                    EnDetVrUnit = table.Column<decimal>(type: "decimal(25, 5)", nullable: false),
                    EnDetPrcIVA = table.Column<decimal>(type: "decimal(25, 5)", nullable: false),
                    EnDetVrIVA = table.Column<decimal>(type: "decimal(25, 5)", nullable: false),
                    EnDetVrTotal = table.Column<decimal>(type: "decimal(25, 5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EntradaD__BF3CEE8DEF3010B2", x => x.EnDetId);
                    table.ForeignKey(
                        name: "FK__EntradaDe__EnDet__6754599E",
                        column: x => x.EnDetProuctoId,
                        principalTable: "Producto",
                        principalColumn: "ProdId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__EntradaDe__EndDe__66603565",
                        column: x => x.EndDetEntradaId,
                        principalTable: "Entrada",
                        principalColumn: "EnId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_EnUsuarioCrea",
                table: "Entrada",
                column: "EnUsuarioCrea");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_EnUsuarioModifica",
                table: "Entrada",
                column: "EnUsuarioModifica");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaDetalle_EnDetProuctoId",
                table: "EntradaDetalle",
                column: "EnDetProuctoId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaDetalle_EndDetEntradaId",
                table: "EntradaDetalle",
                column: "EndDetEntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresa_UsuEmpEmpresa",
                table: "UsuarioEmpresa",
                column: "UsuEmpEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresa_UsuEmpUsuario",
                table: "UsuarioEmpresa",
                column: "UsuEmpUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradaDetalle");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "UsuarioEmpresa");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
