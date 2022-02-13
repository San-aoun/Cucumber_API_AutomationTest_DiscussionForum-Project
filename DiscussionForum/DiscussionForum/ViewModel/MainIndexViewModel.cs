using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscussionForum.Models.db;
using Microsoft.EntityFrameworkCore;

namespace DiscussionForum.ViewModel
{
    public class MainIndexViewModel
    {
        public DbSet<Category> CategoriesLists { get; set; }
        public IQueryable<Discussion> DiscussionsLists { get; set; }
    }
}
