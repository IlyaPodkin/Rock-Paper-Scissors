using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrpcService.Migrations
{
    /// <inheritdoc />
    public partial class CreatingTablesDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GameTransactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sender_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reseiver_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    transactio_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTransactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_GameTransaction_ReseiverUser",
                        column: x => x.reseiver_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameTransaction_SenderUser",
                        column: x => x.sender_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchHistory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    second_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bet_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    winner_id = table.Column<Guid>(type: "uuid", nullable: true),
                    match_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchHistory", x => x.id);
                    table.ForeignKey(
                        name: "FK_MatchHistory_FirstUserId",
                        column: x => x.first_user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchHistory_SecondUserId",
                        column: x => x.second_user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchHistory_WinnerId",
                        column: x => x.winner_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameTransactions_reseiver_id",
                table: "GameTransactions",
                column: "reseiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_GameTransactions_sender_id",
                table: "GameTransactions",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchHistory_first_user_id",
                table: "MatchHistory",
                column: "first_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchHistory_second_user_id",
                table: "MatchHistory",
                column: "second_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchHistory_winner_id",
                table: "MatchHistory",
                column: "winner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTransactions");

            migrationBuilder.DropTable(
                name: "MatchHistory");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
