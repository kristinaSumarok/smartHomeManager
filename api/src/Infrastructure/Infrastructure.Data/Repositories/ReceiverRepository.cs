using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.ApplicationCore.Models;
using Homemap.Domain.Common;
using Homemap.Domain.Core;
using Homemap.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Homemap.Infrastructure.Data.Repositories {
    internal class ReceiverRepository : Repository, IReceiverRepository {
        private readonly DbSet<Receiver> _receivers;
        private readonly ApplicationDbContext _context;

        public ReceiverRepository(ApplicationDbContext context) : base(context) {
            _receivers = context.Set<Receiver>();
            _context = context;
        }

        public async Task<Receiver> AddAsync(Receiver entity) {
            await _receivers.AddAsync(entity);
            return entity;
        }

        public async Task<IReadOnlyList<Receiver>> FindAllAsync() {
            return await _receivers.ToListAsync();
        }

        public async Task<Receiver?> FindByIdAsync(int id) {
            return await _receivers.FindAsync(id);
        }

        public async Task<Receiver?> FindByConditionAsync(Expression<Func<Receiver, bool>> predicate) {
            return await _receivers.Where(predicate).FirstOrDefaultAsync();
        }

        public void Remove(Receiver entity) {
            _receivers.Remove(entity);
        }

        public void Update(Receiver entity) {
            _receivers.Update(entity);
        }

        public async Task<IReadOnlyList<Receiver>> FindByParentAsync(int parentId) {
            return await _receivers.Where(e => EF.Property<int>(e, "ProjectId") == parentId).ToListAsync();
        }

        public async Task<bool> ProjectExistsAsync(int projectId) {

            return await _context.Projects.AnyAsync(p => p.Id == projectId);
        }
    }
  }
