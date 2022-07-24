// <copyright file="HaloApiResultContainer.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models
{
    /// <summary>
    /// Container class that encapsulates the result from a Halo API call.
    /// </summary>
    /// <typeparam name="T">The type of result to fetch.</typeparam>
    /// <typeparam name="THaloApiErrorContainer">Error container, available if an error occurred.</typeparam>
    public class HaloApiResultContainer<T, THaloApiErrorContainer>
    {
        public HaloApiResultContainer(T result, THaloApiErrorContainer container)
        {
            Result = result;
            Error = container;
        }

        public T Result { get; set; }

        public THaloApiErrorContainer Error { get; set; }
    }
}
