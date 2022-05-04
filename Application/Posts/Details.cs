﻿using Domain;
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
    public class Details
    {
        public class Query : IRequest<Post>
        {
            public Guid Id { get; set; } 
        }

        public class Handler : IRequestHandler<Query, Post>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Post> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Posts.FirstOrDefaultAsync(x => x.Id == request.Id);
            }
        }
    }
}
