using MaintenanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.EdmundsAPI
{
	interface ICarMakeRepository
	{
		IEnumerable<CarMake> GetAllMakes();
	}
}
