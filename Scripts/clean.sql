truncate table currencies
truncate table branches
truncate table business_partners
truncate table companies
truncate table customer_groups
truncate table exchange_rates
truncate table item_master_data

delete price_list_details
DBCC CHECKIDENT (price_lists, reseed, 0)
delete price_lists
DBCC CHECKIDENT (price_lists, reseed, 0)

truncate table tax