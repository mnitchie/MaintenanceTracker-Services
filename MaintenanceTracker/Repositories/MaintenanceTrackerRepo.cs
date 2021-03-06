﻿using MaintenanceTracker.DataModels;
using MaintenanceTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceTracker.Repositories
{
	public class MaintenanceTrackerRepository : IMaintenanceTrackerRepository
	{
		public IEnumerable<Car> FindAllCars()
		{
			using (var context = new MaintenanceTrackerContext() )
			{
				return context.Cars.Include( "Make" ).Include( "Model" ).ToList();
			}
		}

		public Car FindById(long id)
		{
			using (var context = new MaintenanceTrackerContext())
			{
				return context.Cars.Include("Make").Include("Model").SingleOrDefault(c => c.Id == id);
			}
		}

		public Car CreateCar(Car car)
		{
			using ( var context = new MaintenanceTrackerContext() )
			{
				if ( context.Makes.Find( car.CarMakeId ) != null )
				{
					car.Make = null;
				}

				if ( context.Models.Find( car.CarModelId ) != null )
				{
					car.Model = null;
				}
				context.Cars.Add( car );
				context.SaveChanges();
				return car;
			}
		}

		public Car UpdateCar(Car car)
		{
			using (var context = new MaintenanceTrackerContext())
			{
				context.Cars.Attach( car );
				context.Entry( car ).State = System.Data.Entity.EntityState.Modified;
				context.SaveChanges();
				return car;
			}
		}

		public void DeleteCar( long id )
		{
			using (var context = new MaintenanceTrackerContext())
			{
				var car = context.Cars.SingleOrDefault( c => c.Id == id );
				context.Cars.Remove( car );
				context.SaveChanges();
			}
		}
	}
}