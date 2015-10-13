namespace CommandQuery.Sample.Migrations
{
    using CommandQuery.Sample.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CommandQuery.Sample.DataAccess.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CommandQuery.Sample.DataAccess.DataContext context)
        {
            //blog1
            var author1 = new Author { Id = Guid.NewGuid(), FirstName = "Zepho", LastName = "Bark"};

            var comment1 = new Comment() { Id = Guid.NewGuid(), Name = "Randolph St. Cosmo", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            var comment2 = new Comment() { Id = Guid.NewGuid(), Name = "Darby Suckling", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            var comment3 = new Comment() { Id = Guid.NewGuid(), Name = "Lindsay Noseworth", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            
            var comments1 = new List<Comment>() { comment1, comment2, comment3 };
            var post1 = new Post { Id = Guid.NewGuid(), Title = "Lorem ipsum dolor", Author = author1, Comments = comments1, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." };
            
            var comment4 = new Comment() { Id = Guid.NewGuid(), Name = "Miles Blundell", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            var comment5 = new Comment() { Id = Guid.NewGuid(), Name = "Chick Counterfly", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            
            var comments2 = new List<Comment>() { comment4, comment5 };
            var post2 = new Post { Id = Guid.NewGuid(), Title = "Sed ut perspiciatis", Author = author1, Comments = comments2, Content = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?" };
            
            var comment6 = new Comment() { Id = Guid.NewGuid(), Name = "Miles Blundell", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            var comment7 = new Comment() { Id = Guid.NewGuid(), Name = "Chick Counterfly", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            
            var comments3 = new List<Comment>() { comment6, comment7 };
            var post3 = new Post { Id = Guid.NewGuid(), Title = "At vero eos et accusamus", Author = author1, Comments = comments3, Content = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat." };
            
            var posts1 = new List<Post>() { post1, post2, post3 };
            var blog1 = new Blog { Id = Guid.NewGuid(), Name = "Flux In A Box", Posts = posts1 };

            //blog2
            var author2 = new Author { Id = Guid.NewGuid(), FirstName = "Teddy", LastName = "Bloat"};

            var comment8 = new Comment() { Id = Guid.NewGuid(), Name = "Randolph St. Cosmo", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            var comment9 = new Comment() { Id = Guid.NewGuid(), Name = "Darby Suckling", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            var comment10 = new Comment() { Id = Guid.NewGuid(), Name = "Lindsay Noseworth", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            
            var comments4 = new List<Comment>() { comment8, comment9, comment10 };
            var post4 = new Post { Id = Guid.NewGuid(), Title = "Libero sed neque vivamus", Author = author2, Comments = comments4, Content = "Libero sed neque vivamus scelerisque arcu etiam, nibh elit, in aliquet, ultrices odio ante fusce. Tortor ac arcu dui nulla vitae ut. Natoque ultricies ultricies vivamus nam, pellentesque pharetra pellentesque neque fames fermentum, quam hendrerit, fames felis mauris ultricies tellus. Lectus sed mauris leo, nullam netus penatibus nascetur proin, laoreet vestibulum, vitae nisl molestie dictumst integer felis et. Commodi a pretium placerat non, nonummy erat id scelerisque felis, tempor aspernatur sit enim, in et cum. Magna nisl magna malesuada velit, dolor magnis blandit inceptos elit nullam ac, eu a, tortor nam volutpat. Aenean integer nec faucibus lacus ut ad, donec augue suscipit at, egestas accumsan mauris, malesuada nulla suscipit in suspendisse tempor. Ante dolor, eros magna, eros in proin ipsum nulla, arcu integer. Amet pellentesque facilisi nascetur per porta cras, turpis est neque fusce purus nonummy, nec mi ligula molestiae mauris quis, leo sit lacus nec gravida." };
            
            var comment11 = new Comment() { Id = Guid.NewGuid(), Name = "Miles Blundell", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            var comment12 = new Comment() { Id = Guid.NewGuid(), Name = "Chick Counterfly", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            
            var comments5 = new List<Comment>() { comment11, comment12 };
            var post5 = new Post { Id = Guid.NewGuid(), Title = "Curabitur sit amet mauris", Author = author2, Comments = comments5, Content = "Curabitur sit amet mauris. Morbi in dui quis est pulvinar ullamcorper. Nulla facilisi. Integer lacinia sollicitudin massa. Cras metus. Sed aliquet risus a tortor. Integer id quam. Morbi mi. Quisque nisl felis, venenatis tristique, dignissim in, ultrices sit amet, augue. Proin sodales libero eget ante. Nulla quam." };
            
            var comment13 = new Comment() { Id = Guid.NewGuid(), Name = "Miles Blundell", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            var comment14 = new Comment() { Id = Guid.NewGuid(), Name = "Chick Counterfly", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            
            var comments6 = new List<Comment>() { comment13, comment14 };
            var post6 = new Post { Id = Guid.NewGuid(), Title = "Quisque volutpat condimentum velit", Author = author2,  Comments = comments6, Content = "Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. Proin quam. Etiam ultrices." };

            var posts2 = new List<Post>() { post4, post5, post6 };
            var blog2 = new Blog { Id = Guid.NewGuid(), Name = "Fun With Teeth", Posts = posts2 };

            //blog2
            var author3 = new Author { Id = Guid.NewGuid(), FirstName = "Meatball", LastName = "Mulligan" };

            var comment15 = new Comment() { Id = Guid.NewGuid(), Name = "Randolph St. Cosmo", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            var comment16 = new Comment() { Id = Guid.NewGuid(), Name = "Darby Suckling", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            var comment17 = new Comment() { Id = Guid.NewGuid(), Name = "Lindsay Noseworth", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            
            var comments7 = new List<Comment>() { comment15, comment16, comment17 };
            var post7 = new Post { Id = Guid.NewGuid(), Title = "Integer nec odio", Author = author3, Comments = comments7, Content = "Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. Curabitur tortor." };
            
            var comment18 = new Comment() { Id = Guid.NewGuid(), Name = "Miles Blundell", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            var comment19 = new Comment() { Id = Guid.NewGuid(), Name = "Chick Counterfly", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            
            var comments8 = new List<Comment>() { comment18, comment19 };
            var post8 = new Post { Id = Guid.NewGuid(), Title = "Pellentesque nibh", Author = author3, Comments = comments8, Content = "Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. Quisque volutpat condimentum velit." };
            
            var comment20 = new Comment() { Id = Guid.NewGuid(), Name = "Miles Blundell", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };
            var comment21 = new Comment() { Id = Guid.NewGuid(), Name = "Chick Counterfly", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla." };

            var comments9 = new List<Comment>() { comment20, comment21 };
            var post9 = new Post { Id = Guid.NewGuid(), Title = "Integer euismod lacus luctus", Author = author3, Comments = comments9, Content = "Integer euismod lacus luctus magna. Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. Praesent blandit dolor. Sed non quam. In vel mi sit amet augue congue elementum. Morbi in ipsum sit amet pede facilisis laoreet. Donec lacus nunc, viverra nec, blandit vel, egestas et, augue. Vestibulum tincidunt malesuada tellus. Ut ultrices ultrices enim. Curabitur sit amet mauris. Morbi in dui quis est pulvinar ullamcorper." };

            var posts3 = new List<Post>() { post7, post8, post9 };
            var blog3 = new Blog { Id = Guid.NewGuid(), Name = "Zero-Gravity Tea Ceremony", Posts = posts3  };

            context.Blogs.AddOrUpdate(
                p => p.Id,
                blog1,
                blog2,
                blog3
                );
        }
    }
}
