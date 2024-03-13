
using MediatR;
using Moq;
using SlapBott.Data.Models;
using SlapBott.Services;
using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;

namespace SlapBottTests.Services
{
    public class AttackServiceTests
    {
        private Mock<IRaidService> _mockIRaidService;
        private Mock<PlayerCharacterDto> _mockCharacter;
        private readonly Mock<IMediator> _mockMediator;

        public AttackServiceTests() {
            _mockIRaidService = new Mock<IRaidService>();
            _mockCharacter = new Mock<PlayerCharacterDto>();
            _mockMediator = new Mock<IMediator>();
        }


       //given 


        //[Fact]
        //public void AssignAttack_GivenInvalidRaidData_ShouldReturnString()
        //{
        //    // arrange
        //    string playerSkill = "Strike";
        //    string raid = "sfdbui";
        //    string PlayerInput = $"{raid} {playerSkill}";
        //    var attackService = new AttackService(_mockIRaidService.Object);
        //    //var skill = new Skill { Name = "Strike" };
        //    //_mockCharacter.Object.Skills = new List<Skill>() { skill };


        //    var result = attackService.AssignAttack(_mockCharacter.Object, 1, null);

        //    //assert
        //    Assert.Equal("Somthing Went Wrong", result);

        //}
        //[Fact]
        //public void ShouldReturnReplyWhenSkillImputRaidIsvalid()
        //{
        //    // arrange
        //    var mockIRaidService = new Mock<IRaidService>();
        //    var mockCharacter = new Mock<CharacterDto>();
        //    string playerSkill = "Strike";
        //    string raid = "";
        //    string PlayerInput = $"{playerSkill}";
        //    var attackService = new AttackService(_mockIRaidService.Object);
        //    var skill = new Skill { Name = "Strike" };
        //    mockCharacter.Object.Skills = new List<Skill>() { skill };



        //    var result = attackService.AssignAttack(mockCharacter.Object, PlayerInput);

        //    //assert
        //    Assert.Equal("Somthing Went Wrong", result);

        //}
        //[Fact]
        //public void ShouldReturnStringReplyWhenNoPlayerInput()
        //{
        //    // arrange
        //    var mockIRaidService = new Mock<IRaidService>();
        //    var mockCharacter = new Mock<CharacterDto>();
          
        //    string PlayerInput = string.Empty;
        //    var attackService = new AttackService(_mockIRaidService.Object);
        //    var skill = new Skill { Name = "Strike" };
        //    mockCharacter.Object.Skills = new List<Skill>() { skill };



        //    var result = attackService.AssignAttack(mockCharacter.Object, PlayerInput);

        //    //assert
        //    Assert.Equal("Please Specify the Skill you want to Use", result);

        //}
        //[Fact]
        //public void ShouldReturnStringReplyWhenPlayerImputInvalid()
        //{
        //    // arrange
        //    var mockIRaidService = new Mock<IRaidService>();
        //    var mockCharacter = new Mock<CharacterDto>();
        //    string playerSkill = "fsdnbfien";
        //    string raid = "raid";
        //    string PlayerInput = $"{raid} {playerSkill}";
        //    var attackService = new AttackService(_mockIRaidService.Object);
        //    var skill = new Skill { Name = "Strike" };
        //    mockCharacter.Object.Skills = new List<Skill>() { skill };



        //    var result = attackService.AssignAttack(mockCharacter.Object, PlayerInput);

        //    //assert
        //    Assert.Equal($"You do not Have {playerSkill} Skill", result);

        //}
        //[Fact]
        //public void ShouldCallAttackRaidWhenImputsAreValid()
        //{
        //    // arrange

        //    var skill = new Skill { Name = "Strike" };

        //    //var mockIRaidService = new Mock<IRaidService>();
        //    IMock<CharacterDto> mockCharacter = new Mock<CharacterDto>();

        //    //mockIRaidService.Setup( x=> x.AttackRaid(
        //    //        It.IsAny<CharacterDto>(),
        //    //        It.IsAny<Skill>()
        //    //    )).Returns("This is the result");

        //    RaidService d = new RaidService();

        //    string playerSkill = "Strike";
        //    string raid = "Raid";
        //    string PlayerInput = $"{raid} {playerSkill}";
        //    var attackService = new AttackService(d);

        //    mockCharacter.Object.Skills = new List<Skill>() { skill };

        //    var result = attackService.AssignAttack(mockCharacter.Object, PlayerInput);

        //    Assert.NotNull(result);
        //    //assert
        //}
        // /attack raid -> /attack -> /attack skill/slash


        //if player input is not equal to raid then return string.empty

        //if player input is equal to raid then attackRaid on raidserive should be called



        //mockIRaidService
        //        .Setup(x => x.AttackRaid(It.IsAny<CharacterDto>()))
        //            .Returns("");

        //


        //    mockIRaidService
        //.Verify(x => x.AttackRaid(It.IsAny<CharacterDto>()), Times.Once);


    }
}
