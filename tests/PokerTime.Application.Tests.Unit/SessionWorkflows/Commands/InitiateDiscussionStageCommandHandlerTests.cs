﻿// ******************************************************************************
//  © 2019 Sebastiaan Dammann | damsteen.nl
// 
//  File:           : InitiateDiscussionStageCommandHandlerTests.cs
//  Project         : PokerTime.Application.Tests.Unit
// ******************************************************************************

namespace PokerTime.Application.Tests.Unit.SessionWorkflows.Commands {
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.SessionWorkflows.Commands;
    using Domain.Entities;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public sealed class InitiateDiscussionStageCommandHandlerTests : RetrospectiveWorkflowCommandTestBase {
        [Test]
        public void InitiateDiscussionStageCommandHandler_InvalidSessionId_ThrowsNotFoundException() {
            // Given
            const string sessionId = "not found surely :)";
            var handler = new InitiateDicussionStageCommandHandler(this.Context, this.SessionStatusUpdateDispatcherMock, this.SystemClockMock);
            var request = new InitiateDiscussionStageCommand { SessionId = sessionId, TimeInMinutes = 10 };

            // When
            TestDelegate action = () => handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();

            // Then
            Assert.That(action, Throws.InstanceOf<NotFoundException>());
        }

        [Test]
        public async Task InitiateDiscussionStageCommandHandler_OnStatusChange_UpdatesRetroStageAndInvokesNotification() {
            // Given
            var handler = new InitiateDicussionStageCommandHandler(this.Context, this.SessionStatusUpdateDispatcherMock, this.SystemClockMock);
            var request = new InitiateDiscussionStageCommand { SessionId = this.SessionId, TimeInMinutes = 10 };

            this.SystemClockMock.CurrentTimeOffset.Returns(DateTimeOffset.UnixEpoch);

            // When
            await handler.Handle(request, CancellationToken.None);

            this.RefreshObject();

            // Then
            Assert.That(this.Session.CurrentStage, Is.EqualTo(SessionStage.Discussion));

            await this.SessionStatusUpdateDispatcherMock.Received().DispatchUpdate(Arg.Any<Session>(), CancellationToken.None);
        }
    }
}