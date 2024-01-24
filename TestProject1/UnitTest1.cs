using Symulator_CL;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToGroupATest()
        {
            //arrange
            List<Club> grupaA = new List<Club>();
            Club c = new Club();
            //act
            grupaA.Add(c);
            //assert
            Assert.AreEqual(1, grupaA.Count);
        }
        [TestMethod]
        public void AddToGroupBTest()
        {
            //arrange
            List<Club> grupaB = new List<Club>();
            Club c = new Club();
            //act
            grupaB.Add(c);
            //assert
            Assert.AreEqual(1, grupaB.Count);
        }
        [TestMethod]
        public void AddToGroupCTest()
        {
            //arrange
            List<Club> grupaC = new List<Club>();
            Club c = new Club();
            //act
            grupaC.Add(c);
            //assert
            Assert.AreEqual(1, grupaC.Count);
        }
        [TestMethod]
        public void AddToGroupDTest()
        {
            //arrange
            List<Club> grupaD = new List<Club>();
            Club c = new Club();
            //act
            grupaD.Add(c);
            //assert
            Assert.AreEqual(1, grupaD.Count);
        }

        [TestMethod]
        public void AddPlayerToClubTest() 
        {
            //arrange 
            Club club = new Club();
            Player player = new Player();
            //act
            club.AddPlayer(player);
            //assertion
            Assert.AreEqual(1, club.Zawodnicy.Count);
        }

        [TestMethod]
        public void AddExistingPlayerToClubTest()
        {
            //arrange 
            Club club = new Club();
            Player player1 = new Player("Jan","Tak",99,"CM","Poland","Wisla",99,99,99,99,99,99);
            Player player2 = new Player("Jan", "Tak", 99, "CM", "Poland", "Wisla", 99, 99, 99, 99, 99, 99); 
            //act
            club.AddPlayer(player1);
            //assertion
            Assert.ThrowsException<ArgumentException>(() => club.AddPlayer(player2));
        }
        [TestMethod]
        public void LosujGraczaZDruzynyTest()
        {
            //arrange 
            Club club = new Club();
            Player player1 = new Player("Jan", "Tak", 99, "CM", "Poland", "Wisla", 99, 99, 99, 99, 99, 99);
            Player player2 = new Player("Jan", "Nie", 99, "CM", "Poland", "Wisla", 99, 99, 99, 99, 99, 99);
            //act
            club.AddPlayer(player1);
            club.AddPlayer(player2);
            club.LosujGraczaZDruzyny();
            //assertion
            Assert.AreEqual(1, club.Zawodnicy.Count);
        }
        [TestMethod]
        public void DodajPunktyNarodowosciTest()
        {
            //arrange 
            Player player1 = new Player("Jan", "Tak", 99, "CM", "Poland", "Wisla", 99, 99, 99, 99, 99, 99);
            //act
            player1.DodajPunktyNarodowosci(player1);
            //assertion
            Assert.AreEqual(104, player1.Rating);
        }
        [TestMethod]
        public void PlayerAtrributesTest()
        {
            //arrange 
            Player player1 = new Player("Jan", "Tak", 99, "CM", "Poland", "Wisla", 99, 99, 99, 99, 99, 99);
            //act
            player1.PlayerAttributes();
            //assertion
            Assert.AreEqual(7, player1.attributes.Count);
        }
        [TestMethod]
        public void PlayerAtrributesRatingTest()
        {
            //arrange 
            Player player1 = new Player("Jan", "Tak", 99, "CM", "Poland", "Wisla", 99, 99, 99, 99, 99, 99);
            //act
            player1.PlayerAttributes();
            //assertion
            Assert.AreEqual(99, player1.attributes[0]);
        }
        [TestMethod]
        public void PlayerAtrributesPaceTest()
        {
            //arrange 
            Player player1 = new Player("Jan", "Tak", 99, "CM", "Poland", "Wisla", 98, 99, 99, 99, 99, 99);
            //act
            player1.PlayerAttributes();
            //assertion
            Assert.AreEqual(98, player1.attributes[1]);
        }
        [TestMethod]
        public void PlayerAtrributesShootingTest()
        {
            //arrange 
            Player player1 = new Player("Jan", "Tak", 99, "CM", "Poland", "Wisla", 98, 97, 99, 99, 99, 99);
            //act
            player1.PlayerAttributes();
            //assertion
            Assert.AreEqual(97, player1.attributes[2]);
        }
    }
}