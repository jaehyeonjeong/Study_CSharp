using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiDesktopApp1.Models;

namespace UiDesktopApp1.Interface
{
    public interface IDatabase<T>      // 템플릿 T를 구현함으로 DB의 컬럼이 추가되더라도 가변성 있게 데이터를 출력
    {
        // 데이터 베이스 인터페이스에 대한 고민을 해봐야함
        // 테이블에 대한 모든 데이터 
        List<T>? GetDataBaseTable();   //Null able

        // 테이블에 대해 특정 ID에 해당하는 데이터 조회
        T? GetDetail(int? id);   //Null able

        // 테이블에 특정 DATA INSERT
        void InsertDB(T entity);

        // 테이블에 특정 DATA UPDATE
        void UpdateDB(T entity);

        // 테이블에 특정 DATA DELTETE
        void DeleteDB(int? id);
    }
}
