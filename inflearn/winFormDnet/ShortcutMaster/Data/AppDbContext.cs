using Microsoft.EntityFrameworkCore;
using ShortcutMaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.Data
{
    public class AppDbContext : DbContext
    {
        // EF Core에서 DBSet을 통한 테이블 데이터 추가, 조회, 수정, 삭제등의 작업 진행
        public DbSet<User> Users { get; set; } = null!;
        // 생성자 코드를 작성하는 이유는 의존성 주입을 통해서 DB 컨텍스트를 초기화 하기 위함
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        // Fluent API 방식
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);       // 고유 PK
                entity.HasIndex(u => u.UserID).IsUnique();  // 고유 값
                entity.Property(u => u.UserID).IsRequired().HasMaxLength(50);    // Not null
                entity.Property(u => u.Password).IsRequired().HasMaxLength(100);    // Not null
                entity.Property(u => u.Email).IsRequired().HasMaxLength(50);    // Not null
            });
        }
    }
}
