#region Copyright (C) 2015 Sascha Simon

//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see http://www.gnu.org/licenses/.
//
//  Visit the official homepage at http://www.sascha-simon.com

#endregion

using System;
using System.Threading.Tasks;
using com.strava.api.Athletes;
using com.strava.api.Authentication;
using com.strava.api.Common;
using com.strava.api.Statistics;

namespace com.strava.api.Clients
{
    /// <summary>
    /// Used to get statistics data from Strava.
    /// </summary>
    public class StatsClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the StatsClient class.
        /// </summary>
        /// <param name="auth">A IAuthenticator object that contains a valid Strava access token.</param>
        public StatsClient(IAuthentication auth) : base(auth) { }

        #region async

        /// <summary>
        /// Gets some stats of the currently authenticated user.
        /// </summary>
        /// <param name="id">The id of the user. <remarks>Must match the authenticated athlete!</remarks></param>
        /// <returns>Strava statistics of the currently authenticated user.</returns>
        private async Task<Stats> GetStatsAsync(String id)
        {
            String getUrl = String.Format("https://www.strava.com/api/v3/athletes/{0}/stats?access_token={1}", id, Authentication.AccessToken);
            String json = await Http.WebRequest.SendGetAsync(new Uri(getUrl));

            return Unmarshaller.Unmarshal<Stats>(json);
        }

        /// <summary>
        /// Gets some stats of the currently authenticated user.
        /// </summary>
        /// <returns>Strava statistics of the currently authenticated user.</returns>
        public async Task<Stats> GetStatsAsync()
        {
            // Get the athlete
            AthleteClient client = new AthleteClient(base.Authentication);
            Athlete a = await client.GetAthleteAsync();

            return await GetStatsAsync(a.Id.ToString());
        }

        #endregion

        #region sync
        #endregion
    }
}
