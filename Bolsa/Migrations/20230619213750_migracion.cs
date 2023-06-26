using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendBolsaDeTrabajoUTN.Migrations
{
    /// <inheritdoc />
    public partial class migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Careers",
                columns: table => new
                {
                    CareerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CareerName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CareerAbbreviation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CareerType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CareerTotalSubjects = table.Column<int>(type: "int", nullable: false),
                    CareerIsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careers", x => x.CareerId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Knowledges",
                columns: table => new
                {
                    KnowledgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KnowledgeIsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowledges", x => x.KnowledgeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserEmail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserIsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NameAdmin = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyCUIT = table.Column<long>(type: "bigint", nullable: true),
                    CompanyLine = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyLocation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyPostalCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyPhone = table.Column<long>(type: "bigint", nullable: true),
                    CompanyWebPage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyPersonalName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyPersonalSurname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyPersonalJob = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyPersonalPhone = table.Column<long>(type: "bigint", nullable: true),
                    CompanyRelationContact = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyPendingConfirmation = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    File = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AltEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentNumber = table.Column<int>(type: "int", nullable: true),
                    CUIL_CUIT = table.Column<long>(type: "bigint", nullable: true),
                    Birth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Sex = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CivilStatus = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FamilyStreet = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FamilyStreetNumber = table.Column<int>(type: "int", nullable: true),
                    FamilyStreetLetter = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FamilyFloor = table.Column<int>(type: "int", nullable: true),
                    FamilyDepartment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FamilyCountry = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FamilyProvince = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FamilyLocation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FamilyPersonalPhone = table.Column<int>(type: "int", nullable: true),
                    FamilyOtherPhone = table.Column<int>(type: "int", nullable: true),
                    PersonalStreet = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalStreetNumber = table.Column<int>(type: "int", nullable: true),
                    PersonalStreetLetter = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalFloor = table.Column<int>(type: "int", nullable: true),
                    PersonalDepartment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalCountry = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalProvince = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalLocation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalPersonalPhone = table.Column<int>(type: "int", nullable: true),
                    PersonalOtherPhone = table.Column<int>(type: "int", nullable: true),
                    Specialty = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovedSubjectsQuantity = table.Column<int>(type: "int", nullable: true),
                    SpecialtyPlan = table.Column<int>(type: "int", nullable: true),
                    CurrentStudyYear = table.Column<int>(type: "int", nullable: true),
                    StudyTurn = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AverageMarksWithPostponement = table.Column<int>(type: "int", nullable: true),
                    AverageMarksWithoutPostponement = table.Column<int>(type: "int", nullable: true),
                    CollegeDegree = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondaryDegree = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observations = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CVFiles",
                columns: table => new
                {
                    CVId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    File = table.Column<byte[]>(type: "longblob", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CVIsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVFiles", x => x.CVId);
                    table.ForeignKey(
                        name: "FK_CVFiles_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OfferTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OfferSpecialty = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OfferDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    OfferIsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offers_Users_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentCareer",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CareerId = table.Column<int>(type: "int", nullable: false),
                    StudentCareerIsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCareer", x => new { x.StudentId, x.CareerId });
                    table.ForeignKey(
                        name: "FK_StudentCareer_Careers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "Careers",
                        principalColumn: "CareerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCareer_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentKnowledge",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    KnowledgeId = table.Column<int>(type: "int", nullable: false),
                    StudentKnowledgeIsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentKnowledge", x => new { x.UserId, x.KnowledgeId });
                    table.ForeignKey(
                        name: "FK_StudentKnowledge_Knowledges_KnowledgeId",
                        column: x => x.KnowledgeId,
                        principalTable: "Knowledges",
                        principalColumn: "KnowledgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentKnowledge_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentOffer",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    StudentOfferIsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOffer", x => new { x.OfferId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentOffer_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentOffer_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "CareerId", "CareerAbbreviation", "CareerIsActive", "CareerName", "CareerTotalSubjects", "CareerType" },
                values: new object[,]
                {
                    { 1, "TUP", true, "Tecnicatura Universitaria en Programación", 20, "Programación" },
                    { 2, "TUHS", true, "Tecnicatura Universitaria en Higiene y Seguridad", 15, "Seguridad" }
                });

            migrationBuilder.InsertData(
                table: "Knowledges",
                columns: new[] { "KnowledgeId", "KnowledgeIsActive", "Level", "Type" },
                values: new object[,]
                {
                    { 1, true, "Advanced", "Programming" },
                    { 2, true, "Intermediate", "Design" },
                    { 3, true, "Beginner", "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CompanyAddress", "CompanyCUIT", "CompanyLine", "CompanyLocation", "CompanyName", "CompanyPendingConfirmation", "CompanyPersonalJob", "CompanyPersonalName", "CompanyPersonalPhone", "CompanyPersonalSurname", "CompanyPhone", "CompanyPostalCode", "CompanyRelationContact", "CompanyWebPage", "Password", "UserEmail", "UserIsActive", "UserName", "UserType" },
                values: new object[,]
                {
                    { 1, "D 15", 20447575751L, "Textil", "Rosario", "Microsoft", true, "Gerente", "Juan Carlos", 22L, "Peralta", 341367898L, "2000", "Vacio", "web", "d404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db", "mail1@gmai.com", true, "Company 1", "Company" },
                    { 2, "E 18", 20445556661L, "Textil", "Rosario", "Apple", true, "Gerente", "Juan Esteban", 25L, "Peralta", 341334455L, "2000", "Vacio", "web2", "7e2feac95dcd7d1df803345e197369af4b156e4e7a95fcb2955bdbbb3a11afd8bb9d35931bf15511370b18143e38b01b903f55c5ecbded4af99934602fcdf38c", "mail2@gmai.com", true, "Company 2", "Company" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AltEmail", "ApprovedSubjectsQuantity", "AverageMarksWithPostponement", "AverageMarksWithoutPostponement", "Birth", "CUIL_CUIT", "CivilStatus", "CollegeDegree", "CurrentStudyYear", "DocumentNumber", "DocumentType", "FamilyCountry", "FamilyDepartment", "FamilyFloor", "FamilyLocation", "FamilyOtherPhone", "FamilyPersonalPhone", "FamilyProvince", "FamilyStreet", "FamilyStreetLetter", "FamilyStreetNumber", "File", "Name", "Observations", "Password", "PersonalCountry", "PersonalDepartment", "PersonalFloor", "PersonalLocation", "PersonalOtherPhone", "PersonalPersonalPhone", "PersonalProvince", "PersonalStreet", "PersonalStreetLetter", "PersonalStreetNumber", "SecondaryDegree", "Sex", "Specialty", "SpecialtyPlan", "StudyTurn", "Surname", "UserEmail", "UserIsActive", "UserName", "UserType" },
                values: new object[,]
                {
                    { 3, "manuelAlt@gmail.com", 10, 6, 7, new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 20445556661L, "Casado", "Sistemas", 2, 44555666, "DNI", "Argentina", "4B", 2, "Ciudad Autónoma de Buenos Aires", 987654321, 123456789, "Buenos Aires", "Calle Principal", "A", 123, 12345, "Manuel", "Fanatico de linux", "2757cb3cafc39af451abb2697be79b4ab61d63d74d85b0418629de8c26811b529f3f3780d0150063ff55a2beee74c4ec102a2a2731a1f1f7f10d473ad18a6a87", "Argentina", "Depto. 2", 1, "Córdoba Capital", 123456789, 987654321, "Córdoba", "Avenida Principal", "B", 456, "Completo", "Masculino", "Sistemas", 2002, "Tarde", "Ibarbia", "manuel@gmail.com", true, "string", "Student" },
                    { 4, "lucianoAlt@gmail.com", 10, 6, 7, new DateTime(1800, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 203334445551L, "Soltero", "Sistemas", 2, 33444555, "DNI", "Argentina", "5B", 22, "Rosario", 987654321, 123456789, "Santa Fe", "Calle asdasd", "AA", 12, 12346, "Luciano", "Fanatico de linux", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", "Argentina", "Depto. 2", 1, "Córdoba Capital", 123456789, 987654321, "Córdoba", "Avenida Principal", "B", 456, "Completo", "Masculino", "Sistemas", 2002, "Tarde", "Solari", "luciano@gmail.com", true, "lucianoS", "Student" },
                    { 5, "santiagoAlt@gmail.com", 10, 6, 7, new DateTime(2005, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 20556667771L, "Soltero", "Sistemas", 2, 55666777, "DNI", "Argentina", "5B", 22, "Rosario", 987654321, 123456789, "Santa Fe", "Calle asdasd", "AA", 12, 12347, "Santiago", "Fanatico de linux", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", "Argentina", "Depto. 2", 1, "Córdoba Capital", 123456789, 987654321, "Córdoba", "Avenida Principal", "B", 456, "Completo", "Masculino", "Sistemas", 2002, "Tarde", "Caso", "santiago@gmail.com", true, "santiagoC", "Student" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "NameAdmin", "Password", "UserEmail", "UserIsActive", "UserName", "UserType" },
                values: new object[] { 6, "AdminPepe", "d404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db", "luciano3924@gmail.com", true, "admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CompanyId", "CreatedDate", "OfferDescription", "OfferIsActive", "OfferSpecialty", "OfferTitle" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conocimientos avanzados en SQL", true, "SQL", "Analista de datos" },
                    { 2, 1, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conocimientos avanzados en entorno .NET", true, ".NET", "Desarrollador Backend" }
                });

            migrationBuilder.InsertData(
                table: "StudentCareer",
                columns: new[] { "CareerId", "StudentId", "StudentCareerIsActive" },
                values: new object[,]
                {
                    { 1, 4, true },
                    { 2, 5, true }
                });

            migrationBuilder.InsertData(
                table: "StudentKnowledge",
                columns: new[] { "KnowledgeId", "UserId", "StudentKnowledgeIsActive" },
                values: new object[,]
                {
                    { 2, 3, true },
                    { 1, 4, true }
                });

            migrationBuilder.InsertData(
                table: "StudentOffer",
                columns: new[] { "OfferId", "StudentId", "StudentOfferIsActive" },
                values: new object[,]
                {
                    { 1, 4, true },
                    { 2, 5, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CVFiles_StudentId",
                table: "CVFiles",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CompanyId",
                table: "Offers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCareer_CareerId",
                table: "StudentCareer",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentKnowledge_KnowledgeId",
                table: "StudentKnowledge",
                column: "KnowledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOffer_StudentId",
                table: "StudentOffer",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVFiles");

            migrationBuilder.DropTable(
                name: "StudentCareer");

            migrationBuilder.DropTable(
                name: "StudentKnowledge");

            migrationBuilder.DropTable(
                name: "StudentOffer");

            migrationBuilder.DropTable(
                name: "Careers");

            migrationBuilder.DropTable(
                name: "Knowledges");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
