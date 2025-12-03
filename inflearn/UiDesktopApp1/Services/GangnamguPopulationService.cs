using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiDesktopApp1.Interface;
using UiDesktopApp1.Models;      // 인터페이스 추가

namespace UiDesktopApp1.Services
{
    class GangnamguPopulationService : IDatabase<GangnamguPopulation>
    {
        // 서비스에 컨텍스트를 추가
        private readonly WpfProjectDatabaseContext? _projectDatabaseContext;

        public GangnamguPopulationService(WpfProjectDatabaseContext databaseContext)
        {
            this._projectDatabaseContext = databaseContext; // 멤버 할당
            // 서비스 처음 생성시 db컨텍스트를 DI를 해서 받아오면 this에 할당
        }

        public List<GangnamguPopulation>? GetDataBaseTable()        //Null able
        {
            return this._projectDatabaseContext?.GangnamguPopulations.ToList();
        }

        public void DeleteDB(int? id)
        {
            // id 에 해당하는 녀석이 있는지 확인
            var validData = this._projectDatabaseContext?.GangnamguPopulations.FirstOrDefault(c=> c.Id == id);

            if (validData != null)
            {
                this._projectDatabaseContext?.GangnamguPopulations.Remove(validData);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public GangnamguPopulation? GetDetail(int? id)
        {
            var validData = this._projectDatabaseContext?.GangnamguPopulations.FirstOrDefault(c=>c.Id == id);
            if (validData != null)
            {
                return validData;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void InsertDB(GangnamguPopulation entity)
        {
            // Add : 데이터 추가
            this._projectDatabaseContext?.GangnamguPopulations.Add(entity);
            this._projectDatabaseContext?.SaveChanges(); // DB 변경점 적용
        }

        public void UpdateDB(GangnamguPopulation entity)
        {
            this._projectDatabaseContext?.GangnamguPopulations.Update(entity);
            this._projectDatabaseContext?.SaveChanges();
        }
    }
}
