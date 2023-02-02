# Hubtel.Wallets

Design an API service to be used to manage a user's wallet on the Hubtel app 

Pre-requisites: 

Sign up at hubtel.com 
Tasks 

1. Develop a POST endpoint to add a wallet 

business rule: 

prevent duplicate wallet additions 
a single user should NOT have more than 5 wallets 
only first 6 digits of card number should be stored 
2. Develop a DELETE endpoint to remove a wallet 

3. Develop a GET endpoint to retrieve a single wallet using an ID 

4. Develop a GET endpoint to list all wallets

 

Wallet Model: 

ID 
Name 
Type [momo or card only] 
Account Number (momo number or card number) 
Account Scheme [visa|mastercard|mtn|vodafone|airteltigo] 
Created At 
Owner - phone number of person that owns the wallet 
Solution Name: Hubtel.Wallets Project Name: Hubtel.Wallets.Api Framework: .NET Core 3.1 Storage: In-memory or RDMS or NOSql
