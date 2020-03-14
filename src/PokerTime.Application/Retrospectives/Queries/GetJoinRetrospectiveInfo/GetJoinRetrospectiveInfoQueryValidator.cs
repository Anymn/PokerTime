﻿// ******************************************************************************
//  ©  Sebastiaan Dammann | damsteen.nl
// 
//  File:           : GetJoinRetrospectiveInfoQueryValidator.cs
//  Project         : PokerTime.Application
// ******************************************************************************

namespace PokerTime.Application.Retrospectives.Queries.GetJoinRetrospectiveInfo {
    using FluentValidation;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = "This is a validation rule set.")]
    public sealed class GetJoinRetrospectiveInfoQueryValidator : AbstractValidator<GetJoinRetrospectiveInfoQuery> {
        public GetJoinRetrospectiveInfoQueryValidator() {
            this.RuleFor(x => x.SessionId).NotEmpty();
        }
    }
}
