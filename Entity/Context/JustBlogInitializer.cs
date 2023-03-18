using Entity.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Entity.Context
{
    public static class JustBlogInitializer
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Tag>().HasData(
                new Tag() { Id = Guid.Parse("46b3e11a-7caa-4bbb-bca3-254baaed7c4f"), Name = "epl", UrlSlug = "epl", Decription = "Premier League", Count = 1 },
                new Tag() { Id = Guid.Parse("ebf175db-f1ae-4989-83b7-a1c828bcef8c"), Name = "transfer", UrlSlug = "transfer", Decription = "Transfer News", Count = 2 },
                new Tag() { Id = Guid.Parse("9257978f-8a06-49bb-ac8f-7b4d35640dbf"), Name = "bundesliga", UrlSlug = "bundesliga", Decription = "bundesliga", Count = 3 },
                new Tag() { Id = Guid.Parse("f562d1b0-02db-4c1c-a4db-3e51c250f8a3"), Name = "champions-league", UrlSlug = "champions-league", Decription = "champions-league", Count = 3 },
                new Tag() { Id = Guid.Parse("5c717df9-2347-4c67-be32-3474ccebc287"), Name = "serie-a", UrlSlug = "serie-a", Decription = "serie-a", Count = 3 },
                new Tag() { Id = Guid.Parse("3c172200-28d2-4758-97df-d595384eb4f5"), Name = "la-liga", UrlSlug = "la-liga", Decription = "la-liga", Count = 3 },
                new Tag() { Id = Guid.Parse("4fa08da5-df70-42c8-96b2-7ad93986c3dd"), Name = "tot", UrlSlug = "tot", Decription = "tot", Count = 3 },
                new Tag() { Id = Guid.Parse("ed9fda2f-8e59-443d-8a79-2991366b27b9"), Name = "liv", UrlSlug = "liv", Decription = "liv", Count = 3 },
                new Tag() { Id = Guid.Parse("c51319df-22b7-4470-ab83-b559a8f5ee19"), Name = "mc", UrlSlug = "mc", Decription = "mc", Count = 3 },
                new Tag() { Id = Guid.Parse("6486ff2a-516c-4586-9668-0dfcf73027fb"), Name = "chel", UrlSlug = "chel", Decription = "chel", Count = 3 },
                new Tag() { Id = Guid.Parse("559bfae1-02f5-4dcf-b8fe-76d3313d3894"), Name = "lei", UrlSlug = "lei", Decription = "lei", Count = 3 },
                new Tag() { Id = Guid.Parse("963eac23-6a1f-46fc-bc67-49b1ebacd3ed"), Name = "ars", UrlSlug = "ars", Decription = "ars", Count = 3 },
                new Tag() { Id = Guid.Parse("f3f34549-daa6-4556-aec4-01ecc41c7182"), Name = "mu", UrlSlug = "mu", Decription = "mu", Count = 3 },
                new Tag() { Id = Guid.Parse("ae54c887-7a64-40eb-9d46-5c828491e348"), Name = "bay", UrlSlug = "bay", Decription = "bay", Count = 3 },
                new Tag() { Id = Guid.Parse("a11e5689-b978-411a-aeae-5d427b4a80ef"), Name = "real", UrlSlug = "real", Decription = "real", Count = 3 }
            );

            builder.Entity<Category>().HasData(
                new Category() { Id = Guid.Parse("7109d8d6-464d-4ff9-bfbb-62c83c9788c3"), Name = "Transfer News", UrlSlug = "transfer-news", Description = "Transfer News" },
                new Category() { Id = Guid.Parse("fd264eff-b43e-4a61-84a2-63dc29ce38cb"), Name = "Premier League", UrlSlug = "premier-league", Description = "Premier League" },
                new Category() { Id = Guid.Parse("af301972-f954-4319-ad44-3b85f5294e61"), Name = "Champions League", UrlSlug = "champions-league", Description = "Champions League" },
                new Category() { Id = Guid.Parse("6dedb11c-5d41-48f3-81dd-d3d5ff0c7a3e"), Name = "Bundesliga", UrlSlug = "bundesliga", Description = "Bundesliga" },
                new Category() { Id = Guid.Parse("8ee8e5b7-ff33-460d-8a5c-2385518a2845"), Name = "Serie A", UrlSlug = "serie-a", Description = "Serie A" },
                new Category() { Id = Guid.Parse("44fcbdd6-262c-408f-927a-88a3d39b482d"), Name = "Laliga", UrlSlug = "la-liga", Description = "Laliga" }
            );

            builder.Entity<Post>().HasData(
                new Post()
                {
                    Id = Guid.Parse("82a43557-d760-4e5e-88c0-4835f36cfb17"),
                    Title = "Tottenham crush Southampton for impressive opening win",
                    ShortDescription = "Tottenham Hotspur underlined their credentials as a team capable of a Premier League title challenge with a confident 4-1 defeat of Southampton to get their campaign up and running on Saturday.",
                    PostContent = "Tottenham Hotspur underlined their credentials as a team capable of a Premier League title challenge with a confident 4-1 defeat of Southampton to get their campaign up and running on Saturday.The hosts fell behind to a James Ward - Prowse volley in the 12th minute but dominated throughout with goals by Ryan Sessegnon,Eric Dier and Dejan Kulusevski sealing the win.Southampton's lead lasted only nine minutes before Sessegnon powered a header past Southampton's Premier League debutant keeper Gavin Bazunu from Kulusevski's cross.",
                    UrlSlug = "tottenham-crush-southampton-for-impressive-opening-win",
                    Published = true,
                    PostedOn = new DateTime(2022, 08, 13, 8, 8, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("fd264eff-b43e-4a61-84a2-63dc29ce38cb"),
                    ViewCount = 1000,
                    RateCount = 2,
                    TotalRate = 10
                },
                new Post()
                {
                    Id = Guid.Parse("54606ea0-ec4f-4ec4-9181-8153e1a2332e"),
                    Title = "Liverpool's Thiago Alcantara out for up to six weeks - sources",
                    ShortDescription = "Liverpool midfielder Thiago Alcantara will be out of action for up to six weeks because of injury, sources have told ESPN.",
                    PostContent = @"Liverpool midfielder Thiago Alcantara will be out of action for up to six weeks because of injury, sources have told ESPN.The Spain international limped off the pitch early in the second half with a suspected hamstring strain during Saturday's 2-2 Premier League draw at Fulham.Thiago's injury comes at a bad time for Liverpool, who are still without midfielders Alex Oxlade-Chamberlain and Curtis Jones.This isn't a good situation. I don't like it at all.We have to see how we react on that,but for sure not panic,  Liverpool coach Jurgen Klopp said.The transfer window closes on Sept. 1 but Klopp indicated Liverpool will not make a rash decision regarding signing new players.",
                    UrlSlug = "liverpools-thiago-alcantara-out-for-up-to-six-weeks-sources",
                    Published = true,
                    PostedOn = new DateTime(2022, 08, 13, 20, 8, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("fd264eff-b43e-4a61-84a2-63dc29ce38cb"),
                    ViewCount = 800,
                    RateCount = 2,
                    TotalRate = 9
                },
                new Post()
                {
                    Id = Guid.Parse("94475a71-ad8e-438f-b917-3c4a667f44ef"),
                    Title = "Man City and Liverpool ahead of the chasing pack in Premier League title race, oddsmakers say",
                    ShortDescription = "Oddsmakers have pegged the quest for the Premier League title as a two-horse race, with defending-champion Manchester City and Liverpool separated from the pack.",
                    PostContent = "Oddsmakers have pegged the quest for the Premier League title as a two-horse race, with defending-champion Manchester City and Liverpool separated from the pack.Man City,who have won four of the past five EPL titles,are the odds favorite to win it again,listed at - 165 at Caesars Sportsbooks.Liverpool,last season's runner-ups, are +200.The gap between the two top clubs and the rest of the table is significant,according to oddsmakers.Man City and Liverpool are the only two teams with single - digit odds.Tottenham,at + 1,400,and Chelsea,at + 1,600,are next but are a ways down oddsboards.Tottenham,however,have attracted the most bets and are the most wagered to win the league title at Caesars Sportsbook,but it'll be a tall task to unseat Man City.Man City added elite striker Erling Haaland in the offseason,bolstering Pep Guardiola's already potent roster that posted 93 points en route to last years title.It was the sixth - most points in league history.Liverpool,though,finished just one point behind and notched a victory over Man City last week in the FA Community Shield.Arsenal,who kick off the season Friday against Crystal Palace,are + 2,800,and Manchester United are + 3,500.Man United's preseason title odds are the longest they've been in over a decade,according to sports betting archive SportsOddsHistory.com.Bournemouth and Fulham,at 1,500 - 1 and 1,000 - 1 respectively,are the longest shots on the board at Caesars Sportsbook.",
                    UrlSlug = "man-city-and-liverpool-ahead-of-the-chasing-pack-in-premier-league-title-race-od",
                    Published = true,
                    PostedOn = new DateTime(2022, 08, 12, 8, 8, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("fd264eff-b43e-4a61-84a2-63dc29ce38cb"),
                    ViewCount = 800,
                    RateCount = 2,
                    TotalRate = 9
                },
                new Post()
                {
                    Id = Guid.Parse("70844495-31db-43d2-b5b0-ce2e2da2ccfa"),
                    Title = "Tottenham close to signing Ivan Perisic from Inter",
                    ShortDescription = "Tottenham are closing in on the signing of versatile Inter winger Ivan Perisic on a two-year deal",
                    PostContent = "Tottenham are closing in on the signing of versatile Inter winger Ivan Perisic on a two-year deal, 90min understands.The 33 - year - old is out of contract at San Siro this summer and has long been linked with a move away from the club.Perisic has previously worked with Tottenham head coach Antonio Conte at Inter,winning the Serie A title under him,and 90min has learned that a reunion in north London is close to completion.Indeed,sources have told 90min that Perisic,who famously scored in Croatia's 2-1 win over England in the 2018 World Cup semi-final, has agreed a two-year deal and will undergo a medical next week.He also fielded offers from Chelsea and Juventus this summer, as well as a bid from the Nerazzurri to extend his contract,but the chance to pair up with Conte - who confirmed to the club in a meeting in Turin that he intends to remain in charge despite links with PSG - appears to have been too good of an opportunity to turn down.",
                    UrlSlug = "tottenham-close-to-signing-ivan-perisic-from-inter",
                    Published = true,
                    PostedOn = new DateTime(2022, 08, 11, 11, 8, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("7109d8d6-464d-4ff9-bfbb-62c83c9788c3"),
                    ViewCount = 800,
                    RateCount = 2,
                    TotalRate = 9
                },
                new Post()
                {
                    Id = Guid.Parse("c23d7677-ab19-4143-810c-4f7bef4cca87"),
                    Title = "Harry Kane: Bayern Munich CEO refuses to discuss move for 'outstanding' Tottenham striker",
                    ShortDescription = "Bayern Munich CEO Oliver Kahn has this time declined to discuss a transfer for Tottenham striker Harry Kane.",
                    PostContent = "Bayern Munich CEO Oliver Kahn has this time declined to discuss a transfer for Tottenham striker Harry Kane.The former goalkeeper recently described Kane as a 'dream of the future', while Bayern boss Julian Naglesmann has also gone public with his admiration of the striker - prompting a frustrated response from Spurs boss Antonio Conte.Seemingly concerned about upsetting Conte once again, Kahn declined to get drawn into a conversation about Kane when asked for an update on Bayern's interest.I can just say that Harry Kane is an outstanding striker who is now under contract at Tottenham, Kahn told Bild.Conte has described Bayern's interest as 'only rumours' and reiterated the club's desire to keep Kane around for the foreseeable future.",
                    UrlSlug = "harry-kane-bayern-munich-ceo-refuses-to-discuss-move-for-outstanding-tottenham",
                    Published = true,
                    PostedOn = new DateTime(2022, 08, 12, 14, 10, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("7109d8d6-464d-4ff9-bfbb-62c83c9788c3"),
                    ViewCount = 900,
                    RateCount = 2,
                    TotalRate = 9
                },
                new Post()
                {
                    Id = Guid.Parse("3cb9eb48-216f-41f5-9752-e2c36a2f1c13"),
                    Title = "Bayern Munich confirm Sadio Mane signing",
                    ShortDescription = "Bayern Munich have confirmed the signing of Sadio Mane from Liverpool on a three-year deal.",
                    PostContent = "Bayern Munich have confirmed the signing of Sadio Mane from Liverpool on a three-year deal.Mane departs Anfield after six glorious years in which he won every honour available to him,including the Champions League in 2019 and Premier League one year later.The forward had long been expected to leave this summer with Bayern kicking off negotiations towards the end of last season.Eventually a deal was struck and 90min understands that Mane agreed to waive some potential future earnings to help smooth negotiations along.I'm really happy to finally be at FC Bayern in Munich, Mane said. We spoke a lot and I felt big interest from this great club right from the beginning, so for me there were no doubts. Its the right time for this challenge.I want to achieve a lot with this club, in Europe too. During my time in Salzburg I watched a lot of Bayern games - I really like this club!Bayern CEO Oliver Kahn added: We are delighted that weve been able to recruit Sadio Mane for FC Bayern. With his outstanding performances and his great successes at the highest international level over many years, there are very few players like him in the world.We re sure that Sadio Mane will delight our fans in the coming years with his spectacular style of play. He s ambitious and eager to win more titles. This package is very strong. With players like him at FC Bayern, all the biggest goals are possible.",
                    UrlSlug = "bayern-munich-confirm-sadio-mane-signing",
                    Published = true,
                    PostedOn = new DateTime(2022, 07, 24, 05, 28, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("7109d8d6-464d-4ff9-bfbb-62c83c9788c3"),
                    ViewCount = 900,
                    RateCount = 2,
                    TotalRate = 9
                },
                new Post()
                {
                    Id = Guid.Parse("472942a5-a3ad-4ef0-be6f-a73ae48028e4"),
                    Title = "Liverpool forced into Darwin Nunez move as Erling Haaland raises Man City ceiling",
                    ShortDescription = "Comfortably the two best sides in England went punch for punch on the pitch last season, and Manchester City and Liverpool are now doing the same off it through the respective arrivals of Erling Haaland and Darwin Nunez, with neither Pep Guardiola or Jurgen Klopp willing to give each other an inch for fear of the other taking a mile in what looks set once again to be a two-horse race in the Premier League.",
                    PostContent = "Comfortably the two best sides in England went punch for punch on the pitch last season, and Manchester City and Liverpool are now doing the same off it through the respective arrivals of Erling Haaland and Darwin Nunez, with neither Pep Guardiola or Jurgen Klopp willing to give each other an inch for fear of the other taking a mile in what looks set once again to be a two-horse race in the Premier League.Manchester City signed a big,fast,prolific central striker in an attempt to adapt,develop or at least offer an alternative to their style of football to steal a march on Liverpool.Only for Liverpool to respond in kind, signing their own big, fast, prolific central striker.Straight comparisons between the pair are reductive given they've played for different clubs with different players in different divisions. What we do know is that they can score goals and – given the competition to sign Haaland and the £85m needed for Nunez – City and Liverpool have little doubt they will continue to do so.One point was all that could separate City and Liverpool last season, with final day drama adding to what was already one of the great title races in Premier League history.Confirmation of their marquee summer signings leads to questions as to whether either has given one team the edge, or if Nunez and Haaland will instead cancel each other out, with respective one per cent improvements simply maintaining the extraordinarily well - matched dominance of these two wonderful football teams.",
                    UrlSlug = "liverpool-forced-into-darwin-nunez-move-as-erling-haaland-raises-man-city-ceiling",
                    Published = true,
                    PostedOn = new DateTime(2022, 07, 09, 16, 48, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("7109d8d6-464d-4ff9-bfbb-62c83c9788c3"),
                    ViewCount = 600,
                    RateCount = 2,
                    TotalRate = 9
                },
                new Post()
                {
                    Id = Guid.Parse("90086993-0826-437c-9aee-993939c11a5e"),
                    Title = "Man City chief executive claims Real Madrid were 'lucky' in Champions League",
                    ShortDescription = "Manchester City chief executive Ferran Soriano has insisted that the is ‘not obsessed’ with winning the Champions League but claims Real Madrid were ‘a bit lucky’ last season.",
                    PostContent = "Manchester City chief executive Ferran Soriano has insisted that the is ‘not obsessed’ with winning the Champions League but claims Real Madrid were ‘a bit lucky’ last season.Real lifted their 14th European crown in May after beating Liverpool in the final.They had already beaten City,Chelsea and Paris Saint - Germain in previous knockout rounds and needed to come from behind in all three ties in order to progress.Discussing Real’s success as well as his own club’s ambitions,Soriano told the Dr.Football podcast: “The Champions League is a trophy that we want,but we know that it is subject to a bit of luck and we are not obsessed.“People talk today about the success that Madrid have had in recent years,and I think it would be fair to say that they were a bit lucky.Perhaps I could say that they deserved to lose against PSG,against Chelsea,against us or against Liverpool.”",
                    UrlSlug = "man-city-chief-executive-claims-real-madrid-were-lucky-in-champions-league",
                    Published = true,
                    PostedOn = new DateTime(2022, 06, 25, 23, 8, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("af301972-f954-4319-ad44-3b85f5294e61"),
                    ViewCount = 700,
                    RateCount = 2,
                    TotalRate = 9
                },
                new Post()
                {
                    Id = Guid.Parse("f30a160c-5c70-4042-ad83-5c128fbeb0f5"),
                    Title = "UEFA president hits back at Jurgen Klopp & Pep Guardiola over fixture congestion complaints",
                    ShortDescription = "UEFA president Aleksander Ceferin has hit back at managers like Pep Guardiola and Jurgen Klopp over their fixture congestion complaints.",
                    PostContent = "UEFA president Aleksander Ceferin has hit back at managers like Pep Guardiola and Jurgen Klopp over their fixture congestion complaints.Guardiola and Klopp have been hyper critical of the football calendar over the last season,with the former even hinting that striking may be the best option to have changes be implemented:The problem is the fixtures. The calendar, 365 days a year with international duties for the national team, huge competitions with a lot of games. The players have two or three weeks of holiday in the summer and it’s the season again. This is too much.Should the players and the managers be all together together and make a strike, or something, because just through words it's not going to be solved? For FIFA, the Premier League, the broadcasters…the business is more important than the welfare.",
                    UrlSlug = "uefa-president-hits-back-at-jurgen-klopp-pep-guardiola-over-fixture-congestion",
                    Published = true,
                    PostedOn = new DateTime(2022, 05, 13, 8, 8, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("af301972-f954-4319-ad44-3b85f5294e61"),
                    ViewCount = 500,
                    RateCount = 2,
                    TotalRate = 9
                },
                new Post()
                {
                    Id = Guid.Parse("42b20213-e508-4220-b509-5cf176ee32ad"),
                    Title = "2022/23 Champions League: Qualification dates, draws & schedule",
                    ShortDescription = "The road to the 2022/23 Champions League has started with some of the earliest qualifying matches being scheduled.",
                    PostContent = "The road to the 2022/23 Champions League has started with some of the earliest qualifying matches being scheduled.A large number of Europe's elite clubs have qualified already through league position, though a fair few teams can still book their spot in next season's competition by winning qualifiers throughout the summer.Here are all the dates you need in the build - up to the 2022 / 23 Champions League.",
                    UrlSlug = "2022-23-champions-league-qualification-dates-draws-schedule",
                    Published = true,
                    PostedOn = new DateTime(2022, 07, 13, 8, 8, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("af301972-f954-4319-ad44-3b85f5294e61"),
                    ViewCount = 800,
                    RateCount = 2,
                    TotalRate = 9
                },
                new Post()
                {
                    Id = Guid.Parse("7e8045c8-c6da-40c0-81bf-4fe0be6c730b"),
                    Title = "Sadio Mane: 'Of course' Bayern Munich would beat Liverpool",
                    ShortDescription = "Bayern Munich forward Sadio Mane has claimed that his new employers would beat former side Liverpool if the two faced off in the Champions League.",
                    PostContent = "Bayern Munich forward Sadio Mane has claimed that his new employers would beat former side Liverpool if the two faced off in the Champions League.Bayern have bested Liverpool just once in the pair's nine meetings and most recently fell 3-1 at the Allianz Arena in March 2019, a game which featured two goals from Mane.The Segenal star's first strike saw him turn Manuel Neuer inside out before firing into the back of the net, with Mane later describing it as one of his two favourite goals from his time with Liverpool.In the Bundesliga newsletter,Mane was asked whether he would still describe his goal against Bayern as his favourite,and he confessed that his new relationship with Neuer has seen him demote the strike to second.I said maybe my favourite but now I would say second favourite goal, not my first, because he's my team-mate, Mane laughed. No, I'm joking… of course, I think it was a good goal, kind of a good goal. We had a good game.This is behind us. If we re going to meet again, of course as Bayern Munich wd beat Liverpool.",
                    UrlSlug = "sadio-mane-of-course-bayern-munich-would-beat-liverpool",
                    Published = true,
                    PostedOn = new DateTime(2022, 08, 05, 8, 8, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("6dedb11c-5d41-48f3-81dd-d3d5ff0c7a3e"),
                    ViewCount = 600,
                    RateCount = 2,
                    TotalRate = 9
                },
                new Post()
                {
                    Id = Guid.Parse("ce5ebd4b-0bc9-46b3-b223-c5c9b7c53b7e"),
                    Title = "Sebastien Haller to start chemotherapy for malignant testicular tumour",
                    ShortDescription = "Borussia Dortmund have confirmed that Sebastien Haller will begin chemotherapy treatment as part of his battle against a malignant testicular tumour.",
                    PostContent = "Borussia Dortmund have confirmed that Sebastien Haller will begin chemotherapy treatment as part of his battle against a malignant testicular tumour.The new signing recently underwent surgery to remove a tumour which sporting director Sebastian Kehl confirmed went positively,adding that the Ivory Coast international will be out of action for the next 'few months'.Kehl has now offered a further update, revealing that Haller will soon begin chemotherapy.Sebastien will now receive the best possible treatment, Kehl said. The chances of recovery are very good.We wish him and his family a lot of strength and optimism and our thoughts are with him during this difficult time.",
                    UrlSlug = "sebastien-haller-to-start-chemotherapy-for-malignant-testicular-tumour",
                    Published = true,
                    PostedOn = new DateTime(2022, 07, 13, 8, 8, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("6dedb11c-5d41-48f3-81dd-d3d5ff0c7a3e"),
                    ViewCount = 500,
                    RateCount = 2,
                    TotalRate = 9
                },
                new Post()
                {
                    Id = Guid.Parse("2c7f0720-cdd9-4a47-818f-25fed485ffbf"),
                    Title = "Eintracht Frankfurt 1-6 Bayern Munich: Champions make imposing start to Bundesliga season",
                    ShortDescription = "Bayern Munich made an intimidating start to their latest Bundesliga title defence by smashing Europa League holders Eintracht Frankfurt 6-1 at Deutsche Bank Park on Friday night.",
                    PostContent = "Bayern Munich made an intimidating start to their latest Bundesliga title defence by smashing Europa League holders Eintracht Frankfurt 6-1 at Deutsche Bank Park on Friday night.Julian Nagelsmann's side finished eight points clear of closest competitors Borussia Dortmund to win the league last season, while Frankfurt weren't in the conversation despite their success in Europe.Bayern were 2 - 0 up inside ten minutes thanks to strikes from Joshua Kimmich and Benjamin Pavard and added another three before half time.Sadio Mane struck for the first time in the Bundesliga by heading in from Serge Gnabry's flick before youngster Jamal Musiala tapped in from close range. Gnabry soon sent the two teams into the interval with the game's fifth strike.Manuel Neuer did offer Frankfurt a crumb of comfort, dithering on the ball for too long and allowing Randal Kolo Muani to nip in and score a consolation on debut, but that was as good as it ever got for the hosts.Musiala later scrambled through the hosts' defence to slide in Bayern's sixth, topping off an impressive night's work for the reigning German champions.",
                    UrlSlug = "eintracht-frankfurt-1-6-bayern-munich-champions-make-imposing-start-to-bundeslig",
                    Published = true,
                    PostedOn = new DateTime(2022, 08, 13, 15, 8, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("6dedb11c-5d41-48f3-81dd-d3d5ff0c7a3e"),
                    ViewCount = 900,
                    RateCount = 2,
                    TotalRate = 9
                },
                new Post()
                {
                    Id = Guid.Parse("5e08bde8-c46b-4df0-a74e-66acecaf62a8"),
                    Title = "Tammy Abraham insists he has 'no regrets' over Chelsea departure",
                    ShortDescription = "Roma striker Tammy Abraham insists he has never looked back following his departure from Chelsea last summer.",
                    PostContent = "Roma striker Tammy Abraham insists he has never looked back following his departure from Chelsea last summer.The Blues academy graduate was offloaded in a £34m deal to help make room for the signing of Romelu Lukaku, who has since returned to Inter on a season - long loan after his £97.5m arrival yielded just eight Premier League goals.While Lukaku was struggling, Abraham settled in quickly at Roma and ended his debut season with 27 goals in 53 games in all competitions, helping them to Europa Conference League glory.The numbers speak for themselves, and Abraham recently told Corriere dello Sport that he has zero regrets about his departure from Chelsea.",
                    UrlSlug = "tammy-abraham-insists-he-has-no-regrets-over-chelsea-departure",
                    Published = true,
                    PostedOn = new DateTime(2022, 08, 10, 8, 8, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("8ee8e5b7-ff33-460d-8a5c-2385518a2845"),
                    ViewCount = 800,
                    RateCount = 2,
                    TotalRate = 9
                },
                new Post()
                {
                    Id = Guid.Parse("bf180548-f7d9-42b8-896d-ab6fc4ddcde4"),
                    Title = "Paulo Dybala explains why he left Juventus for Roma",
                    ShortDescription = "Paulo Dybala has denied that money played a role in his Juventus departure, with the new Roma forward claiming that he exited for footballing reasons.",
                    PostContent = "Paulo Dybala has denied that money played a role in his Juventus departure, with the new Roma forward claiming that he exited for footballing reasons.Back in March it was announced that Dybala would be leaving Juve at the end of his contract this summer and he had seemed set to join Inter,until I Giallorossi swooped in to secure his services.The Argentine was unveiled as a Roma player on Tuesday and,during a press conference,he opened up on the process of departing the Allianz Stadium.I think the director [Maurizio] Arrivabene was very clear in his statements: we had an agreement to sign in October, then [the club] asked to wait, he explained.",
                    UrlSlug = "paulo-dybala-explains-why-he-left-juventus-for-roma",
                    Published = true,
                    PostedOn = new DateTime(2022, 07, 13, 8, 8, 8),
                    Modified = false,
                    CategoryId = Guid.Parse("8ee8e5b7-ff33-460d-8a5c-2385518a2845"),
                    ViewCount = 700,
                    RateCount = 2,
                    TotalRate = 9
                }
                );

            builder.Entity<PostTagMap>().HasData(
                new PostTagMap() { TagId = Guid.Parse("46b3e11a-7caa-4bbb-bca3-254baaed7c4f"), PostId = Guid.Parse("82a43557-d760-4e5e-88c0-4835f36cfb17") },
                new PostTagMap() { TagId = Guid.Parse("46b3e11a-7caa-4bbb-bca3-254baaed7c4f"), PostId = Guid.Parse("54606ea0-ec4f-4ec4-9181-8153e1a2332e") },
                new PostTagMap() { TagId = Guid.Parse("46b3e11a-7caa-4bbb-bca3-254baaed7c4f"), PostId = Guid.Parse("94475a71-ad8e-438f-b917-3c4a667f44ef") },
                new PostTagMap() { TagId = Guid.Parse("46b3e11a-7caa-4bbb-bca3-254baaed7c4f"), PostId = Guid.Parse("70844495-31db-43d2-b5b0-ce2e2da2ccfa") },
                new PostTagMap() { TagId = Guid.Parse("46b3e11a-7caa-4bbb-bca3-254baaed7c4f"), PostId = Guid.Parse("c23d7677-ab19-4143-810c-4f7bef4cca87") },
                new PostTagMap() { TagId = Guid.Parse("46b3e11a-7caa-4bbb-bca3-254baaed7c4f"), PostId = Guid.Parse("472942a5-a3ad-4ef0-be6f-a73ae48028e4") },
                new PostTagMap() { TagId = Guid.Parse("46b3e11a-7caa-4bbb-bca3-254baaed7c4f"), PostId = Guid.Parse("f30a160c-5c70-4042-ad83-5c128fbeb0f5") },

                new PostTagMap() { TagId = Guid.Parse("ebf175db-f1ae-4989-83b7-a1c828bcef8c"), PostId = Guid.Parse("70844495-31db-43d2-b5b0-ce2e2da2ccfa") },
                new PostTagMap() { TagId = Guid.Parse("ebf175db-f1ae-4989-83b7-a1c828bcef8c"), PostId = Guid.Parse("c23d7677-ab19-4143-810c-4f7bef4cca87") },
                new PostTagMap() { TagId = Guid.Parse("ebf175db-f1ae-4989-83b7-a1c828bcef8c"), PostId = Guid.Parse("3cb9eb48-216f-41f5-9752-e2c36a2f1c13") },
                new PostTagMap() { TagId = Guid.Parse("ebf175db-f1ae-4989-83b7-a1c828bcef8c"), PostId = Guid.Parse("472942a5-a3ad-4ef0-be6f-a73ae48028e4") },

                new PostTagMap() { TagId = Guid.Parse("9257978f-8a06-49bb-ac8f-7b4d35640dbf"), PostId = Guid.Parse("c23d7677-ab19-4143-810c-4f7bef4cca87") },
                new PostTagMap() { TagId = Guid.Parse("9257978f-8a06-49bb-ac8f-7b4d35640dbf"), PostId = Guid.Parse("3cb9eb48-216f-41f5-9752-e2c36a2f1c13") },
                new PostTagMap() { TagId = Guid.Parse("9257978f-8a06-49bb-ac8f-7b4d35640dbf"), PostId = Guid.Parse("7e8045c8-c6da-40c0-81bf-4fe0be6c730b") },
                new PostTagMap() { TagId = Guid.Parse("9257978f-8a06-49bb-ac8f-7b4d35640dbf"), PostId = Guid.Parse("ce5ebd4b-0bc9-46b3-b223-c5c9b7c53b7e") },
                new PostTagMap() { TagId = Guid.Parse("9257978f-8a06-49bb-ac8f-7b4d35640dbf"), PostId = Guid.Parse("2c7f0720-cdd9-4a47-818f-25fed485ffbf") },

                new PostTagMap() { TagId = Guid.Parse("f562d1b0-02db-4c1c-a4db-3e51c250f8a3"), PostId = Guid.Parse("90086993-0826-437c-9aee-993939c11a5e") },
                new PostTagMap() { TagId = Guid.Parse("f562d1b0-02db-4c1c-a4db-3e51c250f8a3"), PostId = Guid.Parse("f30a160c-5c70-4042-ad83-5c128fbeb0f5") },
                new PostTagMap() { TagId = Guid.Parse("f562d1b0-02db-4c1c-a4db-3e51c250f8a3"), PostId = Guid.Parse("42b20213-e508-4220-b509-5cf176ee32ad") },

                new PostTagMap() { TagId = Guid.Parse("5c717df9-2347-4c67-be32-3474ccebc287"), PostId = Guid.Parse("5e08bde8-c46b-4df0-a74e-66acecaf62a8") },
                new PostTagMap() { TagId = Guid.Parse("5c717df9-2347-4c67-be32-3474ccebc287"), PostId = Guid.Parse("bf180548-f7d9-42b8-896d-ab6fc4ddcde4") },

                new PostTagMap() { TagId = Guid.Parse("4fa08da5-df70-42c8-96b2-7ad93986c3dd"), PostId = Guid.Parse("82a43557-d760-4e5e-88c0-4835f36cfb17") },
                new PostTagMap() { TagId = Guid.Parse("4fa08da5-df70-42c8-96b2-7ad93986c3dd"), PostId = Guid.Parse("70844495-31db-43d2-b5b0-ce2e2da2ccfa") },

                new PostTagMap() { TagId = Guid.Parse("ed9fda2f-8e59-443d-8a79-2991366b27b9"), PostId = Guid.Parse("54606ea0-ec4f-4ec4-9181-8153e1a2332e") },
                new PostTagMap() { TagId = Guid.Parse("ed9fda2f-8e59-443d-8a79-2991366b27b9"), PostId = Guid.Parse("94475a71-ad8e-438f-b917-3c4a667f44ef") },
                new PostTagMap() { TagId = Guid.Parse("ed9fda2f-8e59-443d-8a79-2991366b27b9"), PostId = Guid.Parse("472942a5-a3ad-4ef0-be6f-a73ae48028e4") },

                new PostTagMap() { TagId = Guid.Parse("c51319df-22b7-4470-ab83-b559a8f5ee19"), PostId = Guid.Parse("94475a71-ad8e-438f-b917-3c4a667f44ef") },
                new PostTagMap() { TagId = Guid.Parse("c51319df-22b7-4470-ab83-b559a8f5ee19"), PostId = Guid.Parse("472942a5-a3ad-4ef0-be6f-a73ae48028e4") },
                new PostTagMap() { TagId = Guid.Parse("c51319df-22b7-4470-ab83-b559a8f5ee19"), PostId = Guid.Parse("90086993-0826-437c-9aee-993939c11a5e") }

                );

            builder.Entity<Comment>().HasData(
                new Comment()
                {
                    Id = Guid.Parse("575e2dd9-3be4-4bc1-bd23-329716c917a2"),
                    Name = "Bruce Lee",
                    Email = "brucelee@mail.com",
                    CommentHeader = "Good",
                    CommentText = "Very good",
                    CommentTime = DateTime.Now,
                    PostId = Guid.Parse("82a43557-d760-4e5e-88c0-4835f36cfb17")
                },
                new Comment()
                {
                    Id = Guid.Parse("2a7faf4c-e357-4e9d-b453-6ad0f858e9d9"),
                    Name = "Tai OBE",
                    Email = "taiobe@mail.com",
                    CommentHeader = "Good",
                    CommentText = "Very very good",
                    CommentTime = DateTime.Now,
                    PostId = Guid.Parse("54606ea0-ec4f-4ec4-9181-8153e1a2332e")
                },
                new Comment()
                {
                    Id = Guid.Parse("4dc88bb0-6d6d-440a-adfe-c87600e721d7"),
                    Name = "Huong VIP",
                    Email = "huongvip@mail.com",
                    CommentHeader = "Good",
                    CommentText = "Very very very good",
                    CommentTime = DateTime.Now,
                    PostId = Guid.Parse("94475a71-ad8e-438f-b917-3c4a667f44ef")
                }
                );

            builder.Entity<Role>().HasData(
                new Role()
                {
                    Id = Guid.Parse("46118fe1-2d15-4c5b-82f9-bc2f19b4a7c3"),
                    Name = "Blog Owner",
                    NormalizedName = "BLOG OWNER"
                },
                new Role()
                {
                    Id = Guid.Parse("bf483ecf-7107-420a-a316-712160ae7e59"),
                    Name = "Contributor",
                    NormalizedName = "Contributor".ToUpper()
                },
                new Role()
                {
                    Id = Guid.Parse("81bd671f-2cb9-40e3-9245-5b37135b1bab"),
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
                );

            var hasher = new PasswordHasher<User>();
            builder.Entity<User>().HasData(
                new User()
                {
                    Id = Guid.Parse("e3b5d306-49b2-46b2-a345-fc9d644f6700"),
                    UserName = "brucelee",
                    FullName = "Bruce Lee",
                    AboutMe = "Good",
                    NormalizedUserName = "BRUCELEE",
                    Email = "brucelee@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = hasher.HashPassword(null, "Admin@123")
                },
                new User()
                {
                    Id = Guid.Parse("96513711-41f4-45d7-b234-769c2c402ec8"),
                    UserName = "brucelee2",
                    FullName = "Bruce Lee 2",
                    AboutMe = "Good",
                    NormalizedUserName = "BRUCELEE2",
                    Email = "brucelee2@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = hasher.HashPassword(null, "Admin@123")
                },
                new User()
                {
                    Id = Guid.Parse("ab517e6c-0ce4-485b-aace-de9a21b8d01b"),
                    UserName = "brucelee3",
                    FullName = "Bruce Lee 3",
                    AboutMe = "Good",
                    NormalizedUserName = "BRUCELEE3",
                    Email = "brucelee3@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = hasher.HashPassword(null, "Admin@123")
                }
                );

            builder.Entity<IdentityUserRole<Guid>>().HasData(
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("46118fe1-2d15-4c5b-82f9-bc2f19b4a7c3"),
                UserId = Guid.Parse("e3b5d306-49b2-46b2-a345-fc9d644f6700")
            },
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("bf483ecf-7107-420a-a316-712160ae7e59"),
                UserId = Guid.Parse("96513711-41f4-45d7-b234-769c2c402ec8")
            },
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("81bd671f-2cb9-40e3-9245-5b37135b1bab"),
                UserId = Guid.Parse("ab517e6c-0ce4-485b-aace-de9a21b8d01b")
            }
            );
        }
    }
}