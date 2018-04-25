using System;

namespace ECS.WebAPI.Services.Factories.Contracts
{
    /// <summary>
    /// Defines the interface for the Factory object
    /// </summary>
    public interface IFactory
    {
        // Some developers like to use CreateInstance instead of Create as the method name
        // Either works fine as long as the name of the implemented class object is descriptive
        Object Create(string type);
    }
}
