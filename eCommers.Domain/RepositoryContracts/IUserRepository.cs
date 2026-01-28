namespace eCommers.Domain.RepositoryContracts
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> AddUser(ApplicationUser user);
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? Email,string? Password);

        /// <summary>
        /// Returns users data based on user ID
        /// </summary>
        /// <param name="userID">User ID to search</param>
        /// <returns>Application User object that maches with given UserID</returns>
        Task<ApplicationUser?> GetUserByUserId(Guid? userID);
    }    
}