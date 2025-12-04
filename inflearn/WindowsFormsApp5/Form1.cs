using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 폼을 불러올 때 해당 함수에서 실행 됨
            // 데이터를 행렬로 저장할 수 있는 형식 제공
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();

            // 1개의 열을 추가
            DataColumn dc = new DataColumn();
            dc.ColumnName = "숫자 타입";
            dc.DataType = typeof(int);  // 데이터에 들어갈 타입을 지정

            // 2번째 열
            DataColumn dc2 = new DataColumn();
            dc2.ColumnName = "이름";
            dc2.DataType = typeof(string);

            dt.Columns.Add(dc);
            dt.Columns.Add(dc2);

            // 데이터 테이블 행을 추가
            dt.Rows.Add(1, "정재현");
            dt.Rows.Add(2, "정다현");
            dt.Rows.Add(3, "정해영");
            dt.Rows.Add(4, "정민희");

            // DataSet
            DataSet ds = new DataSet("MyDataSet");
            // 데이터 셋 <- 데이터 테이블을 저장
            ds.Tables.Add(dt);
            ds.Tables.Add(dt2);


            // 데이터 그리드 뷰 데이터 테이블 연결 표시
            dataGridView1.DataSource = ds.Tables[1];  // ds 정보를 연결 dt = ds.Table[0]
            // ds로 관리하는 이유는 특정 조건에 맞는 테이블을 불러오기 위함
        }
    }
}
