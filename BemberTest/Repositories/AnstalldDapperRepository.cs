using BemberTest.Models;
using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace BemberTest.Repositories
{
    public class AnstalldDapperRepository : IAnstalldDapperRepository
    {
        private readonly string _connectionString;

        public AnstalldDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task<int> AddAsync(Anstalld anstalld)
        {
            using var connection = CreateConnection();
            const string sql = "INSERT INTO Anstalld (AnstalldNamn, Foretag) VALUES (@AnstalldNamn, @Foretag) RETURNING AnstalldId";
            return await connection.ExecuteScalarAsync<int>(sql, anstalld);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            const string sql = "DELETE FROM Anstalld WHERE AnstalldId = @AnstalldId";
            int affectedRows = await connection.ExecuteAsync(sql, new { AnstalldId = id });
            return affectedRows > 0;
        }

        public async Task<IEnumerable<Anstalld>> GetAllAsync()
        {
            using var connection = CreateConnection();
            const string sql = "SELECT * FROM Anstalld";
            return await connection.QueryAsync<Anstalld>(sql);
        }

        public async Task<Anstalld> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            const string sql = "SELECT * FROM Anstalld WHERE AnstalldId = @Id";
            return await connection.QuerySingleOrDefaultAsync<Anstalld>(sql, new { Id = id });
        }


        public async Task<bool> UpdateAsync(Anstalld anstalld)
        {
            using var connection = CreateConnection();
            const string sql = @"UPDATE Anstalld SET
                            AnstalldNamn = @AnstalldNamn,
                            Foretag = @Foretag
                        WHERE AnstalldId = @AnstalldId";
            int affectedRows = await connection.ExecuteAsync(sql, anstalld);
            return affectedRows > 0;
        }
    }
}
