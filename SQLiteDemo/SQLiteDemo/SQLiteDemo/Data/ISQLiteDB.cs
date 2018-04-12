using SQLite;
namespace SQLiteDemo
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
