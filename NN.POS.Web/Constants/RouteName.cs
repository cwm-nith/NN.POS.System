namespace NN.POS.Web.Constants;

public static class RouteName
{
    public const string Home = "/";
    public const string Login = "/login";
    public const string Dashboard = "/dashboard";
    
    public const string Contact = "/contact";
    
    public const string Supplier = $"{Contact}/suppliers";
    public const string CreateSupplier = $"{Contact}/suppliers/create-supplier";
    public const string UpdateSupplier = $"{Contact}/suppliers/update-supplier";

    public const string Customers = $"{Contact}/customers";
    public const string CreateCustomer = $"{Contact}/customers/create";
    public const string UpdateCustomer = $"{Contact}/customers/update";

    public const string CustomerGroups = $"{Contact}/customer-groups";

    public const string UsersManagement = "/users-management";

    public const string Users = $"{UsersManagement}/users";
    public const string CreateUser = $"{UsersManagement}/users/create";
    public const string UpdateUser = $"{UsersManagement}/users/update";

    public const string Roles = $"{UsersManagement}/roles";
    public const string CreateRole= $"{UsersManagement}/roles/create";
    public const string UpdateRole= $"{UsersManagement}/roles/update";

    public const string UserRoles = $"{UsersManagement}/user-roles";

    public const string Products = "/products";

    public const string ItemMasterData = $"{Products}/item-master-data";
    public const string ItemMasterDataCreate = $"{Products}/item-master-data/create";
    public const string ItemMasterDataUpdate = $"{Products}/item-master-data/update";
    
    
    public const string UnitOfMeasure = "uom";
    
    public const string Uom = $"{Products}/{UnitOfMeasure}";
    public const string UomCreate = $"{Products}/{UnitOfMeasure}/create";
    public const string UomUpdate = $"{Products}/{UnitOfMeasure}/update";

    public const string UomGroup = $"{Products}/{UnitOfMeasure}/group";
    public const string UomGroupCreate = $"{Products}/{UnitOfMeasure}/group/create";
    public const string UomGroupUpdate = $"{Products}/{UnitOfMeasure}/group/update";

    public const string UomDefine = $"{Products}/{UnitOfMeasure}/define";
    public const string UomDefineCreate = $"{Products}/{UnitOfMeasure}/define/create";
    public const string UomDefineUpdate = $"{Products}/{UnitOfMeasure}/define/update";
}
