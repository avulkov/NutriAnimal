namespace NutriAnimal.Web.Areas.Administration.Controllers
{
    using NutriAnimal.Common;
    using NutriAnimal.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
