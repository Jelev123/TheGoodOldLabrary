namespace TheGoodOldLibrary.Web.Areas.Administration.Controllers
{
    using TheGoodOldLibrary.Common;
    using TheGoodOldLibrary.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
