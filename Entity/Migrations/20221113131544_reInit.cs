using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    public partial class reInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<bool>(type: "bit", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    RateCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    TotalRate = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.UserId, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider });
                    table.ForeignKey(
                        name: "FK_UserToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMap",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMap", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagMap_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMap_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("44fcbdd6-262c-408f-927a-88a3d39b482d"), "Laliga", "Laliga", "la-liga" },
                    { new Guid("6dedb11c-5d41-48f3-81dd-d3d5ff0c7a3e"), "Bundesliga", "Bundesliga", "bundesliga" },
                    { new Guid("7109d8d6-464d-4ff9-bfbb-62c83c9788c3"), "Transfer News", "Transfer News", "transfer-news" },
                    { new Guid("8ee8e5b7-ff33-460d-8a5c-2385518a2845"), "Serie A", "Serie A", "serie-a" },
                    { new Guid("af301972-f954-4319-ad44-3b85f5294e61"), "Champions League", "Champions League", "champions-league" },
                    { new Guid("fd264eff-b43e-4a61-84a2-63dc29ce38cb"), "Premier League", "Premier League", "premier-league" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("46118fe1-2d15-4c5b-82f9-bc2f19b4a7c3"), "7e877db7-2b78-4ff0-b66d-51de262a4d42", "Blog Owner", "BLOG OWNER" },
                    { new Guid("81bd671f-2cb9-40e3-9245-5b37135b1bab"), "433f9919-e78f-447a-9650-63c4cc973422", "User", "USER" },
                    { new Guid("bf483ecf-7107-420a-a316-712160ae7e59"), "710acf93-de54-4cd3-8cb9-8393f54a0ced", "Contributor", "CONTRIBUTOR" }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "Count", "Decription", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("3c172200-28d2-4758-97df-d595384eb4f5"), 3, "la-liga", "la-liga", "la-liga" },
                    { new Guid("46b3e11a-7caa-4bbb-bca3-254baaed7c4f"), 1, "Premier League", "epl", "epl" },
                    { new Guid("4fa08da5-df70-42c8-96b2-7ad93986c3dd"), 3, "tot", "tot", "tot" },
                    { new Guid("559bfae1-02f5-4dcf-b8fe-76d3313d3894"), 3, "lei", "lei", "lei" },
                    { new Guid("5c717df9-2347-4c67-be32-3474ccebc287"), 3, "serie-a", "serie-a", "serie-a" },
                    { new Guid("6486ff2a-516c-4586-9668-0dfcf73027fb"), 3, "chel", "chel", "chel" },
                    { new Guid("9257978f-8a06-49bb-ac8f-7b4d35640dbf"), 3, "bundesliga", "bundesliga", "bundesliga" },
                    { new Guid("963eac23-6a1f-46fc-bc67-49b1ebacd3ed"), 3, "ars", "ars", "ars" },
                    { new Guid("a11e5689-b978-411a-aeae-5d427b4a80ef"), 3, "real", "real", "real" },
                    { new Guid("ae54c887-7a64-40eb-9d46-5c828491e348"), 3, "bay", "bay", "bay" },
                    { new Guid("c51319df-22b7-4470-ab83-b559a8f5ee19"), 3, "mc", "mc", "mc" },
                    { new Guid("ebf175db-f1ae-4989-83b7-a1c828bcef8c"), 2, "Transfer News", "transfer", "transfer" },
                    { new Guid("ed9fda2f-8e59-443d-8a79-2991366b27b9"), 3, "liv", "liv", "liv" },
                    { new Guid("f3f34549-daa6-4556-aec4-01ecc41c7182"), 3, "mu", "mu", "mu" },
                    { new Guid("f562d1b0-02db-4c1c-a4db-3e51c250f8a3"), 3, "champions-league", "champions-league", "champions-league" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AboutMe", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("96513711-41f4-45d7-b234-769c2c402ec8"), "Good", 0, "01f2d6be-52d2-4bc1-b167-ea54da5c57f6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "brucelee2@gmail.com", false, "Bruce Lee 2", false, null, null, "BRUCELEE2", "AQAAAAEAACcQAAAAEBDOY6AQaGsFeOfA5Dss23Vhm5fvjmWkV/MeDJdUSPMkqYNxLqGlFBltQKlrzXdnbA==", null, false, "61065969-bf1a-48bd-bc4d-1dd99f1d54b2", false, "brucelee2" },
                    { new Guid("ab517e6c-0ce4-485b-aace-de9a21b8d01b"), "Good", 0, "f2cfdc98-1293-448b-8ea9-541f3e143fc8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "brucelee3@gmail.com", false, "Bruce Lee 3", false, null, null, "BRUCELEE3", "AQAAAAEAACcQAAAAEPsSD0QbOEd23E23MCeeN7AMPnU9ZhsWMcqhC40x3T1jDKRE+y+5ZFuuSuQEzO2tvA==", null, false, "8bcc8ad9-f07f-4cda-b20c-98c21ce70dc8", false, "brucelee3" },
                    { new Guid("e3b5d306-49b2-46b2-a345-fc9d644f6700"), "Good", 0, "c289feb5-f62a-49b3-85e4-27311e45b870", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "brucelee@gmail.com", false, "Bruce Lee", false, null, null, "BRUCELEE", "AQAAAAEAACcQAAAAEO7K25flepdptFpJzbZZfRDM3k7tz6ejg4jbxejKd4ag5wBQ05B0rnyL3o8uWZtxEQ==", null, false, "7e5ca526-afb9-43e4-9532-832b775de544", false, "brucelee" }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "CategoryId", "Modified", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("2c7f0720-cdd9-4a47-818f-25fed485ffbf"), new Guid("6dedb11c-5d41-48f3-81dd-d3d5ff0c7a3e"), false, "Bayern Munich made an intimidating start to their latest Bundesliga title defence by smashing Europa League holders Eintracht Frankfurt 6-1 at Deutsche Bank Park on Friday night.Julian Nagelsmann's side finished eight points clear of closest competitors Borussia Dortmund to win the league last season, while Frankfurt weren't in the conversation despite their success in Europe.Bayern were 2 - 0 up inside ten minutes thanks to strikes from Joshua Kimmich and Benjamin Pavard and added another three before half time.Sadio Mane struck for the first time in the Bundesliga by heading in from Serge Gnabry's flick before youngster Jamal Musiala tapped in from close range. Gnabry soon sent the two teams into the interval with the game's fifth strike.Manuel Neuer did offer Frankfurt a crumb of comfort, dithering on the ball for too long and allowing Randal Kolo Muani to nip in and score a consolation on debut, but that was as good as it ever got for the hosts.Musiala later scrambled through the hosts' defence to slide in Bayern's sixth, topping off an impressive night's work for the reigning German champions.", new DateTime(2022, 8, 13, 15, 8, 8, 0, DateTimeKind.Unspecified), true, 2, "Bayern Munich made an intimidating start to their latest Bundesliga title defence by smashing Europa League holders Eintracht Frankfurt 6-1 at Deutsche Bank Park on Friday night.", "Eintracht Frankfurt 1-6 Bayern Munich: Champions make imposing start to Bundesliga season", 9, "eintracht-frankfurt-1-6-bayern-munich-champions-make-imposing-start-to-bundeslig", 900 },
                    { new Guid("3cb9eb48-216f-41f5-9752-e2c36a2f1c13"), new Guid("7109d8d6-464d-4ff9-bfbb-62c83c9788c3"), false, "Bayern Munich have confirmed the signing of Sadio Mane from Liverpool on a three-year deal.Mane departs Anfield after six glorious years in which he won every honour available to him,including the Champions League in 2019 and Premier League one year later.The forward had long been expected to leave this summer with Bayern kicking off negotiations towards the end of last season.Eventually a deal was struck and 90min understands that Mane agreed to waive some potential future earnings to help smooth negotiations along.I'm really happy to finally be at FC Bayern in Munich, Mane said. We spoke a lot and I felt big interest from this great club right from the beginning, so for me there were no doubts. Its the right time for this challenge.I want to achieve a lot with this club, in Europe too. During my time in Salzburg I watched a lot of Bayern games - I really like this club!Bayern CEO Oliver Kahn added: We are delighted that weve been able to recruit Sadio Mane for FC Bayern. With his outstanding performances and his great successes at the highest international level over many years, there are very few players like him in the world.We re sure that Sadio Mane will delight our fans in the coming years with his spectacular style of play. He s ambitious and eager to win more titles. This package is very strong. With players like him at FC Bayern, all the biggest goals are possible.", new DateTime(2022, 7, 24, 5, 28, 8, 0, DateTimeKind.Unspecified), true, 2, "Bayern Munich have confirmed the signing of Sadio Mane from Liverpool on a three-year deal.", "Bayern Munich confirm Sadio Mane signing", 9, "bayern-munich-confirm-sadio-mane-signing", 900 },
                    { new Guid("42b20213-e508-4220-b509-5cf176ee32ad"), new Guid("af301972-f954-4319-ad44-3b85f5294e61"), false, "The road to the 2022/23 Champions League has started with some of the earliest qualifying matches being scheduled.A large number of Europe's elite clubs have qualified already through league position, though a fair few teams can still book their spot in next season's competition by winning qualifiers throughout the summer.Here are all the dates you need in the build - up to the 2022 / 23 Champions League.", new DateTime(2022, 7, 13, 8, 8, 8, 0, DateTimeKind.Unspecified), true, 2, "The road to the 2022/23 Champions League has started with some of the earliest qualifying matches being scheduled.", "2022/23 Champions League: Qualification dates, draws & schedule", 9, "2022-23-champions-league-qualification-dates-draws-schedule", 800 },
                    { new Guid("472942a5-a3ad-4ef0-be6f-a73ae48028e4"), new Guid("7109d8d6-464d-4ff9-bfbb-62c83c9788c3"), false, "Comfortably the two best sides in England went punch for punch on the pitch last season, and Manchester City and Liverpool are now doing the same off it through the respective arrivals of Erling Haaland and Darwin Nunez, with neither Pep Guardiola or Jurgen Klopp willing to give each other an inch for fear of the other taking a mile in what looks set once again to be a two-horse race in the Premier League.Manchester City signed a big,fast,prolific central striker in an attempt to adapt,develop or at least offer an alternative to their style of football to steal a march on Liverpool.Only for Liverpool to respond in kind, signing their own big, fast, prolific central striker.Straight comparisons between the pair are reductive given they've played for different clubs with different players in different divisions. What we do know is that they can score goals and – given the competition to sign Haaland and the £85m needed for Nunez – City and Liverpool have little doubt they will continue to do so.One point was all that could separate City and Liverpool last season, with final day drama adding to what was already one of the great title races in Premier League history.Confirmation of their marquee summer signings leads to questions as to whether either has given one team the edge, or if Nunez and Haaland will instead cancel each other out, with respective one per cent improvements simply maintaining the extraordinarily well - matched dominance of these two wonderful football teams.", new DateTime(2022, 7, 9, 16, 48, 8, 0, DateTimeKind.Unspecified), true, 2, "Comfortably the two best sides in England went punch for punch on the pitch last season, and Manchester City and Liverpool are now doing the same off it through the respective arrivals of Erling Haaland and Darwin Nunez, with neither Pep Guardiola or Jurgen Klopp willing to give each other an inch for fear of the other taking a mile in what looks set once again to be a two-horse race in the Premier League.", "Liverpool forced into Darwin Nunez move as Erling Haaland raises Man City ceiling", 9, "liverpool-forced-into-darwin-nunez-move-as-erling-haaland-raises-man-city-ceiling", 600 },
                    { new Guid("54606ea0-ec4f-4ec4-9181-8153e1a2332e"), new Guid("fd264eff-b43e-4a61-84a2-63dc29ce38cb"), false, "Liverpool midfielder Thiago Alcantara will be out of action for up to six weeks because of injury, sources have told ESPN.The Spain international limped off the pitch early in the second half with a suspected hamstring strain during Saturday's 2-2 Premier League draw at Fulham.Thiago's injury comes at a bad time for Liverpool, who are still without midfielders Alex Oxlade-Chamberlain and Curtis Jones.This isn't a good situation. I don't like it at all.We have to see how we react on that,but for sure not panic,  Liverpool coach Jurgen Klopp said.The transfer window closes on Sept. 1 but Klopp indicated Liverpool will not make a rash decision regarding signing new players.", new DateTime(2022, 8, 13, 20, 8, 8, 0, DateTimeKind.Unspecified), true, 2, "Liverpool midfielder Thiago Alcantara will be out of action for up to six weeks because of injury, sources have told ESPN.", "Liverpool's Thiago Alcantara out for up to six weeks - sources", 9, "liverpools-thiago-alcantara-out-for-up-to-six-weeks-sources", 800 },
                    { new Guid("5e08bde8-c46b-4df0-a74e-66acecaf62a8"), new Guid("8ee8e5b7-ff33-460d-8a5c-2385518a2845"), false, "Roma striker Tammy Abraham insists he has never looked back following his departure from Chelsea last summer.The Blues academy graduate was offloaded in a £34m deal to help make room for the signing of Romelu Lukaku, who has since returned to Inter on a season - long loan after his £97.5m arrival yielded just eight Premier League goals.While Lukaku was struggling, Abraham settled in quickly at Roma and ended his debut season with 27 goals in 53 games in all competitions, helping them to Europa Conference League glory.The numbers speak for themselves, and Abraham recently told Corriere dello Sport that he has zero regrets about his departure from Chelsea.", new DateTime(2022, 8, 10, 8, 8, 8, 0, DateTimeKind.Unspecified), true, 2, "Roma striker Tammy Abraham insists he has never looked back following his departure from Chelsea last summer.", "Tammy Abraham insists he has 'no regrets' over Chelsea departure", 9, "tammy-abraham-insists-he-has-no-regrets-over-chelsea-departure", 800 },
                    { new Guid("70844495-31db-43d2-b5b0-ce2e2da2ccfa"), new Guid("7109d8d6-464d-4ff9-bfbb-62c83c9788c3"), false, "Tottenham are closing in on the signing of versatile Inter winger Ivan Perisic on a two-year deal, 90min understands.The 33 - year - old is out of contract at San Siro this summer and has long been linked with a move away from the club.Perisic has previously worked with Tottenham head coach Antonio Conte at Inter,winning the Serie A title under him,and 90min has learned that a reunion in north London is close to completion.Indeed,sources have told 90min that Perisic,who famously scored in Croatia's 2-1 win over England in the 2018 World Cup semi-final, has agreed a two-year deal and will undergo a medical next week.He also fielded offers from Chelsea and Juventus this summer, as well as a bid from the Nerazzurri to extend his contract,but the chance to pair up with Conte - who confirmed to the club in a meeting in Turin that he intends to remain in charge despite links with PSG - appears to have been too good of an opportunity to turn down.", new DateTime(2022, 8, 11, 11, 8, 8, 0, DateTimeKind.Unspecified), true, 2, "Tottenham are closing in on the signing of versatile Inter winger Ivan Perisic on a two-year deal", "Tottenham close to signing Ivan Perisic from Inter", 9, "tottenham-close-to-signing-ivan-perisic-from-inter", 800 },
                    { new Guid("7e8045c8-c6da-40c0-81bf-4fe0be6c730b"), new Guid("6dedb11c-5d41-48f3-81dd-d3d5ff0c7a3e"), false, "Bayern Munich forward Sadio Mane has claimed that his new employers would beat former side Liverpool if the two faced off in the Champions League.Bayern have bested Liverpool just once in the pair's nine meetings and most recently fell 3-1 at the Allianz Arena in March 2019, a game which featured two goals from Mane.The Segenal star's first strike saw him turn Manuel Neuer inside out before firing into the back of the net, with Mane later describing it as one of his two favourite goals from his time with Liverpool.In the Bundesliga newsletter,Mane was asked whether he would still describe his goal against Bayern as his favourite,and he confessed that his new relationship with Neuer has seen him demote the strike to second.I said maybe my favourite but now I would say second favourite goal, not my first, because he's my team-mate, Mane laughed. No, I'm joking… of course, I think it was a good goal, kind of a good goal. We had a good game.This is behind us. If we re going to meet again, of course as Bayern Munich wd beat Liverpool.", new DateTime(2022, 8, 5, 8, 8, 8, 0, DateTimeKind.Unspecified), true, 2, "Bayern Munich forward Sadio Mane has claimed that his new employers would beat former side Liverpool if the two faced off in the Champions League.", "Sadio Mane: 'Of course' Bayern Munich would beat Liverpool", 9, "sadio-mane-of-course-bayern-munich-would-beat-liverpool", 600 },
                    { new Guid("82a43557-d760-4e5e-88c0-4835f36cfb17"), new Guid("fd264eff-b43e-4a61-84a2-63dc29ce38cb"), false, "Tottenham Hotspur underlined their credentials as a team capable of a Premier League title challenge with a confident 4-1 defeat of Southampton to get their campaign up and running on Saturday.The hosts fell behind to a James Ward - Prowse volley in the 12th minute but dominated throughout with goals by Ryan Sessegnon,Eric Dier and Dejan Kulusevski sealing the win.Southampton's lead lasted only nine minutes before Sessegnon powered a header past Southampton's Premier League debutant keeper Gavin Bazunu from Kulusevski's cross.", new DateTime(2022, 8, 13, 8, 8, 8, 0, DateTimeKind.Unspecified), true, 2, "Tottenham Hotspur underlined their credentials as a team capable of a Premier League title challenge with a confident 4-1 defeat of Southampton to get their campaign up and running on Saturday.", "Tottenham crush Southampton for impressive opening win", 10, "tottenham-crush-southampton-for-impressive-opening-win", 1000 },
                    { new Guid("90086993-0826-437c-9aee-993939c11a5e"), new Guid("af301972-f954-4319-ad44-3b85f5294e61"), false, "Manchester City chief executive Ferran Soriano has insisted that the is ‘not obsessed’ with winning the Champions League but claims Real Madrid were ‘a bit lucky’ last season.Real lifted their 14th European crown in May after beating Liverpool in the final.They had already beaten City,Chelsea and Paris Saint - Germain in previous knockout rounds and needed to come from behind in all three ties in order to progress.Discussing Real’s success as well as his own club’s ambitions,Soriano told the Dr.Football podcast: “The Champions League is a trophy that we want,but we know that it is subject to a bit of luck and we are not obsessed.“People talk today about the success that Madrid have had in recent years,and I think it would be fair to say that they were a bit lucky.Perhaps I could say that they deserved to lose against PSG,against Chelsea,against us or against Liverpool.”", new DateTime(2022, 6, 25, 23, 8, 8, 0, DateTimeKind.Unspecified), true, 2, "Manchester City chief executive Ferran Soriano has insisted that the is ‘not obsessed’ with winning the Champions League but claims Real Madrid were ‘a bit lucky’ last season.", "Man City chief executive claims Real Madrid were 'lucky' in Champions League", 9, "man-city-chief-executive-claims-real-madrid-were-lucky-in-champions-league", 700 },
                    { new Guid("94475a71-ad8e-438f-b917-3c4a667f44ef"), new Guid("fd264eff-b43e-4a61-84a2-63dc29ce38cb"), false, "Oddsmakers have pegged the quest for the Premier League title as a two-horse race, with defending-champion Manchester City and Liverpool separated from the pack.Man City,who have won four of the past five EPL titles,are the odds favorite to win it again,listed at - 165 at Caesars Sportsbooks.Liverpool,last season's runner-ups, are +200.The gap between the two top clubs and the rest of the table is significant,according to oddsmakers.Man City and Liverpool are the only two teams with single - digit odds.Tottenham,at + 1,400,and Chelsea,at + 1,600,are next but are a ways down oddsboards.Tottenham,however,have attracted the most bets and are the most wagered to win the league title at Caesars Sportsbook,but it'll be a tall task to unseat Man City.Man City added elite striker Erling Haaland in the offseason,bolstering Pep Guardiola's already potent roster that posted 93 points en route to last years title.It was the sixth - most points in league history.Liverpool,though,finished just one point behind and notched a victory over Man City last week in the FA Community Shield.Arsenal,who kick off the season Friday against Crystal Palace,are + 2,800,and Manchester United are + 3,500.Man United's preseason title odds are the longest they've been in over a decade,according to sports betting archive SportsOddsHistory.com.Bournemouth and Fulham,at 1,500 - 1 and 1,000 - 1 respectively,are the longest shots on the board at Caesars Sportsbook.", new DateTime(2022, 8, 12, 8, 8, 8, 0, DateTimeKind.Unspecified), true, 2, "Oddsmakers have pegged the quest for the Premier League title as a two-horse race, with defending-champion Manchester City and Liverpool separated from the pack.", "Man City and Liverpool ahead of the chasing pack in Premier League title race, oddsmakers say", 9, "man-city-and-liverpool-ahead-of-the-chasing-pack-in-premier-league-title-race-od", 800 },
                    { new Guid("bf180548-f7d9-42b8-896d-ab6fc4ddcde4"), new Guid("8ee8e5b7-ff33-460d-8a5c-2385518a2845"), false, "Paulo Dybala has denied that money played a role in his Juventus departure, with the new Roma forward claiming that he exited for footballing reasons.Back in March it was announced that Dybala would be leaving Juve at the end of his contract this summer and he had seemed set to join Inter,until I Giallorossi swooped in to secure his services.The Argentine was unveiled as a Roma player on Tuesday and,during a press conference,he opened up on the process of departing the Allianz Stadium.I think the director [Maurizio] Arrivabene was very clear in his statements: we had an agreement to sign in October, then [the club] asked to wait, he explained.", new DateTime(2022, 7, 13, 8, 8, 8, 0, DateTimeKind.Unspecified), true, 2, "Paulo Dybala has denied that money played a role in his Juventus departure, with the new Roma forward claiming that he exited for footballing reasons.", "Paulo Dybala explains why he left Juventus for Roma", 9, "paulo-dybala-explains-why-he-left-juventus-for-roma", 700 },
                    { new Guid("c23d7677-ab19-4143-810c-4f7bef4cca87"), new Guid("7109d8d6-464d-4ff9-bfbb-62c83c9788c3"), false, "Bayern Munich CEO Oliver Kahn has this time declined to discuss a transfer for Tottenham striker Harry Kane.The former goalkeeper recently described Kane as a 'dream of the future', while Bayern boss Julian Naglesmann has also gone public with his admiration of the striker - prompting a frustrated response from Spurs boss Antonio Conte.Seemingly concerned about upsetting Conte once again, Kahn declined to get drawn into a conversation about Kane when asked for an update on Bayern's interest.I can just say that Harry Kane is an outstanding striker who is now under contract at Tottenham, Kahn told Bild.Conte has described Bayern's interest as 'only rumours' and reiterated the club's desire to keep Kane around for the foreseeable future.", new DateTime(2022, 8, 12, 14, 10, 8, 0, DateTimeKind.Unspecified), true, 2, "Bayern Munich CEO Oliver Kahn has this time declined to discuss a transfer for Tottenham striker Harry Kane.", "Harry Kane: Bayern Munich CEO refuses to discuss move for 'outstanding' Tottenham striker", 9, "harry-kane-bayern-munich-ceo-refuses-to-discuss-move-for-outstanding-tottenham", 900 },
                    { new Guid("ce5ebd4b-0bc9-46b3-b223-c5c9b7c53b7e"), new Guid("6dedb11c-5d41-48f3-81dd-d3d5ff0c7a3e"), false, "Borussia Dortmund have confirmed that Sebastien Haller will begin chemotherapy treatment as part of his battle against a malignant testicular tumour.The new signing recently underwent surgery to remove a tumour which sporting director Sebastian Kehl confirmed went positively,adding that the Ivory Coast international will be out of action for the next 'few months'.Kehl has now offered a further update, revealing that Haller will soon begin chemotherapy.Sebastien will now receive the best possible treatment, Kehl said. The chances of recovery are very good.We wish him and his family a lot of strength and optimism and our thoughts are with him during this difficult time.", new DateTime(2022, 7, 13, 8, 8, 8, 0, DateTimeKind.Unspecified), true, 2, "Borussia Dortmund have confirmed that Sebastien Haller will begin chemotherapy treatment as part of his battle against a malignant testicular tumour.", "Sebastien Haller to start chemotherapy for malignant testicular tumour", 9, "sebastien-haller-to-start-chemotherapy-for-malignant-testicular-tumour", 500 },
                    { new Guid("f30a160c-5c70-4042-ad83-5c128fbeb0f5"), new Guid("af301972-f954-4319-ad44-3b85f5294e61"), false, "UEFA president Aleksander Ceferin has hit back at managers like Pep Guardiola and Jurgen Klopp over their fixture congestion complaints.Guardiola and Klopp have been hyper critical of the football calendar over the last season,with the former even hinting that striking may be the best option to have changes be implemented:The problem is the fixtures. The calendar, 365 days a year with international duties for the national team, huge competitions with a lot of games. The players have two or three weeks of holiday in the summer and it’s the season again. This is too much.Should the players and the managers be all together together and make a strike, or something, because just through words it's not going to be solved? For FIFA, the Premier League, the broadcasters…the business is more important than the welfare.", new DateTime(2022, 5, 13, 8, 8, 8, 0, DateTimeKind.Unspecified), true, 2, "UEFA president Aleksander Ceferin has hit back at managers like Pep Guardiola and Jurgen Klopp over their fixture congestion complaints.", "UEFA president hits back at Jurgen Klopp & Pep Guardiola over fixture congestion complaints", 9, "uefa-president-hits-back-at-jurgen-klopp-pep-guardiola-over-fixture-congestion", 500 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("bf483ecf-7107-420a-a316-712160ae7e59"), new Guid("96513711-41f4-45d7-b234-769c2c402ec8") },
                    { new Guid("81bd671f-2cb9-40e3-9245-5b37135b1bab"), new Guid("ab517e6c-0ce4-485b-aace-de9a21b8d01b") },
                    { new Guid("46118fe1-2d15-4c5b-82f9-bc2f19b4a7c3"), new Guid("e3b5d306-49b2-46b2-a345-fc9d644f6700") }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { new Guid("2a7faf4c-e357-4e9d-b453-6ad0f858e9d9"), "Good", "Very very good", new DateTime(2022, 11, 13, 20, 15, 42, 829, DateTimeKind.Local).AddTicks(2614), "taiobe@mail.com", "Tai OBE", new Guid("54606ea0-ec4f-4ec4-9181-8153e1a2332e") },
                    { new Guid("4dc88bb0-6d6d-440a-adfe-c87600e721d7"), "Good", "Very very very good", new DateTime(2022, 11, 13, 20, 15, 42, 829, DateTimeKind.Local).AddTicks(2626), "huongvip@mail.com", "Huong VIP", new Guid("94475a71-ad8e-438f-b917-3c4a667f44ef") },
                    { new Guid("575e2dd9-3be4-4bc1-bd23-329716c917a2"), "Good", "Very good", new DateTime(2022, 11, 13, 20, 15, 42, 829, DateTimeKind.Local).AddTicks(2583), "brucelee@mail.com", "Bruce Lee", new Guid("82a43557-d760-4e5e-88c0-4835f36cfb17") }
                });

            migrationBuilder.InsertData(
                table: "PostTagMap",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { new Guid("2c7f0720-cdd9-4a47-818f-25fed485ffbf"), new Guid("9257978f-8a06-49bb-ac8f-7b4d35640dbf") },
                    { new Guid("3cb9eb48-216f-41f5-9752-e2c36a2f1c13"), new Guid("9257978f-8a06-49bb-ac8f-7b4d35640dbf") },
                    { new Guid("3cb9eb48-216f-41f5-9752-e2c36a2f1c13"), new Guid("ebf175db-f1ae-4989-83b7-a1c828bcef8c") },
                    { new Guid("42b20213-e508-4220-b509-5cf176ee32ad"), new Guid("f562d1b0-02db-4c1c-a4db-3e51c250f8a3") },
                    { new Guid("472942a5-a3ad-4ef0-be6f-a73ae48028e4"), new Guid("46b3e11a-7caa-4bbb-bca3-254baaed7c4f") },
                    { new Guid("472942a5-a3ad-4ef0-be6f-a73ae48028e4"), new Guid("c51319df-22b7-4470-ab83-b559a8f5ee19") },
                    { new Guid("472942a5-a3ad-4ef0-be6f-a73ae48028e4"), new Guid("ebf175db-f1ae-4989-83b7-a1c828bcef8c") },
                    { new Guid("472942a5-a3ad-4ef0-be6f-a73ae48028e4"), new Guid("ed9fda2f-8e59-443d-8a79-2991366b27b9") },
                    { new Guid("54606ea0-ec4f-4ec4-9181-8153e1a2332e"), new Guid("46b3e11a-7caa-4bbb-bca3-254baaed7c4f") },
                    { new Guid("54606ea0-ec4f-4ec4-9181-8153e1a2332e"), new Guid("ed9fda2f-8e59-443d-8a79-2991366b27b9") },
                    { new Guid("5e08bde8-c46b-4df0-a74e-66acecaf62a8"), new Guid("5c717df9-2347-4c67-be32-3474ccebc287") },
                    { new Guid("70844495-31db-43d2-b5b0-ce2e2da2ccfa"), new Guid("46b3e11a-7caa-4bbb-bca3-254baaed7c4f") },
                    { new Guid("70844495-31db-43d2-b5b0-ce2e2da2ccfa"), new Guid("4fa08da5-df70-42c8-96b2-7ad93986c3dd") },
                    { new Guid("70844495-31db-43d2-b5b0-ce2e2da2ccfa"), new Guid("ebf175db-f1ae-4989-83b7-a1c828bcef8c") },
                    { new Guid("7e8045c8-c6da-40c0-81bf-4fe0be6c730b"), new Guid("9257978f-8a06-49bb-ac8f-7b4d35640dbf") },
                    { new Guid("82a43557-d760-4e5e-88c0-4835f36cfb17"), new Guid("46b3e11a-7caa-4bbb-bca3-254baaed7c4f") },
                    { new Guid("82a43557-d760-4e5e-88c0-4835f36cfb17"), new Guid("4fa08da5-df70-42c8-96b2-7ad93986c3dd") },
                    { new Guid("90086993-0826-437c-9aee-993939c11a5e"), new Guid("c51319df-22b7-4470-ab83-b559a8f5ee19") },
                    { new Guid("90086993-0826-437c-9aee-993939c11a5e"), new Guid("f562d1b0-02db-4c1c-a4db-3e51c250f8a3") },
                    { new Guid("94475a71-ad8e-438f-b917-3c4a667f44ef"), new Guid("46b3e11a-7caa-4bbb-bca3-254baaed7c4f") },
                    { new Guid("94475a71-ad8e-438f-b917-3c4a667f44ef"), new Guid("c51319df-22b7-4470-ab83-b559a8f5ee19") },
                    { new Guid("94475a71-ad8e-438f-b917-3c4a667f44ef"), new Guid("ed9fda2f-8e59-443d-8a79-2991366b27b9") },
                    { new Guid("bf180548-f7d9-42b8-896d-ab6fc4ddcde4"), new Guid("5c717df9-2347-4c67-be32-3474ccebc287") },
                    { new Guid("c23d7677-ab19-4143-810c-4f7bef4cca87"), new Guid("46b3e11a-7caa-4bbb-bca3-254baaed7c4f") },
                    { new Guid("c23d7677-ab19-4143-810c-4f7bef4cca87"), new Guid("9257978f-8a06-49bb-ac8f-7b4d35640dbf") },
                    { new Guid("c23d7677-ab19-4143-810c-4f7bef4cca87"), new Guid("ebf175db-f1ae-4989-83b7-a1c828bcef8c") },
                    { new Guid("ce5ebd4b-0bc9-46b3-b223-c5c9b7c53b7e"), new Guid("9257978f-8a06-49bb-ac8f-7b4d35640dbf") },
                    { new Guid("f30a160c-5c70-4042-ad83-5c128fbeb0f5"), new Guid("46b3e11a-7caa-4bbb-bca3-254baaed7c4f") },
                    { new Guid("f30a160c-5c70-4042-ad83-5c128fbeb0f5"), new Guid("f562d1b0-02db-4c1c-a4db-3e51c250f8a3") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategoryId",
                table: "Post",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMap_TagId",
                table: "PostTagMap",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "PostTagMap");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
