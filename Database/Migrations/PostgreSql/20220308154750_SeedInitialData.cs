using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Levi9.Cinema.Api.Database.Migrations.PostgreSql
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Cover", "Rating", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("06279b27-fb0c-4068-9316-a11d6e4fb1a8"), "https://www.slashfilm.com/wp/wp-content/images/International-Avengers-Age-of-Ultron-Poster-700x989.jpg", 0f, 0, "The Avengers: Age of Ultron movie poster" },
                    { new Guid("7447d117-9c70-4b2e-af65-fc12e8634770"), "https://m.media-amazon.com/images/I/713KEd-8jyL._AC_SL1500_.jpg", 0f, 0, "Harry Potter and The Philosopher's Stone" },
                    { new Guid("a51806e9-1f90-49fb-b17d-fbde83e5792a"), "https://media.vanityfair.com/photos/592592596736887ada186bcd/master/w_1600%2Cc_limit/spider-man-homecoming-SMH_DOM_Online_FNL_1SHT_3DRD3DIMX_AOJ_300dpi_01_rgb.jpg", 0f, 0, "Spider-man: Home Coming" },
                    { new Guid("c1ee1710-bc34-48be-aa3a-b060750dbc9d"), "https://lumiere-a.akamaihd.net/v1/images/swtlj_imax_oversize_1-sht_v6_lg_d4edae12.jpeg?region=0%2C0%2C827%2C1200", 0f, 0, "Star Wars: The Last Jedi" },
                    { new Guid("fe9ad1d6-b24f-4861-85ff-8a45e7bd92d0"), "https://m.media-amazon.com/images/M/MV5BNDYxNjQyMjAtNTdiOS00NGYwLWFmNTAtNThmYjU5ZGI2YTI1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_FMjpg_UX1000_.jpg", 0f, 0, "The Avengers" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("06279b27-fb0c-4068-9316-a11d6e4fb1a8"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7447d117-9c70-4b2e-af65-fc12e8634770"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("a51806e9-1f90-49fb-b17d-fbde83e5792a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c1ee1710-bc34-48be-aa3a-b060750dbc9d"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("fe9ad1d6-b24f-4861-85ff-8a45e7bd92d0"));
        }
    }
}
