using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL; // for BuildVersionServices
using WestWindSystem.Entities; // for BuildVersion

namespace WestWindWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BuildVersionServices _buildVersionServices;

        public IndexModel(ILogger<IndexModel> logger, BuildVersionServices buildVersionServices)
        {
            _logger = logger;
            _buildVersionServices = buildVersionServices;
        }

        public BuildVersion? BuildVersionInfo { get; set; }

        public void OnGet()
        {
            BuildVersionInfo = _buildVersionServices.GetBuildVersion();
        }
    }
}