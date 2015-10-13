using AutoMapper;
using CommandQuery.Core;
using CommandQuery.Sample.CQRS.Command;
using CommandQuery.Sample.DataAccess;
using CommandQuery.Sample.Utilities;
using CommandQuery.Sample.Models;
using System;
using System.Threading.Tasks;

namespace CommandQuery.Sample.CQRS.CommandHandler.Blog
{
    public class CreateBlogCommandHandler : ICommandHandlerAsync<CreateBlog>
    {
        private IDataContext Context { get; set; }
        private IMappingEngine Mapper { get; set; }

        public CreateBlogCommandHandler(IDataContext context, IMappingEngine mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<CommandResult> ExecuteAsync(CreateBlog command)
        {
            var result = new CommandResult();

            try
            {
                ValidateArguments(command);

                var blog = new Models.Blog();
                blog = Mapper.Map(command, blog);

                if (blog != null)
                    Context.Blogs.Add(blog);

                await Context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Blog successfully added";
                result.Data = blog.Id;

                return result;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                return result;
            }
        }

        public void ValidateArguments(CreateBlog command)
        {
            Ensure.Argument.IsNot(command == null);
            Ensure.Argument.IsNot(string.IsNullOrEmpty(command.Name));
        }
    }
}