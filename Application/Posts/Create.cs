using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Posts
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>> 
        {
            public Post Post;
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Post).SetValidator(new PostValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var user = _context.Users.FirstOrDefault(x => x.UserName == _userAccessor.GetUsername());

                request.Post.User = user;

                _context.Posts.Add(request.Post);

                var result =await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Nie udalo sie stworzyć posta");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
