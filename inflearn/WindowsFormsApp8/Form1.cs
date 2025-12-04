using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataColumn col1 = new DataColumn();
            col1.ColumnName = "Column1";
            col1.DataType = typeof(string);

            DataColumn col2 = new DataColumn();
            col2.ColumnName = "Column2";   
            col2.DataType = typeof(int);   

            DataTable dt1 = new DataTable();
            dt1.Columns.Add(col1);
            dt1.Columns.Add(col2);

            dt1.Rows.Add("Row1", 1);
            dt1.Rows.Add("Row2", 2);

            dataGridView1.DataSource = dt1;
        }

        /// <summary>
        /// 오류 함수
        /// </summary>
        private void myFunction1()      // 오류 발생 함수
        {
            // 의도적으로 에러 발생
            throw new Exception("An error occurred in myFunction1.");
        }

        /// <summary>
        /// 정상 덧셈 함수
        /// </summary>
        /// <param name="x">첫 번째 정수</param>
        /// <param name="y">두 번째 정수</param>
        /// <returns>두 정수의 합</returns>
        private int myFunction2(int x, int y)   // 정상 덧셈 함수
        {
            int num3 = 0;
            int num4 = 0;
            num3 = x;
            num4 = y;
            return num3 + num4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 5;
            int b = 10;
            int c = 0;

            MessageBox.Show("c is: " + c.ToString());

            // 덧셈 함수
            c = myFunction2(a, b);

            MessageBox.Show("The sum of a and b is: " + c.ToString());
        }
    }
}
