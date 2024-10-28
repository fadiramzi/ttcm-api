using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ttcm_api.Models
{
    public abstract class User:IdentityUser<int>
    {
       
    }

}
