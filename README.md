# Custome-Paginations 🏅
<img src="/Pagination/wwwroot/Images/GitHup.PNG" alt="Photo"/>

<h1>1️⃣ Nuget Packages 🚀:</h1>

```
🔊<PackageReference Include="cloudscribe.Pagination.Models" Version="1.1.0" />
🔊<PackageReference Include="cloudscribe.Web.Pagination" Version="2.1.1" />
```
<h1>2️⃣ Startup.cs ♨:</h1>

```
 public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddCloudscribePagination();
        }
```
<h1>3️⃣ ViewImports ♨:</h1>

```
 @using cloudscribe.Pagination.Models;
 @using cloudscribe.Web.Pagination;
 @addTagHelper "*, cloudscribe.Web.Pagination"
```
<h1> Controller 🔥 :</h1>

```
public class HomeController : Controller
    {
        readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(int pageNumber=1)
        {
            int pagesize = 5;

            var skip = (pageNumber * pagesize) - pagesize;
            IQueryable<Customer> customers = _context.Customers.Skip(skip).Take(pagesize);
            var result = new PagedResult<Customer>()
            {
                Data = customers.AsNoTracking().ToList(),
                TotalItems = _context.Customers.Count(),
                PageNumber = pageNumber,
                PageSize = pagesize
            };
            return View(result);
        }    
    }
}
```

<h1>3️⃣ View 🌞:</h1>

```
@model PagedResult<Customer>;

@{
    ViewData["Title"] = "Customers";
}

<h3 class="text-primary">@ViewData["Title"]</h3>
<hr />
<section>
    <div class="container">
        <table id="Customers" class="table table-striped table-bordered nowrap dt-responsive">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Firs tName</th>
                    <th>Last Name</th>
                    <th>Contact</th>
                    <th>Email</th>
                    <th>Date Birthday</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                @foreach (var item in Model.Data)
                {
                    <tr>
                        <td>@item.ID</td>
                        <td>@item.FirstName</td>
                        <th>@item.LastName</th>
                        <th>@item.Contact</th>
                        <th>@item.Email</th>
                        <th>@item.DataBirth</th>
                        <th>
                            <a href="#" class="btn btn-danger">Delete</a>
                            <a href="#" class="btn btn-primary">Edit</a>
                            <a href="#" class="btn btn-secondary">Details</a>
                        </th>
                    </tr>
                }
            </tbody>
        </table>
    </div>
    <cs-pager cs-paging-pagenumber=@(int)Model.PageNumber
              cs-paging-totalitems=@(int)Model.TotalItems
              cs-paging-pagesize=@Model.PageSize
              asp-controller="Home"
              asp-action="Index"
              cs-pager-li-current-class="page-item active"
              cs-pager-li-other-class="page-item"
              cs-pager-li-non-active-class="page-item disabled"
              cs-pager-link-current-class="page-link"
              cs-pager-link-other-class="page-link">
    </cs-pager>
</section>

```
More details [cloudscribe Page](https://www.cloudscribe.com/cloudscribe-web-pagination).
