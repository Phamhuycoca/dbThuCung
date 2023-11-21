using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbThuCung.Model.Migrations
{
    public partial class acbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonChiTiet_SanPham_ObjectId",
                table: "HoaDonChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonChiTiet_ThuNuoi_ObjectId",
                table: "HoaDonChiTiet");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "HoaDonChiTiet",
                newName: "SanPhamId");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDonChiTiet_ObjectId",
                table: "HoaDonChiTiet",
                newName: "IX_HoaDonChiTiet_SanPhamId");

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    CartItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<long>(type: "bigint", nullable: false),
                    SanPhamId = table.Column<long>(type: "bigint", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_GioHang_NguoiDung_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "NguoiDungId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GioHang_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_NguoiDungId",
                table: "GioHang",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_SanPhamId",
                table: "GioHang",
                column: "SanPhamId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonChiTiet_SanPham_SanPhamId",
                table: "HoaDonChiTiet",
                column: "SanPhamId",
                principalTable: "SanPham",
                principalColumn: "SanPhamId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonChiTiet_SanPham_SanPhamId",
                table: "HoaDonChiTiet");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.RenameColumn(
                name: "SanPhamId",
                table: "HoaDonChiTiet",
                newName: "ObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDonChiTiet_SanPhamId",
                table: "HoaDonChiTiet",
                newName: "IX_HoaDonChiTiet_ObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonChiTiet_SanPham_ObjectId",
                table: "HoaDonChiTiet",
                column: "ObjectId",
                principalTable: "SanPham",
                principalColumn: "SanPhamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonChiTiet_ThuNuoi_ObjectId",
                table: "HoaDonChiTiet",
                column: "ObjectId",
                principalTable: "ThuNuoi",
                principalColumn: "ThuNuoiId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
