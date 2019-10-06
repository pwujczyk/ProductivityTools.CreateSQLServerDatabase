namespace ProductivityTools.CreateSQLServerDatabase
{
    public interface IDatabase
    {
        void Create();
        void CreateSilent();
        bool Exists();
    }
}