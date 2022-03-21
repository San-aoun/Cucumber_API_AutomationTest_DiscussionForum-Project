using System;

namespace DiscussionForum.E2E.Helper
{
    public class DatabaseConnection 
    {
        public DatabaseConnection(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Gets the connection string to the database.
        /// </summary>
        public string ConnectionString { get; }
    }
}
