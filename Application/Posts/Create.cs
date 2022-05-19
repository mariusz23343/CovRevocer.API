using Application.Core;
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

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Posts.Add(request.Post);

                var result =await _context.SaveChangesAsync() > 0; //jesli cos sie zapisze to bedzie wieksze niz zero

                if (!result) return Result<Unit>.Failure("Nie udalo sie stworzyć posta");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
