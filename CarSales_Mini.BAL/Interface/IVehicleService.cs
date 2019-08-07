using CarSales_Mini.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarSales_Mini.BLL.Interface
{
    public interface IVehicleService
    {

        string CurrentName { get; }

        /// <summary>
        /// Get all the elemets
        /// </summary>
        /// <returns>List<typeparamref name="T"/></returns>
        Task<List<Vehicle>> GetAllAsync();

        /// <summary>
        /// Add a new object to the database. Used by POST method of the API.
        /// </summary>
        /// <param name="t"></param>
        /// <returns>T</returns>
        Task<Vehicle> AddAsync(object T);

        /// <summary>
        /// Edit the object. Used by PUT method of API.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="t"></param>
        /// <returns>bool</returns>
        Task<bool> EditAsync(object T);

        /// <summary>
        /// Find an object by Id
        /// </summary>
        /// <param name="UniqueId">UniqueId</param>
        /// <returns>T</returns>
        Task<Vehicle> SelectAsync(string UniqueId);

        /// <summary>
        /// Delete an object by Id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        Task<bool> DeleteAsync(int id);

    }
}
