namespace Portfolio.Client.Pages.Component;

public partial class Breadcrumbs
{
	private List<BreadcrumbItem> _items;

	protected override async Task OnInitializedAsync()
	{
		_items = new List<BreadcrumbItem>()
		{
			new BreadcrumbItem("Home", href: "#", icon: Icons.Material.Filled.Home),
			new BreadcrumbItem("AboutMe", href: "me/about", icon: Icons.Material.Filled.AccountBox),
			new BreadcrumbItem("PortFolio", href: "me/portfolio", icon: Icons.Material.Filled.AccountBox),
			new BreadcrumbItem("Service", href: "me/service", icon: Icons.Material.Filled.AccountBox),
			new BreadcrumbItem("Breadcrumbs", href: null, disabled: true, icon: Icons.Material.Filled.AccountTree),
		};
	}
}