﻿

using SlapBott.Services.Contracts;
using SlapBott.Services.Implmentations;

namespace SlapBottTests.Services
{
    public class RaidServiceTests
    {

        const ulong userId = 1;
        const ulong channelId = 1;
        // Join Raid Returns msg that user has joined the raid
        [Fact]
        void ShouldReturnJoinedMessageWhenUserJoinsRaid()
        {
            IRaidService raidService = new RaidService(null);

            string result = raidService.JoinRaid(userId, channelId);

            Assert.True("you have joined the raid" == result.ToLower());
        }


        [Fact]
        void ShouldThrowExceptionIfUserDoesntExist()
        {
            IRaidService raidService = new RaidService(null);

            Assert.Throws<Exception>(() => { raidService.JoinRaid(userId, channelId); });
        }


        

    }
}
