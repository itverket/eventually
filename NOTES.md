## Working notes when creating the app
> Notes towards the workshop based on eventually


### Terraform partitioning 
* Set up service principal for applying terraform : https://www.terraform.io/docs/providers/azurerm/authenticating_via_service_principal.html

* Set environment varialbes as follows, gotten from the service principal:
echo "Setting environment variables for Terraform"
export ARM_SUBSCRIPTION_ID=your_subscription_id
export ARM_CLIENT_ID=your_appId
export ARM_CLIENT_SECRET=your_password
export ARM_TENANT_ID=your_tenant_id 

* Run `terraform plan` to see what will be done and `terraform apply` to partition the resource group


###Misc
* To attach and debug unit test run `export VSTEST_RUNNER_DEBUG=1` before `dotnet test`