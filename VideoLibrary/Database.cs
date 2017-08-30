using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace VideoLibrary
{
    class Database
    {
        private Database()
        {
            //数据库文件存储路径,(Environment.CurrentDirectory:为当前工作目录的完全路径)
            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            //创建连接数据库实例，指定文件位置 
            SQLiteConnection con = new SQLiteConnection(dbPath);
            //打开数据库，若文件不存在会自动创建 
            con.Open();
            //建表语句 
            string sql = "CREATE TABLE IF NOT EXISTS student(id integer, name varchar(20), sex varchar(2));";
            //创建sql执行指令对象
            SQLiteCommand com = new SQLiteCommand(sql, con);
            //如果不带参数时, 使用一下语句赋值
            //com.CommandText = sql;
            //com.Connection = con;
            //执行sql指令创建建数据表,如果表不存在，创建数据表 
            com.ExecuteNonQuery();

            //给表添加数据
            //1. 使用sql语句逐行添加
            com.CommandText = "INSERT INTO student VALUES(1, '小红', '男')";
            com.ExecuteNonQuery();
            com.CommandText = "INSERT INTO student VALUES(2, '小李', '女')";
            com.ExecuteNonQuery();
            com.CommandText = "INSERT INTO student VALUES(3, '小明', '男')";
            com.ExecuteNonQuery();
            //2. 使用事务添加
            //实例化一个事务对象
            SQLiteTransaction tran = con.BeginTransaction();
            //把事务对象赋值给com的transaction属性
            com.Transaction = tran;
            //设置带参数sql语句
            com.CommandText = "INSERT INTO student VALUES(@id, @name, @sex)";
            for (int i = 0; i < 10; i++)
            {
                //添加参数
                com.Parameters.AddRange(new[] {//添加参数 
               new SQLiteParameter("@id", i + 1),
               new SQLiteParameter("@name", "test" + i),
               new SQLiteParameter("@sex", i % 3 == 0 ? "男" : "女")
           });
                //执行添加
                com.ExecuteNonQuery();
            }
            //提交事务
            tran.Commit();
            //关闭数据库
            con.Close();

        }
    }
}
