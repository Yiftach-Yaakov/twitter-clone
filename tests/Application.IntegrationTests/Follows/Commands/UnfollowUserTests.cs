using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using TwitterClone.Application.Common.Exceptions;
using TwitterClone.Application.Follows.Commands.UnfollowUserCommand;
using static TwitterClone.Application.IntegrationTests.Testing;

namespace TwitterClone.Application.IntegrationTests.Follows.Commands
{
    public class UnfollowUserCommandTests : TestBase
    {
        [Test]
        public async Task ShouldRequireValidUserId()
        {
            var command = new UnfollowUserCommand { UserId = 123};

            await RunAsDefaultDomainUserAsync();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldRemoveFollow()
        {
            var userId = await RunAsDefaultDomainUserAsync();

            var followed = new User { Username = "Followed", FullName = "Followed", ApplicationUserId = "Testing" };
            await AddAsync(followed);
            await AddAsync(new Follow { FollowerId = userId, FollowedId = followed.Id});

            var follow = await FindAsync<Follow>(userId, followed.Id);
            follow.Should().NotBeNull();

            var command = new UnfollowUserCommand { UserId = followed.Id };
            await SendAsync(command);

            follow = await FindAsync<Follow>(userId, followed.Id);
            follow.Should().BeNull();
        }
    }
}