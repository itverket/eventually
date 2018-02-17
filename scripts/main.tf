# Configure the Microsoft Azure Provider
provider "azurerm" {
}


#App service
resource "azurerm_resource_group" "default" {
  name     = "${var.resource_group_name}"
  location = "${var.location}"
}

resource "azurerm_app_service_plan" "default" {
  name                = "${var.app_service_name}-plan"
  location            = "${azurerm_resource_group.default.location}"
  resource_group_name = "${azurerm_resource_group.default.name}"

  sku {
    tier = "${var.app_service_plan_sku_tier}"
    size = "${var.app_service_plan_sku_size}"
  }
}

resource "azurerm_app_service" "default" {
  name                = "${var.app_service_name}"
  location            = "${azurerm_resource_group.default.location}"
  resource_group_name = "${azurerm_resource_group.default.name}"
  app_service_plan_id = "${azurerm_app_service_plan.default.id}"

  site_config {
    dotnet_framework_version = "v4.0"
    remote_debugging_enabled = true
    remote_debugging_version = "VS2015"
  }

  # app_settings {
  #   "SOME_KEY" = "some-value"
  # }
  # connection_string {
  #   name  = "Database"
  #   type  = "SQLServer"
  #   value = "Server=some-server.mydomain.com;Integrated Security=SSPI"
  # }
}

# Database 

resource "azurerm_sql_database" "db" {
  name                             = "${var.db_name}"
  resource_group_name              = "${azurerm_resource_group.default.name}"
  location                         = "${var.location}"
  edition                          = "${var.db_edition}"
  collation                        = "SQL_Latin1_General_CP1_CI_AS"
  server_name                      = "${azurerm_sql_server.server.name}"
  create_mode                      = "Default"
  requested_service_objective_name = "Basic"
}

resource "azurerm_sql_server" "server" {
  name                         = "${var.resource_group_name}-sqlsvr"
  resource_group_name          = "${azurerm_resource_group.default.name}"
  location                     = "${var.location}"
  version                      = "12.0"
  administrator_login          = "${var.sql_admin_username}"
  administrator_login_password = "${var.sql_password}"
}

resource "azurerm_sql_firewall_rule" "fw" {
  name                = "firewallrules"
  resource_group_name = "${azurerm_resource_group.default.name}"
  server_name         = "${azurerm_sql_server.server.name}"
  start_ip_address    = "${var.start_ip_address}"
  end_ip_address      = "${var.end_ip_address}"
}