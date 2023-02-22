using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BindBox.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ao");

            migrationBuilder.EnsureSchema(
                name: "ro");

            migrationBuilder.CreateTable(
                name: "box_folder",
                schema: "ro",
                columns: table => new
                {
                    BoxFolderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxFolderName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_box_folder", x => x.BoxFolderId);
                });

            migrationBuilder.CreateTable(
                name: "grade",
                schema: "ro",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Probability = table.Column<double>(type: "float", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grade", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "staff",
                schema: "ro",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StaffWages = table.Column<decimal>(type: "money", nullable: false),
                    StaffGender = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    StaffPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    StaffCode = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    StaffEntryTime = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    StaffPosition = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StaffState = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Area = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Details = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "userinfo",
                schema: "ao",
                columns: table => new
                {
                    UserInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserGender = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    UserNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserPwd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    HeadPortrait = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userinfo", x => x.UserInfoId);
                });

            migrationBuilder.CreateTable(
                name: "box_commodity",
                schema: "ro",
                columns: table => new
                {
                    BoxCommodityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CoverPhoto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    BoxFolderId = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_box_commodity", x => x.BoxCommodityId);
                    table.ForeignKey(
                        name: "FK_box_commodity_box_folder_BoxFolderId",
                        column: x => x.BoxFolderId,
                        principalSchema: "ro",
                        principalTable: "box_folder",
                        principalColumn: "BoxFolderId");
                });

            migrationBuilder.CreateTable(
                name: "box_commodity_detail",
                schema: "ro",
                columns: table => new
                {
                    CommdityDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComminfoName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ComminfoSpec = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ComminfoPrice = table.Column<decimal>(type: "money", nullable: false),
                    OfficiaPrice = table.Column<decimal>(type: "money", nullable: true),
                    ComminfoImg = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GradeId = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_box_commodity_detail", x => x.CommdityDetailId);
                    table.ForeignKey(
                        name: "FK_box_commodity_detail_grade_GradeId",
                        column: x => x.GradeId,
                        principalSchema: "ro",
                        principalTable: "grade",
                        principalColumn: "GradeId");
                });

            migrationBuilder.CreateTable(
                name: "login",
                schema: "ro",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_login_staff_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "ro",
                        principalTable: "staff",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateTable(
                name: "addressinfo",
                schema: "ao",
                columns: table => new
                {
                    AddressInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Province = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AddressDetails = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    UserInfoId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addressinfo", x => x.AddressInfoId);
                    table.ForeignKey(
                        name: "FK_addressinfo_userinfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalSchema: "ao",
                        principalTable: "userinfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "box_connect",
                schema: "ro",
                columns: table => new
                {
                    BoxCommoditiesBoxCommodityId = table.Column<int>(type: "int", nullable: false),
                    CommdityDetailsCommdityDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_box_connect", x => new { x.BoxCommoditiesBoxCommodityId, x.CommdityDetailsCommdityDetailId });
                    table.ForeignKey(
                        name: "FK_box_connect_box_commodity_BoxCommoditiesBoxCommodityId",
                        column: x => x.BoxCommoditiesBoxCommodityId,
                        principalSchema: "ro",
                        principalTable: "box_commodity",
                        principalColumn: "BoxCommodityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_box_connect_box_commodity_detail_CommdityDetailsCommdityDetailId",
                        column: x => x.CommdityDetailsCommdityDetailId,
                        principalSchema: "ro",
                        principalTable: "box_commodity_detail",
                        principalColumn: "CommdityDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "describetype",
                schema: "ro",
                columns: table => new
                {
                    DescribeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescContent = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CommdityDetailsCommdityDetailId = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_describetype", x => x.DescribeTypeId);
                    table.ForeignKey(
                        name: "FK_describetype_box_commodity_detail_CommdityDetailsCommdityDetailId",
                        column: x => x.CommdityDetailsCommdityDetailId,
                        principalSchema: "ro",
                        principalTable: "box_commodity_detail",
                        principalColumn: "CommdityDetailId");
                });

            migrationBuilder.CreateTable(
                name: "draw",
                schema: "ro",
                columns: table => new
                {
                    DrawId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommdityDetailId = table.Column<int>(type: "int", nullable: true),
                    UserInfoId = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_draw", x => x.DrawId);
                    table.ForeignKey(
                        name: "FK_draw_box_commodity_detail_CommdityDetailId",
                        column: x => x.CommdityDetailId,
                        principalSchema: "ro",
                        principalTable: "box_commodity_detail",
                        principalColumn: "CommdityDetailId");
                    table.ForeignKey(
                        name: "FK_draw_userinfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalSchema: "ao",
                        principalTable: "userinfo",
                        principalColumn: "UserInfoId");
                });

            migrationBuilder.CreateTable(
                name: "orderinfo",
                schema: "ao",
                columns: table => new
                {
                    OrderInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderState = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    ActualPrice = table.Column<decimal>(type: "money", nullable: false),
                    Freight = table.Column<decimal>(type: "money", nullable: false),
                    Channel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    PaymentTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeliverTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddressInfoId = table.Column<int>(type: "int", nullable: true),
                    DrawId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderinfo", x => x.OrderInfoId);
                    table.ForeignKey(
                        name: "FK_orderinfo_addressinfo_AddressInfoId",
                        column: x => x.AddressInfoId,
                        principalSchema: "ao",
                        principalTable: "addressinfo",
                        principalColumn: "AddressInfoId");
                    table.ForeignKey(
                        name: "FK_orderinfo_draw_DrawId",
                        column: x => x.DrawId,
                        principalSchema: "ro",
                        principalTable: "draw",
                        principalColumn: "DrawId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_addressinfo_UserInfoId",
                schema: "ao",
                table: "addressinfo",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_box_commodity_BoxFolderId",
                schema: "ro",
                table: "box_commodity",
                column: "BoxFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_box_commodity_detail_GradeId",
                schema: "ro",
                table: "box_commodity_detail",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_box_connect_CommdityDetailsCommdityDetailId",
                schema: "ro",
                table: "box_connect",
                column: "CommdityDetailsCommdityDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_describetype_CommdityDetailsCommdityDetailId",
                schema: "ro",
                table: "describetype",
                column: "CommdityDetailsCommdityDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_draw_CommdityDetailId",
                schema: "ro",
                table: "draw",
                column: "CommdityDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_draw_UserInfoId",
                schema: "ro",
                table: "draw",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_login_StaffId",
                schema: "ro",
                table: "login",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_orderinfo_AddressInfoId",
                schema: "ao",
                table: "orderinfo",
                column: "AddressInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_orderinfo_DrawId",
                schema: "ao",
                table: "orderinfo",
                column: "DrawId");

            migrationBuilder.CreateIndex(
                name: "IX_orderinfo_Order",
                schema: "ao",
                table: "orderinfo",
                column: "Order",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "box_connect",
                schema: "ro");

            migrationBuilder.DropTable(
                name: "describetype",
                schema: "ro");

            migrationBuilder.DropTable(
                name: "login",
                schema: "ro");

            migrationBuilder.DropTable(
                name: "orderinfo",
                schema: "ao");

            migrationBuilder.DropTable(
                name: "box_commodity",
                schema: "ro");

            migrationBuilder.DropTable(
                name: "staff",
                schema: "ro");

            migrationBuilder.DropTable(
                name: "addressinfo",
                schema: "ao");

            migrationBuilder.DropTable(
                name: "draw",
                schema: "ro");

            migrationBuilder.DropTable(
                name: "box_folder",
                schema: "ro");

            migrationBuilder.DropTable(
                name: "box_commodity_detail",
                schema: "ro");

            migrationBuilder.DropTable(
                name: "userinfo",
                schema: "ao");

            migrationBuilder.DropTable(
                name: "grade",
                schema: "ro");
        }
    }
}
