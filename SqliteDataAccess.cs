using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace ADAL_Video
{
    public class SqliteDataAccess
    {
        public static List<TimeModel> LoadTime(string TableName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    var output = cnn.Query<TimeModel>("select * from " + TableName, new DynamicParameters());
                    return output.ToList();
                }
                catch
                {
                    try
                    {
                        var output = cnn.Query<TimeModel>("select * from " + "table"+(Convert.ToInt32(TableName.Substring(5))-1).ToString(), new DynamicParameters());
                        return output.ToList();
                    }
                    catch
                    {
                        try
                        {
                            var output = cnn.Query<TimeModel>("select * from " + "table" + (Convert.ToInt32(TableName.Substring(5)) + 1).ToString(), new DynamicParameters());
                            return output.ToList();
                        }
                        catch
                        {
                            return null;
                        }
                    }
                }
                
            }
        }
        public static void CreateTimeTable(string TableName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Execute("CREATE TABLE " + TableName + " ( Time  INTEGER PRIMARY KEY ASC, Name  TEXT, Note  TEXT)");
                }
                catch
                {
                    Console.WriteLine("Не получилось создать базу данных");
                }
            }
        }
        public static void SaveTime(TimeModel times, string TableName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Execute("insert into " + TableName + " (Time, Name,Note) values (@Time, @Name,@Note)", times);
                }
                catch
                {
                    try
                    {
                        cnn.Execute("insert into "+"table" + (Convert.ToInt32(TableName.Substring(5)) - 1).ToString() + " (Time, Name,Note) values (@Time, @Name,@Note)", times);
                    }
                    catch
                    {
                        try
                        {
                            cnn.Execute("insert into " + "table" + (Convert.ToInt32(TableName.Substring(5)) + 1).ToString() + " (Time, Name,Note) values (@Time, @Name,@Note)", times);
                        }
                        catch
                        {
                            Console.WriteLine("Не удалось добавить");
                        }
                    }
                }
            }
        }
        public static void RenameTime(TimeModel times, string TableName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Execute("update " + TableName + " set Time = @Time, Name = @Name, Note = @Note where Time = @Time", times);
                }
                catch
                {
                    try
                    {
                        cnn.Execute("update " + "table" + (Convert.ToInt32(TableName.Substring(5)) - 1).ToString() + " set Time = @Time, Name = @Name, Note = @Note where Time = @Time", times);
                    }
                    catch
                    {
                        try
                        {
                            cnn.Execute("update " + "table" + (Convert.ToInt32(TableName.Substring(5)) + 1).ToString() + " set Time = @Time, Name = @Name, Note = @Note where Time = @Time", times);
                        }
                        catch
                        {
                            Console.WriteLine("Не удалось перем");
                        }
                    }
                }
            }
        }
        public static void DeleteTime(TimeModel times, string TableName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try 
                { 
                    cnn.Execute("delete from " + TableName + " where Time = @Time", times);
                }
                catch
                {
                    try
                    {
                        cnn.Execute("delete from " + "table" + (Convert.ToInt32(TableName.Substring(5)) - 1).ToString()+ " where Time = @Time", times);
                    }
                    catch
                    {
                        try
                        {
                            cnn.Execute("delete from " + "table" + (Convert.ToInt32(TableName.Substring(5)) + 1).ToString() + " where Time = @Time", times);
                        }
                        catch
                        {
                            Console.WriteLine("Не удалось удалить");
                        }
                    }
                }
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}