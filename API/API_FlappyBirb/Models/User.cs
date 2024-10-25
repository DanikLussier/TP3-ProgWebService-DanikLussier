using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity;
using System.Net.Mail;

namespace API_FlappyBirb.Models
{
    public class User : IdentityUser
    {
        public virtual List<Score> Scores { get; set; } = null!;
    }
}
