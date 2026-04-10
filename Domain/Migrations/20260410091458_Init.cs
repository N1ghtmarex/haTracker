using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "color",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    is_archive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_color", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "emoji",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    is_archive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_emoji", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task_type",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    is_archive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unit",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    short_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    is_archive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_unit", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    external_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    is_archive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<string>(type: "text", nullable: false),
                    task_type_id = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    emoji_id = table.Column<string>(type: "text", nullable: true),
                    color_id = table.Column<string>(type: "text", nullable: false),
                    tracking_type = table.Column<int>(type: "integer", nullable: false),
                    unit_id = table.Column<string>(type: "text", nullable: true),
                    target_value = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    is_archive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task", x => x.id);
                    table.ForeignKey(
                        name: "fk_task_color_color_id",
                        column: x => x.color_id,
                        principalTable: "color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_task_emoji_emoji_id",
                        column: x => x.emoji_id,
                        principalTable: "emoji",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_task_task_type_task_type_id",
                        column: x => x.task_type_id,
                        principalTable: "task_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_task_unit_unit_id",
                        column: x => x.unit_id,
                        principalTable: "unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_task_user_author_id",
                        column: x => x.author_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "completion",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    task_id = table.Column<string>(type: "text", nullable: false),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false),
                    current_value = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    is_archive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_completion", x => x.id);
                    table.ForeignKey(
                        name: "fk_completion_task_task_id",
                        column: x => x.task_id,
                        principalTable: "task",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_completion_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_color_id",
                table: "color",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_color_value",
                table: "color",
                column: "value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_completion_id",
                table: "completion",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_completion_task_id",
                table: "completion",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "ix_completion_user_id",
                table: "completion",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_emoji_id",
                table: "emoji",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_emoji_value",
                table: "emoji",
                column: "value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_task_author_id",
                table: "task",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "ix_task_color_id",
                table: "task",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "ix_task_emoji_id",
                table: "task",
                column: "emoji_id");

            migrationBuilder.CreateIndex(
                name: "ix_task_id",
                table: "task",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_task_task_type_id",
                table: "task",
                column: "task_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_task_unit_id",
                table: "task",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "ix_task_type_id",
                table: "task_type",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_unit_id",
                table: "unit",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_external_user_id",
                table: "user",
                column: "external_user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_id",
                table: "user",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_username",
                table: "user",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "completion");

            migrationBuilder.DropTable(
                name: "task");

            migrationBuilder.DropTable(
                name: "color");

            migrationBuilder.DropTable(
                name: "emoji");

            migrationBuilder.DropTable(
                name: "task_type");

            migrationBuilder.DropTable(
                name: "unit");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
