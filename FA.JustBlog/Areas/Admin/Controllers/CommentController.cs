using FA.JustBlog.Services.CommentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Comment;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Route("comments")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> ListComment()
        {
            return await Task.FromResult(View());
        }

        [Route("getcomments")]
        [AllowAnonymous]
        public async Task<JsonResult> GetAllComment()
        {
            var comments = await _commentService.GetAllComment();
            var commentJson = comments.Select(x =>
                new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    CommentHeader = x.CommentHeader,
                    CommentText = x.CommentText,
                    CommentTime = x.CommentTime.ToString("dd/MM/yyyy hh:mm tt"),
                    PostId = x.PostId,
                    PostTitle = x.PostTitle
                }).ToList();

            var json = new { data = commentJson };
            return Json(json);
        }

        [Route("comment/delete")]
        [Authorize(Roles = "Blog Owner")]
        public async Task<IActionResult> DeleteComment(Guid commentId)
        {
            var result = await _commentService.DeleteComment(commentId);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("comment/create")]
        [Authorize(Roles = "Blog Owner")]
        public async Task<IActionResult> CreateComment()
        {
            return await Task.FromResult(View());
        }

        [HttpPost("comment/create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateComment(CommentDetailsModel comment)
        {
            var result = await _commentService.CreateComment(comment);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("comment/update/{commentId}")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> UpdateComment(Guid commentId)
        {
            var comment = await _commentService.GetComment(commentId);

            return View(comment);
        }

        [Route("comment/update")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpPost]
        public async Task<IActionResult> UpdateComment(CommentDetailsModel model)
        {
            var result = await _commentService.UpdateComment(model);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}