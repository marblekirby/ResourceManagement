using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fritz.ResourceManagement.WebClient.ViewModels
{
  public class RoleManagementViewModel
  {
		public int Page { get; set; } = 1;
		public string Search { get; set; } = "";
		public List<UserInRole> Users { get; set; }

  }

	public class UserInRole
  {
		public int UserId { get; set; }
		public string Username { get; set; }
		public Role Role { get; set; }
  }

	public enum Role
  {
		Employee,
		Manager,
		Administrator
  }
}
