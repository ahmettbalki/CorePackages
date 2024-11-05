using CorePackages.Persistence.Dynamic;
using CorePackages.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
namespace CorePackages.Persistence.Repositories;
public interface IRepository<TEntity, TId> : IQuery<TEntity> where TEntity : Entity<TId>, new()
{
    TEntity? Get(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);
    Paginate<TEntity> GetList(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);
    Paginate<TEntity> GetListByDynamic(
        DynamicQuery dynamic,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);
    bool Any(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);
    TEntity AddAsync(TEntity entity);
    ICollection<TEntity> AddRange(ICollection<TEntity> entity);
    TEntity Update(TEntity entity);
    ICollection<TEntity> UpdateRange(ICollection<TEntity> entity);
    TEntity Delete(TEntity entity, bool permanent = false);
    ICollection<TEntity> DeleteRange(ICollection<TEntity> entity, bool permanent = false);
}
