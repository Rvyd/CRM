using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CRMApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td",Attributes ="user-role")]
    public class UserRoleTagHelper:TagHelper
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;
       
       [HtmlAttributeName("user-name")]
       public String? UserName { get; set; }
        public UserRoleTagHelper(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public override  async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user= await _userManager.FindByNameAsync(UserName);
            TagBuilder ul= new TagBuilder("ul");

            var roles= _roleManager.Roles.ToList().Select(r=>r.Name);
            
            foreach (var role in roles)
            {
                TagBuilder li=new TagBuilder("li");
                li.InnerHtml.Append($"{role,-8}:{ await _userManager.IsInRoleAsync(user,role)}"); //sekiz karakterli alan ve role tanımlı mı ona baktık
                ul.InnerHtml.AppendHtml(li);
            }
            output.Content.AppendHtml(ul);

            
        }



    }
}