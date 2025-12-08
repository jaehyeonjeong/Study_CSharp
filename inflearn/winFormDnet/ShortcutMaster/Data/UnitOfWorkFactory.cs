using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.Data
{
    // 인터페이스
    public interface IUnitOfWorkFactory<TDbContext>
        where TDbContext : DbContext
    {
        // 트랜잭션을 사용할지에 대한 여부, 비동기를 캔슬하기 위한 토큰을 추가하는 매개변수
        Task<UnitOfWorkSession<TDbContext>> CreateSessionAsync(bool useTransaction = true, CancellationToken
            cancellationToken = default);
    }
    // 인터페이스 구현 클래스
    public class UnitOfWorkFactory<TDbContext> : IUnitOfWorkFactory<TDbContext>
        where TDbContext : DbContext
    {
        private readonly IServiceProvider _services;

        public UnitOfWorkFactory(IServiceProvider service)
        {
            _services = service;
        }

        public async Task<UnitOfWorkSession<TDbContext>> CreateSessionAsync(
            bool useTransaction = true, 
            CancellationToken cancellationToken = default)
        {
            // Dispose 구문이 모두 실행이 되게 되면 스코프와 DbContext의 메모리가 삭제
            var scope = _services.CreateAsyncScope();     
            var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

            IDbContextTransaction? transaction = null;

            // 예외 발생 시 scope패기를 보장하기 위해 try-catch 또는 try-finally를 사용
            try
            {
                if(useTransaction)
                {
                    transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
                }
                return new UnitOfWorkSession<TDbContext>(scope, dbContext, transaction);
                // 즉, 데이터를 읽을 때는 트랜잭션을 사용하지 않아도 괜찮지만,
                // 일반적으로 데이터를때는 트랜잭션을 사용해주는게 데이터 일관성을 보장해준다.
            }
            catch
            {
                await scope.DisposeAsync();
                throw;
            }
        }
    }

    public class UnitOfWorkSession<TDbContext> : IAsyncDisposable
        where TDbContext : DbContext
    {
        private readonly AsyncServiceScope _scope;
        private readonly IServiceProvider _serviceProvider;
        private readonly TDbContext _dbContext;
        private readonly IDbContextTransaction? _transaction;
        private bool _committed = false;

        public UnitOfWorkSession(AsyncServiceScope scope, TDbContext dbContext, IDbContextTransaction? transaction)
        {
            _scope = scope;
            _dbContext = dbContext;
            _transaction = transaction;
            _serviceProvider = _scope.ServiceProvider;
        }

        public TDbContext Context => _dbContext;

        // 해당 스코프 안에서 DI를 하기 위한 매서드
        public TService Resolve<TService>() where TService : notnull
        {
            return _serviceProvider.GetRequiredService<TService>();
        }
        
        // 트랜잭션을 사용하는 경우 커밋하기 위해 만들어 놓은 매서드
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if(_transaction != null && !_committed)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
                await _transaction.CommitAsync(cancellationToken);
                _committed = true;
            }
        }
        
        public async ValueTask DisposeAsync()
        {
            // 트랜젝션이 null이 아니고 커밋이 되지 않았다면 트랜잭션을 롤백
            if (_transaction != null && !_committed)
            {
                await _transaction.RollbackAsync();
            }

            // 트랜잭션이 null이 아니라면 트랜잭션의 메모리를 해제
            if(_transaction != null)
            {
                await _transaction.DisposeAsync();
            }

            await _dbContext.DisposeAsync();
            await _scope.DisposeAsync();
        }
    }
}
