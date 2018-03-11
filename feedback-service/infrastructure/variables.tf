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
  default = "feedback-web"
}

variable "app_service_plan_sku_tier" {
  type    = "string"
  default = "Basic"  # Basic | Standard | ...
}

variable "app_service_plan_sku_size" {
  type    = "string"
  default = "B1"     # B1 | S1 | ...
}
