using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Posts
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(10).MaximumLength(50);
            RuleFor(x => x.Summary).NotEmpty().MinimumLength(20);
            RuleFor(x => x.CreatedAt).NotEmpty();
            RuleFor(x => x.Content).NotEmpty().MinimumLength(300);
            RuleFor(x => x.IsPublished).NotEmpty();
        }
    }
}
