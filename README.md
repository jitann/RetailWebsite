# RetailWebsite
Retail website

#Requirements

On a retail website, the following discounts apply: 
1. If the user is an employee of the store, he gets a 30% discount 
2. If the user is an affiliate of the store, he gets a 10% discount 
3. If the user has been a customer for over 2 years, he gets a 5% discount. 
4. For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount). 
5. The percentage based discounts do not apply on groceries. 
6. A user can get only one of the percentage based discounts on a bill. 

Write a C# program with test cases such that given a bill, it finds the net payable amount. Please note the stress is on object oriented approach and test coverage. What we care about: 
> object oriented programming approach 
> unit test (may be using xUnit) and code coverage 
> code to be generic and simple 
> leverage today's best coding practices 

#Assumption:

User can either be a Employee or an Affiliate and can not be both

Rules are executed in the order mentioned above

#Implementation:

A console application is built which can simulate the billing process. An invoice will consists of different items and 
each item can be categorized and an amount can be set to that.

A rule engine is built which will dynamiclaly apply the rules and generates the final bill.

#Running the application

 User needs to enter the customer type 
 0- Normal customer
 1 - Employee
 2 - Affiliate
 
 Select whether the user is a customer for more than 2 years
 0 - No
 1 - Yes
 
 we call them loyal customer
 
 Then we need to enter items in the invoice 
 Details of each item will be entered in a single line with space as the seperator
 We need to enter the Item Name / Amount / type of Item
 
 0 - default item
 1- Grcocery
 
 When we are finished with items, enter 0 to indicate that we are done
 Example:
 Name       Amount  Type Of Item(Default/Grocery)  
 Chocolate 100 0
 Rice 150 1
 Daal 200 1
 Toothpaste 100 0
 0
 
 
 #Test Cases
 
 Test cases are written to cover all the scenarios within  this application.MSTest is used as a unit testing tool
 
#Test Coverage

Open Cover and Report Generators are installed as nuget packages to measure the code coverage
Current unit test cases have 93.66% coverage
