using System.Collections.Generic;
using EngageLib.Data;

namespace EngageLib.Interfaces
{
    public interface IEngageService
    {
    	EngageGetContactsResponse GetContacts(string authenticationDetailsIdentifier);
		void UpdateStatus(string authenticationDetailsIdentifier, string status);
		//void AddActivity(string authenticationDetailsIdentifier, EngageActivity activity);

    	IDictionary<string, IEnumerable<string>> GetAllMappings();
        IEnumerable<string> GetAllMappings(string localKey);
        void RemoveAllMappings(string localKey);
        void MapLocalKey(string authenticationDetailsIdentifier, string localKey);
        void UnmapLocalKey(string authenticationDetailsIdentifier, string localKey);

    	EngageAuthenticationDetails GetUserData(string authenticationDetailsIdentifier);
        EngageAuthenticationDetails GetAuthenticationDetails(string token, bool extended);
        EngageAuthenticationDetails GetAuthenticationDetails(string token);
    }
}