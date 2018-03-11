# Configure the Microsoft Azure Provider
provider "azurerm" {
}


#App service
resource "azurerm_resource_group" "default" {
  name     = "${var.resource_group_name}-${var.environment_name}"
  location = "${var.location}"
}

resource "azurerm_app_service_plan" "default" {
  name                = "${var.app_service_name}-plan-${var.environment_name}"
  location            = "${azurerm_resource_group.default.location}"
  resource_group_name = "${azurerm_resource_group.default.name}"

  sku {
    tier = "${var.app_service_plan_sku_tier}"
    size = "${var.app_service_plan_sku_size}"
  }
}

resource "azurerm_app_service" "default" {
  name                = "${var.app_service_name}-${var.environment_name}"
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
