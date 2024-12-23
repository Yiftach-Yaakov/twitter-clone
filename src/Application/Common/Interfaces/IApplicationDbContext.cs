﻿using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterClone.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Conversation> Conversations { get; set; }
        DbSet<User> DomainUsers { get; set; }
        DbSet<Follow> Follows { get; set; }
        DbSet<Like> Likes { get; set; }
        DbSet<Media> Medias { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<RePost> RePosts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
