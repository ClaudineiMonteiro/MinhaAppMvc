using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vm.Business.Interfaces;
using Vm.Business.Models;
using Vm.Data.Context;

namespace Vm.Data.Repository
{
	public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
	{
		protected readonly MinhaAppMvcDbContext Db;
		protected readonly DbSet<TEntity> DbSet;

		public BaseRepository(MinhaAppMvcDbContext db)
		{
			Db = db;
			DbSet = db.Set<TEntity>();
		}

		public virtual async Task Add(TEntity entity)
		{
			Db.Add(entity);
			await SaveChanges();
		}

		public virtual async Task Update(TEntity entity)
		{
			Db.Update(entity);
			await SaveChanges();
		}

		public virtual async Task Remove(Guid id)
		{
			DbSet.Remove(new TEntity { Id = id });
			await SaveChanges();
		}

		public virtual async Task<List<TEntity>> GetAll()
		{
			return await DbSet.ToListAsync();
		}

		public virtual async Task<TEntity> GetById(Guid id)
		{
			return await DbSet.FindAsync(id);
		}

		public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
		{
			return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
		}

		public async Task<int> SaveChanges()
		{
			return await Db.SaveChangesAsync();
		}

		public void Dispose()
		{
			Db?.Dispose();
		}
	}
}
