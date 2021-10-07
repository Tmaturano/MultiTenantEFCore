using System.Security.Claims;

namespace Blog.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static int CompanyId(this ClaimsPrincipal claims)
        {
            try
            {
                var value = claims?.FindFirst("CompanyId")?.Value;
                int.TryParse(value, out var companyId);

                return companyId;
            }
            catch 
            {
                // Can log the exception if wanted
                return 0;
            }
        }
    }
}
