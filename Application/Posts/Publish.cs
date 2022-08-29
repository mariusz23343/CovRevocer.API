using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Posts
{
    public class Publish
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.Include(post => post.User).FirstOrDefaultAsync(x => x.Id == request.Id);

                post.IsPublished = true;

                post.PublishedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
