using SportsCarnival;

namespace SportsCarnivalTest;

public class CreateTeamTests
{
    private Game game { get; set; } = null!;
    [SetUp]
    public void Setup()
    {
        game = JSONService.ReadJSON();
    }

    [Test]
    public void GetNumberOfPlayers_Test()
    {
        int gameType1 = 1;
        var numberOfPlayers1 = AdminService.GetNumberOfPlayers(gameType1);
        Assert.AreEqual(11,numberOfPlayers1);

        int gameType2 = 2;
        var numberOfPlayers2 = AdminService.GetNumberOfPlayers(gameType2);
        Assert.AreEqual(2, numberOfPlayers2);

        int gameType3 = 3;
        var numberOfPlayers3 = AdminService.GetNumberOfPlayers(gameType3);
        Assert.AreEqual(1, numberOfPlayers3);

        int gameType4 = 0;
        var numberOfPlayers4 = AdminService.GetNumberOfPlayers(gameType4);
        Assert.AreEqual(0, numberOfPlayers4);

        int gameType5 = -1;
        var numberOfPlayers5 = AdminService.GetNumberOfPlayers(gameType4);
        Assert.AreEqual(0, numberOfPlayers5);

    }

    public void GetNumberOfTeams_Test()
    {
        
    }
}
