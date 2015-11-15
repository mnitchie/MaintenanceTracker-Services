using MaintenanceTracker.EdmundsAPI.Obj;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MaintenanceTracker.EdmundsAPI
{
	public class CarMakeRepository : ICarMakeRepository
	{
		public async Task<IEnumerable<Make>> GetAllMakes()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri( "http://api.edmunds.com/" );
			client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );

			HttpResponseMessage response = await client.GetAsync( "api/vehicle/v2/makes?api_key=''" );
			response.EnsureSuccessStatusCode();

			var something = JsonConvert.DeserializeObject<CarMakesDTO>( await response.Content.ReadAsStringAsync() );
			return something.Makes;
		}
	}
}
