using System;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceTracker.Models
{
	public class Car
	{
		public Guid Id { get; set; }

		[Required]
		public string Year { get; set; }

		[Required]
		public Guid Make { get; set; }

		[Required]
		public Guid Model { get; set; }
	}
}