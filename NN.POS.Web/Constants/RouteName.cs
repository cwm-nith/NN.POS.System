namespace NN.POS.Web.Constants;

public static class RouteName
{
    public const string Home = "/";
    public const string Login = "/login";
    public const string Dashboard = "/dashboard";
    
    public const string Contact = "/contact";
    
    public const string Supplier = "/contact/suppliers";
    public const string CreateSupplier = "/contact/suppliers/create-supplier";
    public const string UpdateSupplier = "/contact/suppliers/update-supplier";

    public const string Customers = "/contact/customers";
    public const string CreateCustomer = "/contact/customers/create";
    public const string UpdateCustomer = "/contact/customers/update";

    public const string CustomerGroups = "/contact/customer-groups";

    public const string UsersManagement = "/users-management";

    public const string Users = "/users-management/users";
    public const string CreateUser = "/users-management/users/create";
    public const string UpdateUser = "/users-management/users/update";

    public const string Roles = "/users-management/roles";
    public const string CreateRole= "/users-management/roles/create";
    public const string UpdateRole= "/users-management/roles/update";

    public const string UserRoles = "/users-management/user-roles";

    public const string Products = "/products";

    public const string ItemMasterData = $"{Products}/item-master-data";
    public const string ItemMasterDataCreate = $"{Products}/item-master-data/create";
    public const string ItemMasterDataUpdate = $"{Products}/item-master-data/update";

    public const string Uom = $"{Products}/uom";
    public const string UomCreate = $"{Products}/uom/create";
    public const string UomUpdate = $"{Products}/uom/update";

    public const string UomGroup = $"{Products}/uom-group";
    public const string UomGroupCreate = $"{Products}/uom-group/create";
    public const string UomGroupUpdate = $"{Products}/uom-group/update";

    public const string UomDefine = $"{Products}/uom-define";
    public const string UomDefineCreate = $"{Products}/uom-define/create";
    public const string UomDefineUpdate = $"{Products}/uom-define/update";
}
