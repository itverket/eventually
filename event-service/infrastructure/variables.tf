variable "environment_name" {
  type = "string"
  default = "dev"
}

variable "resource_group_name" {
  type = "string"
  default = "itv-eventually"
}

variable "location" {
  type = "string"
  default = "North Europe"
}

variable "app_service_name" {
  type = "string"
  default = "eventmng-web"
}

variable "app_service_plan_sku_tier" {
  type    = "string"
  default = "Basic"  # Basic | Standard | ...
}

variable "app_service_plan_sku_size" {
  type    = "string"
  default = "B1"     # B1 | S1 | ...
}

# Database

variable "db_name" {
  description = "The name of the database to be created.",
  type = "string"
  default = "eventmng-db"
}

variable "db_edition" {
  description = "The edition of the database to be created."
  default     = "Basic"
}

variable "sql_admin_username" {
  description = "The administrator username of the SQL Server."
  type = "string"
  default = "eventuelly-admin"
}

variable "sql_password" {
  description = "The administrator password of the SQL Server."
  type = "string"
  default = "Qwer1234*"
}

variable start_ip_address {
  description = "Defines the start IP address used in your database firewall rule."
  default     = "0.0.0.0"
}

variable end_ip_address {
  description = "Defines the end IP address used in your database firewall rule."
  default     = "0.0.0.0"
}