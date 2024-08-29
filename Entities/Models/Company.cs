using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Company
{
    public int CompanyId { get; set; }
    
    public String? CompanyName { get; set; } = String.Empty;
    
    public String? CompanyAddress { get; set; } = String.Empty;
    
    public String? CompanyPhone { get; set; } = String.Empty;
   
    public String? CompanyLogoUrl { get; set; } = String.Empty;
    public String? CompanyWebSite{get;set;}=String.Empty;
  

  
}
