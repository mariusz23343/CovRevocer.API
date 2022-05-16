using Application.Posts;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovRecover.API.Controllers
{
    public class PostsController : ApiControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            
            await _mediator.Send(new Create.Command { Post = post });

            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPost(Guid id, Post post)
        {
            post.Id = id;

            return Ok(await _mediator.Send(new Edit.Command { Post = post }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            return Ok(await _mediator.Send(new Delete.Command { Id = id }));
        }

        [HttpPut("publish/{id}")]
        public async Task<IActionResult> Publish(Guid id)
        {
            return Ok(await _mediator.Send(new Publish.Command { Id = id}));
        }

    }
}
